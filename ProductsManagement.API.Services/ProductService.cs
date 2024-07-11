﻿using AutoMapper;
using ProductsManagement.API.DataAccess.Entities;
using ProductsManagement.API.DataAccess.Repositories;
using ProductsManagement.API.Models.Core;
using ProductsManagement.API.Models.Request;
using ProductsManagement.API.Models.Response;

namespace ProductsManagement.API.Services
{
    public class ProductService : IProductService
    {
        public IJsonDataRespository<Product> _productRepository { get; }
        private readonly IMapper _mapper;
        public ProductService(IJsonDataRespository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductResponseModel> GetAll()
        {
            var products = _productRepository.AsEnumerable();

            return _mapper.Map<List<ProductResponseModel>>(products);
        }

        public ProductResponseModel GetProductsById(int id)
        {
            var product = _productRepository.AsEnumerable().Where(i => i.Id == id).FirstOrDefault();

            return _mapper.Map<ProductResponseModel>(product);
        }

        public ProductResponseModel Create(CreateProductRequest model)
        {
            var product = _mapper.Map<Product>(model);

            product.Id = GetId();

            _productRepository.Add(product);

            _productRepository.SaveChanges();

            return _mapper.Map<ProductResponseModel>(product);
        }

        private int GetId()
        {
            var product = _productRepository.AsEnumerable().OrderByDescending(c => c.Id).FirstOrDefault();
            return product == null ? 1 : product.Id + 1;
        }

        public async Task<ProductResponseModel> Update(int id, CreateProductRequest model)
        {
            var product = _productRepository.AsEnumerable().FirstOrDefault(c => c.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _productRepository.SaveChanges();

            return _mapper.Map<ProductResponseModel>(product); ;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(c => c.Id == id);

            _productRepository.SaveChanges();
        }
    }
}
