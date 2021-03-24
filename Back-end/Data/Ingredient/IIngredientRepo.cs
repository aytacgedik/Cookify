using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public interface IIngredientRepo
    {
        Ingredient GetIngredientById(int id);
        IEnumerable<Ingredient> GetIngredients();
    }
}
