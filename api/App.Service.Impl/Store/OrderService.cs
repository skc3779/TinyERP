using System.Collections.Generic;
using App.Service.Store.Order;
using App.Common.DI;
using App.Repository.Store;
using System;
using App.Common.Data;
using App.Context;
using App.Common;
using App.Entity.Store;
using App.Common.Helpers;
using App.Repository.ProductManagement;
using App.Common.Validation;

namespace App.Service.Impl.Store
{
    public class OrderService : IOrderService
    {
        public CreateOrderResponse Create(CreateOrderRequest request)
        {
            ValidateCreateOrderRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                App.Entity.Store.Order order = GetOrderFromRequest(request, uow);
                IOrderRepository repo = IoC.Container.Resolve<IOrderRepository>(uow);
                repo.Add(order);
                uow.Commit();
                return ObjectHelper.Convert<CreateOrderResponse>(order);
            }
        }

        private Order GetOrderFromRequest(CreateOrderRequest request, IUnitOfWork uow)
        {
            Order order = new Order();

            order.Contact = request.Contact;
            order.Status = request.Status;
            order.TransactionDate = request.TransactionDate;
            order.Comment = request.Comment;
            IProductRepository productRepo = IoC.Container.Resolve<IProductRepository>(uow);
            foreach (CreateOrderItemRequest item in request.Items)
            {
                App.Entity.ProductManagement.Product product = productRepo.GetById(item.ProductId.ToString());
                App.Entity.Store.OrderItem orderItem = new App.Entity.Store.OrderItem(product, item.Quantity, item.UnitPrice, item.Status, item.TransactionDate, item.Comment);
                order.Items.Add(orderItem);
                order.NumberOfItems += item.Quantity;
                order.Price += orderItem.TotalPrice;
            }
            return order;
        }

        private void ValidateCreateOrderRequest(CreateOrderRequest request)
        {
            if (request.Contact == null)
            {
                throw new ValidationException("store.createOrder.contactIsRequired");
            }
            if (!EmailHelper.IsValid(request.Contact.Email))
            {
                throw new ValidationException("store.createOrder.contactEmailIsRequired");
            }
            if (request.Items == null || request.Items.Count == 0)
            {
                throw new ValidationException("store.createOrder.orderItemIsrequires");
            }
            IProductRepository productRepo = IoC.Container.Resolve<IProductRepository>();
            foreach (CreateOrderItemRequest item in request.Items)
            {
                if (productRepo.Exists(item.ProductId)) { continue; }
                throw new ValidationException("store.createOrder.orderItemProductIsInvalid");
            }
        }

        public IList<OrderSummaryListItem> GetOrders()
        {
            IOrderRepository repository = IoC.Container.Resolve<IOrderRepository>();
            return repository.GetOrders<OrderSummaryListItem>();
        }

        public OrderSummary GetOrderSummary(Guid id)
        {
            IOrderRepository repo = IoC.Container.Resolve<IOrderRepository>();
            return repo.GetById<OrderSummary>(id.ToString(), "Contact,Items,Items.Product");
        }
    }
}
