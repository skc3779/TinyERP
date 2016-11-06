using System;
using System.Collections.Generic;

namespace App.Service.Store.Store
{
    public interface IStoreService
    {
        System.Collections.Generic.IList<StoreListItem> GetStores();
        void Delete(Guid id);
        void CreateIfNotExist(IList<CreateStoreRequest> request);
        GetStoreResponse Get(Guid id);
        CreateStoreResponse Create(CreateStoreRequest request);
        void Update(UpdateStoreRequest request);
    }
}
