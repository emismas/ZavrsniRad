using System.Web;
using System.Web.Optimization;

namespace FinancialAnalysis
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));



            //< script src = "../vendor/metisMenu/metisMenu.min.js" ></ script >


            // < !--Morris Charts JavaScript -->

            // < script src = "../vendor/raphael/raphael.min.js" ></ script >

            //  < script src = "../vendor/morrisjs/morris.min.js" ></ script >

            //   < script src = "../data/morris-data.js" ></ script >


            //    < !--Custom Theme JavaScript -->

            //    < script src = "../dist/js/sb-admin-2.js" ></ script >

            bundles.Add(new ScriptBundle("~/bundles/metisMenu").Include(
                      "~/Content/metisMenu/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/raphael").Include(
                      "~/Content/raphael/raphael.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/morris").Include(
                      "~/Content/morrisjs/morris.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/flot").IncludeDirectory(
                      "~/Content/flot", "*.js", false));

            bundles.Add(new ScriptBundle("~/bundles/morrisdata").Include(
                      "~/Content/morris-data.js"));

            bundles.Add(new ScriptBundle("~/bundles/sbadmin").Include(
                      "~/Content/sb-admin-2.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap/css/bootstrap.min.css",
                 //"~/Content/site.css",
                 "~/Content/sb-admin-2.css",
                 "~/Content/metisMenu/metisMenu.min.css",
                 "~/Content/morrisjs/morris.css",
                 "~/Content/font-awesome/css/font-awesome.min.css"));
        }
    }
}
