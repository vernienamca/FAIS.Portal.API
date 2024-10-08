﻿using System;
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
        [ProducesResponseType(typeof(IReadOnlyCollection<ProformaEntryModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_proformaEntriesService.Get());
        }

        /// <summary>
        /// Retrieve the proforma entries by unique identifier.
        /// </summary>
        /// <param name="id">The proforma entries identifier.</param>
        /// <returns>The chart of accounts.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProformaEntry), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_proformaEntriesService.GetById(id));
        }

        /// <summary>
        /// Retrieve a list of proforma entry details by unique identifier.
        /// </summary>
        /// <param name="id">The proforma entry detail identifier</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(ProformaEntryDetail), StatusCodes.Status200OK)]
        public IActionResult GetDetailById(int id)
        {
            return Ok(_proformaEntriesService.GetDetailById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Post the add proforma entry.
        /// </summary>
        /// <param name="proformaEntriesDto">The proforma entry data object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(ProformaEntryDetail), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] ProformaEntryDTO proformaEntryDto)
        {
            if (proformaEntryDto == null)
                throw new ArgumentNullException(nameof(proformaEntryDto));

            return Ok(await _proformaEntriesService.Add(proformaEntryDto));
        }

        #endregion Post

        #region Put

        /// <summary>
        /// Puts the update proforma entry.
        /// </summary>
        /// <param name="proformaEntriesDto">The proforma entry data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProformaEntryDetail), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ProformaEntryDTO proformaEntryDto)
        {
            if (proformaEntryDto == null)
                throw new ArgumentNullException(nameof(proformaEntryDto));

            return Ok(await _proformaEntriesService.Update(proformaEntryDto));
        }

        #endregion Put

        #region Delete

        /// <summary>
        /// Delete proforma entry by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{action}/{id:int}")]
        public IActionResult DeleteProforma([FromRoute] int id)
        {
            return Ok(_proformaEntriesService.Delete(id));
        }

        #endregion Delete
    }
}