#pragma checksum "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2ce2c8723ff5cf0949b8ab4dbaf504d62176c8f"
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
#line 2 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
using Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
using System.Numerics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
using Blazor.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
using Database.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
using Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
           [Authorize]

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
            __builder.AddAttribute(1, "class", "row m-5");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "col-lg-6 col-md-12 bg-white");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "jumbotron");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(6);
            __builder.AddAttribute(7, "class", "regForm col-12 bg-white p-4");
            __builder.AddAttribute(8, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 18 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
                                                                  bankInfo

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 18 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
                                                                                            HandleValidPayment

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(10, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 18 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
                                                                                                                                  HandleInvalidPayment

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(12);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(13, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(14);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(15, "\r\n                ");
                __builder2.OpenElement(16, "div");
                __builder2.AddAttribute(17, "class", "row");
                __builder2.OpenElement(18, "div");
                __builder2.AddAttribute(19, "class", "form-group");
                __builder2.AddMarkupContent(20, "\r\n                        Card holder:<br>\r\n                        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(21);
                __builder2.AddAttribute(22, "class", "regInput");
                __builder2.AddAttribute(23, "style", "width:90%");
                __builder2.AddAttribute(24, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 24 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
                                                                                   bankInfo.cardHolder

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(25, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => bankInfo.cardHolder = __value, bankInfo.cardHolder))));
                __builder2.AddAttribute(26, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => bankInfo.cardHolder));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(27, "\r\n\r\n                ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "class", "row");
                __builder2.OpenElement(30, "div");
                __builder2.AddAttribute(31, "class", "form-group");
                __builder2.AddMarkupContent(32, "\r\n                        Card Number:<br>\r\n                        ");
                __Blazor.Blazor.Pages.Payment.TypeInference.CreateInputNumber_0(__builder2, 33, 34, "regInput", 35, "width:90%", 36, 
#nullable restore
#line 31 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
                                                                                     bankInfo.cardNumber

#line default
#line hidden
#nullable disable
                , 37, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => bankInfo.cardNumber = __value, bankInfo.cardNumber)), 38, () => bankInfo.cardNumber);
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\r\n\r\n                ");
                __builder2.OpenElement(40, "div");
                __builder2.AddAttribute(41, "class", "row");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "col-xl-6 col-lg-12");
                __builder2.OpenElement(44, "div");
                __builder2.AddAttribute(45, "class", "form-group");
                __builder2.AddMarkupContent(46, "\r\n                            Expiry Date:<br>\r\n                            ");
                __Blazor.Blazor.Pages.Payment.TypeInference.CreateInputDate_1(__builder2, 47, 48, "regInput paymentInputSmall", 49, 
#nullable restore
#line 39 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
                                                                                       expiryDate

#line default
#line hidden
#nullable disable
                , 50, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => expiryDate = __value, expiryDate)), 51, () => expiryDate);
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(52, "\r\n                    ");
                __builder2.OpenElement(53, "div");
                __builder2.AddAttribute(54, "class", "col-xl-6 col-lg-12");
                __builder2.OpenElement(55, "div");
                __builder2.AddAttribute(56, "class", "form-group");
                __builder2.AddMarkupContent(57, "\r\n                            CVV:<br>\r\n                            ");
                __Blazor.Blazor.Pages.Payment.TypeInference.CreateInputNumber_2(__builder2, 58, 59, "regInput paymentInputSmall", 60, 
#nullable restore
#line 45 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
                                                                                         cvv

#line default
#line hidden
#nullable disable
                , 61, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => cvv = __value, cvv)), 62, () => cvv);
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(63, "\r\n                ");
                __builder2.AddMarkupContent(64, "<div class=\"row m-3\"><div class=\"row d-flex justify-content-center\"><div class=\"col-12 center-block\"><p class=\"actions \"><button class=\"btn btn-primary order-button\" type=\"submit\">Pay Now</button></p></div></div></div>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n    ");
            __builder.OpenElement(66, "div");
            __builder.AddAttribute(67, "class", "col-lg-6 col-md-12 bg-light p-4");
            __builder.AddMarkupContent(68, "<div class=\"row m-3\"><h3 class=\"text-center text-secondary\">Your order:</h3></div>\r\n        ");
            __builder.OpenElement(69, "div");
            __builder.AddAttribute(70, "class", "row m-3");
            __builder.OpenElement(71, "h1");
            __builder.AddAttribute(72, "class", "display-4");
            __builder.AddContent(73, 
#nullable restore
#line 66 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
                                   Recipe.recipeName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n        ");
            __builder.AddMarkupContent(75, "<div class=\"row m-3\"><div class=\"col-6\"><p class=\"text-secondary\">Shipping</p></div>\r\n            <div class=\"col-6\"><p class=\"text-secondary\">Free</p></div></div>\r\n        ");
            __builder.OpenElement(76, "div");
            __builder.AddAttribute(77, "class", "row m-3");
            __builder.AddMarkupContent(78, "<div class=\"col-6\"><p class=\"text-secondary\">Total</p></div>\r\n            ");
            __builder.OpenElement(79, "div");
            __builder.AddAttribute(80, "class", "col-6");
            __builder.OpenElement(81, "p");
            __builder.AddAttribute(82, "class", "text-secondary");
            __builder.AddContent(83, 
#nullable restore
#line 81 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
                                           orderPrice

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(84, " DKK");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 86 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\Payment.razor"
       


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
            if (cvv >= 100 && cvv <= 999)
            {
                Console.WriteLine("cvv fine");
                if (expiryDate > DateTime.Now)
                {
                    Console.WriteLine("expiry date fine");
                    await OrderService.storeOrder(newOrder);
                    NavigationManager.NavigateTo("/orders");
                }
            }
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
        public static void CreateInputDate_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputDate<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
        public static void CreateInputNumber_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
