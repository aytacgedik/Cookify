using System;
using System.Collections.Generic;

#nullable disable

namespace Back_end.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
            SavedRecipes = new HashSet<SavedRecipe>();
        }

        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public float? Rating { get; set; }
        public string Tag { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<SavedRecipe> SavedRecipes { get; set; }
    }
}
