using System;
using System.Linq.Expressions;
using torc.Iface;
using torc.model;

namespace torc.business
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        public OrderBusiness(IOrderRepository _orderRepository, IProductRepository _productRepository)
        {
            productRepository = _productRepository;
            orderRepository = _orderRepository;
        }

        public Task<Order> CreateOrder(Order entity)
        {
            return Task.Run(() =>
            {
                Expression<Func<Product, bool>> expression = m => m.Id == entity.ProductId;
                var prod = productRepository.Select(expression).FirstOrDefault();
                if (prod == null)
                    return null;   // throw new NotImplementedException("Product Not Found");
                entity.Product = prod;
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

