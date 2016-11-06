using App.Common.Mapping;
using App.Entity.Store;
using System;

namespace App.Service.Store.Store
{
    public class StoreOwner: IMappedFrom<StoreAccount>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
