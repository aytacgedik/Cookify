using System.Collections.Generic;
using Back_end.Data;
using Back_end.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "Admin",AuthenticationSchemes="Bearer")]
        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> GetAllRecipes()
        {
            var recipes = _recipeService.GetRecipes();
            return Ok(recipes);

        }
        [Authorize(Policy = "Admin",AuthenticationSchemes="Bearer")]
        [HttpGet("{id}")]
        public ActionResult<RecipeDto> getRecipe(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            return Ok(recipe);
        }
        [Authorize(Policy = "Admin",AuthenticationSchemes="Bearer")]

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<RecipeDto>> removeRecipe(int id)
        {
            var recipes = _recipeService.RemoveRecipeById(id);
            return Ok(recipes);
        }

        [Authorize(Policy = "Admin",AuthenticationSchemes="Bearer")]


        [HttpPatch("{id}")]
        public ActionResult<RecipeDto> updateRecipe(int id, RecipePatchDto _recipe)
        {
            var recipe = _recipeService.UpdateRecipeById(id,_recipe);
            return Ok(recipe);
        }
        
    }
}