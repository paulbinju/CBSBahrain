#pragma checksum "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\ClassStds\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a209edbc0f73233101520fb20e01bea7657f474"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ClassStds_Index), @"mvc.1.0.view", @"/Views/ClassStds/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a209edbc0f73233101520fb20e01bea7657f474", @"/Views/ClassStds/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9a2d97fd36a1dfc4bc3cf5aabe2db16e3a82f5", @"/Views/_ViewImports.cshtml")]
    public class Views_ClassStds_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CBSBahrainMVC.Models.ClassStd>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\ClassStds\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content-page\">\r\n    <!-- Start content -->\r\n    <div class=\"content\">\r\n\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 193, "\"", 201, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"page-header-title\">\r\n\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 270, "\"", 311, 1);
#nullable restore
#line 14 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\ClassStds\Index.cshtml"
WriteAttributeValue("", 277, Url.Content("~/ClassStds/Create"), 277, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""pull-right btn btn-info"">Create New</a>
                <h4 class=""page-title"">Classes</h4>
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
                                                        <p style=""font-size:11px;margin-left:10px;"">
                                                            Note: Create class in the order yo");
            WriteLiteral(@"u wants it to appear in the App.
                                                        </p>

                                                        <table class=""table table-striped"">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                        Class Name
                                                                    </th>
                                                                    <th>Modify</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
");
#nullable restore
#line 51 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\ClassStds\Index.cshtml"
                                                                 foreach (var item in Model)
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    <tr>\r\n                                                                        <td>\r\n                                                                            ");
#nullable restore
#line 55 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\ClassStds\Index.cshtml"
                                                                       Write(Html.DisplayFor(modelItem => item.ClassName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                                        </td>\r\n                                                                        <td>\r\n                                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a209edbc0f73233101520fb20e01bea7657f4747635", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\ClassStds\Index.cshtml"
                                                                                                   WriteLiteral(item.ClassId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n\r\n                                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a209edbc0f73233101520fb20e01bea7657f4749913", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\ClassStds\Index.cshtml"
                                                                                                     WriteLiteral(item.ClassId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                                        </td>\r\n                                                                    </tr>\r\n");
#nullable restore
#line 63 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\ClassStds\Index.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            </tbody>
                                                        </table>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CBSBahrainMVC.Models.ClassStd>> Html { get; private set; }
    }
}
#pragma warning restore 1591
