using App.Common;
using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Store;
using System;

namespace App.Service.Store.Order
{
    public class OrderSummaryListItem: BaseEntity, IMappedFrom<App.Entity.Store.Order>
    {
        public string Number { get; set; }
        public OrderContact Contact { get; set; }
        public decimal Price { get; set; }
        public ItemStatus Status { get; set; }
        public DateTime TransationDate { get; set; }
        public double NumberOfItems { get; set; }
    }
}
