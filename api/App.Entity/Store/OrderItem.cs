using App.Common;
using App.Common.Data;
using App.Entity.ProductManagement;
using System;

namespace App.Entity.Store
{
    public class OrderItem : BaseEntity
    {
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public StoreOrderStatus Status { get; set; }
        public string Comment { get; set; }
        /// <summary>
        /// called by EF only
        /// </summary>
        public OrderItem() : base()
        {
            this.TransactionDate = DateTime.UtcNow;
            this.Status = StoreOrderStatus.WaittingForApprove;
        }

        public OrderItem(Product product, double quantity, decimal unitPrice, StoreOrderStatus status, DateTime transactionDate, string comment) : base()
        {
            this.Product = product;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.Status = status;
            this.TransactionDate = transactionDate;
            this.Comment = comment;
            this.TotalPrice = (decimal)this.Quantity * this.UnitPrice;
        }
    }
}
