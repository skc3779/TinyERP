using App.Common.Data;
using App.Common.Mapping;
using System.Collections.Generic;

namespace App.Repository.Store
{
    public interface IStoreRepository : IBaseRepository<App.Entity.Store.Store>
    {
        IList<TEntity> GetStores<TEntity>() where TEntity : IMappedFrom<App.Entity.Store.Store>;
        App.Entity.Store.Store GetByName(string name);
    }
}
