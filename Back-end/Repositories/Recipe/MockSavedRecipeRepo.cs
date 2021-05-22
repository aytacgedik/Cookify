using System.Collections.Generic;
using Back_end.Models;
using System.Linq;

namespace Back_end.Data
{
    public class MockSavedRecipeRepo : ISavedRecipeRepo
    {
        List<SavedRecipe> repo;
        public MockSavedRecipeRepo()
        {
            repo = new List<SavedRecipe>
            {
                new SavedRecipe
                {
                    id=1,
                    userId=1,
                    recipeId=1,
                },
                new SavedRecipe{
                    id=2,
                    userId=2,
                    recipeId=2
                }
            };
            
        }

        public IEnumerable<DatabaseModels.SavedRecipe> CreateSavedRecipe(DatabaseModels.SavedRecipe r)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DatabaseModels.SavedRecipe> GetSavedRecipes()
        {
            throw new System.NotImplementedException();
        }
    }
}