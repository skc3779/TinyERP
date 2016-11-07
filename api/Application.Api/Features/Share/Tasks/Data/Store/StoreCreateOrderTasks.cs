using System.Web;
using App.Common;
using App.Common.Tasks;
using System;
using App.Service.ProductManagement.Product;
using App.Common.DI;
using App.Service.ProductManagement.Category;
using App.Entity.Store;
using App.Service.Store.Store;
using System.Linq;
using App.Service.Store.Order;

namespace App.Api.Features.Share.Tasks.Data.Store
{
    public class StoreCreateOrderTasks : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public StoreCreateOrderTasks() : base(ApplicationType.All)
        {
            this.Order = 10;
        }
        public override void Execute(TaskArgument<HttpApplication> context)
        {
            if (!this.IsValid(context.Type)) { return; }

            IStoreService storeService = IoC.Container.Resolve<IStoreService>();
            StoreListItem store = storeService.GetStores().FirstOrDefault();
            Guid categoryId = CreateCategory();
            Guid productId = CreateProduct(categoryId, store.Id);
            CreateOrder(productId);
        }
        private Guid CreateCategory()
        {
            Guid categoryId;
            string categoryName = "Order category";
            ICategoryService service = IoC.Container.Resolve<ICategoryService>();
            if (service.GetByName(categoryName) == null)
            {
                CreateCategoryRequest request = new CreateCategoryRequest();
                request.Name = categoryName;
                categoryId = service.Create(request).Id;
            }
            else {
                categoryId = service.GetByName(categoryName).Id;
            }
            return categoryId;
        }
        private void CreateOrder(Guid productId)
        {
            CreateOrderRequest request = new CreateOrderRequest();
            request.Contact = new OrderContact("Contact Name", "contact@email.com", "123456798");
            request.Status = StoreOrderStatus.WaittintgForApprove;
            request.TransactionDate = DateTime.UtcNow;
            request.Comment = "Comment on order";
            request.Items.Add(new CreateOrderItemRequest(productId, 2, 10000, DateTime.Now, StoreOrderStatus.InActive, "Comment on product"));

            IOrderService orderService = IoC.Container.Resolve<IOrderService>();
            orderService.Create(request);
        }
        private Guid CreateProduct(Guid categoryId, Guid storeId)
        {
            Guid productId = new Guid("60af8ea5-0da2-4bc0-bf18-251b93da5406");
            IProductService productService = IoC.Container.Resolve<IProductService>();
            if (productService.Get(productId) == null)
            {
                CreateProductRequest createRequest = new CreateProductRequest();
                createRequest.Id = productId;
                createRequest.Name = "product for order testing";
                createRequest.Description = "desc";
                createRequest.CategoryId = categoryId;
                createRequest.StoreId = storeId;
                productService.Create(createRequest);
            }
            return productId;
        }
    }
}