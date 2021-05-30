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
        public Recipe UpdateRecipeById(RecipeDto recipe)
        {
            var recipeToUpdate = _context.Recipes.Where(x=>x.Id == recipe.id).FirstOrDefault();
            recipeToUpdate.Name = recipe.name;
            recipeToUpdate.Description = recipe.description;
            recipeToUpdate.Tag = recipe.tag;
            recipeToUpdate.Rating = (decimal)recipe.rating;
            recipeToUpdate.CreatorId = recipe.creatorId;

            _context.Recipes.Update(recipeToUpdate);
            _context.SaveChanges();
            return _context.Recipes.Where(x => x.Id == recipe.id).FirstOrDefault();
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