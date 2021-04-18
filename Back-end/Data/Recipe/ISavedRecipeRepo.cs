using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public interface ISavedRecipeRepo
    {
        IEnumerable<SavedRecipe> GetSavedRecipes();
        IEnumerable<SavedRecipe> CreateSavedRecipe(SavedRecipe r);
    }
}