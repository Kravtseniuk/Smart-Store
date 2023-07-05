using SmartStore_DataAccess.Data;
using SmartStore_DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IApplicationUserRepository User { get; private set; }
        public IInquiryHeaderRepository InquiryHeader { get; private set; }
        public IInquiryDetailRepository InquiryDetail { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            User = new ApplicationUserRepository(_db);
            InquiryHeader = new InquiryHeaderRepository(_db);
            InquiryDetail = new InquiryDetailRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
