using System.Collections.Generic;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Data
{
    public interface IRecipeRepo
    {
        IEnumerable<RecipeDto> GetRecipes();
        RecipeDto GetRecipeById(int id);
        IEnumerable<RecipeDto> DeleteRecipeById(int id);
        RecipeDto UpdateRecipeById(RecipeDto recipe);

        IEnumerable<RecipeDto> CreateRecipe(RecipeDto r);
    }
}