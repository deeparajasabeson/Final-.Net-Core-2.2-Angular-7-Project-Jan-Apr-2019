#pragma checksum "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "098110651c1a5bbf6c65ed6d203ac01d6ed61543"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Category/Edit.cshtml", typeof(AspNetCore.Areas_Admin_Views_Category_Edit))]
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
#line 1 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using WebUI;

#line default
#line hidden
#line 2 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using WebUI.Models;

#line default
#line hidden
#line 3 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using DomainModels.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"098110651c1a5bbf6c65ed6d203ac01d6ed61543", @"/Areas/Admin/Views/Category/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9dd30ea022aa67d079c9f4103eea67dd09b3b9ee", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Category_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DomainModels.Entities.Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml"
  
    ViewBag.Title = "Edit";

#line default
#line hidden
            BeginContext(77, 25, true);
            WriteLiteral("\r\n<h2>Edit</h2>\r\n<hr />\r\n");
            EndContext();
#line 9 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(137, 23, false);
#line 11 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(164, 45, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n\r\n        ");
            EndContext();
            BeginContext(210, 64, false);
#line 15 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(274, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(285, 41, false);
#line 16 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml"
   Write(Html.HiddenFor(model => model.CategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(326, 50, true);
            WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(377, 93, false);
#line 19 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml"
       Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(470, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(526, 93, false);
#line 21 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml"
           Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(619, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(638, 82, false);
#line 22 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(720, 253, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 32 "C:\Deepa\Learning\AspNetCore\DotNetTricks\FinalProjectCoreAngular\WebUI\Areas\Admin\Views\Category\Edit.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Identity.UserManager<User> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DomainModels.Entities.Category> Html { get; private set; }
    }
}
#pragma warning restore 1591
