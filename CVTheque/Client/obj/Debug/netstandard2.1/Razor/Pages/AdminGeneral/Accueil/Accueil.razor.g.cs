#pragma checksum "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\Pages\AdminGeneral\Accueil\Accueil.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b3431cfcc04bb8bfb3c8629b28af348a39acb71"
// <auto-generated/>
#pragma warning disable 1591
namespace CVTheque.Client.Pages.AdminGeneral.Accueil
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Client.Shared.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Client.Shared.Bulma;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Client.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Client.Services.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Client.Services.JS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\_Imports.razor"
using CVTheque.Client.Pages;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AdminGeneral/Accueil")]
    public partial class Accueil : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<CVTheque.Client.Shared.NavBarTop>(0);
            __builder.CloseComponent();
            __builder.AddMarkupContent(1, "\n");
            __builder.AddMarkupContent(2, "<h3>Accueil</h3>\n\n\n");
            __builder.AddMarkupContent(3, "<a class=\"btn btn-success\" href=\"AdminGeneral/Levels\">Levels</a>\n");
            __builder.AddMarkupContent(4, "<a class=\"btn btn-success\" href=\"AdminGeneral/LanguageLevels\">Language Levels</a>");
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
