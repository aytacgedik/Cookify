using System.Collections.Generic;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IRecipeService
    {
        IEnumerable<RecipeDto> GetRecipes();
        RecipeDto GetRecipeById(int id);
        IEnumerable<RecipeDto> DeleteRecipeById(int id);
        RecipeDto UpdateRecipeById(int id, int creatorId, string name, string description, float rating, string tag);

        IEnumerable<RecipeDto> CreateRecipe(Recipe r);
    }
}