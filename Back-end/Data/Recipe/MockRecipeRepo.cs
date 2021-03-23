using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public class MockRecipeRepo : IRecipeRepo
    {
        public List<Recipe> repo;
        public MockRecipeRepo()
        {
            repo = new List<Recipe>{
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
                            tag="Turkish Cuisine"}};

        }
        public Recipe GetRecipeById(int id)
        {
            foreach(var recipe in repo) {
                if (recipe.id == id) {
                    return recipe;
                }
            }
            return null;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return repo; 
        }

        public IEnumerable<Recipe> DeleteRecipeById(int id) {
            int indexToRemove = -1;
            for(int i = 0; i < repo.Count; i++) {
                if (repo[i].id == id) {
                    indexToRemove = i;
                }
            }
            repo.RemoveAt(indexToRemove);
            return repo;
        }
    }
}