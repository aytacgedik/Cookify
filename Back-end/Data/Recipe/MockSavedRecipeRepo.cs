using System.Collections.Generic;
using Back_end.DatabaseModels;
using System.Linq;
using Back_end.DatabaseModels;

namespace Back_end.Data
{
    public class MockSavedRecipeRepo : ISavedRecipeRepo
    {
        private readonly CookifyContext _context;
        public MockSavedRecipeRepo(CookifyContext context)
        {
            _context = context;
        }
        // public IEnumerable<SavedRecipe> CreateSavedRecipe(SavedRecipe r)
        // {
        //     if(repo.Any(x=>x.id == r.id))
        //         return null;
        //     repo.Add(r);
        //     return repo;
        // }

        // public IEnumerable<SavedRecipe> GetSavedRecipes()
        // {
        //     return repo;
        // }
        public IEnumerable<SavedRecipe> CreateSavedRecipe(SavedRecipe r)
        {
            _context.SavedRecipes.Add(r);
            _context.SaveChanges();
            return _context.SavedRecipes.ToList();
        }

        public IEnumerable<SavedRecipe> GetSavedRecipes()
        {
            return _context.SavedRecipes.ToList();
        }
    }
}