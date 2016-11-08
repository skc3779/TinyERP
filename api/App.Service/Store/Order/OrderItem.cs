using App.Common;
using App.Common.Data;
using App.Common.Mapping;
using System;

namespace App.Service.Store.Order
{
    public class OrderItem: BaseEntity, IMappedFrom<App.Entity.Store.OrderItem>
    {
        public OrderSummaryProduct Product { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public StoreOrderStatus Status { get; set; }
        public string Comment { get; set; }

        //public Guid ProductId { get; set; }
        //public double Quantity { get; set; }
        //public string Comment { get; set; }
        ///// <summary>
        ///// Used by EF only
        ///// </summary>
        //public OrderItem()
        //{

        //}
        //public OrderItem(Guid productId, double quantity, string comment)
        //{
        //    this.ProductId = productId;
        //    this.Quantity = quantity;
        //    this.Comment = comment;
        //}
    }
}
