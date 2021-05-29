using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IAdminManageRecipeService
    {
        IEnumerable<RecipeDto> RemoveRecipeById(int id);
        RecipeDto UpdateRecipeById(int id,
                                   int creatorId,
                                   string name,
                                   string description,
                                   float rating,
                                   string tag);
        RecipeDto GetRecipeById(int id);
        IEnumerable<RecipeDto> GetRecipes();
    }
}