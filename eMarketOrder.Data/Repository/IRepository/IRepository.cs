using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eMarketOrder.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetFirstOrDef(Expression<Func<T, bool>> filter,
            string? includeProperties = null);
        //for return to list 
        IEnumerable<T> GetAllItem(Expression<Func<T, bool>>? filter= null,
            string? includeProperties = null);

        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
