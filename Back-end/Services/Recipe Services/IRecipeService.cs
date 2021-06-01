using System.Collections.Generic;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IRecipeService
    {
        IEnumerable<RecipeDto> ServiceGetRecipes();
        RecipeDto ServiceGetRecipeById(int id);
        IEnumerable<RecipeDto> ServiceDeleteRecipeById(int id);
        RecipeDto ServiceUpdateRecipeById(int id,RecipePatchDto recipe);

        IEnumerable<RecipeDto> ServiceCreateRecipe(RecipeInputDto r);
        public IEnumerable<RecipeDto> ServiceSearchRecipe(string query);
    }
}