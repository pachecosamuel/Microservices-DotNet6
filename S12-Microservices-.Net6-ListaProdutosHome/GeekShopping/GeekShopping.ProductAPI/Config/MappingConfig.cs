using AutoMapper;
using GeekShopping.ProductAPI.Model.Base;
using GeekShopping.ProductAPI.Model.Data.DTOs;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<Product, ProductDTO>();
            });

            return mappingConfig;
        }
    }
}
