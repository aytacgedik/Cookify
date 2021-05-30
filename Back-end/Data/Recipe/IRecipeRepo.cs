using System.Collections.Generic;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Data
{
    public interface IRecipeRepo
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipeById(int id);
        IEnumerable<Recipe> DeleteRecipeById(int id);
        Recipe UpdateRecipeById(RecipeDto recipe);

        IEnumerable<Recipe> CreateRecipe(RecipeDto r);
    }
}