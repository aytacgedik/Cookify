using System.Collections.Generic;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using System.Linq;
//Keeping this as example. This gonna be deleted later.
namespace Back_end.Controllers
{
    [Route("admin/recipe")]
    [ApiController]
    public class AdminManageRecipeController:ControllerBase
    {
        private readonly IRecipeRepo _repository;
        public AdminManageRecipeController(IRecipeRepo repository)
        {
            _repository=repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> GetAllRecipes()
        {
            var recipes = _repository.GetRecipes();
            if (recipes == null) {
                return NotFound();
            }
            var recipesDto = recipes.Select(x => x.AsDto()).ToList();
            return Ok(recipesDto);

        }
        [HttpGet("{id}")]
         public ActionResult<RecipeDto> GetAllRecipes(int id)
        {
            var recipe = _repository.GetRecipeById(id);
            if (recipe == null) {
                return NotFound();
            }
            return Ok(recipe.AsDto());
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<RecipeDto>> RemoveRecipe(int id)
        {
            var recipes = _repository.DeleteRecipeById(id);
            if (recipes == null) {
                return NotFound();
            }
            var recipesDto = recipes.Select(x => x.AsDto()).ToList();
            return Ok(recipesDto);
        }

        [HttpPatch("{id}")]
        public ActionResult<RecipeDto> updateRecipe([FromBody] Recipe _recipe)
        {
            var recipe = _repository.UpdateRecipeById(_recipe.id, _recipe.creatorId, _recipe.name, _recipe.description, _recipe.rating, _recipe.tag);
            if (recipe == null) {
                return NotFound();
            }
            return Ok(recipe.AsDto());
        }
        
    }
}