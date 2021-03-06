#pragma checksum "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e4755aee4c672bb44c7a3ebbfd2a3a26b21c9a4"
// <auto-generated/>
#pragma warning disable 1591
namespace Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\_Imports.razor"
using Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\_Imports.razor"
using Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
using Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
using Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
using Blazor.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/orders")]
    public partial class OrdersView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 10 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
 if (orders == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 15 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
}
else if (!orders.Any())
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>No orders items exist. Please make some.</em></p>");
#nullable restore
#line 21 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "table");
            __builder.AddAttribute(3, "class", "table");
            __builder.AddMarkupContent(4, @"<thead class=""thead-dark""><tr><th scope=""col"">Order Id</th>
            <th scope=""col"">Order price</th>
            <th scope=""col"">Username</th>
            <th scope=""col"">Date of order</th>
            <th scope=""col"">Recipe Id</th></tr></thead>
        ");
            __builder.OpenElement(5, "tbody");
#nullable restore
#line 36 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
         foreach (var order in ordersToShow)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "tr");
            __builder.OpenElement(7, "td");
            __builder.AddContent(8, 
#nullable restore
#line 39 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
                     order.orderId

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\n                ");
            __builder.OpenElement(10, "td");
            __builder.AddContent(11, 
#nullable restore
#line 40 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
                     order.orderPrice

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(12, " DKK");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\n                ");
            __builder.OpenElement(14, "td");
            __builder.AddContent(15, 
#nullable restore
#line 41 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
                     order.username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\n                ");
            __builder.OpenElement(17, "td");
            __builder.AddContent(18, 
#nullable restore
#line 42 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
                     order.dateTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\n                ");
            __builder.OpenElement(20, "td");
            __builder.AddContent(21, 
#nullable restore
#line 43 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
                     order.recipeId

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 45 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 48 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\OrdersView.razor"
       
    private IList<Order> orders;
    private IList<Order> ordersToShow;

    protected override async Task OnInitializedAsync()
    {
        orders = await OrderService.GetOrdersAsync();
        ordersToShow = orders.Where(u => u.username.Equals(CustomAuthenticationStateProvider.getUser().username)).ToList();

        base.OnInitialized();
    }

    


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IOrderService OrderService { get; set; }
    }
}
#pragma warning restore 1591
