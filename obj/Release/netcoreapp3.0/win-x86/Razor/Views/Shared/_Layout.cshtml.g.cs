#pragma checksum "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9416719ac9dc342d210c570581734a3830f1d6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\_ViewImports.cshtml"
using CBSBahrainMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\_ViewImports.cshtml"
using CBSBahrainMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9416719ac9dc342d210c570581734a3830f1d6b", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9a2d97fd36a1dfc4bc3cf5aabe2db16e3a82f5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("fixed-left"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" \r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9416719ac9dc342d210c570581734a3830f1d6b3558", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">

    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />

    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <title>CBS Bahrain</title>


    <link rel=""shortcut icon""");
                BeginWriteAttribute("href", " href=\"", 378, "\"", 428, 2);
#nullable restore
#line 15 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 385, Url.Content("~/"), 385, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 403, "assets/images/favicon.ico", 403, 25, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 443, "\"", 496, 2);
#nullable restore
#line 17 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 450, Url.Content("~/"), 450, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 468, "assets/css/bootstrap.min.css", 468, 28, true);
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\">\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 542, "\"", 587, 2);
#nullable restore
#line 18 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 549, Url.Content("~/"), 549, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 567, "assets/css/icons.css", 567, 20, true);
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\">\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 633, "\"", 678, 2);
#nullable restore
#line 19 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 640, Url.Content("~/"), 640, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 658, "assets/css/style.css", 658, 20, true);
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\">\r\n\r\n\r\n    <!-- Summernote css -->\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 757, "\"", 822, 2);
#nullable restore
#line 23 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 764, Url.Content("~/"), 764, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 782, "assets/plugins/summernote/summernote.css", 782, 40, true);
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" />\r\n    <!--bootstrap-wysihtml5-->\r\n    <link rel=\"stylesheet\" type=\"text/css\"");
                BeginWriteAttribute("href", " href=\"", 919, "\"", 1002, 2);
#nullable restore
#line 25 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 926, Url.Content("~/"), 926, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 944, "assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.css", 944, 58, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9416719ac9dc342d210c570581734a3830f1d6b7964", async() => {
                WriteLiteral("\r\n\r\n    <!-- Begin page -->\r\n    <div id=\"wrapper\">\r\n\r\n        <!-- Top Bar Start -->\r\n        <div class=\"topbar\">\r\n            <!-- LOGO -->\r\n            <div class=\"topbar-left\">\r\n                <div class=\"text-center\">\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 1294, "\"", 1319, 1);
#nullable restore
#line 40 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1301, Url.Content("~/"), 1301, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"logo\"><img");
                BeginWriteAttribute("src", " src=\"", 1338, "\"", 1384, 2);
#nullable restore
#line 40 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1344, Url.Content("~/"), 1344, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1362, "assets/images/logo.png", 1362, 22, true);
                EndWriteAttribute();
                WriteLiteral(" alt=\"logo-img\"></a>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 1429, "\"", 1454, 1);
#nullable restore
#line 41 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1436, Url.Content("~/"), 1436, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"logo-sm\"><img");
                BeginWriteAttribute("src", " src=\"", 1476, "\"", 1525, 2);
#nullable restore
#line 41 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1482, Url.Content("~/"), 1482, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1500, "assets/images/logo_sm.png", 1500, 25, true);
                EndWriteAttribute();
                WriteLiteral(@" alt=""logo-img""></a>
                </div>
            </div>
            <!-- Button mobile view to collapse sidebar menu -->
            <div class=""navbar navbar-default"" role=""navigation"">
                <div class=""container"">
                    <div");
                BeginWriteAttribute("class", " class=\"", 1790, "\"", 1798, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <div class=""pull-left"">
                            <button type=""button"" class=""button-menu-mobile open-left waves-effect waves-light"">
                                <i class=""ion-navicon""></i>
                            </button>
                            <span class=""clearfix""></span>
                        </div>



                    </div>
                    <!--/.nav-collapse -->
                </div>
            </div>
        </div>
        <!-- Top Bar End -->
        <!-- ========== Left Sidebar Start ========== -->

        <div class=""left side-menu"">
            <div class=""sidebar-inner slimscrollleft"">

                <!--<div class=""user-details"">-->
                <!--<div class=""pull-left"">-->
                <!--<img src=""");
