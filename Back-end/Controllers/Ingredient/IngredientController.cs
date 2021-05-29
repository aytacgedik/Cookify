using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    public abstract class IngredientController : ControllerBase
    {
        protected readonly IRecipeService _recipeService;
        protected readonly IIngredientService _ingredientService;
        public IngredientController(IIngredientService ingredientService, IRecipeService recipeService)
        {
            _recipeService = recipeService;
            _ingredientService = ingredientService;
        }
    }
}
