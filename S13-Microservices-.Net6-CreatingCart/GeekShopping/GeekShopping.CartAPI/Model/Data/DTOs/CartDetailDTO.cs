namespace GeekShopping.CartAPI.Model.Data.DTOs
{
    public class CartDetailDTO
    {
        public CartDetailDTO()
        {
            Id= Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public Guid CartHeaderId { get; set; }
        public CartHeaderDTO CartHeader { get; set; }

        public Guid ProductId { get; set; }
        public ProductDTO Product { get; set; }

        public int Count { get; set; }
    }
}
