#pragma checksum "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Applicant\Data.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f5cf8afba3ac74241fa0a565137d756bc7fa341"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Applicant_Data), @"mvc.1.0.view", @"/Views/Applicant/Data.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f5cf8afba3ac74241fa0a565137d756bc7fa341", @"/Views/Applicant/Data.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"390e6b011c80c8aacfb8cb7c82a5633b478e25dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Applicant_Data : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Applicant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNew", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Users\bsi50130\Downloads\FinalProject-1.1.0\FinalProject-1.0.0\Views\Applicant\Data.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
  .upload-btn-wrapper {
  position: relative;
  overflow: hidden;
  display: inline-block;
}

.btnx {
  border: 2px solid gray;
  color: gray;
  background-color: white;
  padding: 8px 20px;
  border-radius: 8px;
  font-size: 10px;
  font-weight: bold;
}

.upload-btn-wrapper input[type=file] {
  font-size: 20px;
  position: absolute;
  left: 0;
  top: 0;
  opacity: 0;
}
</style>

<!DOCTYPE html>
<html>
<title></title>
<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
<link rel=""stylesheet"" href=""https://www.w3schools.com/w3css/4/w3.css"">
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f5cf8afba3ac74241fa0a565137d756bc7fa3416248", async() => {
                WriteLiteral(@"

<div class=""container"">
  <div class=""row"">
    <div class=""col-md-12"">
      <div class=""text-center"">
        <h2><b>Employee Information Form</b></h2>
        <p>Be Careful with Sensitive Data Information and Privacy</p>
      </div>
    </div>
  </div>
</div>
<br>

<div class=""w3-sidebar w3-bar-block w3-black w3-card"" style=""width:130px; height: 275px"">
  <h5 class=""w3-bar-item"">Biodata</h5>
  <button class=""w3-bar-item w3-button tablink"" onclick=""openLink(event, 'Fade')"">Profile</button>
</div>

");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f5cf8afba3ac74241fa0a565137d756bc7fa3417029", async() => {
                    WriteLiteral("\n<div class=\"container\">\n  <div class=\"row\">\n    <div class=\"col-md-2\"></div>\n    <div class=\"col-md-6\">\n    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f5cf8afba3ac74241fa0a565137d756bc7fa3417413", async() => {
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
                    WriteLiteral("\n    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f5cf8afba3ac74241fa0a565137d756bc7fa3419034", async() => {
                        WriteLiteral("Save & Add New");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
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
                    WriteLiteral(@"
    <button type=""button"" class=""btn btn-primary"" onclick=""window.location.href ='/Applicant'"">Cancel</button>
    </div>
  </div>
</div>
<br>
<br>

<div style=""margin-left:170px"">
  <div class=""w3-padding""><b>Fill this form completely and correct</b></div>

  <div id=""Fade"" class=""w3-container city w3-animate-left"" style=""display:none"">
    <h2>Profile</h2>
    <div class=""row"">
      <div class=""col"">
        <div id=""1"">
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <img src=""/images/paper.svg"" style=""width: 120px; height: 150px;"">
        </div>
        <canvas style=""width: 250px; height: 300px"" id=""pdfViewer""></canvas>
      </div>
      <div class=""col"">
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <img id=""imgPreview"" alt=""Preview Image"" src=""/images/img.svg"" style=""width: 120px; height: 180px;"">
      </div>
    </div>
    <br>
    
    <div class=""row"">
    <div class=""col"">
    <div class=""upload-btn-wrapper"">
    <bu");
                    WriteLiteral(@"tton class=""btnx"">Upload your CV</button>
    <input type=""file"" id=""myPdf"" name=""cv"">
    </div>
    </div>
    <div class=""col"">
    <div class=""upload-btn-wrapper"">
    <button class=""btnx"">Upload your Photo</button>
    <input type=""file"" name=""photo"" id=""photo"" onchange=""showImagePreview(this)"">
    </div>
    </div>
    </div>
    </div>
    <br>
    <br>

    <div class=""row"">
      <div class=""col"">
        <label>Full Name</label>
        <input class=""form-control"" placeholder=""Name"" id=""name"" name=""name"" required>
      </div>
      <div class=""col"">
        <label>Email</label>
        <input class=""form-control"" placeholder=""Email"" id=""email"" name=""email"" required>
      </div>
    </div>
    <br>
    <div class=""row"">
      <div class=""col"">
        <label>Phone Number</label>
        <input class=""form-control"" placeholder=""Phone"" id=""phone"" name=""phone"" required>
      </div>
      <div class=""col"">
        <br>
        <label>Gender</label>
        <br>
        <div class=""form-check form-che");
                    WriteLiteral(@"ck-inline"">
        <input class=""form-check-input"" type=""radio"" name=""gender"" id=""gender1"" value=""Male"">
        <label class=""form-check-label"" for=""gender1"">Male</label>
        </div>
        <div class=""form-check form-check-inline"">
        <input class=""form-check-input"" type=""radio"" name=""gender"" id=""gender2"" value=""Female"">
        <label class=""form-check-label"" for=""gender2"">Female</label>
        </div>
      </div>
    </div>
    <br>
    <div class=""row"">
      <div class=""col"">
        <label>Bhirtdate</label>
        <input class=""form-control"" type=""date"" placeholder=""date"" id=""date"" name=""date"" required>
      </div>
      <div class=""col"">
        <label>Bhirtplace</label>
        <input class=""form-control"" placeholder=""Place"" id=""place"" name=""place"" required>
      </div>
    </div>
    <div class=""row"">
        <div class=""col"">
        <br>
        <label>Address</label>
        <input class=""form-control"" placeholder=""Address"" id=""address"" name=""address"" required>
        </div>
      ");
                    WriteLiteral("  <div class=\"col\">\n        <br>\n        <label>Position</label>\n        <input class=\"form-control\" placeholder=\"Position\" id=\"posisi\" name=\"posisi\" required>\n        </div>\n    </div>\n  </div>\n</div>\n<br>\n");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

<script src=""https://code.jquery.com/jquery-3.4.1.slim.min.js"" integrity=""sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n"" crossorigin=""anonymous""></script>
<script src=""https://code.jquery.com/jquery-3.1.1.min.js""></script>
<script src=""https://code.jquery.com/jquery-3.1.1.slim.min.js""></script>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js""></script> 
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js""></script>
<script src=""https://mozilla.github.io/pdf.js/build/pdf.js""></script>


<script type=""text/javascript"" src=""http://code.jquery.com/jquery-1.8.2.js""></script>
  <script type=""text/javascript"">
  function showImagePreview(input) {
  if (input.files && input.files[0]) {
  var filerdr = new FileReader();
  filerdr.onload = function (e) {
  $('#imgPreview').attr('src', e.target.result);
  }
  filerdr.readAsDataURL(input.files[0]);
  }
  }
</script>

<script>
function openLink(evt, animName) {
  var i, x, tablinks;
  x =");
                WriteLiteral(@" document.getElementsByClassName(""city"");
  for (i = 0; i < x.length; i++) {
    x[i].style.display = ""none"";
  }
  tablinks = document.getElementsByClassName(""tablink"");
  for (i = 0; i < x.length; i++) {
    tablinks[i].className = tablinks[i].className.replace("" w3-red"", """");
  }
  document.getElementById(animName).style.display = ""block"";
  evt.currentTarget.className += "" w3-red"";
}
</script>
   
<script>
  // Loaded via <script> tag, create shortcut to access PDF.js exports.
var pdfjsLib = window['pdfjs-dist/build/pdf'];
// The workerSrc property shall be specified.
pdfjsLib.GlobalWorkerOptions.workerSrc = 'https://mozilla.github.io/pdf.js/build/pdf.worker.js';

$(""#myPdf"").on(""change"", function(e){
  $(""#1"").remove();
	var file = e.target.files[0]
	if(file.type == ""application/pdf""){
		var fileReader = new FileReader();  
		fileReader.onload = function() {
			var pdfData = new Uint8Array(this.result);
			// Using DocumentInitParameters object to load binary data.
			var loadingTask = pdfjsLib.getDocume");
                WriteLiteral(@"nt({data: pdfData});
			loadingTask.promise.then(function(pdf) {
			  console.log('PDF loaded');
			  
			  // Fetch the first page
			  var pageNumber = 1;
			  pdf.getPage(pageNumber).then(function(page) {
				console.log('Page loaded');
				
				var scale = 1.5;
				var viewport = page.getViewport({scale: scale});

				// Prepare canvas using PDF page dimensions
				var canvas = $(""#pdfViewer"")[0];
				var context = canvas.getContext('2d');
				canvas.height = viewport.height;
				canvas.width = viewport.width;

				// Render PDF page into canvas context
				var renderContext = {
				  canvasContext: context,
				  viewport: viewport
				};
				var renderTask = page.render(renderContext);
				renderTask.promise.then(function () {
				  console.log('Page rendered');
				});
			  });
			}, function (reason) {
			  // PDF loading error
			  console.error(reason);
			});
		};
		fileReader.readAsArrayBuffer(file);
	}
});
</script>
");
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
            WriteLiteral("\n</html> \n");
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