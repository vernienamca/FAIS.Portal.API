﻿using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AmrController : ControllerBase
    {
        #region Variables

        private readonly IAmrService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AmrController"/> class.
        /// <param name="service">List the AMR.</param>
        /// </summary>
        public AmrController(IAmrService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// Retrieve the list of AMR.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AmrModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Retrieve the AMR by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(AmrModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Posts the create AMR.
        /// </summary>
        /// <param name="dto">The amr data object.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(Amr), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(AddAmrDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(await _service.Add(dto));
        }
        #endregion

        #region Put
        /// <summary>
        /// Puts the update AMR
        /// </summary>
        /// <param name="dto">The amr data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(Amr), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateAmrDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(_service.Update(dto));
        }
        #endregion
    }
}  