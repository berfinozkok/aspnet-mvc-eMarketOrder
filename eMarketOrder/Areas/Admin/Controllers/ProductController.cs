using eMarketOrder.Data.Repository.IRepository;
using eMarketOrder.Models.ViewModels;
using IronBarCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace eMarketOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
            var productList = _unitOfWork.Product.GetAllItem();
            return View(productList);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts =  _unitOfWork.Product.GetAllItem();

            if (!string.IsNullOrEmpty(searchString))
            {            
                var filteredResult = allProducts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Filter", filteredResult);               
            }

            return View("Filter", allProducts);
        }
        public IActionResult Crup(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                categories = _unitOfWork.Category.GetAllItem().Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Id.ToString()
                })

            };

            if (id == null || id <= 0)
            {
                return View(productVM);
            }
            productVM.Product = _unitOfWork.Product.GetFirstOrDef(x => x.Id == id);

            if (productVM.Product == null)
            {
                return View(productVM);
            }
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Crup(ProductVM productVM, IFormFile picfile, IFormFile qrfile, IFormFile barfile)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (picfile != null)
            {
                //aynı isimli dosya saklamamak için
                string fileName = Guid.NewGuid().ToString(); //çakışması imkansız
                var uploadRoot = Path.Combine(wwwRootPath, @"img\products"); //best practice için bunu kullan
                var extension = Path.GetExtension(picfile.FileName);
                //resim güncelleme, veritabanı check, sil tekrar yükle

                if (productVM.Product.Picture != null)
                {
                    var oldPicPath = Path.Combine(wwwRootPath, productVM.Product.Picture);
                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension),
                    FileMode.Create))
                {
                    picfile.CopyTo(fileStream);
                }
                productVM.Product.Picture = @"\img\products\" + fileName + extension;
            }
           
            if (qrfile != null)
            {
                //aynı isimli dosya saklamamak için
                string fileName2 = Guid.NewGuid().ToString(); //çakışması imkansız
                var uploadRoot2 = Path.Combine(wwwRootPath, @"img\products"); //best practice için bunu kullan
                var extension2 = Path.GetExtension(qrfile.FileName);
                //resim güncelleme, veritabanı check, sil tekrar yükle

                if (productVM.Product.QRCode != null)
                {
                    var oldQRPath = Path.Combine(wwwRootPath, productVM.Product.QRCode);
                    if (System.IO.File.Exists(oldQRPath))
                    {
                        System.IO.File.Delete(oldQRPath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(uploadRoot2, fileName2 + extension2),
                    FileMode.Create))
                {
                    qrfile.CopyTo(fileStream);
                }
                productVM.Product.QRCode = @"\img\products\" + fileName2 + extension2;
            }

            if (barfile != null)
            {
                string fileName3 = Guid.NewGuid().ToString(); 
                var uploadRoot3 = Path.Combine(wwwRootPath, @"img\products"); 
                var extension3 = Path.GetExtension(barfile.FileName);

                if (productVM.Product.BarcodePic != null)
                {
                    var oldbarPath = Path.Combine(wwwRootPath, productVM.Product.BarcodePic);
                    if (System.IO.File.Exists(oldbarPath))
                    {
                        System.IO.File.Delete(oldbarPath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(uploadRoot3, fileName3 + extension3),
                    FileMode.Create))
                {
                    barfile.CopyTo(fileStream);
                }
                productVM.Product.BarcodePic = @"\img\products\" + fileName3 + extension3;
            }

            if (productVM.Product.Id <= 0)
            {
                _unitOfWork.Product.Add(productVM.Product);
            }
            else
            {
                _unitOfWork.Product.Update(productVM.Product);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var product = _unitOfWork.Product.GetFirstOrDef(x => x.Id == id);
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
        
    }
}
