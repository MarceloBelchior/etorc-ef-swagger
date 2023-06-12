using System.Linq.Expressions;
using torc.Iface;
using torc.model;

namespace torc.business;
public class ProductBusiness : IProductBusiness
{
    private readonly IProductRepository productRepository;
    public ProductBusiness(IProductRepository _productRepository) => productRepository = _productRepository;

    public Task<Product> GetProdutById(int id)
    {
        return Task.Run(() =>
        {
            return productRepository.SelectById(id);
        });

    }

    public Task<IEnumerable<Product>> GetListProductActive()
    {

        return Task.Run(() =>
        {
            Expression<Func<Product, bool>> expression = m => m.Id > 0; //
            return productRepository.Select(expression).AsEnumerable();
        });
    }
}

