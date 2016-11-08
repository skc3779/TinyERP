using App.Common;
using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Store;
using System;
using System.Collections.Generic;

namespace App.Service.Store.Order
{
    public class OrderSummary: BaseEntity, IMappedFrom<App.Entity.Store.Order>
    {
        public decimal Price { get; set; }
        public StoreOrderStatus Status { get; set; }
        public DateTime TransactionDate { get; set; }
        public double NumberOfItems { get; set; }
        public string Comment { get; set; }
        public OrderContact Contact { get; set; }
        public IList<OrderItem> Items { get; set; }
    }
}