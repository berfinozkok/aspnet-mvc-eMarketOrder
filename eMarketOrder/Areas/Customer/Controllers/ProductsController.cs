using eMarketOrder.Data.Repository.IRepository;
using eMarketOrder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eMarketOrder.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAllItem(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            Cart cart = new Cart()
            {
                Count = 0,
                Gram = 0,
                ProductId = productId,
                Product = _unitOfWork.Product.GetFirstOrDef(p => p.Id == productId, includeProperties: "Category"),
            };
            WishList wishList = new WishList()
            {
                ProductId = productId,
                Product = _unitOfWork.Product.GetFirstOrDef(p => p.Id == productId, includeProperties: "Category"),
            };
            return View(cart);
            return View(wishList);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(Cart cart)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            cart.AppUserId = claim.Value;
            Cart cartDb = _unitOfWork.Cart.GetFirstOrDef(p => p.AppUserId == claim.Value && p.ProductId == cart.ProductId);

            if (cartDb == null)
            {
                _unitOfWork.Cart.Add(cart);
                _unitOfWork.Save();
                int cartCount = _unitOfWork.Cart.GetAllItem(u => u.AppUserId == claim.Value).ToList().Count();
                HttpContext.Session.SetInt32("SessionCartCount", cartCount);
            }
            else
            {
                cartDb.Count += cart.Count;
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }
        
    }
}
