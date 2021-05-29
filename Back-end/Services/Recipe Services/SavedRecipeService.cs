using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Back_end.Data;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Services
{

    public class SavedRecipeService : ISavedRecipeService
    {

        private readonly ISavedRecipeRepo _savedRecipeRepository;



        //Recipe Service is dependent on the IRecipeRepo
        public SavedRecipeService(ISavedRecipeRepo savedRecipeRepository)
        {
            _savedRecipeRepository = savedRecipeRepository;
        }

        public IEnumerable<SavedRecipeDto> ServiceCreateSavedRecipe(SavedRecipe r)
        {
            return _savedRecipeRepository.CreateSavedRecipe(r).Select(x=>x.AsDto()).ToList();
        }

        public IEnumerable<SavedRecipeDto> ServiceGetSavedRecipes()
        {
            return _savedRecipeRepository.GetSavedRecipes().Select(x=>x.AsDto()).ToList();
        }
    }
}