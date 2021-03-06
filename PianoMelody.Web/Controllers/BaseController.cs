﻿namespace PianoMelody.Web.Controllers
{
    using System;
    using System.Threading;
    using System.Web.Mvc;

    using Data;
    using Data.Contracts;
    using Helpers;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new PianoMelodyData())
        {
        }

        public BaseController(IPianoMelodyData data)
        {
            this.Data = data;
        }

        protected IPianoMelodyData Data { get; set; }

        protected string GetBaseUrl()
        {
            //var request = System.Web.HttpContext.Current.Request;
            //var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            //var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);
            var baseUrl = "/";
            return baseUrl;
        }

        public string CurrentCulture { get { return CultureHelper.GetCurrentCulture().Substring(0, 2); } }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = RouteData.Values["culture"] as string;

            // Attempt to read the culture cookie from Request
            if (cultureName == null)
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            if (RouteData.Values["culture"] as string != cultureName)
            {
                // Force a valid culture in the URL
                RouteData.Values["culture"] = cultureName.ToLowerInvariant(); // lower case too

                // Redirect user
                Response.RedirectToRoute(RouteData.Values);
            }

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }
    }
}