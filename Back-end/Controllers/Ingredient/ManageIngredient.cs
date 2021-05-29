using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("api/ingredient")]
    [ApiController]
    public class ManageIngredient : IngredientController
    {
        public ManageIngredient(IIngredientService ingredientService, IRecipeService recipeService) : base(ingredientService, recipeService)
        {

        }

        //GET{all} - getIngredients()
        [HttpGet]
        public ActionResult<IEnumerable<IngredientDto>> getIngredients()
        {
            var ingredients = _ingredientService.GetIngredients();
            if (ingredients == null)
                return NotFound();
            return Ok(ingredients);
        }

        //GET{id} - getIngredient()
        [HttpGet("{id}")]
        public ActionResult<IngredientDto> getIngredient(int id)
        {
            var ingredient = _ingredientService.GetIngredientById(id);
            if (ingredient == null)
                return NotFound();
            return Ok(ingredient);
        }
    }
}
