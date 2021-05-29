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
            return ingredient.AsDto();
        }

        public IEnumerable<IngredientDto> ServiceGetIngredients()
        {
            var ingredient = _ingredientRepository.GetIngredients();
            return ingredient.Select(x => x.AsDto()).ToList();
        }

        public IEnumerable<IngredientDto> ServiceSearchIngredient(string query)
        {
            List<IngredientDto> ingredientsToReturn = new List<IngredientDto>();
            if (!String.IsNullOrEmpty(query))
            {
                foreach (var ingredient in _ingredientRepository.GetIngredients())
                {
                    if (ingredient.Name.Contains(query))
                        ingredientsToReturn.Add(ingredient.AsDto());
                }
            }

            if (ingredientsToReturn.Count == 0)
                return null;

            return ingredientsToReturn;
        }

        public IEnumerable<IngredientDto> ServiceGenerateList(int id)
        {
            var ingredientsToReturn = _ingredientRepository.GetRecipeIngredients(id);

            if (ingredientsToReturn.Count() == 0)
                return null;

            var ingredientsDtoList = ingredientsToReturn.Select(x => x.AsDto()).ToList();
            return ingredientsDtoList;
        }
    }
}
