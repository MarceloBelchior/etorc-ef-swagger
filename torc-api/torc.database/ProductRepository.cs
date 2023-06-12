using System.Linq.Expressions;
using torc.Iface;
using torc.model;

namespace torc.database
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    { 
        public ProductRepository(TorcDB _dbcontext) : base(_dbcontext)
        {
        }
        public override Product Insert(Product item, bool saveImmediately = true)
        {
            return base.Insert(item, saveImmediately);
        }



        bool IProductRepository.Delete(Product item, bool saveImmediately)
        {
            base.Delete(item);
            return true;
        }

  
       
    }

}