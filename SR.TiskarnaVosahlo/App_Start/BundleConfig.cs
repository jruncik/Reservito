using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new Bundle("~/bundles/tv").Include("~/Scripts/TV/users.js"));
            bundles.Add(new Bundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));
            bundles.Add(new Bundle("~/Content/css").Include("~/Content/*.css"));
        }
    }
}
