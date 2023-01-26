using SmartStore_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore_DataAccess.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void Update(OrderDetail obj);
    }
}
