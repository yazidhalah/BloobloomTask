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
    public class FrameController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public FrameController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("GetAllFrames")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<List<LookupFrame>>> GetAllFrames()
        {
            var FrameList = await unitOfWork.LookupFrameService.FindAllAsync(x => x.Status != BaseEntity.StatusEnum.Deleted, null, null, null, OrderBy.Ascending);

            var response = new ResponseStandardJson<List<LookupFrame>>
            {
                Code = 200,
                Message = "OK",
                Result = FrameList != null ? FrameList.ToList() : new List<LookupFrame>(),
                Success = true
            };
            return response;
        }


        [HttpGet("GetFramesList")]
        [Authorize(Roles = "User , Admin")]
        public async Task<ResponseStandardJson<List<LookupFrame>>> GetFramesList()
        {
            var FrameList = await unitOfWork.LookupFrameService.FindAllAsync(x => x.Status == BaseEntity.StatusEnum.Active
            && x.LookupFrameStock > 0, null, null, null, OrderBy.Ascending);

            return new ResponseStandardJson<List<LookupFrame>>
            {
                Code = 200,
                Message = "OK",
                Result = FrameList != null ? FrameList.ToList() : new List<LookupFrame>(),
                Success = true
            };
        }


        [HttpPost("AddFrame")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> AddFrame(LookupFrameVM entity)
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

            var frame = mapper.Map<LookupFrame>(entity);
            frame.LookupFrameId = 0;
            frame.Status = BaseEntity.StatusEnum.Active;
            frame.CreateId = int.Parse(userId);
            frame.CreateDate = DateTime.Now;

            await unitOfWork.LookupFrameService.AddAsync(frame);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "OK",
                Result = result != 0,
                Success = result != 0
            };
        }

        [HttpPut("UpdateFrame")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> UpdateFrame(LookupFrameVM entity)
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

            var frame = await unitOfWork.LookupFrameService.FindAsync(x => x.LookupFrameId == entity.LookupFrameId);
            if (frame == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 404,
                    Message = "Frame not found",
                    Success = false
                };
            }

            mapper.Map(entity, frame);
            frame.EditId = int.Parse(userId);
            frame.EditDate = DateTime.Now;

            unitOfWork.LookupFrameService.Update(frame);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "Frame updated successfully",
                Result = result != 0,
                Success = result != 0
            };
        }


        [HttpDelete("DeleteFrame")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> DeleteFrame(IdVM entity)
        {
            var frame = await unitOfWork.LookupFrameService.FindAsync(x => x.LookupFrameId == entity.Id);
            if (frame == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 404,
                    Message = "Frame not found",
                    Success = false
                };
            }

            frame.Status = BaseEntity.StatusEnum.Deleted;
            unitOfWork.LookupFrameService.Update(frame);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "Frame deleted successfully",
                Result = result != 0,
                Success = result != 0
            };
        }

        [HttpPut("ActiveInactive")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<bool>> ActiveInactive(IdVM entity)
        {
            var frame = await unitOfWork.LookupFrameService.FindAsync(x => x.LookupFrameId == entity.Id);
            if (frame == null)
            {
                return new ResponseStandardJson<bool>
                {
                    Code = 404,
                    Message = "Frame not found",
                    Success = false
                };
            }

            frame.Status = frame.Status == BaseEntity.StatusEnum.Active ? BaseEntity.StatusEnum.InActive : BaseEntity.StatusEnum.Active;
            unitOfWork.LookupFrameService.Update(frame);
            var result = unitOfWork.Complete();

            return new ResponseStandardJson<bool>
            {
                Code = 200,
                Message = "Frame status toggled successfully",
                Result = result != 0,
                Success = result != 0
            };
        }

    }
}
