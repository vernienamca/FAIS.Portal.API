using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;

namespace FAIS.ApplicationCore.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Role, RoleModel>();
            CreateMap<Role, RoleDTO>();
            CreateMap<AddPermissionDTO, RolePermission>()
                .ForMember(x => x.IsCreate, opt => opt.MapFrom(s => s.IsCreate ? 'Y' : 'N'))
                .ForMember(x => x.IsUpdate, opt => opt.MapFrom(s => s.IsUpdate ? 'Y' : 'N'))
                .ForMember(x => x.IsRead, opt => opt.MapFrom(s => s.IsRead ? 'Y' : 'N')).ReverseMap();
            CreateMap<PermissionDTO, RolePermission>()
                .ForMember(x => x.IsCreate, opt => opt.MapFrom(s => s.IsCreate ? 'Y' : 'N'))
                .ForMember(x => x.IsUpdate, opt => opt.MapFrom(s => s.IsUpdate ? 'Y' : 'N'))
                .ForMember(x => x.IsRead, opt => opt.MapFrom(s => s.IsRead ? 'Y' : 'N')).ReverseMap();
            CreateMap<UpdatePermissionDTO, RolePermission>()
                .ForMember(x => x.IsCreate, opt => opt.MapFrom(s => s.IsCreate ? 'Y' : 'N'))
                .ForMember(x => x.IsUpdate, opt => opt.MapFrom(s => s.IsUpdate ? 'Y' : 'N'))
                .ForMember(x => x.IsRead, opt => opt.MapFrom(s => s.IsRead ? 'Y' : 'N')).ReverseMap();
            CreateMap<ProformaEntriesDTO, ProformaEntries>();
            CreateMap<UpdateProformaEntriesDTO, ProformaEntries>();
            CreateMap<StringInterpolationDTO, StringInterpolation>();
            CreateMap<AddStringInterpolationDTO, StringInterpolation>()
                .ForMember(x => x.IsActive, opt => opt.MapFrom(s => s.IsActive ? 'Y' : 'N'));
            CreateMap<CostCenterDTO, CostCenter>();
            CreateMap<VersionModel, Versions>().ReverseMap();
            CreateMap<VersionDTO, Versions>().ReverseMap();
            CreateMap<AddVersionDTO, Versions>().ReverseMap();
            CreateMap<ChartOfAccountsDTO, ChartOfAccounts>();
            CreateMap<ChartOfAccountDetailsDTO, ChartOfAccountDetails>();
            CreateMap<LibraryTypeDTO, LibraryType>();
            CreateMap<AddLibraryTypeDTO, LibraryType>()
                .ForMember(x => x.IsActive, opt => opt.MapFrom(s => s.IsActive ? 'Y' : 'N'));
        }

            CreateMap<LibraryOptions, LibraryOptionAddDto>().ReverseMap();
            CreateMap<LibraryOptions, LibraryOptionModel>().ReverseMap();
        }        
    }
}