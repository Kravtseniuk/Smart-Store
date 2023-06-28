using Microsoft.AspNetCore.Mvc.Rendering;
using SmartStore_DataAccess.Data;
using SmartStore_DataAccess.Repository.IRepository;
using SmartStore_Models;
using SmartStore_Utility;

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
                return _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }

            return null;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }

        public IEnumerable<Product> SearchProductsByName(string searchString)
        {
            return _db.Products.Where(p => p.Name.Contains(searchString)).ToList();
        }
    }
}
