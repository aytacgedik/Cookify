using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Models;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("api/ingredients/list")]
    [ApiController]
    public class IngredientsListCreator : IngredientController
    {
        public IngredientsListCreator(IIngredientService ingredientService, IRecipeService recipeService) : base(ingredientService, recipeService)
        {

        }

        [HttpGet]
        public ActionResult<IEnumerable<IngredientDto>> generateList([FromQuery] int id)
        {
            var toReturn = _ingredientService.generateList(id);
            if (toReturn == null)
                return NotFound();
            return Ok(toReturn);
        }
    }
}
