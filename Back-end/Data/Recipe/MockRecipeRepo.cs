using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public class MockRecipeRepo : IRecipeRepo
    {
        public Recipe GetRecipeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            throw new System.NotImplementedException();
        }
    }
}