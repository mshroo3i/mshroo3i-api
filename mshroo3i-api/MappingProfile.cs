using AutoMapper;
using Mshroo3i.Domain;
using mshroo3i_api.Dtos;
using mshroo3i_api.Requests;

namespace mshroo3i_api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Store, StoreResponse>();
        CreateMap<Product, ProductResponse>();
        CreateMap<ProductOption, ProductOptionResponse>();
        CreateMap<Option, OptionResponse>();

        CreateMap<ProductRequest, Product>()
            .ForAllMembers(opt => opt.Condition(IgnoreNullCondition));
    }

    private bool IgnoreNullCondition<TSource, TDestination, TMember>(TSource src, TDestination dest, TMember sourceMember)
    {
        return sourceMember is not null;
    }
}