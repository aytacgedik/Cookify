using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Models;
using Back_end.Dtos;

namespace Back_end.Controllers
{
    [Route("api/ingredients/search")]
    [ApiController]
    public class SearchIngredients : IngredientController
    {
        public SearchIngredients(IRecipeRepo recipeRepository, IIngredientRepo ingredientRepository) : base(recipeRepository, ingredientRepository)
        {

        }
        
        [HttpGet]
        public ActionResult<IEnumerable<IngredientDto>> searchIngredients([FromQuery]string query)
        {
            List<Ingredient> ingredientsToReturn = new List<Ingredient>();
            // if (!String.IsNullOrEmpty(query))
            // {
            //     foreach (var ingredient in _ingredientRepository.GetIngredients())
            //     {
            //         if (ingredient.name.Contains(query))
            //             ingredientsToReturn.Add(ingredient);
            //     }
            // }
            // if (ingredientsToReturn == null)
            //     return NotFound();
            // var ingredientsDtoToReturn = ingredientsToReturn.Select(x => x.AsDto()).ToList();
            return Ok(ingredientsToReturn);
        }
    }
}
