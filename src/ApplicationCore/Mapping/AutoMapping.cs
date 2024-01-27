using AutoMapper;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
namespace FAIS.ApplicationCore.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<RolePermission, PermissionModel>();
        }        
    }
}
