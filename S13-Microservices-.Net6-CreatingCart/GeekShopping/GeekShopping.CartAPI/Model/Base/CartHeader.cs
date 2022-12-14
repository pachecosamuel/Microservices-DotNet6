using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model.Base
{
    [Table("cart_header")]
    public class CartHeader : BaseEntity
    {
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("coupon_code")]
        public string CouponCode { get; set; }
    }
}
