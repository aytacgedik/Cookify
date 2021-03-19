namespace Back_end.Models
{
    public class Recipe
    {
        private int id { get; set; }
        private int creatorId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float rating { get; set; }
        public string tag { get; set; }
        
        public void calcNutritionalValues(){}
        public Ingredient getRecipeIngredient() => new Ingredient();
    }
}