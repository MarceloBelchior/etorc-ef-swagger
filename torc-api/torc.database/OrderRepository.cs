using torc.Iface;
using torc.model;

namespace torc.database
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
    

        public OrderRepository(TorcDB _dbcontext) : base(_dbcontext)
        {
        }

        public override Order Insert(Order item, bool saveImmediately = true)
        {
            return base.Insert(item, saveImmediately);
        }

        bool IOrderRepository.Delete(Order item, bool saveImmediately)
        {
            base.Delete(item, saveImmediately);
            return true;
        }
    }

}