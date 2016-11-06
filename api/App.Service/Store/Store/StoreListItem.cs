using App.Common;
using App.Common.Data;
using App.Common.Mapping;

namespace App.Service.Store.Store
{
    public class StoreListItem : BaseEntity, IMappedFrom<App.Entity.Store.Store>
    {
        public string Name { get; set; }
        public StoreOwner Owner{ get; set; }
        public ItemStatus Status { get; set; }
        public string Description { get; set; }
    }
}
