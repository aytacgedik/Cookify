using System.Collections.Generic;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
//Keeping this as example. This gonna be deleted later.
namespace Back_end.Controllers
{

    public abstract class RecipeController : ControllerBase
    {
        protected readonly IRecipeRepo _repository;
        
        public RecipeController(IRecipeRepo repository)
        {
            _repository = repository;
        }
        
    }
}