using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Back_end.Controllers;

using Back_end.DatabaseModels;
using Back_end.Services;

namespace Back_end
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Back_end", Version = "v1" });


                c.AddSecurityDefinition("Bearer",  new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });


            });

            //Change this later
            services.AddDbContext<CookifyContext>();//NEW

            services.AddScoped<IUserRepo,MockUserRepo>();
            services.AddScoped<IUserFriendRepo,MockUserFriendRepo>();
            services.AddScoped<IRecipeRepo,MockRecipeRepo>();
            services.AddScoped<ISavedRecipeRepo,MockSavedRecipeRepo>();
            services.AddScoped<IIngredientRepo, MockIngredientRepo>();

            services.AddScoped<IUserService,UserServices>();//NEW
            services.AddScoped<IUserFriendService,UserFriendServices>();//NEW

            services.AddScoped<IAdminManageUserService,AdminManageUserServices>();
            services.AddScoped<IAdminManageRecipeService,AdminManageRecipeServices>();

            services.AddScoped<IIngredientService, IngredientServices>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<ISavedRecipeService, SavedRecipeService>();

            var key = "this is a string used for encrypt and decrypt token";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
                cfg.AddPolicy("User", policy => policy.RequireClaim("type", "User"));

            });

            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(key,new CookifyContext()));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json", "Back_end v1");});
            if(env.IsDevelopment()){//for docker
                app.UseHttpsRedirection();
            }
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
