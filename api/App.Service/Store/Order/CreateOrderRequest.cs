using App.Common;
using App.Entity.Store;
using System;
using System.Collections.Generic;

namespace App.Service.Store.Order
{
    public class CreateOrderRequest
    {
        public OrderContact Contact { get; set; }
        public StoreOrderStatus Status { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Comment { get; set; }
        public IList<CreateOrderItemRequest> Items { get; set; }
        public CreateOrderRequest()
        {
            this.Items = new List<CreateOrderItemRequest>();
            this.TransactionDate = DateTime.Now;
        }
    }
}
