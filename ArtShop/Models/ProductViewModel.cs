using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtShop.Models;

namespace ArtShop.Models
{
    public class ProductViewModel
    {
        //get och set properties
        //från databasens kolumner
        public string Id { get; set; }
        public string Title {get; set;}
        public string Description {get; set;}
        public string Technique {get; set;}
        public string Image {get; set;}
        public string Price { get; set; }
    }
}
