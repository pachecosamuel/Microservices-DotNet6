using AutoMapper;
using GeekShopping.CartAPI.Model.Base;
using GeekShopping.CartAPI.Model.Data.DTOs;

namespace GeekShopping.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>().ReverseMap();
                cfg.CreateMap<CartHeaderDTO, CartHeader>().ReverseMap();
                cfg.CreateMap<CartDetailDTO, CartDetail>().ReverseMap();
                cfg.CreateMap<CartDTO, Cart>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
