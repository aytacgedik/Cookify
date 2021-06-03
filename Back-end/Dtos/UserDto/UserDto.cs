using System.Collections.Generic;
namespace Back_end.Dtos
{
    public class UserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public bool verified { get; set; }
        public bool admin { get; set; }

        public List<RecipeDto> SavedRecipes{get;set;}
        public IEnumerable<RecipeDto> generateRecommeddedRecipes() => new List<RecipeDto>();
    }
}