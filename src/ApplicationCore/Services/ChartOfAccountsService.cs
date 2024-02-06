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
        private readonly IChartOfAccountDetailsRepository _detailsRepository;
        private readonly IMapper _mapper;

        public ChartOfAccountsService(
            IChartOfAccountsRepository repository, 
            IChartOfAccountDetailsRepository detailsRepository, 
            IMapper mapper)
        {
            _repository = repository;
            _detailsRepository = detailsRepository;
            _mapper = mapper;
        }

        public async Task<ChartOfAccounts> Add(ChartOfAccountsDTO chartOfAccountsDTO)
        {
            var chartOfAccount = _mapper.Map<ChartOfAccounts>(chartOfAccountsDTO);
            var chartOfAccountDetails = _mapper.Map<ChartOfAccountDetails>(chartOfAccountsDTO.ChartOfAccountDetailsDTO);
            var chartofAccountResult = await _repository.Add(chartOfAccount);

            if (chartofAccountResult != null)
            {
                if(chartOfAccountDetails != null)
                {
                    chartOfAccountDetails.ChartOfAccountsId = chartofAccountResult.Id;
                    await _detailsRepository.Add(chartOfAccountDetails);
                }
            }   

            return chartofAccountResult;
        }

        public IReadOnlyCollection<ChartOfAccountModel> Get()
        {
            return _repository.Get();
        }

        public ChartOfAccountModel GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<ChartOfAccounts> Update(ChartOfAccountsDTO chartOfAccountsDTO)
        {
            var chartOfAccount = _mapper.Map<ChartOfAccounts>(chartOfAccountsDTO);
            var chartOfAccountDetails = _mapper.Map<ChartOfAccountDetails>(chartOfAccountsDTO.ChartOfAccountDetailsDTO);
            var chartofAccountResult = await _repository.Update(chartOfAccount);

            if (chartofAccountResult != null)
            {
                await _detailsRepository.Update(chartOfAccountDetails);
            }

            return chartofAccountResult;
        }
    }
}
