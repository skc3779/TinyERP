using App.Common;
using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Common.Mapping;
using App.Context;
using App.Entity.Store;
using App.Repository.Store;
using System.Collections.Generic;
using System;
using System.Linq;

namespace App.Repository.Impl.Store
{
    public class StoreRepository : BaseRepository<App.Entity.Store.Store>, IStoreRepository
    {
        public StoreRepository() : base(new AppDbContext(IOMode.Read)) { }
        public StoreRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext) { }
        public IList<TEntity> GetStores<TEntity>() where TEntity : IMappedFrom<App.Entity.Store.Store>
        {
            return this.GetItems<TEntity>();
        }

        public App.Entity.Store.Store GetByName(string name)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(item => item.Name == name);
        }
    }
}
