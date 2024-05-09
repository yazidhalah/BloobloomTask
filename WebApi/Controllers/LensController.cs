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
    public class LensController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LensController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("GetAllLenses")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<List<LookupLens>>> GetAllLenses()
        {
            var lensList = await unitOfWork.LookupLensService.FindAllAsync(x => x.Status != BaseEntity.StatusEnum.Deleted, null, null, null, OrderBy.Ascending);

            return new ResponseStandardJson<List<LookupLens>>
            {
                Code = 200,
                Message = "OK",
                Result = lensList != null ? lensList.ToList() : new List<LookupLens>(),
                Success = true
            };
        }

        [HttpGet("GetLensesList")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ResponseStandardJson<List<LookupLens>>> GetLensesList()
        {
            var lensList = await unitOfWork.LookupLensService.FindAllAsync(x => x.Status == BaseEntity.StatusEnum.Active, null, null, null, OrderBy.Ascending);

            return new ResponseStandardJson<List<LookupLens>>
            {
                Code = 200,
                Message = "OK",
                Result = lensList != null ? lensList.ToList() : new List<LookupLens>(),
                Success = true
            };
        }

        [HttpPost("AddLens")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> AddLens(LookupLensVM entity)
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

            var lens = mapper.Map<LookupLens>(entity);
            lens.Status = BaseEntity.StatusEnum.Active;
            lens.CreateId = int.Parse(userId);
            lens.CreateDate = DateTime.Now;

            await unitOfWork.LookupLensService.AddAsync(lens);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "OK",
                Result = result != 0,
                Success = result != 0
            };
        }

        [HttpPut("UpdateLens")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> UpdateLens(LookupLensVM entity)
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

            var lens = await unitOfWork.LookupLensService.FindAsync(x => x.LookupLensId == entity.LookupLensId);
            if (lens == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 404,
                    Message = "Lens not found",
                    Success = false
                };
            }

            mapper.Map(entity, lens);
            lens.EditId = int.Parse(userId);
            lens.EditDate = DateTime.Now;

            unitOfWork.LookupLensService.Update(lens);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "Lens updated successfully",
                Result = result != 0,
                Success = result != 0
            };
        }

        [HttpDelete("DeleteLens")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> DeleteLens(IdVM entity)
        {
            var lens = await unitOfWork.LookupLensService.FindAsync(x => x.LookupLensId == entity.Id);
            if (lens == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 404,
                    Message = "Lens not found",
                    Success = false
                };
            }

            lens.Status = BaseEntity.StatusEnum.Deleted;
            unitOfWork.LookupLensService.Update(lens);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "Lens deleted successfully",
                Result = result != 0,
                Success = result != 0
            };
        }


        [HttpPut("ActiveInactiveLens")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> ActiveInactiveLens(IdVM entity)
        {
            var lens = await unitOfWork.LookupLensService.FindAsync(x => x.LookupLensId == entity.Id);
            if (lens == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 404,
                    Message = "Lens not found",
                    Success = false
                };
            }

            lens.Status = lens.Status == BaseEntity.StatusEnum.Active ? BaseEntity.StatusEnum.InActive : BaseEntity.StatusEnum.Active;
            unitOfWork.LookupLensService.Update(lens);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "Lens status toggled successfully",
                Result = result != 0,
                Success = result != 0
            };
        }


    }
}
