using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Back_end.Data;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Services
{

    public class RecipeService : IRecipeService
    {

        private readonly IRecipeRepo _recipeRepository;
        private readonly IUserRepo _userRepository;


        //Recipe Service is dependent on the IRecipeRepo
        public RecipeService(IRecipeRepo recipeRepository, IUserRepo userRepository)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
        }


        private void sendEmailNotification(Recipe recipe, string tomail, string text)
        {

            try
            {
                string subject = "New " + recipe.Name + " available at Cookify";
                string body = text + ",\n" + "Cookify team";
                string FromMail = "cookify@gmail.com";
                string emailTo = tomail;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(FromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("cookify@gmail.com", "password-here");
                SmtpServer.EnableSsl = true;
                SmtpServer.SendMailAsync(mail);
            }
            catch (System.Exception ex)
            {
                //Email does not exists hence it always throws the exception
                Console.WriteLine(ex.StackTrace);
            }
        }

        public IEnumerable<RecipeDto> CreateRecipe(Recipe recipe)
        {
            var recipes = _recipeRepository.CreateRecipe(recipe);
            //why would database return null??
            // if(recipes == null)
            // {
            //     return NotFound();
            // }
            //some bussiness logic below
            foreach (var user in _userRepository.GetUsers())
            {
                sendEmailNotification(recipe, user.Email, recipe.Name);
            }
            return recipes.Select(x => x.AsDto()).ToList();
        }

        public IEnumerable<RecipeDto> DeleteRecipeById(int id)
        {
            _recipeRepository.DeleteRecipeById(id);
            return _recipeRepository.GetRecipes().Select(x => x.AsDto()).ToList();
        }

        public RecipeDto GetRecipeById(int id)
        {
            return _recipeRepository.GetRecipeById(id).AsDto();
        }

        public IEnumerable<RecipeDto> GetRecipes()
        {
            return _recipeRepository.GetRecipes().Select(x => x.AsDto()).ToList();
        }

        public RecipeDto UpdateRecipeById(int id, int creatorId, string name, string description, float rating, string tag)
        {
            return _recipeRepository.UpdateRecipeById(id, creatorId, name, description, rating, tag).AsDto();
        }
    }
}