namespace PianoMelody.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-3.1.0.min.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(
                new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-2.8.3.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.min.js",
                    "~/Scripts/respond.min.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/shared").Include(
                    "~/Scripts/Custom/shared.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/image-preview").Include(
                    "~/Scripts/Custom/image-preview.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/images-preview").Include(
                    "~/Scripts/Custom/images-preview.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/photoswipe").Include(
                    "~/Scripts/photoswipe/photoswipe.min.js",
                    "~/Scripts/photoswipe/photoswipe-ui-default.min.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/load-gallery").Include(
                    "~/Scripts/Custom/photoswipe-function.js",
                    "~/Scripts/Custom/load-gallery.js"));

            bundles.Add(
                new StyleBundle("~/Content/css").Include(
                    "~/Content/menu.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/photoswipe/photoswipe.css",
                    "~/Content/photoswipe/default-skin/default-skin.css",
                    "~/Content/site.css"));
        }
    }
}