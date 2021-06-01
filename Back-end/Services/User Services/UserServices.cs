using System.Collections.Generic;
using System.Linq;
using Back_end.Data;
using Back_end.Dtos;

namespace Back_end.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepo _userRepository;
        private readonly ISavedRecipeService _savedRecipeService;

        private readonly IIngredientService _ingredientService;


        public UserServices(IUserRepo userRepository,ISavedRecipeService savedRecipeService,IIngredientService ingredientService)
        {
            _userRepository = userRepository;
            _savedRecipeService = savedRecipeService;
            _ingredientService = ingredientService;
        }

        public IEnumerable<UserDto> ServiceCreateUser(UserInputDto _user)
        {
            var users = _userRepository.CreateUser(_user);
            return ServiceGetUsers();
        }

        public IEnumerable<UserDto> ServiceRemoveUserById(int id)
        {
            var users = _userRepository.RemoveUserById(id);
            return users.Select(x => x).ToList();
        }

        public UserDto ServiceUpdateUserById(int id, UserInputDto _user)
        {
            var user = _userRepository.UpdateUserById(id,_user);
            return ServiceGetUserById(user.id);
        }

        public UserDto ServiceGetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null)
                return null;
            user.SavedRecipes = _savedRecipeService.ServiceGetUserSavedRecipes(id).ToList();
            foreach (var item in user.SavedRecipes)
            {
                item.Ingredients = _ingredientService.ServiceGenerateList(item.id).ToList();
            }
            return user;
        }

        public IEnumerable<UserDto> ServiceGetUsers()
        {
            var users = _userRepository.GetUsers();
            var realthingtoReturn = new List<UserDto>();
            foreach (var item in users)
            {
                realthingtoReturn.Add(ServiceGetUserById(item.id));
            }
            return realthingtoReturn;
        }
    }
}