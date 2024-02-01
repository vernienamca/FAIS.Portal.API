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
using AutoMapper;
using FAIS.ApplicationCore.Mapping;

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

            services.AddAutoMapper(map => map.AddProfile(new AutoMapping()), typeof(AutoMapping));

            services.AddScoped(typeof(IAuditLogRepository), typeof(AuditLogRepository));
            services.AddScoped(typeof(IModuleRepository), typeof(ModuleRepository));
            services.AddScoped(typeof(ISettingsRepository), typeof(SettingsRepository));
            services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
            services.AddScoped(typeof(ILibraryTypeRepository), typeof(LibraryTypeRepository));
            services.AddScoped(typeof(ILoginHistoryRepository), typeof(LoginHistoryRepository));
            services.AddScoped(typeof(INotificationRepository), typeof(NotificationRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
            services.AddScoped(typeof(IProformaEntriesRepository), typeof(ProformaEntriesRepository));
            services.AddScoped(typeof(IVersionsRepository), typeof(VersionsRepository));

            services.AddScoped(typeof(IAuditLogService), typeof(AuditLogService));
            services.AddScoped(typeof(IModuleService), typeof(ModuleService));
            services.AddScoped(typeof(ISettingsService), typeof(SettingsService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(ILibraryTypeService), typeof(LibraryTypeService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped(typeof(INotificationService), typeof(NotificationService));
            services.AddScoped(typeof(IUserRoleService), typeof(UserRoleService));
            services.AddScoped(typeof(IUserRoleRepository), typeof(UserRoleRepository));
            services.AddScoped(typeof(IPermissionService), typeof(PermissionService));
            services.AddScoped(typeof(IProformaEntriesService), typeof(ProformaEntriesService));
            services.AddScoped(typeof(IVersionService), typeof(VersionService));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FAIS Portal API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
              .AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed((host) => true)
              .AllowCredentials()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FAIS Portal API");
                c.RoutePrefix = "swagger";
            });
        }
    }
}
