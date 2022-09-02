using eMarketOrder.Data.Repository.IRepository;
using eMarketOrder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UdemySiparis.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<OrderProduct> orderProduct;

            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            orderProduct = _unitOfWork.OrderProduct.GetAllItem(u => u.AppUserId == claim.Value);

            return View(orderProduct);
        }

        public IActionResult CancelOrder(int id)
        {
            var order = _unitOfWork.OrderProduct.GetFirstOrDef(x => x.Id == id);

            if (order.OrderStatus == "Ordered")
                order.OrderStatus = "Cancel";

            _unitOfWork.OrderProduct.Update(order);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));

        }


    }
}