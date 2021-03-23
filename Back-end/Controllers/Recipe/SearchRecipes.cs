using Microsoft.AspNetCore.Mvc;
using Back_end.Models;
using System.Collections.Generic;
using Back_end.Data;
using System.Net.Mail;
using System;

namespace Back_end.Controllers
{
    [Route("api/recipes/search")]
    [ApiController]
    public class SearchRecipes : RecipeController
    {
        public SearchRecipes(IRecipeRepo recipeRepository,IUserRepo userRepository):base(recipeRepository,userRepository)
        {
            
        }

        [HttpPost]
        public ActionResult createSavedRecipe(string query)
        {
            List<Recipe> recipesToReturn = new List<Recipe>();
            if(!String.IsNullOrEmpty(query))
                foreach(var recipe in base._recipeRepository.GetRecipes())
                {
                    if(recipe.name.Contains(query))
                        recipesToReturn.Add(recipe);
                }

            return Ok(recipesToReturn);
        }


    }
}