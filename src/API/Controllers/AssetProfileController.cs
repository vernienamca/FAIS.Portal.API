using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using FAIS.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class AssetProfileController : ControllerBase
    {
        #region Variables

        private readonly IAssetProfileService _assetProfileService;

        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetProfileController"/> class.
        /// <param name="assetProfileService">The asset profile service.</param>
        /// </summary>
        public AssetProfileController(IAssetProfileService assetProfileService) 
        {
            _assetProfileService= assetProfileService;
        }
        #endregion Constructor

        #region Get
        /// <summary>
        /// Retrieve the list of asset profile.
        /// </summary>
        /// <returns>List of asset profile.</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AssetProfileModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_assetProfileService.Get());
        }
        #endregion Get
    }
}  
