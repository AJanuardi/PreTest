#pragma checksum "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "643d2aa06054ac3bb47e75fb645cac9d23757a67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Edit), @"mvc.1.0.view", @"/Views/Employee/Edit.cshtml")]
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
#line 1 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\_ViewImports.cshtml"
using HR_App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\_ViewImports.cshtml"
using HR_App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"643d2aa06054ac3bb47e75fb645cac9d23757a67", @"/Views/Employee/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"390e6b011c80c8aacfb8cb7c82a5633b478e25dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Editor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Employee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
  
    var x = ViewBag.emp;
    foreach(var i in x)
    {

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "643d2aa06054ac3bb47e75fb645cac9d23757a675551", async() => {
                WriteLiteral("\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "643d2aa06054ac3bb47e75fb645cac9d23757a675807", async() => {
                    WriteLiteral("Save");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n<button type=\"button\" class=\"btn btn-primary\"");
                BeginWriteAttribute("onclick", " onclick=\"", 257, "\"", 318, 4);
                WriteAttributeValue("", 267, "window.location.href", 267, 20, true);
                WriteAttributeValue(" ", 287, "=\'/Employee/Information/", 288, 25, true);
#nullable restore
#line 7 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 312, i.id, 312, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 317, "\'", 317, 1, true);
                EndWriteAttribute();
                WriteLiteral(@">Cancel</button>
<br>
<br>

<div class=""tab"">
  <button class=""tablinks"" onclick=""openTab(event, 'Profile')"" id=""defaultopen"">Profile</button>
  <button class=""tablinks"" onclick=""openTab(event, 'Occupation')"">Occupation</button>
  <button class=""tablinks"" onclick=""openTab(event, 'Address')"">Address</button>
  <button class=""tablinks"" onclick=""openTab(event, 'Emergency')"">Emergency</button>
  <button class=""tablinks"" onclick=""openTab(event, 'Aggrements')"">Aggrements</button>
</div>



<div id=""Profile"" class=""tabcontent"">
  <input placeholder=""Id"" id=""id"" name=""id""");
                BeginWriteAttribute("value", " value=\"", 889, "\"", 902, 1);
#nullable restore
#line 22 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 897, i.id, 897, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 903, "\"", 919, 1);
#nullable restore
#line 22 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 911, i.photo, 911, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input type=\"file\" id=\"photo\" name=\"photo\" onchange=\"showImagePreview(this)\">\n  <img id=\"imgPreview\" alt=\"Preview Image\" style=\"width: 200px; height: 300px;\">\n  <img");
                BeginWriteAttribute("src", " src=\"", 1098, "\"", 1112, 1);
#nullable restore
#line 25 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1104, i.photo, 1104, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 200px; height: 300px;\">\n  <input placeholder=\"Name\" id=\"name\" name=\"name\"");
                BeginWriteAttribute("value", " value=\"", 1201, "\"", 1216, 1);
#nullable restore
#line 26 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1209, i.name, 1209, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"Email\" id=\"email\" name=\"email\"");
                BeginWriteAttribute("value", " value=\"", 1280, "\"", 1296, 1);
#nullable restore
#line 27 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1288, i.email, 1288, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"Phone\" id=\"phone\" name=\"phone\"");
                BeginWriteAttribute("value", " value=\"", 1360, "\"", 1376, 1);
#nullable restore
#line 28 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1368, i.phone, 1368, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"Gender\" id=\"gender\" name=\"gender\"");
                BeginWriteAttribute("value", " value=\"", 1443, "\"", 1460, 1);
#nullable restore
#line 29 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1451, i.gender, 1451, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"date\" id=\"date\" name=\"date\"");
                BeginWriteAttribute("value", " value=\"", 1521, "\"", 1541, 1);
#nullable restore
#line 30 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1529, i.bhirtdate, 1529, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"place\" id=\"place\" name=\"place\"");
                BeginWriteAttribute("value", " value=\"", 1605, "\"", 1626, 1);
#nullable restore
#line 31 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1613, i.bhirtplace, 1613, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n</div>\n\n<div id=\"Occupation\" class=\"tabcontent\">\n  <input placeholder=\"Position\" id=\"position\" name=\"position\"");
                BeginWriteAttribute("value", " value=\"", 1748, "\"", 1767, 1);
#nullable restore
#line 35 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1756, i.position, 1756, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"Department\" id=\"department\" name=\"department\"");
                BeginWriteAttribute("value", " value=\"", 1846, "\"", 1867, 1);
#nullable restore
#line 36 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1854, i.department, 1854, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n</div>\n\n<div id=\"Address\" class=\"tabcontent\">\n  <input placeholder=\"Address\" id=\"address\" name=\"address\"");
                BeginWriteAttribute("value", " value=\"", 1983, "\"", 2001, 1);
#nullable restore
#line 40 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 1991, i.address, 1991, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n</div>\n\n<div id=\"Emergency\" class=\"tabcontent\">\n  <input placeholder=\"Person Name\" id=\"nameugd1\" name=\"nameugd1\"");
                BeginWriteAttribute("value", " value=\"", 2125, "\"", 2144, 1);
#nullable restore
#line 44 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 2133, i.nameugd1, 2133, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"Emergency 1\" id=\"emergency1\" name=\"emergency1\"");
                BeginWriteAttribute("value", " value=\"", 2224, "\"", 2245, 1);
#nullable restore
#line 45 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 2232, i.emergency1, 2232, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"Person Name\" id=\"nameugd2\" name=\"nameugd2\"");
                BeginWriteAttribute("value", " value=\"", 2321, "\"", 2340, 1);
#nullable restore
#line 46 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 2329, i.nameugd2, 2329, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"Emergency 2\" id=\"emergency2\" name=\"emergency2\"");
                BeginWriteAttribute("value", " value=\"", 2420, "\"", 2441, 1);
#nullable restore
#line 47 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 2428, i.emergency2, 2428, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"Person Name\" id=\"nameugd3\" name=\"nameugd3\"");
                BeginWriteAttribute("value", " value=\"", 2517, "\"", 2536, 1);
#nullable restore
#line 48 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 2525, i.nameugd3, 2525, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input placeholder=\"Emergency 3\" id=\"emergency3\" name=\"emergency3\"");
                BeginWriteAttribute("value", " value=\"", 2616, "\"", 2637, 1);
#nullable restore
#line 49 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 2624, i.emergency3, 2624, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n</div>\n\n<div id=\"Aggrements\" class=\"tabcontent\">\n  <input placeholder=\"Status\" id=\"status\" name=\"status\"");
                BeginWriteAttribute("value", " value=\"", 2753, "\"", 2770, 1);
#nullable restore
#line 53 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 2761, i.status, 2761, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n  <input type=\"datetime\" placeholder=\"Contract\" id=\"contract\" name=\"contract\"");
                BeginWriteAttribute("value", " value=\"", 2859, "\"", 2878, 1);
#nullable restore
#line 54 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
WriteAttributeValue("", 2867, i.contract, 2867, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\n</div>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 57 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Employee\Edit.cshtml"
    }

#line default
#line hidden
#nullable disable
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