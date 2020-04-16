using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VehicleHistory.Logic.Models.Mappings;
using VehicleHistory.Logic.DB;
using VehicleHistory.Logic.Middlewares;
using VehicleHistory.Logic.Models.Utility;
using VehicleHistory.Logic.Services.Implementations;
using VehicleHistory.Logic.Services.Interfaces;

namespace VehicleHistory.WebApi
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
        	services.AddCors();
            services.AddSession();
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "127.0.0.1";
            });
            
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var appSettings = appSettingsSection.Get<AppSettings>();
            services.AddCors();
            services.AddDbContext<VehicleHistoryContext>(x => x.UseSqlServer(appSettings.ConnectionString));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMappings());
                mc.AddProfile(new DictionaryItemsMappings());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            // configure jwt authentication
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userService = context.HttpContext.RequestServices.GetRequiredService<IUsersService>();
                            var userId = context.Principal.Identity.Name;
                            var user = userService.GetUserById(userId);
                            if (user == null)
                            {
                                context.Fail("Unauthorized");
                            }
                            return Task.CompletedTask;
                        }
                    };
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
            
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IDictionaryService, DictionaryService>();
            services.AddTransient<IEmailSender, EmailService>();
            services.AddTransient<TokenManagerMiddleware>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ITokenService, TokenService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseMiddleware<TokenManagerMiddleware>();
            app.UseSession();
            app.UseMvc();
        }
    }
}
