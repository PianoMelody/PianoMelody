namespace PianoMelody.Web.Extensions
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    public class I18NAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string culture;
            string language = (string)filterContext.RouteData.Values["language"] ?? "bg";
            switch (language)
            {
                case "bg":
                    culture = "BG";
                    break;
                case "en":
                    culture = "US";
                    break;
                case "ru":
                    culture = "RU";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(
                string.Format("{0}-{1}", language, culture));
            Thread.CurrentThread.CurrentUICulture =
                CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
        }
    }
}