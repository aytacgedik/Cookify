using System;
using System.Collections.Generic;

#nullable disable

namespace Back_end.DatabaseModels
{
    public partial class User
    {
        public User()
        {
            Recipes = new HashSet<Recipe>();
            SavedRecipes = new HashSet<SavedRecipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool? Verified { get; set; }
        public bool? Admin { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<SavedRecipe> SavedRecipes { get; set; }
    }
}
