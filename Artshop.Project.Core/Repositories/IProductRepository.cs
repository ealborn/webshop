using ArtShop.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artshop.Project.Core.Repositories
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAll();  
    }
}
