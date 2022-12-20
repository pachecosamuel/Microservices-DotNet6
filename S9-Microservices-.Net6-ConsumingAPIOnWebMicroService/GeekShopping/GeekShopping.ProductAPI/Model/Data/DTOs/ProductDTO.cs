using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GeekShopping.ProductAPI.Model.Base;

namespace GeekShopping.ProductAPI.Model.Data.DTOs
{
    public class ProductDTO : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
