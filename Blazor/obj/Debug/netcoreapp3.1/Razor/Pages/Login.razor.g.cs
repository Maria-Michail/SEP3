#pragma checksum "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5df608c152ba3948c0dcd5fb091b20c8e221d31b"
// <auto-generated/>
#pragma warning disable 1591
namespace LoginComponent
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/wojtek/RiderProjects/SEP3/Blazor/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/wojtek/RiderProjects/SEP3/Blazor/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/wojtek/RiderProjects/SEP3/Blazor/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/wojtek/RiderProjects/SEP3/Blazor/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/wojtek/RiderProjects/SEP3/Blazor/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/wojtek/RiderProjects/SEP3/Blazor/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/wojtek/RiderProjects/SEP3/Blazor/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/wojtek/RiderProjects/SEP3/Blazor/_Imports.razor"
using Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/wojtek/RiderProjects/SEP3/Blazor/_Imports.razor"
using Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Login.razor"
using Blazor.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n        ");
                __builder2.OpenElement(3, "div");
                __builder2.AddAttribute(4, "class", "form-group m-2");
                __builder2.AddMarkupContent(5, "\r\n            ");
                __builder2.OpenElement(6, "input");
                __builder2.AddAttribute(7, "class", "form-control");
                __builder2.AddAttribute(8, "placeholder", "Username");
                __builder2.AddAttribute(9, "aria-label", "Username");
                __builder2.AddAttribute(10, "aria-describedby", "basic-addon1");
                __builder2.AddAttribute(11, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 10 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Login.razor"
                                                                                                                                  username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(12, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => username = __value, username));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(13, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(14, "\r\n        ");
                __builder2.OpenElement(15, "div");
                __builder2.AddAttribute(16, "class", "form-group m-2");
                __builder2.AddMarkupContent(17, "\r\n           ");
                __builder2.OpenElement(18, "input");
                __builder2.AddAttribute(19, "class", "form-control");
                __builder2.AddAttribute(20, "type", "password");
                __builder2.AddAttribute(21, "placeholder", "Password");
                __builder2.AddAttribute(22, "aria-label", "Password");
                __builder2.AddAttribute(23, "aria-describedby", "basic-addon1");
                __builder2.AddAttribute(24, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 13 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Login.razor"
                                                                                                                                                 password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(25, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => password = __value, password));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(26, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(27, "\r\n        ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "style", "color:red");
                __builder2.AddContent(30, 
#nullable restore
#line 15 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Login.razor"
                                errorMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, " \r\n        ");
                __builder2.OpenElement(32, "button");
                __builder2.AddAttribute(33, "type", "button");
                __builder2.AddAttribute(34, "class", "btn btn-light");
                __builder2.OpenElement(35, "a");
                __builder2.AddAttribute(36, "href", "");
                __builder2.AddAttribute(37, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Login.razor"
                                                                         PerformLogin

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(38, "Login");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\r\n    ");
            }
            ));
            __builder.AddAttribute(40, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(41, "\r\n        ");
                __builder2.OpenElement(42, "button");
                __builder2.AddAttribute(43, "type", "button");
                __builder2.AddAttribute(44, "class", "btn btn-light");
                __builder2.OpenElement(45, "a");
                __builder2.AddAttribute(46, "href", "");
                __builder2.AddAttribute(47, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Login.razor"
                                                                         PerformLogout

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(48, "Log out");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(49, "\r\n        \r\n\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Login.razor"
       
    private string username;
    private string password;
    private string errorMessage;

    public async Task PerformLogin()
    {
        errorMessage = "";
        try
        {
            Console.WriteLine("Trying login");
            await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(username, password);
            username = "";
            password = "";
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            Console.WriteLine("login failed");
            errorMessage = e.Message;
        }
    }

    public async Task PerformLogout()
    {
        errorMessage = "";
        username = "";
        password = "";
        try
        {
            await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).Logout();
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
