using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace UIFormAPP.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/jquery-3.6.3.js"
                , "~/Scripts/umd/popper.js","~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Styles/bootstrap").Include("~/Content/bootstarp.css"));

            BundleTable.EnableOptimizations= true;

        }
    }
}