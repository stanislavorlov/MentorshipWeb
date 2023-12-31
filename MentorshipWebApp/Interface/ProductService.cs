﻿using MentorshipWebApp.Repositories;

namespace MentorshipWebApp.Interface
{
    public class ProductService : IProductService
    {
        private IProductRepo _producrRepo;

        public ProductService(IProductRepo productRepo)
        {
            _producrRepo= productRepo;
        }

        public void AddProduct(Product product)
        {
            _producrRepo.Create(product);
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
