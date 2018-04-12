using Artshop.Project.Core.Repositories;
using ArtShop.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Artshop.Project.Core.Repositories.Implementations;

namespace Artshop.Project.Core.Services
{
    public class OrderService
    {
        private OrderRepository checkoutRepository;

        public OrderService(OrderRepository checkoutRepository)
        {
            this.checkoutRepository = checkoutRepository;
        }

        public void PostToOrder(string Firstname, string Lastname, string Email, int Phone, string Address, int Zipcode)
        {
            this.checkoutRepository.PostToOrder(Firstname, Lastname, Email, Phone, Address, Zipcode);
        }
    }
}
