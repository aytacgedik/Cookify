using Microsoft.AspNetCore.Mvc;
using Back_end.Models;
using System.Collections.Generic;
using Back_end.Data;

namespace Back_end.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class ManageRecipe : RecipeController
    {
        public ManageRecipe(IRecipeRepo repository):base(repository)
        {
            
        }

        //private sendEmailNotification()

        //POST - createRecipe()
        [HttpPost]
        public IActionResult createRecipe([FromBody]Recipe recipe)
        {
            return Ok("Got the Post call");
        }

        //DELETE{id} - removeRecipe() 

        //PATCH/PUT{id} - updateRecipe()

        //GET{all} - getRecipe()
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> getRecipe()
        {
            var users= base._repository.GetRecipes();

            return Ok(users);

        }

        //GET{id} - getRecipes()
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Recipe>> getRecipe(int id)
        {
            var user= base._repository.GetRecipeById(id);

            return Ok(user);

        }
    }
}