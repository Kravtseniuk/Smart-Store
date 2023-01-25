using Microsoft.AspNetCore.Mvc.Rendering;
using SmartStore_DataAccess.Repository.IRepository;
using SmartStore_Models;
using SmartStore_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartStore_DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if (obj == WC.CategoryName)
            {
                return _db.Category.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }

            return null;
        }

        public void Update(Product obj)
        {
            _db.Product.Update(obj);
        }
    }
}
