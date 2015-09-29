using System.Web.Optimization;

namespace MobileGuestList
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css").Include(
                "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/main.js",
                "~/Scripts/changeStation.js",
                "~/Scripts/contestlist.js",
                "~/Scripts/guestlist.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}