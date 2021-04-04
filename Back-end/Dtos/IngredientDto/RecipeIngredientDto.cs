namespace Back_end.Dtos{
    public class RecipeIngredientDto
    {
        public int id { get; set; }
        public int recipeId { get; set; }
        public int ingredientId { get; set; }
    }
}