using System.Collections.Generic;

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
        

        public List<IngredientDto> Ingredients {get;set;} = new List<IngredientDto>();
        // public void calcNutritionalValues(){}
        // public IngredientDto getRecipeIngredient() => new IngredientDto();
    }
}