//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Back_end.Data;
//using Back_end.Models;

//namespace Back_end.Controllers
//{
//    [Route("api/ingredients/list")]
//    [ApiController]
//    public class IngredientsListCreator : IngredientController
//    {
//        public IngredientsListCreator(IRecipeRepo recipeRepository, IIngredientRepo ingredientRepository) : base(recipeRepository, ingredientRepository)
//        {

//        }

//        [HttpGet]
//        public ActionResult generateList([FromQuery] int id)
//        {
//            List<Ingredient> ingredientsList = new List<Ingredient>();
//            foreach (var recipe in _recipeRepository.GetRecipes())
//            {
//                if (recipe.id == id)
//                {
//                    ingredientsList.Add(recipe.getRecipeIngredient());
//                }
//            }

//            return Ok(ingredientsList);
//        }
//    }
//}
