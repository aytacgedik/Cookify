using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public class MockIngredientRepo : IIngredientRepo
    {
        public List<Ingredient> repo;
        public MockIngredientRepo()
        {
            repo = new List<Ingredient>{
                new Ingredient{id = 1, name = "Hershey Dark Chocolate"},
                new Ingredient{id = 2, name = "Cadbury Milky Chocolate"},
                new Ingredient{id = 3, name = "Lindt White Chocolate"}
            };

        }
        public Ingredient GetIngredientById(int id)
        {
            foreach (var ingredient in repo)
            {
                if (ingredient.id == id)
                {
                    return ingredient;
                }
            }
            return null;
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return repo;
        }
    }
}