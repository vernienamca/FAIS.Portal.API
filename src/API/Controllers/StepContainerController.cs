using FAIS.ApplicationCore.DTOs;
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
    public class StepContainerController : ControllerBase
    {
        #region Variables

        private readonly IStepContainerService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StepContainerController"/> class.
        /// <param name=service">The step container service.</param>
        /// </summary>
        public StepContainerController(IStepContainerService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the step containers.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<StepContainerModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Get the step container by unique identifier.
        /// </summary>
        /// <param name="id">The step container unique identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(StepContainerModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Posts the create step container.
        /// </summary>
        /// <param name="stepContainerDto">The step container data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(StepContainer), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(StepContainerDTO stepContainerDto)
        {
            if (stepContainerDto == null)
                throw new ArgumentNullException(nameof(stepContainerDto));

            return Ok(await _service.Add(stepContainerDto));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update step container.
        /// </summary>
        /// <param name="stepContainerDto">The step container data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(StepContainer), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(StepContainerDTO stepContainerDto)
        {
            if (stepContainerDto == null)
                throw new ArgumentNullException(nameof(stepContainerDto));

            return Ok(await _service.Update(stepContainerDto));
        }

        #endregion
    }
}  