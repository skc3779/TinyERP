namespace App.Common
{
    using App.Common.Helpers;
    using App.Common.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Routing;

    public class BaseApplication<TContext> : IApplication
    {
        public TContext Context { get; private set; }
        public ApplicationType Type { get; private set; }
        public BaseApplication(TContext context, ApplicationType type)
        {
            this.Context = context;
            this.Type = type;
        }

        public void OnApplicationStarted()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IApplicationStartedTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
            AssemblyHelper.ExecuteTasks<IApplicationReadyTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg, true);
        }

        public void OnApplicationEnded()
        {
        }

        public void OnRouteConfigured()
        {
            TaskArgument<RouteCollection> taskArg = new TaskArgument<RouteCollection>(RouteTable.Routes, this.Type);
            AssemblyHelper.ExecuteTasks<IRouteConfiguredTask, TaskArgument<RouteCollection>>(taskArg);
        }

        public void OnApplicationRequestStarted()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IApplicationRequestStartedTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
        }

        public void OnApplicationRequestEnded()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IApplicationRequestEndedTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
        }

        public void OnUnHandledError()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IUnHandledErrorTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
        }

        public void OnApplicationRequestExecuting()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IApplicationRequestExecutingTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
        }

        public void ConfigServiceContainer()
        {
            TaskArgument<ServicesContainer> taskArg = new TaskArgument<ServicesContainer>(GlobalConfiguration.Configuration.Services, this.Type);
            AssemblyHelper.ExecuteTasks<IServiceContainerConfiguredTask<TaskArgument<ServicesContainer>>, TaskArgument<ServicesContainer>>(taskArg);
        }
    }
}