using Microsoft.AspNetCore.Mvc;
using Back_end.Models;
using System.Collections.Generic;
using System.Net.Mail;
using System;
using System.Linq;

namespace Back_end.Controllers
{
    [Route("api/recipes/search")]
    [ApiController]
    public class SearchRecipes : RecipeController
    {
        public SearchRecipes():base()
        {
            
        }

        [HttpGet]
        public ActionResult searchRecipes(string query)
        {
            List<Recipe> recipesToReturn = new List<Recipe>();
            if(!String.IsNullOrEmpty(query))
                foreach(var recipe in base.context.Recipes.ToList())
                {
                    if(recipe.RecipeName.Contains(query))
                        recipesToReturn.Add(recipe);
                }

            return Ok(recipesToReturn);
        }


    }
}