using Microsoft.AspNetCore.Mvc;
using Back_end.Models;
using System.Collections.Generic;
using Back_end.Data;
using System.Net.Mail;
using System;

namespace Back_end.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class ManageRecipe : RecipeController
    {
        public ManageRecipe(IRecipeRepo recipeRepository,IUserRepo userRepository):base(recipeRepository,userRepository)
        {
            
        }

        //private sendEmailNotification()
         private void sendEmailNotification(Recipe recipe,string tomail, string text)
        {

            try
            {
                string subject = "New " + recipe.name + " available at Cookify" ;
                string body =  text + ",\n" + "Cookify team";
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


        //POST - createRecipe()
        [HttpPost]
        public IActionResult createRecipe([FromBody]Recipe recipe)
        {
            //return what is going to be added to database for now
            //later we will do an insert on the database
            //send mail notification
            //var recipeJSON = Newtonsoft.Json.JsonConvert.SerializeObject(recipe);
            //System.Console.WriteLine(recipeJSON);
            //foreach(var user in _userRepository.GetUsers())
            //{
            //    sendEmailNotification(recipe,user.email,recipeJSON);                
            //}

            return Ok(recipe);
        }

        //DELETE{id} - removeRecipe() 
        [HttpDelete("{id}")]
        public ActionResult removeRecipe(int id)
        {
            //DELETE operation to be done from the database
            return Ok();
        }

        //PATCH/PUT{id} - updateRecipe()
        [HttpPatch("{id}")]
        public ActionResult updateRecipe([FromBody] Recipe recipe)
        {
            //recipe json passed from front-end
            //find object from recipe.id
            //set all other fields of found object to recipe fields
            return Ok(recipe);
        }

        //GET{all} - getRecipe()
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> getRecipe()
        {
            var users= base._recipeRepository.GetRecipes();

            return Ok(users);

        }

        //GET{id} - getRecipes()
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Recipe>> getRecipe(int id)
        {
            var user= base._recipeRepository.GetRecipeById(id);

            return Ok(user);

        }
    }
}