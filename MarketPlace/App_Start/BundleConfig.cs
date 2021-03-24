using System.Web;
using System.Web.Optimization;

namespace MarketPlace {
  public class BundleConfig {
    // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles) {
      bundles.Add(new ScriptBundle("~/bundles/jquery").
        Include("~/Scripts/jquery-{version}.js").
        Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));

      bundles.Add(new StyleBundle("~/Content/css").
        Include("~/Content/styles.css").
        Include("~/Content/Site.css").
        Include("~/Content/jquery-ui.theme.min.css").
        Include("~/Content/jquery-ui.structure.min.css").
        Include("~/Content/jquery-ui.min.css"));


    }
  }
}
