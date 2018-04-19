using System;
using System.Collections.Generic;
using System.Text;

namespace ArtShop.Project.Core.Models
{
    public class OrderRowViewModel
    {

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int OrderId { get; set; }
        public Guid Guid { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }

    }
}
