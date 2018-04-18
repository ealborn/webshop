using Artshop.Project.Core.Repositories.Implementations;
using ArtShop.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artshop.Project.Core.Services
{
    public class CartService
    {
        private CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public List<CartViewModel> GetAll()
        {
            return this.cartRepository.GetAll();
        }

        public void PostToCart(int Id, string Cookie)
        {
            this.cartRepository.PostToCart(Id, Cookie);
        }
    }
}
