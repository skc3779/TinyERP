using App.Common;
using System;

namespace App.Service.Store.Order
{
    public class CreateOrderItemRequest
    {
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public ItemStatus Status { get; set; }
        public string Comment { get; set; }
        public CreateOrderItemRequest(Guid productid, double quantity, decimal unitPrice, DateTime transactionDate, ItemStatus status, string comment)
        {
            this.ProductId = productid;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.TransactionDate = transactionDate;
            this.Status = status;
            this.Comment = comment;

        }
    }
}
