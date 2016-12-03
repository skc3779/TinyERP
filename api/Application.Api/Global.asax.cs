namespace App.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private App.Common.Application.IApplication application;
        public WebApiApplication()
        {
            this.application = App.Common.Application.ApplicationFactory.Create<System.Web.HttpApplication>(App.Common.ApplicationType.WebApi, this);
        }

        protected void Application_Start()
        {
            this.application.OnApplicationStarted();
        }

        protected void Application_End()
        {
            this.application.OnApplicationEnded();
        }
    }
}
