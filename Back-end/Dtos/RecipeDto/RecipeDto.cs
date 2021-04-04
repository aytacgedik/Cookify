namespace Back_end.Dtos
{
    public class RecipeDto
    {
        public int id { get; set; }
        public int creatorId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float rating { get; set; }
        public string tag { get; set; }
        
        public void calcNutritionalValues(){}
        public IngredientDto getRecipeIngredient() => new IngredientDto();
    }
}