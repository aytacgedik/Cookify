namespace Back_end.Models
{
    public class RecipeIngredient
    {
        public int id { get; set; }
        public int recipeId { get; set; }
        public int ingredientId { get; set; }
    }
}