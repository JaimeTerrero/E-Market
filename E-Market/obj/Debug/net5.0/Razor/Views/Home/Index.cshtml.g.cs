#pragma checksum "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c8e6c07d5f74bbbb402cb296202e200ba5191e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\_ViewImports.cshtml"
using E_Market;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\_ViewImports.cshtml"
using E_Market.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
using EMarket.Core.Application.ViewModels.Articles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
using EMarket.Core.Application.ViewModels.Categories;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c8e6c07d5f74bbbb402cb296202e200ba5191e5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50c54cf008c447c2d0a5d6d66ca1cd50ba0ed456", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ArticleViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">

    <div class=""row"">
        <div class=""col-3"">
            <div class=""card shadow-sm"">
                <div class=""card-header bg-black text-light"">
                    <h4>Filtros</h4>
                </div>
                <div class=""card-body"">
                    <h4>Categorías</h4>

                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c8e6c07d5f74bbbb402cb296202e200ba5191e55277", async() => {
                WriteLiteral(@"
                        
                        <div class=""mb-3"">
                            <div class=""form-check"">
                                <input class=""form-check-input"" value=""null"" type=""radio"" name=""CategoryId"" id=""category-all""/>
                                <label class=""form-check-label"" for=""category-all"">Todas</label>
                            </div>
                        </div>

");
#nullable restore
#line 28 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                         foreach (CategoryViewModel category in ViewBag.Categories)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"mb-3\">\r\n                                <div class=\"form-check\">\r\n                                    <input class=\"form-check-input\"");
                BeginWriteAttribute("value", " value=\"", 1312, "\"", 1332, 1);
#nullable restore
#line 32 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
WriteAttributeValue("", 1320, category.Id, 1320, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"radio\" name=\"CategoryId\"");
                BeginWriteAttribute("id", " id=\"", 1364, "\"", 1390, 2);
                WriteAttributeValue("", 1369, "category-", 1369, 9, true);
#nullable restore
#line 32 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
WriteAttributeValue("", 1378, category.Id, 1378, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r\n                                    <label class=\"form-check-label\"");
                BeginWriteAttribute("for", " for=\"", 1462, "\"", 1489, 2);
                WriteAttributeValue("", 1468, "category-", 1468, 9, true);
#nullable restore
#line 33 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
WriteAttributeValue("", 1477, category.Id, 1477, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 33 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                                                                                           Write(category.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 36 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <button type=\"submit\" class=\"btn btn-primary\">filtrar</button>\r\n\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                   \r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-9\">\r\n            <div class=\"row\">\r\n\r\n");
#nullable restore
#line 50 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                 if(Model == null || Model.Count == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h2>No hay nada aún</h2>\r\n");
#nullable restore
#line 53 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                     foreach (ArticleViewModel item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-4\">\r\n                            <div class=\"card shadow-sm\">\r\n                                <img class=\"bd-placeholder-img card-img-top img-product-size\"");
            BeginWriteAttribute("src", " src=\"", 2349, "\"", 2369, 1);
#nullable restore
#line 60 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
WriteAttributeValue("", 2355, item.ImageUrl, 2355, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                                <div class=\"card-body\">\r\n                                    <h4>");
#nullable restore
#line 63 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    <p class=\"card-text\">");
#nullable restore
#line 64 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                                                    Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <div class=\"d-flex justify-content-between align-items-center\">\r\n                                        <span class=\"fw-bold\">");
#nullable restore
#line 66 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                                                         Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        <small class=\"fw-bold fs-6\">$");
#nullable restore
#line 67 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                                                                Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 72 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\Jaime David Terrero\OneDrive\Documentos\GitHub\E-Market\E-Market\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n\r\n    \r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ArticleViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
