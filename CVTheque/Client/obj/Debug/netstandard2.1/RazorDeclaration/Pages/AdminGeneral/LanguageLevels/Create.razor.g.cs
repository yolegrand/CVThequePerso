#pragma checksum "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\Pages\AdminGeneral\LanguageLevels\Create.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e5f381b1a7e24a54fc51278ebab2e3067cd9daf"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CVTheque.Client.Pages.AdminGeneral.LanguageLevels
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
#nullable restore
#line 4 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\Pages\AdminGeneral\LanguageLevels\Create.razor"
using Services.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\Pages\AdminGeneral\LanguageLevels\Create.razor"
using System.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\Pages\AdminGeneral\LanguageLevels\Create.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AdminGeneral/LanguageLevels/create")]
    public partial class Create : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 16 "C:\Users\jevra\Desktop\CVTheque\CVTheque\Client\Pages\AdminGeneral\LanguageLevels\Create.razor"
        LanguageLevelApi lev = new LanguageLevelApi();
            async Task CreateLevel()
            {
                var response = await _levelRepo.Post(lev);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string content = await response.Content.ReadAsStringAsync();
                        lev = JsonConvert.DeserializeObject<LanguageLevelApi>(content);
                        break;
                }
                //await http.PostAsJsonAsync("LevelApi", lev);
                uriHelper.NavigateTo("AdminGeneral/LanguageLevels");
            } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRepository<int, LanguageLevelApi> _levelRepo { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uriHelper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
