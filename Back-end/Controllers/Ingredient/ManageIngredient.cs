//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Back_end.Data;
//using Back_end.Models;

//namespace Back_end.Controllers
//{
//    [Route("api/ingredient")]
//    [ApiController]
//    public class ManageIngredient : IngredientController
//    {
//        public ManageIngredient(IRecipeRepo recipeRepository, IIngredientRepo ingredientRepository) : base(recipeRepository, ingredientRepository)
//        {

//        }

//        //GET{all} - getIngredient()
//        [HttpGet]
//        public ActionResult<IEnumerable<Recipe>> getRecipe()
//        {
//            var ingredient = base._ingredientRepository.GetIngredients();

//            return Ok(ingredient);

//        }

//        //GET{id} - getIngredient()
//        [HttpGet("{id}")]
//        public ActionResult<IEnumerable<Ingredient>> getIngredient(int id)
//        {
//            var ingredient = base._ingredientRepository.GetIngredientById(id);

//            return Ok(ingredient);

//        }
//    }
//}
