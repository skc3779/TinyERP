using App.Common.Tasks;
using System.Collections.Generic;
using System.Web;
using App.Common;
using App.Common.DI;
using App.Service.Inventory;
using App.Entity.Inventory;

namespace App.Api.Features.Share.Tasks.Data
{
    public class CreateProductCategoryTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public CreateProductCategoryTask() : base(ApplicationType.All)
        {
        }

        public override void Execute(TaskArgument<HttpApplication> context)
        {
            ICategoryService categoryService = IoC.Container.Resolve<ICategoryService>();
            IList<Category> categories = GetCategories();
            categoryService.CreateIfNotExist(categories);
        }

        private IList<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category("name 1", "description 1"),
                new Category("name 2","description 2")
            };
        }
    }
}