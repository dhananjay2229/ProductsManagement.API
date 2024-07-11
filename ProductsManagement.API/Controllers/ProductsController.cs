using ProductsManagement.API.Helpers;
using ProductsManagement.API.Models.Request;
using ProductsManagement.API.Services;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.API.DataAccess.Entities;

namespace ProductsManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService userService)
        {
            _productService = userService;
        }


        /// <summary>
        /// Returns all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();

            return ResponseHelper.Success(products);
        }

        ///// <summary>
        ///// Returns the products by id
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public IActionResult GetProductsById(int id)
        //{
        //    var product = _productService.GetProductsById(id);

        //    return ResponseHelper.Success(product);
        //}

        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="model">Product Model</param>
        /// <returns>Created Product</returns>
        [HttpPost]
        public IActionResult Create(CreateProductRequest model)
        {
            var product = _productService.Create(model);

            return ResponseHelper.Success(product);
        }


        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="id">Id of the product to update</param>
        /// <param name="model">Product Model</param>
        /// <returns>Updated Product</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateProductRequest model)
        {
            var product = await _productService.Update(id, model);

            return ResponseHelper.Success(product);
        }

        /// <summary>
        /// Deletes the product
        /// </summary>
        /// <param name="id">Id of the product to delete</param>
        /// <returns>Empty Result</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);

            return ResponseHelper.Success();
        }
    }
}