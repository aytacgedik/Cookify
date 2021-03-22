namespace Back_end.Models
{
    public class Recipe
    {
        public int id { get; set; }
        public int creatorId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float rating { get; set; }
        public string tag { get; set; }
        
        public void calcNutritionalValues(){}
        public Ingredient getRecipeIngredient() => new Ingredient();
    }
}