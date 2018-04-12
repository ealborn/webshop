using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Project.Core.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title {get; set;}
        public string Description {get; set;}
        public string Technique {get; set;}
        public string Image {get; set;}
        public int Price { get; set; }
    }
}
