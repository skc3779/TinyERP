using System;

namespace App.Service.Store.Order
{
    public interface IOrderService
    {
        System.Collections.Generic.IList<OrderSummaryListItem> GetOrders();
        CreateOrderResponse Create(CreateOrderRequest request);
        OrderSummary GetOrderSummary(Guid id);
    }
}
