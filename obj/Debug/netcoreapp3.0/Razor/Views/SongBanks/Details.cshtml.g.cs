#pragma checksum "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07f24e24bd8d0f31b990c94b5187ece9fb7bf2ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SongBanks_Details), @"mvc.1.0.view", @"/Views/SongBanks/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07f24e24bd8d0f31b990c94b5187ece9fb7bf2ba", @"/Views/SongBanks/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9a2d97fd36a1dfc4bc3cf5aabe2db16e3a82f5", @"/Views/_ViewImports.cshtml")]
    public class Views_SongBanks_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CBSBahrainMVC.Models.SongBank>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n \r\n\r\n\r\n\r\n<div class=\"content-page\">\r\n    <!-- Start content -->\r\n    <div class=\"content\">\r\n\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 191, "\"", 199, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""page-header-title"">

                <button class=""btn btn-warning pull-right"" onclick=""window.history.back()"">Back</button>
                <h4 class=""page-title"">Song</h4>
            </div>
        </div>

        <div class=""page-content-wrapper "">

            <div class=""container"">
                <div class=""row"">
                    <div class=""col-sm-12"">
                        <div class=""panel panel-primary"">
                            <div class=""panel-body"">


                                <div class=""row"">


                                    <div class=""col-md-12"">
                                        <div class=""panel panel-primary"">
                                            <div class=""panel-body"">

                                                <div class=""row"">
                                                    <div class=""col-xs-12"">
                                                        <h3> ");
#nullable restore
#line 41 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml"
                                                        Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                                        <br />\r\n                                                        <b>Category:</b> ");
#nullable restore
#line 43 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml"
                                                                    Write(Model.Category.Category1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        <br />\r\n");
#nullable restore
#line 45 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml"
                                                         if (Model.YoutubeUrl != null || Model.YoutubeUrl == "")
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <b>Youtube URL :</b> ");
#nullable restore
#line 47 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.YoutubeUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <br />\r\n                                                            <iframe width=\"560\" height=\"315\"");
            BeginWriteAttribute("src", " src=\"", 1927, "\"", 2028, 2);
            WriteAttributeValue("", 1933, "https://www.youtube.com/embed/", 1933, 30, true);
#nullable restore
#line 50 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml"
WriteAttributeValue("", 1963, Model.YoutubeUrl.Replace("https://www.youtube.com/watch?v=", ""), 1963, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" frameborder=""0"" allow=""accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen></iframe>
                                                            <br />
                                                            <br />
");
#nullable restore
#line 53 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml"
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <b>Youtube URL : Not added</b>\r\n");
#nullable restore
#line 57 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        <br style=\"clear:both\" /><br />\r\n                                                        <b>Lyrics</b><br />\r\n                                                        ");
#nullable restore
#line 61 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Details.cshtml"
                                                   Write(Html.Raw(Model.Lyrics));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>




                                </div> <!-- end row -->
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end row -->




            </div><!-- container -->

        </div> <!-- Page content Wrapper -->

    </div> <!-- content -->



</div>





");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CBSBahrainMVC.Models.SongBank> Html { get; private set; }
    }
}
#pragma warning restore 1591