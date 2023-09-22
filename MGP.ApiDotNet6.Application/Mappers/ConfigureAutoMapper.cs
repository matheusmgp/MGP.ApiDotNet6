using AutoMapper;
using MGP.ApiDotNet6.Application.Dtos;
using MGP.ApiDotNet6.Domain.Entities;

namespace MGP.ApiDotNet6.Application.Mappers
{
    public  class ConfigureAutoMapper : Profile
    {
        public ConfigureAutoMapper()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Purchase, PurchaseDto>().ReverseMap();
        }
    }
}
