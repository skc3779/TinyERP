using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Store;
using System.Collections.Generic;

namespace App.Repository.Store
{
    public interface IAccountRepository : IBaseRepository<StoreAccount>
    {
        IList<TEntity> GetAccounts<TEntity>() where TEntity : IMappedFrom<StoreAccount>;
        StoreAccount GetByName(string name);
        StoreAccount GetByEmail(string email);
        StoreAccount GetByUserName(string userName);
    }
}
