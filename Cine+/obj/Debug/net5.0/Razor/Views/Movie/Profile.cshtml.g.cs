#pragma checksum "C:\Users\Jose Alejandro\Documents\IS\Cine+\Cine+\Views\Movie\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71964c3d34812949b7f796474a86911da5c79ddb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie_Profile), @"mvc.1.0.view", @"/Views/Movie/Profile.cshtml")]
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
#line 1 "C:\Users\Jose Alejandro\Documents\IS\Cine+\Cine+\Views\_ViewImports.cshtml"
using Cine_;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jose Alejandro\Documents\IS\Cine+\Cine+\Views\_ViewImports.cshtml"
using Cine_.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Jose Alejandro\Documents\IS\Cine+\Cine+\Views\_ViewImports.cshtml"
using Cine_.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Jose Alejandro\Documents\IS\Cine+\Cine+\Views\_ViewImports.cshtml"
using Cine_.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71964c3d34812949b7f796474a86911da5c79ddb", @"/Views/Movie/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8196eac22f44d534c3ea0d7cca19e5662f959d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Movie_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Movie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"jumbotron margin\">\r\n    <h1 class=\"display-3\">");
#nullable restore
#line 3 "C:\Users\Jose Alejandro\Documents\IS\Cine+\Cine+\Views\Movie\Profile.cshtml"
                     Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p class=\"lead\">");
#nullable restore
#line 4 "C:\Users\Jose Alejandro\Documents\IS\Cine+\Cine+\Views\Movie\Profile.cshtml"
               Write(Model.GenreName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <hr class=\"my-4\">\\\r\n    <p>");
#nullable restore
#line 6 "C:\Users\Jose Alejandro\Documents\IS\Cine+\Cine+\Views\Movie\Profile.cshtml"
  Write(Model.Synopsis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Movie> Html { get; private set; }
    }
}
#pragma warning restore 1591
