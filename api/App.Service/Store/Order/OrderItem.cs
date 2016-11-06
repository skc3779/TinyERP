using App.Common.Data;
using System;

namespace App.Service.Store.Order
{
    public class OrderItem: BaseEntity
    {
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public string Comment { get; set; }
        /// <summary>
        /// Used by EF only
        /// </summary>
        public OrderItem()
        {

        }
        public OrderItem(Guid productId, double quantity, string comment)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Comment = comment;
        }
    }
}
