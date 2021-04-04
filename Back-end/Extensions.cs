using Back_end.Dtos;
using Back_end.Models;
namespace Back_end
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user){
            return new UserDto {
                id = user.id,
                name=user.name,
                surname=user.surname,
                email=user.email,
                verified=user.verified,
                admin=user.admin
            };
        }

        public static UserFriendDto AsDto(this UserFriend userFriend){
            return new UserFriendDto {
                userFollowedId=userFriend.userFollowedId,
                userFollowerId=userFriend.userFollowerId
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