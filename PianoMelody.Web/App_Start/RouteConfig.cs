namespace PianoMelody.Web
{
    using Helpers;
    using LowercaseRoutesMVC;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRouteLowercase(
                name: "Admin",
                url: "{culture}/admin",
                defaults: new
                {
                    culture = CultureHelper.GetDefaultCulture(),
                    controller = "Account",
                    action = "Login"
                }
            );

            routes.MapRouteLowercase(
                name: "About",
                url: "{culture}/about-us",
                defaults: new
                {
                    culture = CultureHelper.GetDefaultCulture(),
                    controller = "Home",
                    action = "About"
                }
            );

            routes.MapRouteLowercase(
                name: "Contact",
                url: "{culture}/contact-us",
                defaults: new
                {
                    culture = CultureHelper.GetDefaultCulture(),
                    controller = "Home",
                    action = "Contact"
                }
            );

            routes.MapRouteLowercase(
                name: "DefaultLocalized",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new
                {
                    culture = CultureHelper.GetDefaultCulture(),
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRouteLowercase(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}