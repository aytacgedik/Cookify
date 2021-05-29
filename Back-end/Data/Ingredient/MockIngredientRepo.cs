using System.Collections.Generic;
using System.Linq;
using Back_end.DatabaseModels;

namespace Back_end.Data
{
    public class MockIngredientRepo : IIngredientRepo
    {
        private readonly CookifyContext _context;
        public MockIngredientRepo(CookifyContext context)
        {
            _context = context;
        }

        public Ingredient GetIngredientById(int id)
        {
            return _context.Ingredients.Where(i => i.Id == id).FirstOrDefault();
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return _context.Ingredients;
        }

        public IEnumerable<Ingredient> GetRecipeIngredients(int id)
        {
            return _context.RecipeIngredients.Where(r => r.RecipeId == id).Select(i => i.Ingredient).ToList();
        }
    }
}