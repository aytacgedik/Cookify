using Back_end.Dtos;
using Back_end.DatabaseModels;
namespace Back_end
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                id = user.Id,
                name = user.Name,
                surname = user.Surname,
                email = user.Email,
                verified = (bool)user.Verified,
                admin = (bool)user.Admin
            };
        }

        public static UserFriendDto AsDto(this UserFriend userFriend)
        {
            return new UserFriendDto
            {
                userFollowedId = (int)userFriend.UserFollowedId,
                userFollowerId = (int)userFriend.UserFollowerId
            };
        }

        public static IngredientDto AsDto(this Ingredient ingredient)
        {
            return new IngredientDto
            {
                id = ingredient.Id,
                name = ingredient.Name
            };
        }

        public static RecipeIngredientDto AsDto(this RecipeIngredient recipeIngredient)
        {
            return new RecipeIngredientDto
            {
                id = recipeIngredient.Id,
                recipeId = (int)recipeIngredient.RecipeId,
                ingredientId = (int)recipeIngredient.IngredientId
            };
        }

        public static RecipeDto AsDto(this Recipe recipe)
        {
            return new RecipeDto
            {
                id = recipe.Id,
                creatorId = (int)recipe.CreatorId,
                name = recipe.Name,
                description = recipe.Description,
                rating = (float)recipe.Rating,
                tag = recipe.Tag
            };
        }

        public static SavedRecipeDto AsDto(this SavedRecipe savedRecipe)
        {
            return new SavedRecipeDto
            {
                id = savedRecipe.Id,
                userId = (int)savedRecipe.UserId,
                recipeId = (int)savedRecipe.RecipeId
            };
        }

    }
}