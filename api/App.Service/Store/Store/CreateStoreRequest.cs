using App.Common;
using System;

namespace App.Service.Store.Store
{
    public class CreateStoreRequest
    {
        public string Name { get; set; }
        public StoreOwner Owner { get; set; }
        public StoreItemStatus Status { get; set; }
        public string Description { get; set; }
    }
}
