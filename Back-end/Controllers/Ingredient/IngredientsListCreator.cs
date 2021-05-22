using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.DatabaseModels;
using Back_end.Dtos;
using Back_end.Data;

namespace Back_end.Controllers
{
    [Route("api/ingredients/list")]
    [ApiController]
    public class IngredientsListCreator : IngredientController
    {

        public IngredientsListCreator(IRecipeRepo recipeRepository, IIngredientRepo ingredientRepository) : base(recipeRepository, ingredientRepository)
        {

        }

        [HttpGet]
        public ActionResult<IEnumerable<IngredientDto>> generateList([FromQuery] int id)
        {
            List<Ingredient> ingredientsList = new List<Ingredient>();
            // foreach (var recipe in _recipeRepository.GetRecipes())
            // {
            //     if (recipe.id == id)
            //     {
            //         //getRecipeIngredient should be a function of IRecipeRepo then logic build here can be moved to IngredientService
            //         ingredientsList.Add(recipe.getRecipeIngredient());
            //     }
            // }
            // if (ingredientsList == null)
            //     return NotFound();
            // var ingredientsDtoList = ingredientsList.Select(x => x.AsDto()).ToList();
            return Ok(ingredientsList);
        }
    }
}
