using System.Collections.Generic;
using Back_end.DatabaseModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Back_end.Dtos;

namespace Back_end.Data
{
    public class MockRecipeRepo : IRecipeRepo
    {
        //Repository meaning any type of CRUD should be done here and returned.
        //In the Service folders do the Logic
        //https://stackoverflow.com/questions/1440096/difference-between-repository-and-service
        private readonly CookifyContext _context;
        public MockRecipeRepo(CookifyContext context)
        {
            _context = context;

            // repo = new List<Recipe>{
            //     new Recipe{id=1,
            //                 creatorId=1,
            //                 name="Pilav",
            //                 description="Boiled rice fried with butter",
            //                 rating=9.8F,
            //                 tag="Turkish Cuisine"},
            //     new Recipe{id=2,
            //                 creatorId=2,
            //                 name="Karni Yarik",
            //                 description="Eggplants stuffed with minced meat",
            //                 rating=10.0F,
            //                 tag="Turkish Cuisine"},
            //     new Recipe{id=3,
            //                 creatorId=3,
            //                 name="Simit",
            //                 description="Turkish bagel with sesame",
            //                 rating=6.9F,
            //                 tag="Turkish Cuisine"}};

        }
        public Recipe GetRecipeById(int id)
        {
            return _context.Recipes.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return _context.Recipes.ToList();
        }

        public IEnumerable<Recipe> DeleteRecipeById(int id)
        {
            var recipeingredits = _context.RecipeIngredients.Where(x=>x.RecipeId ==id).ToList();
            foreach (var item in recipeingredits)
            {
                _context.RecipeIngredients.Remove(item);
                _context.SaveChanges();
            }
            var savedrecipes = _context.SavedRecipes.Where(x=>x.RecipeId ==id).ToList();
            foreach (var saved in savedrecipes)
            {
                _context.SavedRecipes.Remove(saved);
                _context.SaveChanges();
            }

            _context.Recipes.Remove(GetRecipeById(id));
            _context.SaveChanges();
            return _context.Recipes.ToList();
        }
        public Recipe UpdateRecipeById(int id, int creatorId, string name, string description, float rating, string tag)
        {
            _context.Recipes.Update(new Recipe { Id = id, CreatorId = creatorId, Name = name, Description = description, Rating = (decimal?)rating, Tag = tag });
            _context.SaveChanges();
            return _context.Recipes.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Recipe> CreateRecipe(RecipeDto r)
        {
            var toAdd = new Recipe
            {
                CreatorId = r.creatorId,
                Name = r.name,
                Description = r.description,
                Rating = (decimal)r.rating,
                Tag = r.tag,
            };
            _context.Add(toAdd);
            _context.SaveChanges();
            foreach (var ingredient in r.Ingredients)
            {

                    int? ingredientID = _context.Ingredients.Where(i=> i.Name == ingredient.name).Select(x=>x.Id).FirstOrDefault();
                    if(ingredientID != 0)
                    {
                        //link to recipe
                        var RecipeIngredient = new RecipeIngredient();
                        RecipeIngredient.IngredientId = ingredientID;
                        RecipeIngredient.RecipeId = toAdd.Id;
                        _context.RecipeIngredients.Add(RecipeIngredient);
                        _context.SaveChanges();

                    }
            }

            return _context.Recipes.ToList();
        }
    }
}