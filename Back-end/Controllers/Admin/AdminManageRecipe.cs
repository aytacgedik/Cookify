//using System.Collections.Generic;
//using Back_end.Data;
//using Back_end.Models;
//using Microsoft.AspNetCore.Mvc;
////Keeping this as example. This gonna be deleted later.
//namespace Controllers.AdminManageRecipeController
//{
//    [Route("admin/recipe")]
//    [ApiController]
//    public class AdminManageRecipeController:ControllerBase
//    {
//        private readonly IRecipeRepo _repository;
//        public AdminManageRecipeController(IRecipeRepo repository)
//        {
//            _repository=repository;
//        }
//        [HttpGet]
//        public ActionResult<IEnumerable<Back_end.Models.Recipe>> GetAllRecipes()
//        {
//            var recipes=_repository.GetRecipes();

//            return Ok(recipes);

//        }
//        [HttpGet("{id}")]
//         public ActionResult<Back_end.Models.Recipe> GetAllRecipes(int id)
//        {
//            var recipe=_repository.GetRecipeById(id);
//            return Ok(recipe);
//        }

//        [HttpDelete("{id}")]
//        public ActionResult<Back_end.Models.Recipe> RemoveRecipe(int id)
//        {
//            var recipes = _repository.DeleteRecipeById(id);
//            return Ok(recipes);
//        }
        
//    }
//}