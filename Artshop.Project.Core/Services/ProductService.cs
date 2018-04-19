using Artshop.Project.Core.Repositories;
using ArtShop.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artshop.Project.Core.Services
{
    public class ProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<ProductViewModel> GetAll()
        {
            return this.productRepository.GetAll();
        }
    }
}
