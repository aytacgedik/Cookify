using System.Collections.Generic;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface ISavedRecipeService
    {
        IEnumerable<SavedRecipeDto> ServiceGetSavedRecipes();
        IEnumerable<SavedRecipeDto> ServiceCreateSavedRecipe(SavedRecipeInputDto r);

        IEnumerable<RecipeDto> ServiceGetUserSavedRecipes(int id);
    }
}