#pragma checksum "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dce14b10a713c730fa7eb4b788f2fa186c29d1f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dce14b10a713c730fa7eb4b788f2fa186c29d1f2", @"/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9a2d97fd36a1dfc4bc3cf5aabe2db16e3a82f5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal m-t-20"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dce14b10a713c730fa7eb4b788f2fa186c29d1f24324", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta content=""Admin Dashboard"" name=""description"" />
    <meta content=""ThemeDesign"" name=""author"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />

    <title>CBS Bahrain</title>

    <link rel=""shortcut icon""");
                BeginWriteAttribute("href", " href=\"", 403, "\"", 453, 2);
#nullable restore
#line 17 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 410, Url.Content("~/"), 410, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 428, "assets/images/favicon.ico", 428, 25, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 468, "\"", 521, 2);
#nullable restore
#line 19 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 475, Url.Content("~/"), 475, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 493, "assets/css/bootstrap.min.css", 493, 28, true);
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\">\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 567, "\"", 612, 2);
#nullable restore
#line 20 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 574, Url.Content("~/"), 574, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 592, "assets/css/icons.css", 592, 20, true);
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\">\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 658, "\"", 703, 2);
#nullable restore
#line 21 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 665, Url.Content("~/"), 665, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 683, "assets/css/style.css", 683, 20, true);
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\">\r\n\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dce14b10a713c730fa7eb4b788f2fa186c29d1f27603", async() => {
                WriteLiteral(@"

    <!-- Begin page -->
    <div class=""accountbg""></div>
    <div class=""wrapper-page"">
        <div class=""panel panel-color panel-primary panel-pages"">

            <div class=""panel-body"">
                <h3 class=""text-center m-t-0 m-b-15"">
                    <a href=""index.html"" class=""logo""><img");
                BeginWriteAttribute("src", " src=\"", 1077, "\"", 1129, 2);
#nullable restore
#line 35 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 1083, Url.Content("~/"), 1083, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1101, "assets/images/logo_white.png", 1101, 28, true);
                EndWriteAttribute();
                WriteLiteral(" alt=\"logo-img\"></a>\r\n                </h3>\r\n                <h4 class=\"text-muted text-center m-t-0\"><b>Sign In</b></h4>\r\n\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dce14b10a713c730fa7eb4b788f2fa186c29d1f28795", async() => {
                    WriteLiteral("\r\n\r\n                    <div class=\"form-group\">\r\n                        <div class=\"col-xs-12\">\r\n                            <input class=\"form-control\" type=\"text\"");
                    BeginWriteAttribute("required", " required=\"", 1526, "\"", 1537, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" placeholder=""userid"" name=""userid"">
                        </div>
                    </div>

                    <div class=""form-group"">
                        <div class=""col-xs-12"">
                            <input class=""form-control"" type=""password""");
                    BeginWriteAttribute("required", " required=\"", 1804, "\"", 1815, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" placeholder=""password"" name=""password"">
                        </div>
                    </div>

                    <div class=""form-group"">
                        <div class=""col-xs-12"">
                            <div class=""checkbox checkbox-primary"">
                                <input id=""checkbox-signup"" type=""checkbox"" checked>
                                <label for=""checkbox-signup"">
                                    Remember me
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class=""form-group text-center m-t-40"">
                        <div class=""col-xs-12"">
                            <button class=""btn btn-primary btn-block btn-lg waves-effect waves-light"" type=""submit"">Log In</button>
                        </div>
                    </div>

                    <div class=""form-group m-t-30 m-b-0"">
                        <div class=""col-sm-12"" sty");
                    WriteLiteral("le=\"color:red\">\r\n                        \r\n                            ");
#nullable restore
#line 73 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
                       Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 39 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
AddHtmlAttributeValue("", 1316, Url.Content("~/Home/Login"), 1316, 28, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n    <!-- jQuery  -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3103, "\"", 3150, 2);
#nullable restore
#line 85 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3109, Url.Content("~/"), 3109, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3127, "assets/js/jquery.min.js", 3127, 23, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3174, "\"", 3224, 2);
#nullable restore
#line 86 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3180, Url.Content("~/"), 3180, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3198, "assets/js/bootstrap.min.js", 3198, 26, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3248, "\"", 3298, 2);
#nullable restore
#line 87 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3254, Url.Content("~/"), 3254, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3272, "assets/js/modernizr.min.js", 3272, 26, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3322, "\"", 3365, 2);
#nullable restore
#line 88 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3328, Url.Content("~/"), 3328, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3346, "assets/js/detect.js", 3346, 19, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3389, "\"", 3435, 2);
#nullable restore
#line 89 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3395, Url.Content("~/"), 3395, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3413, "assets/js/fastclick.js", 3413, 22, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3459, "\"", 3513, 2);
#nullable restore
#line 90 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3465, Url.Content("~/"), 3465, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3483, "assets/js/jquery.slimscroll.js", 3483, 30, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3537, "\"", 3588, 2);
#nullable restore
#line 91 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3543, Url.Content("~/"), 3543, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3561, "assets/js/jquery.blockUI.js", 3561, 27, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3612, "\"", 3654, 2);
#nullable restore
#line 92 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3618, Url.Content("~/"), 3618, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3636, "assets/js/waves.js", 3636, 18, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3678, "\"", 3722, 2);
#nullable restore
#line 93 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3684, Url.Content("~/"), 3684, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3702, "assets/js/wow.min.js", 3702, 20, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3746, "\"", 3800, 2);
#nullable restore
#line 94 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3752, Url.Content("~/"), 3752, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3770, "assets/js/jquery.nicescroll.js", 3770, 30, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3824, "\"", 3880, 2);
#nullable restore
#line 95 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3830, Url.Content("~/"), 3830, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3848, "assets/js/jquery.scrollTo.min.js", 3848, 32, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3906, "\"", 3946, 2);
#nullable restore
#line 97 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\Home\Login.cshtml"
WriteAttributeValue("", 3912, Url.Content("~/"), 3912, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3930, "assets/js/app.js", 3930, 16, true);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
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