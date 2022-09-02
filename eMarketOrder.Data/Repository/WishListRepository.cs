using eMarketOrder.Data.Repository.IRepository;
using eMarketOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarketOrder.Data.Repository
{
    public class WishListRepository : Repository<WishList>, IWishListRepository
    {
        private ApplicationDbContext _context;
        public WishListRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
