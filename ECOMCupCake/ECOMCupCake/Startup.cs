﻿using ECOMCupCake.Data;
using ECOMCupCake.Models;
using ECOMCupCake.Models.Handlers;
using ECOMCupCake.Models.Interfaces;
using ECOMCupCake.Models.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOMCupCake
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProdDB")));
            services.AddTransient<IInventory, InventoryService>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("IdentityDB")));
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.Requirements.Add(new RequireAdminRequirement()));
            });

            services.AddScoped<IAuthorizationHandler, AdminEmailHandler>();

            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = Configuration["OAUTH:Microsoft:AppId"];
                microsoftOptions.ClientSecret = Configuration["OAUTH:Microsoft:Password"];
                microsoftOptions.CallbackPath = new Microsoft.AspNetCore.Http.PathString("/signin-microsoft");
                microsoftOptions.SaveTokens = true;
                microsoftOptions.Scope.Add("https://login.microsoftonline.com/common/oauth2/v2.0/authorize");
                microsoftOptions.ClaimsIssuer = "Microsoft";
                microsoftOptions.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                microsoftOptions.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                microsoftOptions.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                microsoftOptions.ClaimActions.MapJsonKey(ClaimTypes.StateOrProvince, "state");
                microsoftOptions.Events.OnCreatingTicket = ctx =>
                {
                    List<AuthenticationToken> tokens = ctx.Properties.GetTokens() as List<AuthenticationToken>;
                    tokens.Add(new AuthenticationToken()
                    {
                        Name = "TicketCreated",
                        Value = DateTime.UtcNow.ToString()
                    });
                    ctx.Properties.StoreTokens(tokens);
                    return Task.CompletedTask;
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

        }
    }
}
