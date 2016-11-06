using System;
using System.Collections.Generic;

namespace App.Service.Store
{
    public interface IAccountService
    {
        System.Collections.Generic.IList<AccountListItem> GetAccounts();
        void Delete(Guid id);
        void CreateIfNotExist(IList<CreateAccountRequest> request);
        GetAccountResponse Get(Guid id);
        CreateAccountResponse Create(CreateAccountRequest request);
        void Update(UpdateAccountRequest request);
    }
}
