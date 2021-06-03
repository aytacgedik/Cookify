using System.Collections.Generic;
using Back_end.DatabaseModels;
using System.Linq;
using Back_end.Dtos;

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
        public IEnumerable<SavedRecipeDto> CreateSavedRecipe(SavedRecipeInputDto r)
        {
            var srtoAdd = new SavedRecipe{
                UserId = r.userId,
                RecipeId = r.recipeId
            };
            _context.SavedRecipes.Add(srtoAdd);
            _context.SaveChanges();
            return _context.SavedRecipes.Select(x=>x.AsDto());
        }

        public IEnumerable<SavedRecipeDto> GetSavedRecipes()
        {
            return _context.SavedRecipes.Select(x=>x.AsDto());
        }

        public IEnumerable<RecipeDto> GetUserSavedRecipes(int uid)
        {
           return _context.SavedRecipes.Where(x=>x.UserId == uid).Select(y => y.Recipe.AsDto());
        }
    }
}