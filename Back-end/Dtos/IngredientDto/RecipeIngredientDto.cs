namespace Back_end.Dtos{
    public class RecipeIngredient
    {
        public int id { get; set; }
        public int recipeId { get; set; }
        public int ingredientId { get; set; }
    }
}