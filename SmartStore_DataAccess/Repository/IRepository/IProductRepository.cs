using Microsoft.AspNetCore.Mvc.Rendering;
using SmartStore_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore_DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);

        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}
