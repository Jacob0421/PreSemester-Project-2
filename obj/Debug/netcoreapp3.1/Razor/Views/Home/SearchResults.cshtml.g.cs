#pragma checksum "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcaf4d037c4b6be952b7cf8a9518024d2018eb40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SearchResults), @"mvc.1.0.view", @"/Views/Home/SearchResults.cshtml")]
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
#line 1 "D:\Senior Project\Pre-Semester-Project2\Views\_ViewImports.cshtml"
using PreSemester_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Senior Project\Pre-Semester-Project2\Views\_ViewImports.cshtml"
using PreSemester_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcaf4d037c4b6be952b7cf8a9518024d2018eb40", @"/Views/Home/SearchResults.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"009175c5b324e34369f87ce36a474e7e2b35ca78", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SearchResults : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PreSemester_Project.Models.Volunteer>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
  
    ViewData["Title"] = "SearchResults";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>SearchResults</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.StreetAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 38 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.ZipCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 41 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayNameFor(model => model.ApprovalStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 47 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 59 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 62 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 65 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.StreetAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 68 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 71 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 74 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.ZipCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 77 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.DisplayFor(modelItem => item.ApprovalStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 80 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = item.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 81 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id = item.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 82 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id = item.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 85 "D:\Senior Project\Pre-Semester-Project2\Views\Home\SearchResults.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PreSemester_Project.Models.Volunteer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
