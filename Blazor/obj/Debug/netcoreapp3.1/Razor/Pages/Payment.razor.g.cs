#pragma checksum "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7c6e6520cead5bedf0e79903c57a0bcf021b908"
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
#line 1 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\_Imports.razor"
using Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\_Imports.razor"
using Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
using Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
using System.Numerics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
using Blazor.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
using Database.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
using Model;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/payment")]
    public partial class Payment : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "row");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(2);
            __builder.AddAttribute(3, "class", "regForm col-7 bg-white");
            __builder.AddAttribute(4, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 17 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
                                                     bankInfo

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 17 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
                                                                               HandleValidPayment

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 17 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
                                                                                                                     HandleInvalidPayment

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "p-2 m-2");
                __builder2.AddMarkupContent(10, "<h2 class=\"title\" xmlns=\"http://www.w3.org/1999/html\">Payment</h2>\r\n            ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "p-2 m-2");
                __builder2.OpenElement(13, "div");
                __builder2.AddAttribute(14, "class", "row ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(15);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(17);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(18, "\r\n\r\n                    \r\n                    ");
                __builder2.OpenElement(19, "div");
                __builder2.AddAttribute(20, "class", "col-11 bg-white");
                __builder2.OpenElement(21, "ul");
                __builder2.AddAttribute(22, "class", "orderPageList");
                __builder2.AddAttribute(23, "data-role", "listview");
                __builder2.AddAttribute(24, "style", "list-style-type: none");
                __builder2.OpenElement(25, "li");
                __builder2.OpenElement(26, "div");
                __builder2.AddAttribute(27, "class", "form-group");
                __builder2.AddMarkupContent(28, "\r\n                                    Card holder:<br>\r\n                                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(29);
                __builder2.AddAttribute(30, "class", "regInput");
                __builder2.AddAttribute(31, "style", "width:90%");
                __builder2.AddAttribute(32, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
                                                                                               bankInfo.cardHolder

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(33, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => bankInfo.cardHolder = __value, bankInfo.cardHolder))));
                __builder2.AddAttribute(34, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => bankInfo.cardHolder));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(35, "\r\n                            ");
                __builder2.OpenElement(36, "li");
                __builder2.OpenElement(37, "div");
                __builder2.AddAttribute(38, "class", "form-group");
                __builder2.AddMarkupContent(39, "\r\n                                    Card Number:<br>\r\n                                    ");
                __Blazor.Blazor.Pages.Payment.TypeInference.CreateInputNumber_0(__builder2, 40, 41, "regInput", 42, "width:90%", 43, 
#nullable restore
#line 37 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
                                                                                                 bankInfo.cardNumber

#line default
#line hidden
#nullable disable
                , 44, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => bankInfo.cardNumber = __value, bankInfo.cardNumber)), 45, () => bankInfo.cardNumber);
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(46, "\r\n                            ");
                __builder2.OpenElement(47, "div");
                __builder2.AddAttribute(48, "class", "row");
                __builder2.OpenElement(49, "div");
                __builder2.AddAttribute(50, "class", "col-6");
                __builder2.OpenElement(51, "li");
                __builder2.OpenElement(52, "div");
                __builder2.AddAttribute(53, "class", "form-group");
                __builder2.AddMarkupContent(54, "\r\n                                            Expiry Date:<br>\r\n                                            ");
                __Blazor.Blazor.Pages.Payment.TypeInference.CreateInputDate_1(__builder2, 55, 56, "regInput", 57, "width:80%", 58, 
#nullable restore
#line 45 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
                                                                                                       expiryDate

#line default
#line hidden
#nullable disable
                , 59, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => expiryDate = __value, expiryDate)), 60, () => expiryDate);
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(61, "\r\n                                ");
                __builder2.OpenElement(62, "div");
                __builder2.AddAttribute(63, "class", "col-6");
                __builder2.OpenElement(64, "li");
                __builder2.OpenElement(65, "div");
                __builder2.AddAttribute(66, "class", "form-group");
                __builder2.AddMarkupContent(67, "\r\n                                            CVV:<br>\r\n                                            ");
                __Blazor.Blazor.Pages.Payment.TypeInference.CreateInputNumber_2(__builder2, 68, 69, "regInput", 70, "width:80%", 71, 
#nullable restore
#line 53 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
                                                                                                         cvv

#line default
#line hidden
#nullable disable
                , 72, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => cvv = __value, cvv)), 73, () => cvv);
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(74, "\r\n                            ");
                __builder2.AddMarkupContent(75, "<div class=\"row d-flex justify-content-center\"><p class=\"actions \"><button class=\"btn btn-primary order-button\" type=\"submit\">Pay Now</button></p></div>");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(76, "\r\n                    <div class=\"col-1 bg-white\"></div>");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(77, "\r\n    \r\n\r\n");
            __builder.OpenElement(78, "div");
            __builder.AddAttribute(79, "class", "col-5 bg-light");
            __builder.AddMarkupContent(80, "<div class=\"p-2 m-3\"><h3 class=\"text-center text-secondary\">Order</h3></div>\r\n    ");
            __builder.OpenElement(81, "div");
            __builder.AddAttribute(82, "class", "row");
            __builder.AddMarkupContent(83, "<div class=\"col-2\"></div>\r\n        ");
            __builder.OpenElement(84, "div");
            __builder.AddAttribute(85, "class", "col-8");
            __builder.OpenElement(86, "div");
            __builder.AddAttribute(87, "class", "row");
            __builder.OpenElement(88, "div");
            __builder.AddAttribute(89, "class", "col-8");
            __builder.OpenElement(90, "h1");
            __builder.AddAttribute(91, "class", "display-4");
            __builder.AddContent(92, 
#nullable restore
#line 86 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
                                           Recipe.recipeName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n                ");
            __builder.AddMarkupContent(94, "<div class=\"col-4\"><p>$ 400</p></div>");
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n            ");
            __builder.AddMarkupContent(96, "<div class=\"row\" style=\"margin-top: 100px\"><div class=\"col-8\"><p class=\"text-secondary\">Shipping</p></div>\r\n                        <div class=\"col-4\"><p class=\"text-secondary\">Free</p></div></div>\r\n                        <hr>\r\n                ");
            __builder.AddMarkupContent(97, "<div class=\"row\"><div class=\"col-8\"><p class=\"text-secondary\">TOTAL</p></div>\r\n                            <div class=\"col-4\"><p class=\"text-secondary\">$400</p></div></div>");
            __builder.CloseElement();
            __builder.AddMarkupContent(98, "\r\n        <div class=\"col-2\"></div>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 120 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\Payment.razor"
       


    private DateTime expiryDate;
    private int cvv;
    
    //Change those two
    private int orderId = 0;
    private double orderPrice = 0;

    private string errorMessage;

    private BankInfo bankInfo = new BankInfo();
    private Order newOrder = new Order();
    public Recipe Recipe;
    public Account currentUser;
    private IList<OrderedShopIngredients> newShopIngredients = new List<OrderedShopIngredients>();
    private IList<OrderedShopIngredients> newShopIngredientsWithoutUnchecked = new List<OrderedShopIngredients>();
    protected override async Task OnInitializedAsync()
    {
        //bankInfo = CustomAuthenticationStateProvider.getUser().bankInfo;
        Recipe = RecipeService.recipe;
        currentUser = CustomAuthenticationStateProvider.getUser();
        newShopIngredients = IngredientsService.OrderedShopIngredients;
        //filter to get only the checked ingredients
        for (int i=0; i<newShopIngredients.Count ;i++)
        {
            if (newShopIngredients[i].uncheck == true)
            {
                newShopIngredientsWithoutUnchecked.Add(newShopIngredients[i]);
            }
        }
        //end of filtering
        foreach (var order in newShopIngredientsWithoutUnchecked)
        {
            orderPrice = orderPrice + order.totalPrice;
        }
        
    }
    
    public async Task HandleValidPayment()
    {
        errorMessage = "";
        try
        {
            newOrder.orderId = orderId;
            newOrder.dateTime = DateTime.Now;
            newOrder.orderPrice = orderPrice;
            newOrder.recipeId = Recipe.recipeId;
            newOrder.username = currentUser.username;
            newOrder.OrderedShopIngredients = newShopIngredientsWithoutUnchecked;
            Console.WriteLine("Trying paying");
            await OrderService.storeOrder(newOrder);
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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IIngredientsService IngredientsService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRecipeService RecipeService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IOrderService OrderService { get; set; }
    }
}
namespace __Blazor.Blazor.Pages.Payment
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputNumber_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "style", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateInputDate_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputDate<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "style", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateInputNumber_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "style", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
