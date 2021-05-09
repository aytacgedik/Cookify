using Microsoft.AspNetCore.Mvc;
using Back_end.Models;
using System.Collections.Generic;
using Back_end.Data;
using System.Net.Mail;
using System;
using Back_end.Dtos;
using System.Linq;

namespace Back_end.Controllers
{
    [Route("api/saved_recipes")]
    [ApiController]
    public class ManageSavedRecipe : RecipeController
    {

        public ManageSavedRecipe(IRecipeRepo recipeRepository,IUserRepo userRepository,ISavedRecipeRepo repo):base(recipeRepository,userRepository,repo)
        {
            
        }

        [HttpPost]
        public ActionResult<IEnumerable<SavedRecipeDto>> createSavedRecipe([FromBody] SavedRecipe recipeToSave)
        {
            var result = base._savedRecipeRepository.
            CreateSavedRecipe(new SavedRecipe{id=recipeToSave.id,userId=recipeToSave.userId,recipeId=recipeToSave.recipeId});
            if(result==null)
                return NotFound();
            var resultDto = result.Select(x=>x.AsDto());
            return Ok(resultDto);


        }


    }
}