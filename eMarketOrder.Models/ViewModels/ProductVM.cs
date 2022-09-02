using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarketOrder.Models.ViewModels
{
    //hem product name hem categoy göstermek için
    public class ProductVM
    {
        public Product Product { get; set; }
        public WishList WishList { get; set; }
        public IEnumerable<SelectListItem> categories { get; set; }
    }
}
