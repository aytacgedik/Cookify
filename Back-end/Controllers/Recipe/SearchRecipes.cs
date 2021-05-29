using Microsoft.AspNetCore.Mvc;
using Back_end.DatabaseModels;
using System.Collections.Generic;
using Back_end.Data;
using System.Net.Mail;
using System;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("api/recipes/search")]
    [ApiController]
    public class SearchRecipes : RecipeController
    {
        private readonly IRecipeService _recipeService;
        public SearchRecipes(IRecipeService recipeService){
            _recipeService = recipeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> searchRecipes(string query)
        {

            return Ok(_recipeService.ServiceSearchRecipe(query));
        }


    }
}