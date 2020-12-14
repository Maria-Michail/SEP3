#pragma checksum "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b178b44f8e9e0b51bd7602ef4ca6e447873a89f8"
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
#line 2 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
using Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
using Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/viewRecipes")]
    public partial class ViewRecipes : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2 class=\"title\">ViewRecipes</h2>\n");
            __builder.OpenElement(1, "p");
            __builder.AddMarkupContent(2, "\n    Filter by Category: ");
            __builder.OpenElement(3, "input");
            __builder.AddAttribute(4, "type", "text");
            __builder.AddAttribute(5, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 10 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
                                                       (arg)=>FilterByCategory(arg)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "style", "width:150px");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 13 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
 if (RecipesToShow == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(7, "<p><em>Loading...</em></p>");
#nullable restore
#line 18 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
}
else if (!RecipesToShow.Any())
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(8, "<p><em>No recipes exist. Please add some.</em></p>");
#nullable restore
#line 24 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "row");
#nullable restore
#line 28 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
         foreach (var recipe in RecipesToShow)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "col-12");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "card");
            __builder.AddAttribute(15, "style", "width: 100%;");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "row");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "col-3");
            __builder.OpenElement(20, "img");
            __builder.AddAttribute(21, "src", "../Images/" + (
#nullable restore
#line 34 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
                                                         recipe.imageName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(22, "class", "card-img-top");
            __builder.AddAttribute(23, "alt", 
#nullable restore
#line 34 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
                                                                                                      recipe.recipeName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\n                                ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "col-9");
            __builder.OpenElement(27, "div");
            __builder.AddAttribute(28, "class", "card-body");
            __builder.OpenElement(29, "h5");
            __builder.AddAttribute(30, "class", "card-title");
            __builder.AddAttribute(31, "style", "text-decoration: underline");
            __builder.AddContent(32, 
#nullable restore
#line 38 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
                                                                                                   recipe.recipeName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\n                                        ");
            __builder.OpenElement(34, "p");
            __builder.AddAttribute(35, "class", "card-text");
            __builder.AddContent(36, 
#nullable restore
#line 39 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
                                                              recipe.instructions

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\n                                        ");
            __builder.OpenElement(38, "button");
            __builder.AddAttribute(39, "class", "btn btn-primary");
            __builder.AddAttribute(40, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 40 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
                                                                                    () => NavigateToComponent(recipe)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(41, "Check the recipe now!");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 48 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 50 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 54 "C:\Users\maria\OneDrive\Documents\Rider\SEP3\Blazor\Pages\ViewRecipes.razor"
       
    public IList<Recipe> Recipes { get; set; }
    public IList<Recipe> RecipesToShow;
    
    
    private void FilterByCategory(ChangeEventArgs changeEventArgs){
        string? filterByCat = null;
        try
        {
            filterByCat = changeEventArgs.Value.ToString();
        } catch(Exception e){}
        if (!String.IsNullOrEmpty(filterByCat))
        {    
            RecipesToShow = Recipes.Where(r => r.category.categoryName.Equals(filterByCat)).ToList();
        }
        else
        {
            RecipesToShow = Recipes;
        }
    }

    
    protected override async Task OnInitializedAsync()
    {
        Recipes = await RecipeService.GetRecipesAsync();
        RecipesToShow = Recipes;
        base.OnInitialized();
    }

    private void NavigateToComponent(Recipe p) {
      NavigationManager.NavigateTo("recipeView/" + p.recipeId);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRecipeService RecipeService { get; set; }
    }
}
#pragma warning restore 1591
