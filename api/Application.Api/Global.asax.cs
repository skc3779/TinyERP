namespace App.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private App.Common.IApplication application;
        public WebApiApplication()
        {
            this.application = App.Common.ApplicationFactory.Create<System.Web.HttpApplication>(App.Common.ApplicationType.WebApi, this);
        }

        protected void Application_Start()
        {
            this.application.OnApplicationStarted();
            this.RegisterRoutes();
        }

        protected void Application_PreRequestHandlerExecute()
        {
        }

        protected void RegisterRoutes()
        {
            this.application.OnRouteConfigured();
        }
    }
}
