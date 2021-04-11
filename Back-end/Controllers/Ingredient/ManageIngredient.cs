using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Dtos;

namespace Back_end.Controllers
{
    [Route("api/ingredient")]
    [ApiController]
    public class ManageIngredient : IngredientController
    {
        public ManageIngredient(IRecipeRepo recipeRepository, IIngredientRepo ingredientRepository) : base(recipeRepository, ingredientRepository)
        {

        }

        //GET{all} - getIngredients()
        [HttpGet]
        public ActionResult<IEnumerable<IngredientDto>> getIngredients()
        {
            var ingredients = base._ingredientRepository.GetIngredients();
            if (ingredients == null)
                return NotFound();
            var ingredientsDto = ingredients.Select(x => x.AsDto()).ToList();
            return Ok(ingredientsDto);
        }

        //GET{id} - getIngredient()
        [HttpGet("{id}")]
        public ActionResult<IngredientDto> getIngredient(int id)
        {
            var ingredient = base._ingredientRepository.GetIngredientById(id);
            if (ingredient == null) 
                return NotFound(); 
            return Ok(ingredient.AsDto());
        }
    }
}
