#pragma checksum "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1a9d438810507b5cc8a60cf698f0e9e1f793aee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SongBanks_Delete), @"mvc.1.0.view", @"/Views/SongBanks/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1a9d438810507b5cc8a60cf698f0e9e1f793aee", @"/Views/SongBanks/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9a2d97fd36a1dfc4bc3cf5aabe2db16e3a82f5", @"/Views/_ViewImports.cshtml")]
    public class Views_SongBanks_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CBSBahrainMVC.Models.SongBank>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
 

<h3>Are you sure you want to delete this?</h3>
 


<div class=""content-page"">
    <!-- Start content -->
    <div class=""content"">

        
            <div class=""page-header-title"">

                <div class=""pull-right"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1a9d438810507b5cc8a60cf698f0e9e1f793aee5215", async() => {
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d1a9d438810507b5cc8a60cf698f0e9e1f793aee5497", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 22 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.SongId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" />  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1a9d438810507b5cc8a60cf698f0e9e1f793aee7276", async() => {
                    WriteLiteral("Back ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>

                <h4 class=""page-title"">Song</h4>
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
#line 49 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml"
                                                        Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                                        <br />\r\n                                                        <b>Category:</b> ");
#nullable restore
#line 51 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml"
                                                                    Write(Model.Category.Category1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        <br />\r\n                                                        <b>Youtube URL</b> : ");
#nullable restore
#line 53 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml"
                                                                        Write(Html.DisplayFor(model => model.YoutubeUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        <br />\r\n");
#nullable restore
#line 55 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml"
                                                         try
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <iframe width=\"560\" height=\"315\"");
            BeginWriteAttribute("src", " src=\"", 2140, "\"", 2241, 2);
            WriteAttributeValue("", 2146, "https://www.youtube.com/embed/", 2146, 30, true);
#nullable restore
#line 57 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml"
WriteAttributeValue("", 2176, Model.YoutubeUrl.Replace("https://www.youtube.com/watch?v=", ""), 2176, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" frameborder=\"0\" allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>\r\n");
#nullable restore
#line 58 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml"
                                                        }
                                                        catch { }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                        <br />
                                                        <br />

                                                        <b>Lyrics</b><br />
                                                        ");
#nullable restore
#line 64 "E:\Web\CBSBahrainNew\CBSBahrainMVC\Views\SongBanks\Delete.cshtml"
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
