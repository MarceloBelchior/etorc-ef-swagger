using System;
using System.Linq.Expressions;
using torc.model;

namespace torc.Iface
{
    public interface IOrderRepository
    {

        IEnumerable<Order> Select(Expression<Func<Order, bool>> where = null,IOrderByClause<Order>[] orderBy = null, int skip = 0, int top = 0, string[] include = null);
        Order Insert(Order item, bool saveImmediately = true);
        Order Update(Order item, bool saveImmediately = true);
        bool Delete(Order item, bool saveImmediately = true);


    }
}

