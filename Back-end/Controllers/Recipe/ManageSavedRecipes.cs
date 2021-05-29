using Microsoft.AspNetCore.Mvc;
using Back_end.DatabaseModels;
using System.Collections.Generic;
using Back_end.Data;
using System.Net.Mail;
using System;
using Back_end.Dtos;
using System.Linq;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("api/saved_recipes")]
    [ApiController]
    public class ManageSavedRecipe : RecipeController
    {
        private readonly ISavedRecipeService _savedRecipeService;
        public ManageSavedRecipe(ISavedRecipeService savedRecipeService)
        {
            _savedRecipeService = savedRecipeService;
        }

        [HttpPost]
        public ActionResult<IEnumerable<SavedRecipeDto>> createSavedRecipe([FromBody] SavedRecipe recipeToSave)
        {
            // var result = base._savedRecipeRepository.
            // CreateSavedRecipe(new SavedRecipe{id=recipeToSave.id,userId=recipeToSave.userId,recipeId=recipeToSave.recipeId});
            // if(result==null)
            //     return NotFound();
            // var resultDto = result.Select(x=>x.AsDto());
            return Ok(_savedRecipeService.ServiceCreateSavedRecipe(recipeToSave));


        }

        [HttpGet]
        public ActionResult<IEnumerable<SavedRecipeDto>> getSavedRecipes()
        {
            // var result = base._savedRecipeRepository.
            // CreateSavedRecipe(new SavedRecipe{id=recipeToSave.id,userId=recipeToSave.userId,recipeId=recipeToSave.recipeId});
            // if(result==null)
            //     return NotFound();
            // var resultDto = result.Select(x=>x.AsDto());
            return Ok(_savedRecipeService.ServiceGetSavedRecipes());


        }


    }
}