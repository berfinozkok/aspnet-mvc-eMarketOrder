using eMarketOrder.Data.Repository.IRepository;
using eMarketOrder.Models;
using eMarketOrder.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eMarketOrder.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class WishListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public WishListVM WishListVM { get; set; }
        public WishListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            WishListVM = new WishListVM()
            {
                wishLists = _unitOfWork.WishList.GetAllItem(p => p.AppUserId == claim.Value, includeProperties: "Product"),
                Product = new(),
            };
            List<WishList> wishLists = _unitOfWork.WishList.GetAllItem(includeProperties: "Product").ToList();
            return View(WishListVM);
        }
        
        public IActionResult AddFavor(int productId)
        {
            WishList wishList = new WishList()
            {
                ProductId = productId,
                Product = _unitOfWork.Product.GetFirstOrDef(p => p.Id == productId, includeProperties: "Product"),
            };
            return View(wishList);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddFavor(WishList wishList)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            wishList.AppUserId = claim.Value;
            WishList wishListDb = _unitOfWork.WishList.GetFirstOrDef(p => p.AppUserId == claim.Value && p.ProductId == wishList.ProductId);
            _unitOfWork.WishList.Add(wishList);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveWL(int productId)
        {
            var wishList = _unitOfWork.WishList.GetFirstOrDef(c => c.Id == productId);
            _unitOfWork.WishList.Remove(wishList);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        } 
        
    }
}


