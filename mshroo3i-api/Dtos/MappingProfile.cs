using AutoMapper;
using Mshroo3i.Domain;

namespace mshroo3i_api.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Store, StoreDto>();
        CreateMap<Product, ProductDto>();
        CreateMap<ProductOption, ProductOptionDto>();
        CreateMap<Option, OptionDto>();
    }
}