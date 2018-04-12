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

        public void PostToOrder(string Firstname)
        {
            this.checkoutRepository.PostToOrder(Firstname);
        }
    }
}
