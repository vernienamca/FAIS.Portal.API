using ArrayToExcel;
using AutoMapper;
using FAIS.ApplicationCore.BusinessRules;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Repository;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            var accounts = _repository.Get();
            if (accounts != null)
            {
                if (accounts.Any(d => d.RcaGL == chartOfAccountsDTO.RcaGL || d.RcaSL == chartOfAccountsDTO.RcaSL))
                {
                    throw new LedgerAlreadyExistException();
                }
            }

            var chartOfAccount = _mapper.Map<ChartOfAccounts>(chartOfAccountsDTO);
            var chartOfAccountDetails = _mapper.Map<List<ChartOfAccountDetails>>(chartOfAccountsDTO.ChartOfAccountDetailsDTO);
            var chartofAccountResult = await _repository.Add(chartOfAccount);
            var details = _detailsRepository.GetByChartOfAccountId(chartOfAccount.Id).ToList();

            if (chartofAccountResult != null)
            {
                if(chartOfAccountDetails != null)
                {
                    foreach (var detail in chartOfAccountDetails)
                    {
                        if (details != null)
                        {
                            if (details.Any(d => d.GL == detail.GL || d.SL == detail.SL))
                            {
                                throw new LedgerAlreadyExistException();
                            }
                        }
                        detail.ChartOfAccountsId = chartofAccountResult.Id;
                        await _detailsRepository.Add(detail);
                    }
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
            var chartOfAccountDetails = _mapper.Map<List<ChartOfAccountDetails>>(chartOfAccountsDTO.ChartOfAccountDetailsDTO);
            var chartofAccountResult = await _repository.Update(chartOfAccount);
           
            if (chartofAccountResult != null)
            {
                var details = _detailsRepository.GetByChartOfAccountId(chartOfAccount.Id).ToList();
                if (details != null)
                {
                    if (details.Count > 0 && details.Count != chartOfAccountDetails.Count)
                    {
                        foreach (var detail in details.Where(o => !chartOfAccountDetails.Select(a => a.Id).Contains(o.Id)))
                        {
                            if (detail.DateRemoved == null)
                            {
                                detail.DateRemoved = DateTime.Now;
                                await _detailsRepository.Update(detail);
                            }
                        }
                    }
                }

                if (chartOfAccountDetails != null && chartOfAccountDetails.Count > 0)
                {
                    foreach (var item in chartOfAccountDetails)
                    {
                        if (item.Id > 0)
                        {
                            await _detailsRepository.Update(item);
                        }
                        else
                        {
                            if (details != null)
                            {
                                if (details.Any(d => d.GL == item.GL || d.SL == item.SL))
                                {
                                    throw new LedgerAlreadyExistException();
                                }
                            }

                            item.ChartOfAccountsId = chartofAccountResult.Id;
                            await _detailsRepository.Add(item);
                        }
                    }
                }
            }

            return chartofAccountResult;
        }

        public byte[] ExportChartofAccounts()
        {
            return _repository.Get().ToExcel();
        }
    }
}
