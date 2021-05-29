using Microsoft.AspNetCore.Mvc;
using Back_end.DatabaseModels;
using System.Collections.Generic;
using Back_end.Data;
using System.Net.Mail;
using System;
using System.Linq;
using Back_end.Dtos;
using Back_end.Services;

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
        [HttpPost]
        public ActionResult<IEnumerable<RecipeDto>> createRecipe([FromBody]Recipe recipe)
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
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Recipe>> removeRecipe(int id)
        {
            //DELETE operation to be done from the database
            var result = _recipeService.ServiceDeleteRecipeById(id);
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        //PATCH/PUT{id} - updateRecipe()
        [HttpPatch]
        public ActionResult<Recipe> updateRecipe([FromBody] Recipe recipe)
        {
            //recipe json passed from front-end
            //find object from recipe.id
            //set all other fields of found object to recipe fields
            var result = _recipeService.ServiceUpdateRecipeById(recipe.Id,(int)recipe.CreatorId,recipe.Name,recipe.Description,(int)recipe.Rating,recipe.Tag);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> getRecipe()
        {
            var result = _recipeService.ServiceGetRecipes();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        //GET{id} - getRecipes()
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Recipe>> getRecipe(int id)
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
