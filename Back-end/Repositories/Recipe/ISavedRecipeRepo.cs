using System.Collections.Generic;
using Back_end.DatabaseModels;

namespace Back_end.Data
{
    public interface ISavedRecipeRepo
    {
        IEnumerable<SavedRecipe> GetSavedRecipes();
        IEnumerable<SavedRecipe> CreateSavedRecipe(SavedRecipe r);
    }
}