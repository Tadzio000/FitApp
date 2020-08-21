using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Helpers;
using WebApi.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using Microsoft.OpenApi.Models;
using WebApi.Entities;
using Microsoft.Extensions.Hosting.Internal;

namespace WebApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddCors();
            services.AddControllers();

             // Use a PostgreSQL database
            var sqlConnectionString = Configuration.GetConnectionString("AmazonRDS");

            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(sqlConnectionString));

            // AutoMapper
            services.AddAutoMapper(typeof(Startup));


            // Swagger

            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger App Demo", Version = "v1" });
            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IExerciseService, ExerciseService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {

                dataContext.Database.Migrate();
                app.UseRouting();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger App Demo V1");
                });

                // global cors policy
                app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                app.UseAuthentication();
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

        }
    }
}
