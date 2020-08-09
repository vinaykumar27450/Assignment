using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Application
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundle)
        {
            StyleBundle myCssBundle = new StyleBundle("~/Content/MyCss");
            myCssBundle.Include("~/Content/bootstrap.css", "~/Content/bootstrap-datetimepicker.min.css", "~/Content/Site.css", "~/Content/bootstrap-theme.css");

            ScriptBundle myJSBundle = new ScriptBundle("~/Scripts/MyJS");
            myJSBundle.Include("~/Scripts/jquery-3.4.1.js", "~/Scripts/moment.min.js", "~/Scripts/bootstrap.js", "~/Scripts/bootstrap-datetimepicker.min.js", "~/Scripts/jquery.validate.min.js", "~/Scripts/jquery.validate.unobtrusive.min.js", "~/Scripts/jquery.unobtrusive-ajax.min.js");

            bundle.Add(myCssBundle);
            bundle.Add(myJSBundle);
            BundleTable.EnableOptimizations = true;
        }
    }
}