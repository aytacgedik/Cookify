using Back_end.Dtos;
using Back_end.Models;
namespace Back_end
{
    public static class Extensions
    {
        public static UserDto AsDto(this Back_end.DatabaseModels.User user){
            return new UserDto {
                id = user.Id,
                name=user.Name,
                surname=user.Surname,
                email=user.Email,
                verified=(bool)user.Verified,
                admin=(bool)user.Admin
            };
        }

        public static UserFriendDto AsDto(this Back_end.DatabaseModels.UserFriend userFriend){
            return new UserFriendDto {
                userFollowedId=(int)userFriend.UserFollowedId,
                userFollowerId=(int)userFriend.UserFollowerId
            };
        }

         public static IngredientDto AsDto(this Ingredient ingredient){
            return new IngredientDto {
                id=ingredient.id,
                name=ingredient.name
            };
        }

        public static RecipeIngredientDto AsDto(this RecipeIngredient recipeIngredient){
            return new RecipeIngredientDto {
                id=recipeIngredient.id,
                recipeId=recipeIngredient.recipeId,
                ingredientId=recipeIngredient.ingredientId
            };
        }
         public static RecipeDto AsDto(this Recipe recipe){
            return new RecipeDto {
                id=recipe.id,
                creatorId=recipe.creatorId,
                name=recipe.name,
                description=recipe.description,
                rating=recipe.rating,
                tag=recipe.tag
            };
        }

         public static SavedRecipeDto AsDto(this SavedRecipe savedRecipe){
            return new SavedRecipeDto {
                id=savedRecipe.id,
                userId=savedRecipe.userId,
                recipeId=savedRecipe.recipeId
            };
        }
        
    }
}