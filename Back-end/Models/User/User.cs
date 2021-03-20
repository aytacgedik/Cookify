using System.Collections.Generic;
namespace Back_end.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public bool verified { get; set; }
        public bool admin { get; set; }

        //Given specification is not correct
        public IEnumerable<Recipe> generateRecommeddedRecipes() => new List<Recipe>();
    }
}