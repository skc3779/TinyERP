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
    public class AccountRepository : BaseRepository<StoreAccount>, IAccountRepository
    {
        public AccountRepository() : base(new AppDbContext(IOMode.Read)) { }
        public AccountRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext) { }
        public IList<TEntity> GetAccounts<TEntity>() where TEntity : IMappedFrom<StoreAccount>
        {
            return this.GetItems<TEntity>();
        }

        public StoreAccount GetByEmail(string email)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(item => item.Email == email);
        }
        public StoreAccount GetByName(string name)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(item => item.Name == name);
        }

        public StoreAccount GetByUserName(string userName)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(item => item.UserName == userName);
        }
    }
}
