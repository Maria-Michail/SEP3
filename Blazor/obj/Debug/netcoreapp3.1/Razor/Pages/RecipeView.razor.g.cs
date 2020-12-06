#pragma checksum "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba5f874bb496974692bf481b09d3fa55fc6231d5"
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
#line 3 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
using Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
using Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/recipeView")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/recipeView/{Id:int}")]
    public partial class RecipeView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 11 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
 if (Recipe == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 16 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
}
else if (ingredients == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>");
#nullable restore
#line 22 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
}
else if (!ingredients.Any())
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<p><em>No ingredient exist. Please add some.</em></p>");
#nullable restore
#line 28 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "jumbotron");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "row");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "col-4");
            __builder.OpenElement(9, "img");
            __builder.AddAttribute(10, "src", "../Images/" + (
#nullable restore
#line 34 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                                     Recipe.imageName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "class", true);
            __builder.AddAttribute(12, "alt", "...");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\n            ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "col-8");
            __builder.OpenElement(16, "h1");
            __builder.AddAttribute(17, "class", "display-4");
            __builder.AddContent(18, 
#nullable restore
#line 37 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                                       Recipe.recipeName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\n                ");
            __builder.OpenElement(20, "p");
            __builder.AddAttribute(21, "class", "lead");
            __builder.AddContent(22, 
#nullable restore
#line 38 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                                 Recipe.description

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\n                <hr class=\"my-4\">\n                ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "row");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "col");
            __builder.OpenElement(28, "ul");
            __builder.OpenElement(29, "li");
            __builder.AddAttribute(30, "class", "my-3");
            __builder.AddContent(31, "Preparation time: ");
            __builder.AddContent(32, 
#nullable restore
#line 43 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                                                                Recipe.cookingTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\n                    ");
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", "col");
            __builder.OpenElement(36, "button");
            __builder.AddAttribute(37, "class", "btn btn-primary");
            __builder.AddAttribute(38, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 48 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                                                                    () => ChooseRecipe()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(39, "Order necessary ingredients to your home!");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.OpenElement(40, "div");
            __builder.AddAttribute(41, "class", "row");
            __builder.OpenElement(42, "div");
            __builder.AddAttribute(43, "class", "col");
            __builder.OpenElement(44, "div");
            __builder.AddAttribute(45, "class", "jumbotron instruction");
            __builder.AddMarkupContent(46, "<h2 class=\"mb-5\">Preparation guide</h2>\n                ");
            __builder.OpenElement(47, "ol");
            __builder.OpenElement(48, "li");
            __builder.AddContent(49, 
#nullable restore
#line 64 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                         Recipe.instructions

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\n    \n        ");
            __builder.OpenElement(51, "div");
            __builder.AddAttribute(52, "class", "col");
            __builder.OpenElement(53, "div");
            __builder.AddAttribute(54, "class", "jumbotron ingredients");
            __builder.AddMarkupContent(55, "<h2 class=\"mb-5\">Needed ingredients</h2>\n                ");
            __builder.OpenElement(56, "ul");
#nullable restore
#line 73 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                     foreach(Ingredient ingredient in ingredients)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(57, "li");
            __builder.AddAttribute(58, "class", "my-3");
            __builder.AddContent(59, 
#nullable restore
#line 75 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                                          ingredient.number

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(60, " ");
            __builder.AddContent(61, 
#nullable restore
#line 75 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                                                             ingredient.unitType

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(62, " of ");
            __builder.AddContent(63, 
#nullable restore
#line 75 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                                                                                     ingredient.ingredientName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 76 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 82 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 85 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Blazor\Pages\RecipeView.razor"
       
    [Parameter]
    public int Id { get; set; }

    public Recipe Recipe { get; set; }
    public IList<Ingredient> ingredients { get; set; } 



    protected override async Task OnInitializedAsync() {
        if (Id != 0) {
            Recipe = RecipeService.Recipes.FirstOrDefault(p => p.recipeId == Id);
            await IngredientsService.GetIngredientsAsync(Id);
            ingredients = IngredientsService.Ingredients;
        }
    }

    public async Task ChooseRecipe()
    {
        try
        {
            NavigationManager.NavigateTo("/ingredientsList");
        }
        catch (Exception e)
        {
            Console.WriteLine("failed");
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IIngredientsService IngredientsService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRecipeService RecipeService { get; set; }
    }
}
#pragma warning restore 1591
