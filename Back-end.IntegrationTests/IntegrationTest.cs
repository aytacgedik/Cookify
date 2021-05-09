using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace Back_end.IntegrationTests
{
    public class IntegrationTest
    {

        //set true if you are testing for local docker. However using local docker may cause exceptions about SSL.
        //ofc it is windows issue https://stackoverflow.com/questions/64610237/net-5-0-cannot-determine-the-frame-size-or-a-corrupted-frame-was-received
        readonly bool DOCKER = false;
        protected readonly HttpClient TestClient;
        //protected readonly string  ApiRoute = "http://localhost:5001/";
        protected IntegrationTest()
        {
            if(DOCKER)
                TestClient = new HttpClient(){
                BaseAddress = new Uri("https://localhost:5000"),
                
                };
            else  
                TestClient = new HttpClient(){
                BaseAddress = new Uri("https://cookify.azurewebsites.net")
                };
            
        }

        // [Fact]
        // public async Task Test1()
        // {
        //     var response = await TestClient.GetAsync("api/recipes/{id}".Replace("{id}","1"));
        //     //We need the authorization set up for these request to work later 

        // }

        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            var response =await TestClient.PostAsJsonAsync("api/sessions", new SessionCredentials{
                Email = "james@gg.com"
            });
            var registrationResponse = await response.Content.ReadAsStringAsync();
            return registrationResponse;
        }


    }
}
