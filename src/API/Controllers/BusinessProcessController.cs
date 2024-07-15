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
    public class BusinessProcessController : ControllerBase
    {
        #region Variables

        private readonly IBusinessProcessService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessProcessController"/> class.
        /// <param name="service">List the business process.</param>
        /// </summary>
        public BusinessProcessController(IBusinessProcessService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// List of business process.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<BusinessProcessModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Get the business process by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(BusinessProcessModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Posts the create business process.
        /// </summary>
        /// <param name="DTO">The business process data object.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(BusinessProcess), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(BusinessProcessDTO DTO)
        {
            if (DTO == null)
                throw new ArgumentNullException(nameof(DTO));

            return Ok(await _service.Add(DTO));
        }
        #endregion

        #region Put
        /// <summary>
        /// Puts the update business process
        /// </summary>
        /// <param name="dto">The business process data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(BusinessProcess), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateBusinessProcessDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
           
            return Ok(await _service.Update(dto));
        }
        #endregion
    }
}  