using System;
using System.Collections.Generic;

#nullable disable

namespace Back_end.DatabaseModels
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
