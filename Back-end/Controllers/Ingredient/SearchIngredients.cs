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
    [Route("api/ingredients/search")]
    [ApiController]
    public class SearchIngredients : IngredientController
    {
        public SearchIngredients(IIngredientService ingredientService, IRecipeService recipeService) : base(ingredientService, recipeService)
        {

        }
        
        [HttpGet]
        public ActionResult<IEnumerable<IngredientDto>> searchIngredients([FromQuery]string query)
        {
            var toReturn = _ingredientService.SearchIngredient(query);
            if (toReturn == null)
                return NotFound();
            return Ok(toReturn);
        }
    }
}
