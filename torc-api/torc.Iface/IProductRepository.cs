using System;
using System.Linq.Expressions;
using torc.model;

namespace torc.Iface
{
	public interface IProductRepository
	{
        IEnumerable<Product> Select(Expression<Func<Product, bool>> where = null, IOrderByClause<Product>[] orderBy = null, int skip = 0, int top = 0, string[] include = null);
        Product Insert(Product item, bool saveImmediately = true);
        Product Update(Product item, bool saveImmediately = true);
        bool Delete(Product item, bool saveImmediately = true);
        Product SelectById(int id);
    }
}

