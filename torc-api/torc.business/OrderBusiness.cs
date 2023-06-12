using System;
using System.Linq.Expressions;
using torc.Iface;
using torc.model;

namespace torc.business
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IOrderRepository orderRepository;
        public OrderBusiness(IOrderRepository _orderRepository) => orderRepository = _orderRepository;

        public Task<Order> CreateOrder(Order entity)
        {
            return Task.Run(() =>
            {
                var result = orderRepository.Insert(entity);
                return result;
            });
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            return Task.Run(() =>
            {
                Expression<Func<Order, bool>> where = m => m.Id > 0;
                return orderRepository.Select(where).AsEnumerable();
            });

        }

    }
}

