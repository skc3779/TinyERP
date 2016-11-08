using App.Common.Data;
using App.Common.Mapping;

namespace App.Service.Store.Order
{
    public class OrderSummaryProduct: BaseEntity, IMappedFrom<App.Entity.ProductManagement.Product>
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
    }
}