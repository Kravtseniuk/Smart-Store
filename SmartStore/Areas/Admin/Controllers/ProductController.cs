using Microsoft.AspNetCore.Mvc;

namespace SmartStore.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
