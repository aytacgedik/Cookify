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
        RecipeDto ServiceUpdateRecipeById(int id, int creatorId, string name, string description, float rating, string tag);

        IEnumerable<RecipeDto> ServiceCreateRecipe(RecipeDto r);
        public IEnumerable<RecipeDto> ServiceSearchRecipe(string query);
    }
}