using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IIngredientService
    {
        IngredientDto GetIngredientById(int id);
        IEnumerable<IngredientDto> GetIngredients();
        IEnumerable<IngredientDto> SearchIngredient(string query);
        IEnumerable<IngredientDto> generateList(int id);
    }
}
