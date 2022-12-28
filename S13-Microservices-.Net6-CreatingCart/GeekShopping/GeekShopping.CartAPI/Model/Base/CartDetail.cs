using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model.Base
{
    public class CartDetail : BaseEntity
    {
        public Guid CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public CartHeader CartHeader { get; set; }

        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Column("count")]
        public int Count { get; set; }
    }
}
