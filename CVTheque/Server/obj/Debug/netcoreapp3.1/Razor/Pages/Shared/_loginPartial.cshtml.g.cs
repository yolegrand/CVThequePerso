#pragma checksum "C:\Users\jevra\Desktop\CVTheque\CVTheque\Server\Pages\Shared\_loginPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d04956abdf5869f99b16247551cccf6fbcf5c09d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Shared__loginPartial), @"mvc.1.0.view", @"/Pages/Shared/_loginPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d04956abdf5869f99b16247551cccf6fbcf5c09d", @"/Pages/Shared/_loginPartial.cshtml")]
    public class Pages_Shared__loginPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Server\Pages\Shared\_loginPartial.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul class=\"navbar-nav\">\r\n        <li>\r\n            <span class=\"navbar-text\">\r\n                hello, ");
#nullable restore
#line 6 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Server\Pages\Shared\_loginPartial.cshtml"
                  Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </span>
            &nbsp;
            <a onclick=""document.getElementById('logout_form').submit();"" style=""cursor: pointer"">Logout</a>
        </li>
    </ul>
    <form asp-controller=""Login"" asp-action=""Logout"" method=""post"" id=""logout_form""></form>
");
#nullable restore
#line 13 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Server\Pages\Shared\_loginPartial.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul class=\"navbar-nav\">\r\n        <li><a asp-controller=\"Login\" asp-action=\"Login\">Login</a></li>\r\n    </ul>\r\n");
#nullable restore
#line 19 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Server\Pages\Shared\_loginPartial.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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