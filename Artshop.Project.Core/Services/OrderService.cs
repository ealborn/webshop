using ArtShop.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Artshop.Project.Core.Repositories.Implementations;

namespace Artshop.Project.Core.Services
{
    public class OrderService
    {
        private readonly OrderRepository checkoutRepository;
        private readonly CartRepository cartRepository;

        public OrderService(OrderRepository checkoutRepository, CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
            this.checkoutRepository = checkoutRepository;
        }

        public void PostToOrder(string Firstname, string Lastname, string Email, string Address, int Zipcode, string cookie)
        {
            this.checkoutRepository.PostToOrder(Firstname, Lastname, Email, Address, Zipcode, cookie);
        }

        public void DeleteCart(string cookie)
        {
            this.checkoutRepository.DeleteCart(cookie);
        }

        public OrderViewModel GetAll(string Id)
        {
            var cart = this.cartRepository.GetAll(Id);
            var checkoutModel = new OrderViewModel { Cart = cart };

            return checkoutModel;
        }
    }
}
