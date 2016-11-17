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
            List<CreateCategoryRequest> createCategoriesRequest = GetCreateCategoriesRequest();
            categoryService.CreateIfNotExist(createCategoriesRequest);
        }

        private List<CreateCategoryRequest> GetCreateCategoriesRequest()
        {
            return new List<CreateCategoryRequest>()
            {
                new CreateCategoryRequest("name 1", "description 1"),
                new CreateCategoryRequest("name 2","description 2")
            };
        }
    }
}