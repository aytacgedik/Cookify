using Microsoft.AspNetCore.Mvc;
using Back_end.Models;
using System.Collections.Generic;
using Back_end.Data;
using System.Net.Mail;
using System;

namespace Back_end.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class ManageSavedRecipe : RecipeController
    {
        public ManageSavedRecipe(IRecipeRepo recipeRepository,IUserRepo userRepository):base(recipeRepository,userRepository)
        {
            
        }

        [HttpPost]
        public ActionResult createSavedRecipe([FromBody] SavedRecipe recipeToSave)
        {
            SavedRecipe recipe = new SavedRecipe{id=1,userId=1,recipeId=1};
            return Ok(recipe);
        }


    }
}