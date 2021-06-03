using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IIngredientService
    {
        IngredientDto ServiceGetIngredientById(int id);
        IEnumerable<IngredientDto> ServiceGetIngredients();
        IEnumerable<IngredientDto> ServiceSearchIngredient(string query);
        IEnumerable<IngredientDto> ServiceGenerateList(int id);
    }
}
