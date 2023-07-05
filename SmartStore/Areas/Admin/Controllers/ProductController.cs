using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartStore_DataAccess.Repository.IRepository;
using SmartStore_Models;
using SmartStore_Models.ViewModels;
using SmartStore_Utility;
using System.Collections.Generic;

namespace SmartStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objList = _unitOfWork.Product.GetAll(includeProperties: "Category");

            return View(objList);
        }

        public IActionResult Create()
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategorySelectList = _unitOfWork.Product.GetAllDropdownList(WC.CategoryName)
            };

            return View(productVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (files.Count > 0)
                {
                    string upload = webRootPath + WC.ImagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    productVM.Product.Image = fileName + extension;
                }

                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Product.Save();

                return RedirectToAction("Index");
            }

            productVM.CategorySelectList = _unitOfWork.Product.GetAllDropdownList(WC.CategoryName);

            return View(productVM);
        }

        // GET: Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ProductVM productVM = new ProductVM()
            {
                Product = _unitOfWork.Product.Find(id.GetValueOrDefault()),
                CategorySelectList = _unitOfWork.Product.GetAllDropdownList(WC.CategoryName)
            };

            if (productVM.Product == null)
            {
                return NotFound();
            }

            return View(productVM);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductVM productVM)
        {
            if (id != productVM.Product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var objFromDb = _unitOfWork.Product.FirstOrDefault(u => u.Id == id, isTracking: false);

                if (objFromDb == null)
                {
                    return NotFound();
                }

                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (files.Count > 0)
                {
                    string upload = webRootPath + WC.ImagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    var oldFile = Path.Combine(upload, objFromDb.Image);

                    if (System.IO.File.Exists(oldFile))
                    {
                        System.IO.File.Delete(oldFile);
                    }

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    productVM.Product.Image = fileName + extension;
                }
                else
                {
                    productVM.Product.Image = objFromDb.Image;
                }

                _unitOfWork.Product.Update(productVM.Product);
                _unitOfWork.Product.Save();

                return RedirectToAction("Index");
            }

            return View(productVM);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product product = _unitOfWork.Product.FirstOrDefault(u => u.Id == id, includeProperties: "Category");

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Product.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            string upload = _webHostEnvironment.WebRootPath + WC.ImagePath;
            var oldFile = Path.Combine(upload, obj.Image);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Product.Save();
            return RedirectToAction("Index");
        }
    }
}