#nullable restore
#line 70 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
                         Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"assets/images/users/avatar-1.jpg"" alt="""" class=""thumb-md img-circle"">-->
                <!--</div>-->
                <!--<div class=""user-info"">-->
                <!--<div class=""dropdown"">-->
                <!--<a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"" aria-expanded=""false"">David Cooper <span class=""caret""></span></a>-->
                <!--<ul class=""dropdown-menu"">-->
                <!--<li><a href=""javascript:void(0)""><i class=""md md-face-unlock""></i> Profile<div class=""ripple-wrapper""></div></a></li>-->
                <!--<li><a href=""javascript:void(0)""><i class=""md md-settings""></i> Settings</a></li>-->
                <!--<li><a href=""javascript:void(0)""><i class=""md md-lock""></i> Lock screen</a></li>-->
                <!--<li><a href=""javascript:void(0)""><i class=""md md-settings-power""></i> Logout</a></li>-->
                <!--</ul>-->
                <!--</div>-->
                <!--<p class=""text-muted m-0"">Admin</p>-->
                <!--</div>-->
        ");
                WriteLiteral("        <!--</div>-->\r\n                <!--- Divider -->\r\n\r\n\r\n                <div id=\"sidebar-menu\">\r\n                    <ul>\r\n                        <li class=\"menu-title\">Menu</li>\r\n                        <li>\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 3900, "\"", 3925, 1);
#nullable restore
#line 92 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3907, Url.Content("~/"), 3907, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"waves-effect\"><i class=\"mdi mdi-home\"></i><span> Home  </span></a>\r\n                        </li>\r\n                        <li>\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 4093, "\"", 4128, 1);
#nullable restore
#line 95 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4100, Url.Content("~/Categories"), 4100, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"waves-effect\"><i class=\"mdi mdi-album\"></i><span> Categories  </span></a>\r\n                        </li>\r\n\r\n                        <li>\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 4305, "\"", 4339, 1);
#nullable restore
#line 99 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4312, Url.Content("~/SongBanks"), 4312, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"waves-effect\"><i class=\"mdi mdi-layers\"></i><span> Songs  </span></a>\r\n                        </li>\r\n                        <li>\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 4510, "\"", 4544, 1);
#nullable restore
#line 102 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4517, Url.Content("~/ClassStds"), 4517, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"waves-effect\"><i class=\"mdi mdi-album\"></i><span> Classes  </span></a>\r\n                        </li>\r\n\r\n                        <li>\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 4718, "\"", 4750, 1);
#nullable restore
#line 106 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4725, Url.Content("~/Lessons"), 4725, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"waves-effect\"><i class=\"mdi mdi-layers\"></i><span> Lessons  </span></a>\r\n                        </li>\r\n                        <li>\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 4923, "\"", 4961, 1);
#nullable restore
#line 109 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4930, Url.Content("~/Notifications"), 4930, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"waves-effect\"><i class=\"mdi mdi-layers\"></i><span> Notification  </span></a>\r\n                        </li>\r\n                        <li>\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 5139, "\"", 5172, 1);
#nullable restore
#line 112 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 5146, Url.Content("~/Settings"), 5146, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"waves-effect\"><i class=\"mdi mdi-layers\"></i><span> Settings  </span></a>\r\n                        </li>\r\n\r\n                        <li>\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 5348, "\"", 5388, 1);
#nullable restore
#line 116 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 5355, Url.Content("~/CMSUsers/Edit/1"), 5355, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"waves-effect\"><i class=\"mdi mdi-layers\"></i><span> Reset Password  </span></a>\r\n                        </li>\r\n\r\n                        <li>\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 5570, "\"", 5610, 1);
#nullable restore
#line 120 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 5577, Url.Content("~/CMSUsers/Logout"), 5577, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""waves-effect""><i class=""mdi mdi-layers""></i><span> Logout  </span></a>
                        </li>

                    </ul>
                    
                </div>
                <div class=""clearfix""></div>
            </div> <!-- end sidebarinner -->
        </div>
        <!-- Left Sidebar End -->
        <!-- Start right Content here -->
        ");
#nullable restore
#line 131 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        <!-- End Right content here -->\r\n        <footer class=\"footer\">\r\n            © ");
#nullable restore
#line 135 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
         Write(DateTime.Now.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - All Rights Reserved.\r\n        </footer>\r\n    </div>\r\n    <!-- END wrapper -->\r\n    <!-- jQuery  -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6229, "\"", 6276, 2);
#nullable restore
#line 140 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6235, Url.Content("~/"), 6235, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6253, "assets/js/jquery.min.js", 6253, 23, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6300, "\"", 6350, 2);
#nullable restore
#line 141 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6306, Url.Content("~/"), 6306, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6324, "assets/js/bootstrap.min.js", 6324, 26, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6374, "\"", 6424, 2);
#nullable restore
#line 142 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6380, Url.Content("~/"), 6380, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6398, "assets/js/modernizr.min.js", 6398, 26, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6448, "\"", 6491, 2);
#nullable restore
#line 143 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6454, Url.Content("~/"), 6454, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6472, "assets/js/detect.js", 6472, 19, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6515, "\"", 6561, 2);
#nullable restore
#line 144 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6521, Url.Content("~/"), 6521, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6539, "assets/js/fastclick.js", 6539, 22, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6585, "\"", 6639, 2);
#nullable restore
#line 145 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6591, Url.Content("~/"), 6591, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6609, "assets/js/jquery.slimscroll.js", 6609, 30, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6663, "\"", 6714, 2);
#nullable restore
#line 146 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6669, Url.Content("~/"), 6669, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6687, "assets/js/jquery.blockUI.js", 6687, 27, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6738, "\"", 6780, 2);
#nullable restore
#line 147 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6744, Url.Content("~/"), 6744, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6762, "assets/js/waves.js", 6762, 18, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6804, "\"", 6848, 2);
#nullable restore
#line 148 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6810, Url.Content("~/"), 6810, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6828, "assets/js/wow.min.js", 6828, 20, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6872, "\"", 6926, 2);
#nullable restore
#line 149 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6878, Url.Content("~/"), 6878, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6896, "assets/js/jquery.nicescroll.js", 6896, 30, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 6950, "\"", 7006, 2);
#nullable restore
#line 150 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6956, Url.Content("~/"), 6956, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 6974, "assets/js/jquery.scrollTo.min.js", 6974, 32, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 7032, "\"", 7072, 2);
#nullable restore
#line 152 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 7038, Url.Content("~/"), 7038, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7056, "assets/js/app.js", 7056, 16, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n\r\n\r\n\r\n    <!-- Wysihtml js -->\r\n    <script type=\"text/javascript\"");
                BeginWriteAttribute("src", " src=\"", 7151, "\"", 7228, 2);
#nullable restore
#line 157 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 7157, Url.Content("~/"), 7157, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7175, "assets/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js", 7175, 53, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script type=\"text/javascript\"");
                BeginWriteAttribute("src", " src=\"", 7275, "\"", 7356, 2);
#nullable restore
#line 158 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 7281, Url.Content("~/"), 7281, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7299, "assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js", 7299, 57, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n\r\n    <!--Summernote js-->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 7408, "\"", 7475, 2);
#nullable restore
#line 161 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 7414, Url.Content("~/"), 7414, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7432, "assets/plugins/summernote/summernote.min.js", 7432, 43, true);
                EndWriteAttribute();
                WriteLiteral(@"></script>


    <script>

        jQuery(document).ready(function () {
            $('.wysihtml5').wysihtml5();

            $('.summernote').summernote({
                height: 200,                 // set editor height

                minHeight: null,             // set minimum height of editor
                maxHeight: null,             // set maximum height of editor

                focus: true                 // set focus to editable area after initializing summernote
            });

        });
    </script>


");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
