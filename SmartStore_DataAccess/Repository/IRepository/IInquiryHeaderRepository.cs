using SmartStore_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore_DataAccess.Repository.IRepository
{
    public interface IInquiryHeaderRepository : IRepository<InquiryHeader>
    {
        void Update(InquiryHeader obj);
    }
}
