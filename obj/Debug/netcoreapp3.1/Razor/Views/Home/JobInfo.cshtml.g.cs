#pragma checksum "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2197a85c51e438067cb4f3b765d3a99c836caf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_JobInfo), @"mvc.1.0.view", @"/Views/Home/JobInfo.cshtml")]
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
#line 1 "D:\Users\bsi50130\Downloads\Job Vacation\Views\_ViewImports.cshtml"
using Job_Vacation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\bsi50130\Downloads\Job Vacation\Views\_ViewImports.cshtml"
using Job_Vacation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2197a85c51e438067cb4f3b765d3a99c836caf0", @"/Views/Home/JobInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27d6295a4faf2c6303394bd130f4944ddcf57f5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_JobInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
  
    var y = ViewBag.sub;
    var x = ViewBag.job;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
Write(x.title);

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
            ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
Write(x.description);

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
                  ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
Write(x.requirement);

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
                  ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
Write(x.informations);

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
                   ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
Write(x.flyer);

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
            ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
Write(x.stardate);

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
               ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
Write(x.enddate);

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
              ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input id=\"1\"");
            BeginWriteAttribute("value", " value=\"", 202, "\"", 212, 1);
#nullable restore
#line 11 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
WriteAttributeValue("", 210, y, 210, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>\r\n    <input id=\"2\"");
            BeginWriteAttribute("value", " value=\"", 240, "\"", 253, 1);
#nullable restore
#line 12 "D:\Users\bsi50130\Downloads\Job Vacation\Views\Home\JobInfo.cshtml"
WriteAttributeValue("", 248, x.id, 248, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>\r\n    <button onclick=takeData(this)>Take Job</button>\r\n");
            WriteLiteral(@"
<script type=""text/javascript"">
function takeData(btn)
{
var id = document.getElementById(1).value;
var idjob = document.getElementById(2).value;
    if(id != 1)
    {
        window.location.href='/Home/TakeJob?idjob='+idjob+'&idseeker='+id;
    }
    else
    {
        window.location.href='/Home/Fail'
    }
}
</script>");
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