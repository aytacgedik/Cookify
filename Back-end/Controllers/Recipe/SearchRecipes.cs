using Microsoft.AspNetCore.Mvc;
using Back_end.DatabaseModels;
using System.Collections.Generic;
using Back_end.Data;
using System.Net.Mail;
using System;
using Back_end.Dtos;

namespace Back_end.Controllers
{
    [Route("api/recipes/search")]
    [ApiController]
    public class SearchRecipes : RecipeController
    {
        // public SearchRecipes(IRecipeRepo recipeRepository,IUserRepo userRepository):base(recipeRepository,userRepository)
        // {
            
        // }

        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> searchRecipes(string query)
        {
            // List<RecipeDto> recipesToReturn = new List<RecipeDto>();
            // if(!String.IsNullOrEmpty(query))
            //     foreach(var recipe in base._recipeRepository.GetRecipes())
            //     {
            //         if(recipe.name.ToLower().Contains(query.ToLower()))
            //             recipesToReturn.Add(recipe.AsDto());
                    
            //     }
            // if(recipesToReturn.Count == 0)
            //     return NotFound(query);
            return Ok();
        }


    }
}