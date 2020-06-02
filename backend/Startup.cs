using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TrainingFoodAnalyser.Models;
using TrainingFoodAnalyser.Data;
using TrainingFoodAnalyser.Extensions;
using TrainingFoodAnalyser.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrainingFoodAnalyser.Services.MainServices;
using TrainingFoodAnalyser.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace TrainingFoodAnalyser
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
            #region Add CORS  
			services.AddCors(options => options.AddPolicy("Cors", builder =>
			{
				builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
    			.AllowCredentials();// nzm
			}));
			#endregion

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMvc().
				SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IFoodRepository, FoodRepository>();
			services.AddScoped<ITrainingRepository, TrainingRepository>();

			services.AddScoped<IFoodService,FoodService>();
			services.AddScoped<ITrainingService,TrainingService>();

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddSingleton<IConfiguration>(provider => Configuration);
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddTransient<ITokenService, TokenService>();
			services.AddTransient<IPasswordHasher, PasswordHasher>();
			
			

			services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aktivnost i ishrana API", Version = "v1" });
            
			});

		
            services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;

				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = false,
					ValidateIssuer = false,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes
				};

				options.Events = new JwtBearerEvents
				{
					OnAuthenticationFailed = context =>
					{
						if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
						{
							context.Response.Headers.Add("Token-Expired", "true");
						}
						return Task.CompletedTask;
					}
				};
			});

            services.AddHttpContextAccessor();
            services.AddDataProtection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
			app.UseSwagger();
			app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aktivnost i ishrana API V1");
                c.RoutePrefix = "docs";
            });

			
			app.UseAuthentication();
            app.UseCors(builder => builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
    			.AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();

        }
    }
}
