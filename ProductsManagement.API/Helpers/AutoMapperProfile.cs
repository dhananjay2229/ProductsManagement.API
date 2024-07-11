using AutoMapper;
using ProductsManagement.API.DataAccess.Entities;
using ProductsManagement.API.Models.Request;
using ProductsManagement.API.Models.Response;
using ProductsManagement.API.DataAccess.Entities;

namespace ProductsManagement.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponseModel>();
        }
    }
}
