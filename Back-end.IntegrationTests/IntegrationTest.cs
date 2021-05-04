using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Back_end.Controllers;
using Back_end.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace Back_end.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();
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
