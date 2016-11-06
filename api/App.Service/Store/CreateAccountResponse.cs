using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Store;

namespace App.Service.Store
{
    public class CreateAccountResponse: BaseEntity, IMappedFrom<StoreAccount>
    {
    }
}
