using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ChartOfAccountsController : ControllerBase
    {
        #region Variables

        private readonly IChartOfAccountsService _chartOfAccountsService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartOfAccountsController"/> class.
        /// <param name="chartOfAccountsService">The chart of accounts service.</param>
        /// </summary>
        public ChartOfAccountsController(IChartOfAccountsService chartOfAccountsService) => _chartOfAccountsService = chartOfAccountsService;

        #endregion Constructor

        #region Get

        /// <summary>
        /// Retrieve the list of chart of accounts.
        /// </summary>
        /// <returns>List of chart of accounts.</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<ChartOfAccountModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_chartOfAccountsService.Get());
        }

        /// <summary>
        /// Retrieve the chart of accounts by unique identifier.
        /// </summary>
        /// <param name="id">The chart of accounts identifier.</param>
        /// <returns>The chart of accounts.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ChartOfAccounts), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(_chartOfAccountsService.GetById(id));
        }
        /// <summary>
        /// Gets the exported logs file in bytes.
        /// </summary>
        /// <returns></returns>
        [HttpGet("export")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        public IActionResult ExportChartofAccounts()
        {
            return File(_chartOfAccountsService.ExportChartofAccounts(), System.Net.Mime.MediaTypeNames.Application.Octet,
                $"logs_{DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")}.xlsx");
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Posts the create chart of accounts.
        /// </summary>
        /// <param name="chartOfAccountsDTO">chart of accounts object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(ChartOfAccountsDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] ChartOfAccountsDTO chartOfAccountsDTO)
        {
            if (chartOfAccountsDTO == null)
                throw new ArgumentNullException(nameof(chartOfAccountsDTO));

            return Ok(await _chartOfAccountsService.Add(chartOfAccountsDTO));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update chart of accounts.
        /// </summary>
        /// <param name="data">The chart of accounts data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(ChartOfAccounts), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ChartOfAccountsDTO data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Ok(await _chartOfAccountsService.Update(data));
        }

        #endregion Put
    }
}
