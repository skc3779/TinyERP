namespace App.Api
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("*", "Accept,Origin,content-type,authtoken,cache-control,x-requested-with", "*");
            config.EnableCors(corsAttr);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "users", id = RouteParameter.Optional });
        }
    }
}
