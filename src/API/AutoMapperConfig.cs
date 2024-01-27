using AutoMapper;
using System.Reflection;
using FAIS.Portal.API.Models;
using FAIS.ApplicationCore.Models;
using FAIS.ApplicationCore.Entities.Security;

namespace FAIS.Portal.API
{
    /// <summary>
    /// The automapper configuration
    /// </summary>
    public static class AutoMapperConfig 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperConfiguration"/> class.
        /// </summary>
        public static MapperConfiguration Initialize()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.RecognizePrefixes("Date");
                config.RecognizeDestinationPostfixes("Date");

                ConfigureModule(config);
            });

            return mapperConfig;
        }

        #region ModuleMapping

        /// <summary>
        /// Configures the module mapping.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        private static void ConfigureModule(IProfileExpression configuration)
        {
            configuration.CreateMap<Module, ModuleModel>();
            configuration.CreateMap<RolePermission, PermissionModel>();
        }

        #endregion ModuleMapping
    }
}
