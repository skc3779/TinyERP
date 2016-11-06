using App.Common;
using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Store;
using System;

namespace App.Service.Store
{
    public class GetAccountResponse: BaseEntity, IMappedFrom<StoreAccount>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public ItemStatus Status { get; set; }
        public string Description { get; set; }
        public Guid Photo { get; set; }
    }
}
