using System.Web;
using App.Common;
using App.Common.Tasks;
using App.Service.Store;
using System.Collections.Generic;
using App.Common.DI;

namespace App.Api.Features.Share.Tasks.Data.Store
{
    public class StoreCreateAccountTasks : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public StoreCreateAccountTasks() : base(ApplicationType.All){
        }
        public override void Execute(TaskArgument<HttpApplication> context)
        {
            if (!this.IsValid(context.Type)) { return; }
            IList<CreateAccountRequest> request = new List<CreateAccountRequest>();
            request.Add(new CreateAccountRequest("Store 1", "store1@email.com", "store1", "Store 1 description"));
            request.Add(new CreateAccountRequest("Store 2", "store2@email.com", "store2", "Store 2 description"));
            IAccountService service = IoC.Container.Resolve<IAccountService>();
            service.CreateIfNotExist(request);

        }
    }
}