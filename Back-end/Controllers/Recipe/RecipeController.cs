using System.Collections.Generic;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
//Keeping this as example. This gonna be deleted later.
namespace Controllers.Recipe
{

    public abstract class RecipeController:ControllerBase
    {
        protected readonly IRecipeRepo _repository;
        
        
    }
}