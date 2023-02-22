using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartStore_Utility
{
    public static class WC
    {
        public const string ImagePath = @"\images\product\";
        public const string SessionCart = "ShoppingCartSession";
        public const string SessionInquiryId = "SessionSession";

        public const string AdminRole = "AdminRole";
        public const string CustomerRole = "CustomerRole";

        public const string EmailAdmin = "kravtseniuk@gmail.com";

        public const string CategoryName = "Category";

        public const string Success = "Success";
        public const string Error = "Error";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public static readonly IEnumerable<string> listStatus = new ReadOnlyCollection<string>(
            new List<string>
            {
                StatusApproved,StatusCancelled,StatusInProcess,StatusPending,StatusRefunded,StatusShipped
            });
    }
}
