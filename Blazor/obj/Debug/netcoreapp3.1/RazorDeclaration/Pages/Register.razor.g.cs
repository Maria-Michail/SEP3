#pragma checksum "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\Pages\Register.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "401535a9fa475d85df8a3a84667e9b02cccbaab8"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\_Imports.razor"
using Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\_Imports.razor"
using Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\Pages\Register.razor"
using Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\Pages\Register.razor"
using Model;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "C:\Users\Janni\OneDrive\Skrivebord\SEP3\Blazor\Pages\Register.razor"
       

    private string username;
    private string password;
    private string email;
    private string errorMessage;
    
    private Account newAccount = new Account();
    
    
    public async Task HandleValidRegister()
    {
        errorMessage = "";
        try
        {
            Console.WriteLine("Trying register");
            await AccountService.Register(newAccount);
            username = "";
            password = "";
            email = "";
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            Console.WriteLine("Register failed");
            errorMessage = e.Message;
        }
    }
    
    public async Task HandleInvalidRegister()
    {
        Console.WriteLine("Invalid");
    }
    
    protected override async Task OnInitializedAsync()
    {
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountService AccountService { get; set; }
    }
}
#pragma warning restore 1591
