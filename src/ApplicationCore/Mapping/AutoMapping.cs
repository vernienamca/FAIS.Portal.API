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
            CreateMap<ProformaEntryDTO, ProformaEntry>();
            CreateMap<ProformaEntryDetailDTO, ProformaEntryDetail>();
            CreateMap<StringInterpolationDTO, StringInterpolation>().ReverseMap();
            CreateMap<AddStringInterpolationDTO, StringInterpolation>().ReverseMap();
            CreateMap<UpdateStringInterpolationDTO, StringInterpolation>().ReverseMap();
            CreateMap<TemplateDTO, Template>().ReverseMap();
            CreateMap<AddTemplateDTO, Template>().ReverseMap();
            CreateMap<UpdateTemplateDTO, Template>().ReverseMap();
            CreateMap<CostCenterDTO, CostCenter>();
            CreateMap<VersionModel, Versions>().ReverseMap();
            CreateMap<VersionDTO, Versions>().ReverseMap();
            CreateMap<AddVersionDTO, Versions>().ReverseMap();
            CreateMap<ChartOfAccountsDTO, ChartOfAccounts>();
            CreateMap<ChartOfAccountDetailsDTO, ChartOfAccountDetails>();
            CreateMap<LibraryTypeDTO, LibraryType>().ReverseMap();
            CreateMap<AddLibraryTypeDTO, LibraryType>().ReverseMap();
            CreateMap<UpdateLibraryTypeDTO, LibraryType>().ReverseMap();
            CreateMap<LibraryOptionAddDto, LibraryType>().ReverseMap();
            CreateMap<LibraryTypeModel, LibraryType>().ReverseMap();
            CreateMap<LibraryOptions, LibraryOptionAddDto>().ReverseMap();
            CreateMap<LibraryOptions, LibraryOptionUpdateDto>().ReverseMap()
                .ForMember(x => x.Remarks, opt => opt.MapFrom(s => s.Remark));
            CreateMap<LibraryOptions, LibraryOptionModel>().ReverseMap()
                .ForMember(x => x.Remarks, opt => opt.MapFrom(s => s.Remark));
            CreateMap<AssetProfileDTO, AssetProfile>();
            CreateMap<AddAssetProfileDTO, AssetProfile>();
            CreateMap<UpdateAssetProfileDTO, AssetProfile>();
            CreateMap<MeteringProfileDTO, MeteringProfile>();
            CreateMap<MeteringProfile, MeteringProfileDTO>();
            CreateMap<ProjectProfile, ProjectProfileDTO>().ReverseMap();
            CreateMap<ProjectComponent, ProjectComponentDTO>().ReverseMap();
        }        
    }
}