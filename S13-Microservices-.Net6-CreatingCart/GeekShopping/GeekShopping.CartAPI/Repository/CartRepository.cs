using AutoMapper;
using GeekShopping.CartAPI.Model.Base;
using GeekShopping.CartAPI.Model.Context;
using GeekShopping.CartAPI.Model.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private IMapper _mapper;

        public CartRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _dbContext=applicationDbContext;
            _mapper=mapper;
        }

        public async Task<bool> ApplyCoupon(Guid userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDTO> FindCartByUserId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(Guid cartDetailsId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDTO> SaveOrUpdateCart(CartDTO dto)
        {
            Cart cart = _mapper.Map<Cart>(dto);

            //Checks if the product is already saved in DB. If it doesn't exist then we gonna save
            var product = await _dbContext.Products.FirstOrDefaultAsync(
                p => p.Id == dto.CartDetails.FirstOrDefault().ProductId);

            if(product == null)
            {
                _dbContext.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await _dbContext.SaveChangesAsync();
            }

            //Checks if CartHeader is null
            var cartHeader = await _dbContext.CartHeader.AsNoTracking().FirstOrDefaultAsync(
                c => c.UserId == cart.CartHeader.UserId);

            if (cartHeader == null)
            {
                //Create CartHeader and CartDetails
                _dbContext.CartHeader.Add(cart.CartHeader);
                await _dbContext.SaveChangesAsync();

                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;

                _dbContext.CartDetail.Add(cart.CartDetails.FirstOrDefault());
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
