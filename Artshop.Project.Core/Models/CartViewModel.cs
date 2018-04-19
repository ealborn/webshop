using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Project.Core.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
}
