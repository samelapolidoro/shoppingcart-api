using AutoMapper;
using KingShoppingCart.API.Models;
using KingShoppingCart.Domain.Entities;

namespace KingShoppingCart.API.Mappers
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();

            CreateMap<ShoppingCart, CreateShoppingCartResponse>();
            CreateMap<ShoppingCart, ShoppingCartResponse>();
            CreateMap<ShoppingCartItem, ShoppingCartResponse.Item>();
            CreateMap<Product, ShoppingCartResponse.Product>();
        }
    }
}
