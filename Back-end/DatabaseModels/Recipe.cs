using System;
using System.Collections.Generic;

#nullable disable

namespace Back_end.DatabaseModels
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
            SavedRecipes = new HashSet<SavedRecipe>();
        }

        public int Id { get; set; }
        public int? CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Rating { get; set; }
        public string Tag { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<SavedRecipe> SavedRecipes { get; set; }
    }
}
