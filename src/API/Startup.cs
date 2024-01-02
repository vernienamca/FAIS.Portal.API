using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using FAIS.Infrastructure.Data;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Services;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;

namespace FAIS
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

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = "http://localhost:55653",
                   ValidAudience = "http://localhost:55653",
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"))
               };
            });

            services.AddControllers();

            services.AddDbContext<FAISContext>(options =>
            {
                options.UseOracle(Configuration.GetConnectionString("DefaultConnection"), oracleOptions =>
                {
                    oracleOptions.UseOracleSQLCompatibility("11");
                })
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });



            services.Configure<TokenKeys>(Configuration.GetSection("TokenOptions"));

            services.AddScoped(typeof(IAuditLogRepository), typeof(AuditLogRepository));
            services.AddScoped(typeof(IModuleRepository), typeof(ModuleRepository));
            services.AddScoped(typeof(ISettingsRepository), typeof(SettingsRepository));
            services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(ILibraryTypeRepository), typeof(LibraryTypeRepository));
            services.AddScoped(typeof(ILoginHistoryRepository), typeof(LoginHistoryRepository));

            services.AddScoped(typeof(IAuditLogService), typeof(AuditLogService));
            services.AddScoped(typeof(IModuleService), typeof(ModuleService));
            services.AddScoped(typeof(ISettingsService), typeof(SettingsService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(ILibraryTypeService), typeof(LibraryTypeService));
            services.AddScoped<IEmailService, EmailService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Title", Version = "v1" });

             
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(
                options => options.WithOrigins("localhost:4200").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Title V1");
                c.RoutePrefix = "swagger";
            });
        }
    }
}
