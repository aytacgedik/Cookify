using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IAdminManageRecipeService
    {
        IEnumerable<RecipeDto> RemoveRecipeById(int id);
        RecipeDto UpdateRecipeById(RecipeDto r);
        RecipeDto GetRecipeById(int id);
        IEnumerable<RecipeDto> GetRecipes();
    }
}