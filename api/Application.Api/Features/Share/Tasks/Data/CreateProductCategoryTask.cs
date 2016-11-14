using App.Common.Tasks;
using System.Collections.Generic;
using System.Web;
using App.Common;
using App.Common.DI;
using App.Service.Security;
using App.Entity.Security;
using System;
using App.Common.Helpers;
using App.Service.Inventory;
using App.Entity.ProductManagement;

namespace App.Api.Features.Share.Tasks.Data
{
    public class CreateProductCategoryTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public CreateProductCategoryTask() : base(ApplicationType.All)
        {
        }

        public override void Execute(TaskArgument<HttpApplication> context)
        {
            IProductCategoryService categoryService = IoC.Container.Resolve<IProductCategoryService>();
            IList<ProductCategory> categories = GetCategories();
            categoryService.CreateIfNotExist(categories);
        }

        private IList<ProductCategory> GetCategories()
        {
            return new List<ProductCategory>()
            {
                new ProductCategory("name 1", ItemStatus.Active, "description 1", Guid.NewGuid()),
                new ProductCategory("name 2", ItemStatus.Active, "description 2", Guid.NewGuid())
            };
        }
    }
}