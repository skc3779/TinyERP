using App.Common.Tasks;
using System.Collections.Generic;
using System.Web;
using App.Common;
using App.Common.DI;
using App.Service.Inventory;

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
            List<CategoryListItem> categories = GetCategories();
            categoryService.CreateIfNotExist(categories);
        }

        private List<CategoryListItem> GetCategories()
        {
            return new List<CategoryListItem>()
            {
                new CategoryListItem("name 1", "description 1"),
                new CategoryListItem("name 2","description 2")
            };
        }
    }
}