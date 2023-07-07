using Microsoft.AspNetCore.Mvc;
using SmartStore_DataAccess.Repository.IRepository;
using SmartStore_Models;
using SmartStore_Models.ViewModels;
using SmartStore_Utility;

namespace SmartStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InquiryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public InquiryVM InquiryVM { get; set; }

        public InquiryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            InquiryVM = new InquiryVM()
            {
                InquiryHeader = _unitOfWork.InquiryHeader.FirstOrDefault(u => u.Id == id),
                InquiryDetail = _unitOfWork.InquiryDetail.GetAll(u=>u.InquiryHeaderId == id, includeProperties: "Product")
            };

            return View(InquiryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details()
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            InquiryVM.InquiryDetail = _unitOfWork.InquiryDetail.GetAll(u => u.InquiryHeaderId == InquiryVM.InquiryHeader.Id);

            foreach (var detail in InquiryVM.InquiryDetail)
            {
                ShoppingCart shoppingCart = new ShoppingCart()
                {
                    ProductId = detail.ProductId
                };
                shoppingCartList.Add(shoppingCart);
            }
            HttpContext.Session.Clear();
            HttpContext.Session.Set(WC.SessionCart, shoppingCartList);
            HttpContext.Session.Set(WC.SessionInquiryId, InquiryVM.InquiryHeader.Id);
            return RedirectToAction("Index", "Cart");
        }


        [HttpPost]
        public IActionResult Delete()
        {
            InquiryHeader inquiryHeader = _unitOfWork.InquiryHeader.FirstOrDefault(u => u.Id == InquiryVM.InquiryHeader.Id);
            IEnumerable<InquiryDetail> inquiryDetails = _unitOfWork.InquiryDetail.GetAll(u => u.InquiryHeaderId == InquiryVM.InquiryHeader.Id);

            _unitOfWork.InquiryDetail.RemoveRange(inquiryDetails);
            _unitOfWork.InquiryHeader.Remove(inquiryHeader);
            _unitOfWork.InquiryHeader.Save();
            return RedirectToAction(nameof(Index));
        }

        #region
        [HttpGet]
        public IActionResult GetInquiryList()
        {
            return Json(new { data = _unitOfWork.InquiryHeader.GetAll() });
        }
        #endregion
    }
}
