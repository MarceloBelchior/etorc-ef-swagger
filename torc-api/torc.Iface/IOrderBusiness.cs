using System;
using torc.model;

namespace torc.Iface
{
    public interface IOrderBusiness
    {

        Task<Order> CreateOrder(Order entity);


        Task<IEnumerable<Order>> GetOrders();

    }
}

