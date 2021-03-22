using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public class MockRecipeRepo : IRecipeRepo
    {
        public Recipe GetRecipeById(int id)
        {
            return new Recipe{id=3,
                            creatorId=3,
                            name="Simit",
                            description="Turkish bagel with sesame",
                            rating=6.9F,
                            tag="Turkish Cuisine"};
        }

        public IEnumerable<Recipe> GetRecipes()
        {
                        return new List<Recipe>{
                new Recipe{id=1,
                            creatorId=1,
                            name="Pilav",
                            description="Boiled rice fried with butter",
                            rating=9.8F,
                            tag="Turkish Cuisine"},
                new Recipe{id=2,
                            creatorId=2,
                            name="Karni Yarik",
                            description="Eggplants stuffed with minced meat",
                            rating=10.0F,
                            tag="Turkish Cuisine"},
                new Recipe{id=3,
                            creatorId=3,
                            name="Simit",
                            description="Turkish bagel with sesame",
                            rating=6.9F,
                            tag="Turkish Cuisine"}
            };
        }
    }
}