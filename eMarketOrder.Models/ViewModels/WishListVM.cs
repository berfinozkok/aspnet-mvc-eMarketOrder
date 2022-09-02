using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarketOrder.Models.ViewModels
{
    public class WishListVM
    {
        public WishList WishList { get; set; }
        public Product Product { get; set; }
        public IEnumerable<WishList> wishLists { get; set; }
    }
}
