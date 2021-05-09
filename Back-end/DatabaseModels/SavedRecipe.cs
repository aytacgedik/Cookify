using System;
using System.Collections.Generic;

#nullable disable

namespace Back_end.DatabaseModels
{
    public partial class SavedRecipe
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
