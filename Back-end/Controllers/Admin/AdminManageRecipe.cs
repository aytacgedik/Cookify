using System.Collections.Generic;
using Back_end.Data;
using Back_end.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("admin/recipe")]
    [ApiController]
    public class AdminManageRecipeController : ControllerBase
    {
        private readonly IAdminManageRecipeService _recipeService;
        public AdminManageRecipeController(IAdminManageRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> GetAllRecipes()
        {
            var recipes = _recipeService.GetRecipes();
            return Ok(recipes);

        }
        [HttpGet("{id}")]
        public ActionResult<RecipeDto> getRecipe(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            return Ok(recipe);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<RecipeDto>> removeRecipe(int id)
        {
            var recipes = _recipeService.RemoveRecipeById(id);
            return Ok(recipes);
        }

        [HttpPatch("{id}")]
        public ActionResult<RecipeDto> updateRecipe([FromBody] RecipeDto _recipe)
        {
            var recipe = _recipeService.UpdateRecipeById(_recipe);
            return Ok(recipe);
        }
        
    }
}