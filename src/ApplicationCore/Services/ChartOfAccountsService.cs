using AutoMapper;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class ChartOfAccountsService : IChartOfAccountsService
    {
        private readonly IChartOfAccountsRepository _repository;
        private readonly IMapper _mapper;

        public ChartOfAccountsService(IChartOfAccountsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ChartOfAccounts> Add(ChartOfAccountsDTO chartOfAccountsDTO)
        {
            var chartOfAccount = _mapper.Map<ChartOfAccounts>(chartOfAccountsDTO);
            return await _repository.Add(chartOfAccount);
        }

        public IReadOnlyCollection<ChartOfAccountModel> Get()
        {
            return _repository.Get();
        }

        public ChartOfAccounts GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<ChartOfAccounts> Update(ChartOfAccountsDTO chartOfAccountsDTO)
        {
            var chartOfAccount = _mapper.Map<ChartOfAccounts>(chartOfAccountsDTO);
            return await _repository.Update(chartOfAccount);
        }
    }
}
