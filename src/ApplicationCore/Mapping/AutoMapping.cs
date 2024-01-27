using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System;

namespace FAIS.ApplicationCore.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Role, RoleModel>();
            CreateMap<Role, RoleDTO>();
            CreateMap<RolePermission, PermissionModel>();
            CreateMap<RolePermission, PermissionDTO>();
        }        
    }
}
