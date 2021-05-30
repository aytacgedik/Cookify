using System;
using System.Collections.Generic;
using System.Linq;
using Back_end.Data;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Services
{
    public class IngredientServices : IIngredientService
    {
        private readonly IIngredientRepo _ingredientRepository;

        public IngredientServices(IIngredientRepo ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IngredientDto ServiceGetIngredientById(int id)
        {
            var ingredient = _ingredientRepository.GetIngredientById(id);
            if(ingredient == null)
                return null;
            return ingredient;
        }

        public IEnumerable<IngredientDto> ServiceGetIngredients()
        {
            var ingredient = _ingredientRepository.GetIngredients();
            if (ingredient == null)
                return null;
            return ingredient.Select(x => x).ToList();
        }

        public IEnumerable<IngredientDto> ServiceSearchIngredient(string query)
        {
            List<IngredientDto> ingredientsToReturn = _ingredientRepository.ServiceSearchIngredient(query).ToList();

            if (ingredientsToReturn == null)
                return null;

            return ingredientsToReturn;
        }

        public IEnumerable<IngredientDto> ServiceGenerateList(int id)
        {
            var ingredientsToReturn = _ingredientRepository.GetRecipeIngredients(id);

            if (ingredientsToReturn == null)
                return null;

            var ingredientsDtoList = ingredientsToReturn.Select(x => x).ToList();
            return ingredientsDtoList;
        }
    }
}
