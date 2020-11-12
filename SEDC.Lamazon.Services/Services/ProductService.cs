using AutoMapper;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels.Enum;
using SEDC.Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.Services.Services
{
    public class ProductService : IProductService
    {
        protected readonly IRepository<Product> _productRepository;
        protected readonly IMapper _mapper;
        public ProductService(IRepository<Product> productRepository, 
                              IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            //The following line was the first implementation
            //return _productRepository.GetAll();

            //List<Product> products = _productRepository.GetAll().ToList();

            //List<ProductViewModel> mappedProducts = new List<ProductViewModel>();

            //foreach (var product in products)
            //{
            //    ProductViewModel model = new ProductViewModel();
            //    model.Id = product.Id;
            //    model.Name = product.Name;
            //    model.Description = product.Description;
            //    model.Category = (CategoryTypeViewModel)product.Category;
            //    model.Price = product.Price;

            //    mappedProducts.Add(model);
            //}
            //return mappedProducts;


            //Return result using Automapper mapping 
            List<Product> products = _productRepository.GetAll().ToList();
            return _mapper.Map<List<Product>, List<ProductViewModel>>(products);

        }

        public ProductViewModel GetProductById(int id)
        {
            Product product = _productRepository.GetById(id);

            //ProductViewModel model = new ProductViewModel();
            //model.Id = product.Id;
            //model.Name = product.Name;
            //model.Description = product.Description;
            //model.Category = (CategoryTypeViewModel)product.Category;
            //model.Price = product.Price;

            ProductViewModel model = _mapper.Map<ProductViewModel>(product);

            if (model != null)
            {
                return model;
            }
            else
            {
                throw new Exception($"Product with id: {id} does not exist!");
            }
        }
    }
}
