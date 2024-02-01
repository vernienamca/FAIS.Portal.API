using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        #region Put
        
        /// <summary>
        /// Puts the update of Proforma Entries.
        /// </summary>
        /// <param name="data">The Proforma Entries data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProformaEntries), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateProformaEntriesDTO data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Ok(await _proformaEntriesService.Update(data));
        }
        
        #endregion Put
    }
}
