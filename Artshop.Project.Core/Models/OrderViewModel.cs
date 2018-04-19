using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Project.Core.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public int Cartid { get; set; }

        public List<CartViewModel> Cart { get; set; }
    }
}
