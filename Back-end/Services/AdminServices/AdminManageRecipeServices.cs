using System.Collections.Generic;
using System.Linq;
using Back_end.Data;
using Back_end.Dtos;

namespace Back_end.Services
{
    public class AdminManageRecipeServices : IAdminManageRecipeService
    {
        private readonly IRecipeRepo _recipeRepository;

        public AdminManageRecipeServices(IRecipeRepo recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IEnumerable<RecipeDto> RemoveRecipeById(int id)
        {
            var recipes = _recipeRepository.DeleteRecipeById(id);
            return recipes.Select(x => x.AsDto()).ToList();
        }

        // public RecipeDto UpdateRecipeById(int id,
        //                                  int creatorId,
        //                                  string name,
        //                                  string description,
        //                                  float rating,
        //                                  string tag)
        // {
        //     //var recipe = _recipeRepository.UpdateRecipeById(id, creatorId, name, description, rating, tag);
        //     return //recipe.AsDto();
        // }

        public RecipeDto GetRecipeById(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);
            return recipe.AsDto();
        }

        public IEnumerable<RecipeDto> GetRecipes()
        {
            var recipes = _recipeRepository.GetRecipes();
            return recipes.Select(x => x.AsDto()).ToList();
        }

        public RecipeDto UpdateRecipeById(int id, int creatorId, string name, string description, float rating, string tag)
        {
            throw new System.NotImplementedException();
        }
    }
}