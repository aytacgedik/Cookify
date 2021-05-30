using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Data
{
    public interface IIngredientRepo
    {
        IngredientDto GetIngredientById(int id);
        IEnumerable<IngredientDto> GetIngredients();
        IEnumerable<IngredientDto> ServiceSearchIngredient(string query);
        IEnumerable<IngredientDto> GetRecipeIngredients(int id);
    }
}
