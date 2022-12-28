using GeekShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model.Data.DTOs
{
    public class CartHeaderDTO
    {
        public CartHeaderDTO()
        {
            Id= Guid.NewGuid();
        }

        public string UserId { get; set; }
        public string CouponCode { get; set; }
        public Guid Id { get; set; }
    }
}
