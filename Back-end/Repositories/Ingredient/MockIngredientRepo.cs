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

        public DatabaseModels.Ingredient GetIngredientById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DatabaseModels.Ingredient> GetIngredients()
        {
            throw new System.NotImplementedException();
        }
    }
}