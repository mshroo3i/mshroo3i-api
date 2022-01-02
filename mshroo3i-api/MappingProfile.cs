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
        CreateMap<ProductField, ProductFieldResponse>();
        CreateMap<ProductFieldOption, ProductFieldOptionResponse>();

        CreateMap<ProductUpdateRequest, Product>()
            .ForAllMembers(opt => opt.Condition(IgnoreNullCondition));

        CreateMap<StoreAddRequest, Store>();
        CreateMap<ProductAddRequest, Product>();
        CreateMap<ProductFieldAddRequest, ProductField>();
        CreateMap<ProductFieldOptionsAddRequest, ProductFieldOption>();
    }

    private bool IgnoreNullCondition<TSource, TDestination, TMember>(TSource src, TDestination dest, TMember sourceMember)
    {
        return sourceMember is not null;
    }
}