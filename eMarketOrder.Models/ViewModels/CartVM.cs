using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarketOrder.Models.ViewModels
{
    public class CartVM
    {
        public OrderProduct OrderProduct { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Cart> ListOfCart { get; set; }
    }
}
