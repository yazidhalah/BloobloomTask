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
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CartController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("GetAllCarts")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseStandardJson<List<TransactionCart>>> GetAllCarts()
        {
            var carts = await unitOfWork.TransactionCartService.FindAllAsync(x => x.Status != BaseEntity.StatusEnum.Deleted, null, null, null, OrderBy.Ascending);
            return new ResponseStandardJson<List<TransactionCart>>
            {
                Code = 200,
                Message = "OK",
                Result = carts != null ? carts.ToList() : new List<TransactionCart>(),
                Success = true
            };
        }

        [HttpGet("GetCartById/{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ResponseStandardJson<TransactionCart>> GetCartById(int id)
        {
            var cart = await unitOfWork.TransactionCartService.GetByIdAsync(id);
            return new ResponseStandardJson<TransactionCart>
            {
                Code = 200,
                Message = "OK",
                Result = cart != null ? cart : new TransactionCart(),
                Success = cart != null
            };
        }


        [HttpPost("AddOrUpdateCart")]
        [Authorize(Roles = "User , Admin")]
        public async Task<ResponseStandardJson<TransactionCart>> AddOrUpdateCart(TransactionCartVM cartVM)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return new ResponseStandardJson<TransactionCart>
                {
                    Code = 401,
                    Message = "User ID not found",
                    Success = false
                };
            }

            TransactionCart cart;
            bool isNew = cartVM.TransactionCartId == 0;

            if (isNew)
            {
                cart = new TransactionCart();
                cart.CreateId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                cart.CreateDate = DateTime.Now;
            }
            else
            {
                cart = await unitOfWork.TransactionCartService.GetByIdAsync(cartVM.TransactionCartId);
                if (cart == null)
                {
                    return new ResponseStandardJson<TransactionCart>
                    {
                        Code = 404,
                        Message = "Cart not found",
                        Success = false
                    };
                }
            }

            var frame = await unitOfWork.LookupFrameService.GetByIdAsync(cartVM.LookupFrameId);
            var lens = await unitOfWork.LookupLensService.GetByIdAsync(cartVM.LookupLensId);
            if (frame == null || lens == null)
            {
                return new ResponseStandardJson<TransactionCart>
                {
                    Code = 404,
                    Message = "Frame or Lens not found",
                    Success = false
                };
            }

            int quantityChange = cartVM.TransactionCartQuantity - (isNew ? 0 : cart.TransactionCartQuantity);

            if (quantityChange > 0 && (frame.LookupFrameStock < quantityChange || lens.LookupLensStock < quantityChange))
            {
                return new ResponseStandardJson<TransactionCart>
                {
                    Code = 404,
                    Message = "Insufficient stock for frame or lens",
                    Success = false
                };

            }

            if (quantityChange > 0)
            {
                frame.LookupFrameStock -= quantityChange;
                lens.LookupLensStock -= quantityChange;
            }


            mapper.Map(cartVM, cart);
            cart.TransactionCartDate = DateTime.Now;
            cart.TransactionCartUserId = int.Parse(userId);
            cart.LookupCurrencyId = cartVM.LookupCurrencyId;
            cart.LookupCurrency = await unitOfWork.LookupCurrencyService.GetByIdAsync(cartVM.LookupCurrencyId);

            if (!isNew)
            {
                cart.EditId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                cart.EditDate = DateTime.Now;
            }

            cart.Status = isNew ? BaseEntity.StatusEnum.Entered : cart.Status;

            using (var transaction = await unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    if (isNew)
                    {
                        await unitOfWork.TransactionCartService.AddAsync(cart);
                    }
                    else
                    {
                        unitOfWork.TransactionCartService.Update(cart);
                    }

                    unitOfWork.LookupFrameService.Update(frame);
                    unitOfWork.LookupLensService.Update(lens);
                    unitOfWork.Complete();
                    await transaction.CommitAsync();

                    var actionName = isNew ? nameof(GetCartById) : "GetCartById";

                    return new ResponseStandardJson<TransactionCart>
                    {
                        Code = 200,
                        Message = isNew ? "Cart Add Successfully" : "Cart Updated Successfully",
                        Success = true,
                        Result = cart
                    };

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new ResponseStandardJson<TransactionCart>
                    {
                        Code = 500,
                        Message = "An error occurred while processing your request.",
                        Success = false
                    };
                }
            }
        }



    }
}
