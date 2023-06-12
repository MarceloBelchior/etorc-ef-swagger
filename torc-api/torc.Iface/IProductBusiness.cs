using System;
using torc.model;

namespace torc.Iface
{
	public interface IProductBusiness
	{
        Task<Product> GetProdutById(int id);
        Task<IEnumerable<Product>> GetListProductActive();

    }
}

