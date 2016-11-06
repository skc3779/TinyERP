using App.Common;
using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Common.Mapping;
using App.Context;
using App.Repository.Store;
using System.Collections.Generic;

namespace App.Repository.Impl.Store
{
    public class OrderRepository : BaseRepository<App.Entity.Store.Order>, IOrderRepository
    {
        public OrderRepository() : base(new AppDbContext(IOMode.Read)) { }
        public OrderRepository(IUnitOfWork uow) : base(uow.Context as MSSQLDbContext) { }

        public IList<TEntity> GetOrders<TEntity>() where TEntity : IMappedFrom<App.Entity.Store.Order>
        {
            return this.GetItems<TEntity>("Contact");
        }
    }
}
