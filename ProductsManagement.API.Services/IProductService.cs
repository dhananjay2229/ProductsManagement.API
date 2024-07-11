using ProductsManagement.API.Models.Request;
using ProductsManagement.API.Models.Response;

namespace ProductsManagement.API.Services
{
    public interface IProductService
    {
        IEnumerable<ProductResponseModel> GetAll();
        ProductResponseModel GetProductsById(int id);
        ProductResponseModel Create(CreateProductRequest model);
        Task<ProductResponseModel> Update(int id, CreateProductRequest model);
        void Delete(int id);
    }
}