using GeekShopping.CartAPI.Model.Data.DTOs;

namespace GeekShopping.CartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartDTO> FindCartByUserId(Guid id);
        Task<CartDTO> SaveOrUpdateCart(CartDTO cartDTO);
        Task<bool> RemoveFromCart(Guid cartDetailsId);
        Task<bool> ApplyCoupon(Guid userId, string couponCode);
        Task<bool> RemoveCoupon(Guid userId);
        Task<bool> ClearCart(Guid userId);
    }
}
