﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartStore_Models.ViewModels
{
    public class OrderListVM
    {
        public IEnumerable<OrderHeader> OrderHList { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public string Status { get; set; }
    }
}
