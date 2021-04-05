using System;
using System.Collections.Generic;

#nullable disable

namespace Back_end.Models
{
    public partial class User
    {
        public User()
        {
            Recipes = new HashSet<Recipe>();
            SavedRecipes = new HashSet<SavedRecipe>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Isverified { get; set; }
        public bool Isadmin { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<SavedRecipe> SavedRecipes { get; set; }
    }
}
