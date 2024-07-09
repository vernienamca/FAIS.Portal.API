using AutoMapper;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Interfaces.Services;
using FAIS.ApplicationCore.Mapping;
using FAIS.ApplicationCore.Services;
using FAIS.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

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
            services.AddScoped(typeof(ILibraryOptionRepository), typeof(LibraryOptionRepository));
            services.AddScoped(typeof(ILoginHistoryRepository), typeof(LoginHistoryRepository));
            services.AddScoped(typeof(IStringInterpolationRepository), typeof(StringInterpolationRepository));
            services.AddScoped(typeof(ITemplateRepository), typeof(TemplateRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
            services.AddScoped(typeof(IProformaEntriesRepository), typeof(ProformaEntriesRepository));
            services.AddScoped(typeof(IProformaEntryDetailsRepository), typeof(ProformaEntryDetailsRepository));
            services.AddScoped(typeof(ICostCenterRepository), typeof(CostCenterRepository));
            services.AddScoped(typeof(IChartOfAccountsRepository), typeof(ChartOfAccountsRepository));
            services.AddScoped(typeof(IChartOfAccountDetailsRepository), typeof(ChartOfAccountDetailsRepository));
            services.AddScoped(typeof(IVersionsRepository), typeof(VersionsRepository));
            services.AddScoped(typeof(IAssetProfileRepository), typeof(AssetProfileRepository));
            services.AddScoped(typeof(IMeteringProfileRepository), typeof(MeteringProfilesRepository));
            services.AddScoped(typeof(IProjectProfileRepository), typeof(ProjectProfilesRepository));
            services.AddScoped(typeof(IProjectProfileComponentsRepository), typeof(ProjectProfileComponentsRepository));
            services.AddScoped(typeof(ITransmissionLineProfileRepository), typeof(TransmissionLineProfileRepository));
            services.AddScoped(typeof(IPlantInformationRepository), typeof(PlantInformationRepository));
            services.AddScoped(typeof(IPlantInformationDetailsRepository), typeof(PlantInformationDetailsRepository));
            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            services.AddScoped(typeof(IAmrRepository), typeof(AmrRepository));
            services.AddScoped(typeof(IAmr100BatchRepository), typeof(Amr100BatchRepository));
            services.AddScoped(typeof(IAmr100BatchDRepository), typeof(Amr100BatchDRepository));
            services.AddScoped(typeof(IAmr100BatchDbdRepository), typeof(Amr100BatchDbdRepository));
            services.AddScoped(typeof(IFieldDictionaryRepository), typeof(FieldDictionaryRepository));
            services.AddScoped(typeof(IBusinessProcessRepository), typeof(BusinessProcessRepository));
            services.AddScoped(typeof(IDefinedTablesRepository), typeof(DefinedTablesRepository));
            services.AddScoped(typeof(IDefinedTableColumnsRepository), typeof(DefinedTableColumnsRepository));
            services.AddScoped(typeof(IDepreciationMethodsRepository), typeof(DepreciationMethodsRepository));
            services.AddScoped(typeof(IDefinedMethodFieldDictionaryRepository), typeof(DefinedMethodFiledDictionaryRepository));
            services.AddScoped(typeof(IStepContatinerRepository), typeof(StepContainerRepository));

            services.AddScoped(typeof(IAuditLogService), typeof(AuditLogService));
            services.AddScoped(typeof(IModuleService), typeof(ModuleService));
            services.AddScoped(typeof(ISettingsService), typeof(SettingsService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(ILibraryTypeService), typeof(LibraryTypeService));
            services.AddScoped(typeof(ILibraryOptionService), typeof(LibraryOptionService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped(typeof(INotificationService), typeof(NotificationService));
            services.AddScoped(typeof(IUserRoleService), typeof(UserRoleService));
            services.AddScoped(typeof(IUserRoleRepository), typeof(UserRoleRepository));
            services.AddScoped(typeof(IPermissionService), typeof(PermissionService));
            services.AddScoped(typeof(IProformaEntriesService), typeof(ProformaEntriesService));
            services.AddScoped(typeof(IProformaEntryDetailsService), typeof(ProformaEntryDetailsService));
            services.AddScoped(typeof(ICostCenterService), typeof(CostCenterService));
            services.AddScoped(typeof(IChartOfAccountsService), typeof(ChartOfAccountsService));
            services.AddScoped(typeof(IVersionService), typeof(VersionService));
            services.AddScoped(typeof(IAssetProfileService), typeof(AssetProfileService));
            services.AddScoped(typeof(IMeteringProfileService), typeof(MeteringProfileService));
            services.AddScoped(typeof(IProjectProfileService), typeof(ProjectProfileService));
            services.AddScoped(typeof(IProjectProfileComponentService), typeof(ProjectProfileComponentService));
            services.AddScoped(typeof(ITransmissionLineProfileService), typeof(TransmissionLineProfileService));
            services.AddScoped(typeof(IPlantInformationService), typeof(PlantInformationService));
            services.AddScoped(typeof(IAmrService), typeof(AmrService));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FAIS Portal API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Please enter your token with this format: Bearer 'YOUR_TOKEN'",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
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