using System.Collections.Generic;
using Back_end.Data;
using Back_end.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
//Keeping this as example. This gonna be deleted later.
namespace Back_end.Controllers
{

    public abstract class RecipeController : ControllerBase
    {
        protected readonly IRecipeRepo _recipeRepository;

        protected readonly IUserRepo _userRepository;

        protected readonly ISavedRecipeRepo _savedRecipeRepository;
        
        // public RecipeController(IRecipeRepo recipeRepository,IUserRepo userRepository)
        // {
        //     _recipeRepository = recipeRepository;
        //     _userRepository = userRepository;
        // }
        

        // public RecipeController(IRecipeRepo recipeRepository,IUserRepo userRepository,ISavedRecipeRepo repo)
        // {
        //     _recipeRepository = recipeRepository;
        //     _userRepository = userRepository;
        //     _savedRecipeRepository = repo;
        // }
        
    }
}