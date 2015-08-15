using System.Web.Optimization;

namespace MobileGuestList
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/slidebars").Include(
                "~/Scripts/slidebars.js"));

            bundles.Add(new ScriptBundle("~/bundles/contestlist").Include(
                "~/Scripts/contestlist.js"));

            bundles.Add(new ScriptBundle("~/bundles/guestlist").Include(
                "~/Scripts/guestlist.js"));

            bundles.Add(new ScriptBundle("~/bundles/calculateChekboxesNum").Include(
                "~/Scripts/calculateChekboxesNum.js"));

            bundles.Add(new ScriptBundle("~/bundles/changeStation").Include(
                "~/Scripts/changeStation.js"));

#if (!DEBUG)
            BundleTable.EnableOptimizations = true;
#endif
        }
	}
}