using System.Collections.Generic;
using Back_end.DatabaseModels;

namespace Back_end.Data
{
    public interface IIngredientRepo
    {
        Ingredient GetIngredientById(int id);
        IEnumerable<Ingredient> GetIngredients();
        IEnumerable<Ingredient> GetRecipeIngredients(int id);
    }
}
