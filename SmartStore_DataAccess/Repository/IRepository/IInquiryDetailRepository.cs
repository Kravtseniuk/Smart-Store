using SmartStore_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore_DataAccess.Repository.IRepository
{
    public interface IInquiryDetailRepository : IRepository<InquiryDetail>
    {
        void Update(InquiryDetail obj);
    }
}
