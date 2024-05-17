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
    public class AssetProfileController : ControllerBase
    {
        #region Variables

        private readonly IAssetProfileService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetProfileController"/> class.
        /// <param name="assetProfileService">List the asset profiles.</param>
        /// </summary>
        public AssetProfileController(IAssetProfileService assetProfileService) 
        {
            _service = assetProfileService;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// Retrieve the list of asset profile.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AssetProfileModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Retrieve the asset profile by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(AssetProfileModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Posts the create asset profile.
        /// </summary>
        /// <param name="assetProfileDTO">The asset profile data object.</param>
        /// <returns></returns>
        [HttpPost("asset-profile")]
        [ProducesResponseType(typeof(AssetProfile), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(AddAssetProfileDTO assetProfileDTO)
        {
            if (assetProfileDTO == null)
                throw new ArgumentNullException(nameof(assetProfileDTO));

            return Ok(await _service.Add(assetProfileDTO));
        }
        #endregion

        #region Put
        /// <summary>
        /// Puts the update asset profile
        /// </summary>
        /// <param name="dto">The asset profile data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(AssetProfile), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateAssetProfileDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var assetProfile = await _service.GetById(dto.Id);
            if (dto.IsActive != assetProfile.IsActive)
            {
                assetProfile.IsActive = dto.IsActive;
                dto.StatusDate = DateTime.Now;
            }

            return Ok(_service.Update(dto));
        }
        #endregion
    }
}  