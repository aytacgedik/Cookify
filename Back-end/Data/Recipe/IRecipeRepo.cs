using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public interface IRecipeRepo
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipeById(int id);
        IEnumerable<Recipe> DeleteRecipeById(int id);
    }
}