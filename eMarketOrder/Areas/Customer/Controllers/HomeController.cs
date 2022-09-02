using eMarketOrder.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace eMarketOrder.Areas.Customer.Controllers
{
    [Area("Customer")]    
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {           
            return View();
        }

    }
}