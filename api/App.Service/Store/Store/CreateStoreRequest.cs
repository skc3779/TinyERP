using App.Common;
using System;

namespace App.Service.Store.Store
{
    public class CreateStoreRequest
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public ItemStatus Status { get; set; }
        public string Description { get; set; }
    }
}
