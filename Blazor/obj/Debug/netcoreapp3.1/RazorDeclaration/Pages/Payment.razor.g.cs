#pragma checksum "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Payment.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18aa45edf048874ea4049e2400c9528402f10d29"
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
#line 2 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Payment.razor"
using Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Payment.razor"
using System.Numerics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Payment.razor"
using Blazor.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Payment.razor"
using Database.Model;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/payment")]
    public partial class Payment : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 116 "/Users/wojtek/RiderProjects/SEP3/Blazor/Pages/Payment.razor"
       


    private DateTime expiryDate;
    private int cvv;

    private string errorMessage;

    private BankInfo bankInfo = new BankInfo();

    protected override async Task OnInitializedAsync()
    {
        //bankInfo = CustomAuthenticationStateProvider.getUser().bankInfo;
    }
    
    public async Task HandleValidPayment()
    {
        errorMessage = "";
        try
        {
            Console.WriteLine("Trying paying");
            //await AccountService.Payment();
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            Console.WriteLine("Payment failed");
            errorMessage = e.Message;
        }
    }

    public async Task HandleInvalidPayment()
    {
        Console.WriteLine("Invalid");
    }

    


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountService AccountService { get; set; }
    }
}
#pragma warning restore 1591
