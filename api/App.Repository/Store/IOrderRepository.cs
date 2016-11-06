using App.Common.Data;
using App.Common.Mapping;

namespace App.Repository.Store
{
    public interface IOrderRepository : IBaseRepository<App.Entity.Store.Order>
    {
        System.Collections.Generic.IList<TEntity> GetOrders<TEntity>() where TEntity: IMappedFrom<App.Entity.Store.Order>;
    }
}
