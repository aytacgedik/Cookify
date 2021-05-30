namespace Back_end.IntegrationTests.GroupHModels
{
    public class Recipe
    {
        public int recipeId { get; set; }
        public int creatorId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float rating { get; set; }
        public string tag { get; set; }
    }
}