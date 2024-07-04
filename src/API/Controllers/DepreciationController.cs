using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DepreciationController : ControllerBase
    {
        #region Variables
        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DepreciationController"/> class.
        /// </summary>
        public DepreciationController()
        {

        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// Gets the list of field dictionaries.
        /// </summary>
        /// <returns></returns>
        [HttpGet("dictionaries")]
        [ProducesResponseType(typeof(IReadOnlyCollection<object>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok();
        }

        #endregion Get
    }
}
