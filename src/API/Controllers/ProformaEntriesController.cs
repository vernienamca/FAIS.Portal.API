using System;
using System.Threading.Tasks;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FAIS.ApplicationCore.Models;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProformaEntriesController : ControllerBase
    {
        #region Variables
        
        private readonly IProformaEntriesService _proformaEntriesService;
        
        #endregion Variables

        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProformaEntriesController"/> class.
        /// <param name="proformaEntriesService">The proforma entries service.</param>
        /// </summary>
        public ProformaEntriesController(IProformaEntriesService proformaEntriesService)
        {
            _proformaEntriesService = proformaEntriesService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the proforma entries.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<ProformaEntriesModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_proformaEntriesService.Get());
        }

        #endregion

        #region Post

        /// <summary>
        /// Post the add proforma entry.
        /// </summary>
        /// <param name="proformaEntriesDto">The proforma entry data object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(ProformaEntries), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] ProformaEntriesDTO proformaEntriesDto)
        {
            if (proformaEntriesDto == null)
                throw new ArgumentNullException(nameof(proformaEntriesDto));

            return Ok(await _proformaEntriesService.Add(proformaEntriesDto));
        }

        #endregion Post

        #region Put

        /// <summary>
        /// Puts the update proforma entry.
        /// </summary>
        /// <param name="proformaEntriesDto">The proforma entry data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProformaEntries), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateProformaEntriesDTO proformaEntriesDto)
        {
            if (proformaEntriesDto == null)
                throw new ArgumentNullException(nameof(proformaEntriesDto));

            return Ok(await _proformaEntriesService.Update(proformaEntriesDto));
        }
        
        #endregion Put
    }
}
