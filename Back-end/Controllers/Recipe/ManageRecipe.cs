using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Back_end.DatabaseModels;
using System.Net.Mail;
using System;
using System.Linq;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class ManageRecipe : RecipeController
    {
        private readonly IRecipeService _recipeService;

        private readonly IUserService _userService;
        public ManageRecipe(IRecipeService recipeService, IUserService userService)
        {
            _recipeService = recipeService;
            _userService = userService;
        }

        //private sendEmailNotification()
        //moved to services
        //  private void sendEmailNotification(Recipe recipe,string tomail, string text)
        // {

        //     try
        //     {
        //         string subject = "New " + recipe.name + " available at Cookify" ;
        //         string body =  text + ",\n" + "Cookify team";
        //         string FromMail = "cookify@gmail.com";
        //         string emailTo = tomail;
        //         MailMessage mail = new MailMessage();
        //         SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //         mail.From = new MailAddress(FromMail);
        //         mail.To.Add(emailTo);
        //         mail.Subject = subject;
        //         mail.Body = body;
        //         SmtpServer.Port = 25; 
        //         SmtpServer.Credentials = new System.Net.NetworkCredential("cookify@gmail.com", "password-here");
        //         SmtpServer.EnableSsl = true;
        //         SmtpServer.SendMailAsync(mail);
        //     }
        //     catch (System.Exception ex)
        //     {
        //         //Email does not exists hence it always throws the exception
        //         Console.WriteLine(ex.StackTrace);
        //     }


        // }


        //POST - createRecipe()
        [HttpPost]
        public ActionResult<IEnumerable<RecipeDto>> createRecipe([FromBody]Recipe recipe)
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

            return Ok(_recipeService.CreateRecipe(recipe));
        }

        //DELETE{id} - removeRecipe() 
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<RecipeDto>> removeRecipe(int id)
        {
            //DELETE operation to be done from the database
            var result = _recipeService.DeleteRecipeById(id);
            if(result == null)
            {
                return NotFound();
            }
            //var resultDto = result.Select(x => x.AsDto()).ToList();
            return Ok(result);
        }

        //PATCH/PUT{id} - updateRecipe()
        [HttpPatch]
        public ActionResult<Recipe> updateRecipe([FromBody] Recipe recipe)
        {
            //recipe json passed from front-end
            //find object from recipe.id
            //set all other fields of found object to recipe fields
            var result = _recipeService.UpdateRecipeById(recipe.Id,(int)recipe.CreatorId,recipe.Name,recipe.Description,(float)recipe.Rating,recipe.Tag);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //GET{all} - getRecipe()
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> getRecipe()
        {
            var result= _recipeService.GetRecipes();
            if(result == null)
            {
                return NotFound();
            }
            //var resultDto = result.Select(x => x.AsDto()).ToList();
            return Ok(result);

        }

        //GET{id} - getRecipes()
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Recipe>> getRecipe(int id)
        {
            var result= _recipeService.GetRecipeById(id);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
    }
}