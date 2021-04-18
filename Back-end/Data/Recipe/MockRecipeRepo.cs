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
            var toremove = repo.Find(x => x.id == id);
            if(toremove!=null)
                repo.Remove(toremove);
            return repo;
        }
        public Recipe UpdateRecipeById(int id, int creatorId, string name, string description, float rating, string tag) {
            int indexToUpdate = -1;
            for(int i = 0; i < repo.Count; i++) {
                if (repo[i].id == id) {
                    indexToUpdate = i;
                }
            }
            repo[indexToUpdate].id = id;
            repo[indexToUpdate].creatorId = creatorId;
            repo[indexToUpdate].name = name;
            repo[indexToUpdate].description = description;
            repo[indexToUpdate].rating = rating;
            repo[indexToUpdate].tag = tag;
            return repo[indexToUpdate];
        }

        public IEnumerable<Recipe> CreateRecipe(Recipe r)
        {
            repo.Add(new Recipe{id=r.id,creatorId=r.creatorId,name
            =r.name,description=r.description,rating=r.rating,tag=r.tag});
            return repo;
        }
    }
}