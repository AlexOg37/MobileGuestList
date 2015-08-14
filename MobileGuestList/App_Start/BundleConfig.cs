using System.Web;
using System.Web.Optimization;

namespace MobileGuestList
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
									"~/Scripts/jquery-1.*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
									"~/Scripts/jquery-ui*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
									"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
									"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/jquerymobile").Include("~/Scripts/jquery.mobile*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/slidebars").Include("~/Scripts/slidebars.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootstrap*"));

			bundles.Add(new StyleBundle("~/Content/mobilecss").Include("~/Content/jquery.mobile*"));
            
			bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
									"~/Content/themes/base/jquery.ui.core.css",
									"~/Content/themes/base/jquery.ui.resizable.css",
									"~/Content/themes/base/jquery.ui.selectable.css",
									"~/Content/themes/base/jquery.ui.accordion.css",
									"~/Content/themes/base/jquery.ui.autocomplete.css",
									"~/Content/themes/base/jquery.ui.button.css",
									"~/Content/themes/base/jquery.ui.dialog.css",
									"~/Content/themes/base/jquery.ui.slider.css",
									"~/Content/themes/base/jquery.ui.tabs.css",
									"~/Content/themes/base/jquery.ui.datepicker.css",
									"~/Content/themes/base/jquery.ui.progressbar.css",
									"~/Content/themes/base/jquery.ui.theme.css"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/contestlist").Include("~/Scripts/contestlist.js"));

            bundles.Add(new ScriptBundle("~/bundles/guestlist").Include("~/Scripts/guestlist.js"));

            bundles.Add(new ScriptBundle("~/bundles/calculateChekboxesNum").Include("~/Scripts/calculateChekboxesNum.js"));

            bundles.Add(new ScriptBundle("~/bundles/changeStation").Include("~/Scripts/changeStation.js"));

#if (!DEBUG)
            BundleTable.EnableOptimizations = true;
#endif
        }
	}
}