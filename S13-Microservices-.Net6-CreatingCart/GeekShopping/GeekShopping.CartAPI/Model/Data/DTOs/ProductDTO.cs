using GeekShopping.CartAPI.Model.Base;

namespace GeekShopping.CartAPI.Model.Data.DTOs
{
    public class ProductDTO : BaseEntity
    {
        public ProductDTO()
        {
            Id= Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
