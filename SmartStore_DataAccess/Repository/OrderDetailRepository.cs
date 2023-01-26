using SmartStore_DataAccess.Repository.IRepository;
using SmartStore_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore_DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetail obj)
        {
            _db.OrderDetail.Update(obj);
        }
    }
}
