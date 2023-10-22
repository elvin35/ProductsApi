using AutoMapper;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Profiles;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Products, UpdateProduct>().ReverseMap();
        
        CreateMap<Products, ProductsModel>().ReverseMap();
        
        CreateMap<Customers, CustomerModel>().ReverseMap();
    }   
}