using Microsoft.AspNetCore.Mvc;

namespace SmartStore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
