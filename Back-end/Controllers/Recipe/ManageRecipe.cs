using Microsoft.AspNetCore.Mvc;
using Back_end.DatabaseModels;
using System.Collections.Generic;
using Back_end.Data;
using System.Net.Mail;
using System;
using System.Linq;
using Back_end.Dtos;
using Back_end.Services;
using Microsoft.AspNetCore.Authorization;

namespace Back_end.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class ManageRecipe : RecipeController
    {
        private readonly IRecipeService _recipeService;
        public ManageRecipe(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        //private sendEmailNotification()
         


        //POST - createRecipe()
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpPost]
        public ActionResult<IEnumerable<RecipeDto>> createRecipe(RecipeInputDto recipe)
        {
            //return what is going to be added to database for now
            //later we will do an insert on the database
            //send mail notification
            //var recipeJSON = Newtonsoft.Json.JsonConvert.SerializeObject(recipe);
            //System.Console.WriteLine(recipeJSON);
            //foreach(var user in _userRepository.GetUsers())
            //{
            //    sendEmailNotification(recipe,user.email,recipeJSON);                
            //}
            var recipes = _recipeService.ServiceCreateRecipe(recipe);
            if(recipes == null)
                return NotFound();
            return Ok(recipes);
        }

        //DELETE{id} - removeRecipe() 
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<RecipeDto>> removeRecipe(int id)
        {
            //DELETE operation to be done from the database
            var result = _recipeService.ServiceDeleteRecipeById(id);
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        //PATCH/PUT{id} - updateRecipe()
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpPatch("{id}")]
        public ActionResult<RecipeDto> updateRecipe( int id, RecipePatchDto recipe)
        {
            //recipe json passed from front-end
            //find object from recipe.id
            //set all other fields of found object to recipe fields
            var result = _recipeService.ServiceUpdateRecipeById(id,recipe);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes="Bearer")]
        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> getRecipe()
        {
            var result = _recipeService.ServiceGetRecipes();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        //GET{id} - getRecipes()
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RecipeDto>> getRecipe(int id)
        {
            var result = _recipeService.ServiceGetRecipeById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
    }
}
