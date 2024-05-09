using AutoMapper;
using Core;
using Core.Consts;
using Core.Models;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CurrencyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("GetAllCurrencies")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<List<LookupCurrency>>> GetAllCurrencies()
        {
            var currencies = await unitOfWork.LookupCurrencyService.FindAllAsync(x => x.Status != BaseEntity.StatusEnum.Deleted, null, null, null, OrderBy.Ascending);
            return new ResponseStandardJson<List<LookupCurrency>>
            {
                Code = 200,
                Message = "OK",
                Result = currencies != null ? currencies.ToList() : new List<LookupCurrency>(),
                Success = true
            };
        }

        [HttpPost("AddCurrency")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> AddCurrency(LookupCurrencyVM entity)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 401,
                    Message = "User ID not found",
                    Success = false
                };
            }
            var currency = mapper.Map<LookupCurrency>(entity);
            currency.LookupCurrencyId = 0;
            currency.Status = BaseEntity.StatusEnum.Active;
            currency.CreateId = int.Parse(userId);
            currency.CreateDate = DateTime.Now;

            await unitOfWork.LookupCurrencyService.AddAsync(currency);
            var result = unitOfWork.Complete();
            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "Currency added successfully",
                Result = result > 0,
                Success = result > 0,
            };
        }

        [HttpPut("UpdateCurrency")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> UpdateCurrency(LookupCurrencyVM entity)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 401,
                    Message = "User ID not found",
                    Success = false
                };
            }

            var currency = await unitOfWork.LookupCurrencyService.FindAsync(x => x.LookupCurrencyId == entity.LookupCurrencyId);
            if (currency == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 404,
                    Message = "currency not found",
                    Success = false
                };
            }

            mapper.Map(entity, currency);
            currency.EditId = int.Parse(userId);
            currency.EditDate = DateTime.Now;

            unitOfWork.LookupCurrencyService.Update(currency);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "currency updated successfully",
                Result = result != 0,
                Success = result != 0
            };
        }

        [HttpDelete("DeleteCurrency")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> DeleteCurrency(IdVM entity)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 401,
                    Message = "User ID not found",
                    Success = false
                };
            }
            var currency = await unitOfWork.LookupCurrencyService.FindAsync(x => x.LookupCurrencyId == entity.Id);
            if (currency == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 404,
                    Message = "currency not found",
                    Success = false
                };
            }

            currency.Status = BaseEntity.StatusEnum.Deleted;
            unitOfWork.LookupCurrencyService.Update(currency);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "currency deleted successfully",
                Result = result != 0,
                Success = result != 0
            };
        }
    }
}
