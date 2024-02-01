using AutoMapper;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class VersionService : IVersionService
    {
        private readonly IVersionsRepository _versionsRepository;
        private readonly IMapper _mapper;

        public VersionService(IVersionsRepository versionsRepository, IMapper mapper)
        {
            _versionsRepository = versionsRepository;
            _mapper = mapper;
        }

        public async Task<VersionModel> GetById(int id)
        {
            var result = _versionsRepository.Get().FirstOrDefault(x => x.Id == id);
            var versionDto = _mapper.Map<VersionModel>(result);

            return versionDto;
        }

        public async Task<List<VersionModel>> GetListVersion()
        {
            var result = _versionsRepository.Get().OrderByDescending(x=>x.VersionDate);
            var versionList = _mapper.Map<List<VersionModel>>(result);

            return versionList;
        }

        public async Task Delete(int id)
        {
            await _versionsRepository.Delete(id);
        }       

        public async Task<List<VersionModel>> Add(AddVersionDTO versionDto)
        {
            var version = _mapper.Map<Versions>(versionDto);
            var result = await _versionsRepository.Add(version);

            if(result != null)
            {
                var versionRes = _versionsRepository.Get().OrderByDescending(x => x.VersionDate);
                return _mapper.Map<List<VersionModel>>(versionRes);
            }

            return null;
        }
    }
}
