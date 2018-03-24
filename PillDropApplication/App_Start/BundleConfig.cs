using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace PillDropApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.11.1.js"));

            var bundle = new ScriptBundle("~/bundles/pilldrop").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate-vsdoc.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery-ui-1.10.1.custom.min.js",
                "~/Scripts/jquery.tmpl.js",
                "~/Scripts/toastr.min.js",
                "~/Scripts/messenger/messenger.min.js",
                "~/Scripts/messenger/messenger-theme-future.js",
                "~/Scripts/underscore.js",
                "~/Scripts/popper.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.bootstrap.wizard.js",
                "~/Scripts/respond.js",
                "~/Scripts/breakpoints.js",
                "~/Scripts/jquery.unveil.min.js",
                "~/Scripts/jquery.cookie.js",
                "~/Scripts/jquery.blockUI.js",
                "~/Scripts/jquery.slimscroll.min.js",
                "~/Scripts/jquery.sidr.min.js",
                "~/Scripts/jquery.animateNumbers.js",
                "~/Scripts/core.js",
                "~/Scripts/jquery.dataTables.js",
                "~/Scripts/dataTables.tableTools.min.js",
                "~/Scripts/datatables.responsive.js",
                "~/Scripts/jquery.dataTables.columnFilter.js",
                "~/Scripts/select2.js",
                "~/Scripts/jquery.dataTableWrapper.js",
                "~/Scripts/jquery.formValidationWrapper.js",
                "~/Scripts/jquery.maskedinput.js",
                "~/Scripts/lodash.min.js",
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/jquery.inputmask.min.js",
                "~/Scripts/autoNumeric.js",
                "~/Scripts/bootstrap-wysihtml5.js",
                "~/Scripts/bootstrap-tagsinput.js",
                "~/Scripts/bootstrap-timepicker.js",
                "~/Scripts/dropzone.js",
                "~/Scripts/jquery.multiple.select.js",
                "~/Scripts/namespace.js",
                "~/Scripts/general.js",
                "~/Scripts/modal.js",
               
                "~/Scripts/additional-methods.js",
                "~/Scripts/jQuery.FileUpload/jquery.fileupload.js",
                "~/Scripts/models.js",
                "~/Scripts/jQuery.print.js",
                "~/Scripts/jquery.alphanum.js",
                "~/Scripts/wizard.js",
                "~/Scripts/ajaxhandler.js"
                );
            
            bundle.Orderer = new BundleOrderer();
            bundles.Add(bundle);

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/jquery.sidr.light.css",
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-tagsinput.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/dropzone.css",
                "~/Content/bootstrap-wysihtml5.css",
                "~/Content/datepicker3.css",
                "~/Content/font-awesome.css",
                "~/Content/custom-icon-set.css",
                "~/Content/jquery.dataTables.css",
                "~/Content/datatables.responsive.css",
                "~/Content/jquery-ui.css",
                "~/Content/select2.css",
                "~/Content/style.css",
                "~/Content/responsive.css",
                "~/Content/custom-css.css",
                "~/Content/styleguide.css",
                "~/Content/bootstrap-timepicker.css",
                "~/Content/multiple-select.css",
                "~/Content/toastr.css",
                "~/Content/messenger/messenger.css",
                "~/Content/messenger/messenger-theme-future.css",
                "~/Content/jQuery.FileUpload/jquery.fileupload.css",
                "~/Content/jquery.Jcrop.css"));
        }

    }
    public class BundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
