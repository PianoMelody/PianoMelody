namespace PianoMelody.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "admin",
                defaults: new
                {
                    controller = "Account",
                    action = "Login"
                });

            routes.MapRoute(
                name: "DefaultLocalized",
                url: "{language}/{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                    language = "bg"
                });
        }
    }
}