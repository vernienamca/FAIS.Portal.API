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
        private readonly IProformaEntriesService _proformaEntriesService;

        public ProformaEntriesController(IProformaEntriesService proformaEntriesService)
        {
            _proformaEntriesService = proformaEntriesService;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProformaEntriesDTO data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Ok(await _proformaEntriesService.Update(data));
        }
    }
}
