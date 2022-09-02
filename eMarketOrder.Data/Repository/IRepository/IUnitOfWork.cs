using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarketOrder.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAppUserRepository AppUser { get; }
        ICartRepository Cart { get; }
        ICategoryRepository Category { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IOrderProductRepository OrderProduct { get; }
        IProductRepository Product { get; }
        IWishListRepository WishList { get; }

        void Save();
    }
}
