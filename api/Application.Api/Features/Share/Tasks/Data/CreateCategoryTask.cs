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
    public class CreateCategoryTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public CreateCategoryTask() : base(ApplicationType.All)
        {
        }

        public override void Execute(TaskArgument<HttpApplication> context)
        {
            ICategoryService categoryService = IoC.Container.Resolve<ICategoryService>();
            IList<ProductCategory> categories = GetCategoryies();
            categoryService.CreateIfNotExist(categories);
        }

        private IList<ProductCategory> GetCategoryies()
        {
            return new List<ProductCategory>()
            {
                new ProductCategory("name 1", ItemStatus.Active, "description 1", Guid.NewGuid()),
                new ProductCategory("name 2", ItemStatus.Active, "description 2", Guid.NewGuid())
            };
        }
    }
}