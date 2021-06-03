using System.Collections.Generic;
using System.Linq;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Data
{
    public class MockIngredientRepo : IIngredientRepo
    {
        private readonly CookifyContext _context;
        public MockIngredientRepo(CookifyContext context)
        {
            _context = context;
        }

        public IngredientDto GetIngredientById(int id)
        {
            return _context.Ingredients.Where(i => i.Id == id).FirstOrDefault().AsDto();
        }

        public IEnumerable<IngredientDto> GetIngredients()
        {
            return _context.Ingredients.Select(x => x.AsDto());
        }
        public IEnumerable<IngredientDto> ServiceSearchIngredient(string query)
        {
            return _context.Ingredients.Where(x => x.Name.Contains(query)).Select(y => y.AsDto());
        }

        public IEnumerable<IngredientDto> GetRecipeIngredients(int id)
        {
            return _context.RecipeIngredients.Where(r => r.RecipeId == id).Select(i => i.Ingredient).Select(y => y.AsDto());
        }
    }
}