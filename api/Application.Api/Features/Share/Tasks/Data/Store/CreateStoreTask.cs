using System.Web;
using App.Common;
using App.Common.Tasks;
using App.Service.Store;
using System.Collections.Generic;
using App.Common.DI;
using App.Service.Store.Store;
using System.Linq;
using App.Common.Helpers;

namespace App.Api.Features.Share.Tasks.Data.Store
{
    public class CreateStoreTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public CreateStoreTask() : base(ApplicationType.All){
            this.Order = 1;
        }
        public override void Execute(TaskArgument<HttpApplication> context)
        {
            if (!this.IsValid(context.Type)) { return; }
            IAccountService storeAccountService = IoC.Container.Resolve<IAccountService>();
            IList<CreateStoreRequest> request = new List<CreateStoreRequest>();
            request.Add(new CreateStoreRequest() {
                Name="Store 1",
                Description="Store 1 description",
                Status=StoreItemStatus.InActive,
                Owner = new StoreOwner() { Id = storeAccountService.GetAccounts().FirstOrDefault().Id }
            });
            IStoreService service = IoC.Container.Resolve<IStoreService>();
            service.CreateIfNotExist(request);

        }
    }
}