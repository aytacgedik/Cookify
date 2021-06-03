using System.Collections.Generic;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Data
{
    public interface ISavedRecipeRepo
    {
        IEnumerable<SavedRecipeDto> GetSavedRecipes();
        IEnumerable<SavedRecipeDto> CreateSavedRecipe(SavedRecipeInputDto r);
        IEnumerable<RecipeDto> GetUserSavedRecipes(int uid);
    }
}