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
        }
    }
}
