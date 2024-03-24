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

            //CreateMap<UpdateProformaEntriesDTO, ProformaEntryDetail>();

            CreateMap<StringInterpolationDTO, StringInterpolation>();
            //CreateMap<StringInterpolationDTO, StringInterpolation>()
            //    .ForMember(x => x.IsActive, opt => opt.MapFrom(s => s.IsActive ? 'Y' : 'N'));

            CreateMap<CostCenterDTO, CostCenter>();

            CreateMap<VersionModel, Versions>().ReverseMap();
            CreateMap<VersionDTO, Versions>().ReverseMap();
            CreateMap<AddVersionDTO, Versions>().ReverseMap();

            CreateMap<ChartOfAccountsDTO, ChartOfAccounts>();
            CreateMap<ChartOfAccountDetailsDTO, ChartOfAccountDetails>();

            CreateMap<LibraryTypeDTO, LibraryType>();
            CreateMap<AddLibraryTypeDTO, LibraryType>()
                .ForMember(x => x.IsActive, opt => opt.MapFrom(s => s.IsActive ? 'Y' : 'N'));

            CreateMap<LibraryOptions, LibraryOptionAddDto>().ReverseMap()
                .ForMember(x=>x.Remarks, opt => opt.MapFrom(s=>s.Remark));
            CreateMap<LibraryOptions, LibraryOptionUpdateDto>().ReverseMap()
                .ForMember(x => x.Remarks, opt => opt.MapFrom(s => s.Remark));
            CreateMap<LibraryOptions, LibraryOptionModel>().ReverseMap()
                .ForMember(x => x.Remarks, opt => opt.MapFrom(s => s.Remark));

            CreateMap<LibraryType, LibraryOptionAddDto>().ReverseMap();
            CreateMap<LibraryType, LibraryTypeModel>().ReverseMap();

            CreateMap<AssetProfileDTO, AssetProfile>();
            CreateMap<AddAssetProfileDTO, AssetProfile>();
            CreateMap<UpdateAssetProfileDTO, AssetProfile>();

            //CreateMap<TemplateDto, Template>();
            //CreateMap<AddTemplateDto, Template>();
=========

        }        
    }
}