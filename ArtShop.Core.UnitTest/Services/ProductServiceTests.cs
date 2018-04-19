using System.Collections.Generic;
using NUnit.Framework;
using Artshop.Project.Core.Repositories;
using FakeItEasy;
using Artshop.Project.Core.Services;
using ArtShop.Project.Core.Models;

namespace ArtShop.Core.UnitTest.Services
{
    class ProductServiceTests
    {
        private ProductService productService;
        private IProductRepository productRepository;

        [SetUp]
        public void SetUp()
        {
            this.productRepository = A.Fake<IProductRepository>();

            this.productService = new ProductService(this.productRepository);
        }

        [Test]
        public void GetAll_ReturnsExpectedProducts()
        {
            // Arrange
            var products = new List<ProductViewModel>
            {
                new ProductViewModel { Id = 1 }
            };


            A.CallTo(() => this.productRepository.GetAll()).Returns(products);

            // Act
            var result = this.productService.GetAll();

            // Assert
            Assert.That(result, Is.EqualTo(products));
        }
    
    }
}
