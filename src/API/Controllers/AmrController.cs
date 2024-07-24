using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Enumeration;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <param name="service">The AMR Service</param>
        /// </summary>
        public AmrController(IAmrService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// List of AMRs.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AmrModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// List of AMR 100 Batch.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Amr100Batch")]
        [ProducesResponseType(typeof(IReadOnlyCollection<Amr100BatchModel>), StatusCodes.Status200OK)]
        public IActionResult GetAmr100Batch(int reportSeqId, string yearMonth)
        {
            return Ok(_service.GetAmr100Batch(reportSeqId, yearMonth));
        }

        /// <summary>
        /// List of AMR 100 Batch D.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Amr100BatchD")]
        [ProducesResponseType(typeof(IReadOnlyCollection<Amr100BatchDModel>), StatusCodes.Status200OK)]
        public IActionResult GetAmr100BatchD(int amrBatchSeq, int reportSeq, string yearMonth)
        {
            return Ok(_service.GetAmr100BatchD(amrBatchSeq, reportSeq, yearMonth));
        }

        /// <summary>
        /// List of AMR 100 Batch Dbd.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Amr100BatchDbd")]
        [ProducesResponseType(typeof(IReadOnlyCollection<Amr100BatchDbdModel>), StatusCodes.Status200OK)]
        public IActionResult GetAmr100BatchDbd()
        {
            return Ok(_service.GetAmr100BatchDbd());
        }

        /// <summary>
        /// Gets the AMR by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AmrModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        /// <summary>
        /// Gets the exported AMR logs file in bytes.
        /// </summary>
        /// <returns></returns>
        [HttpGet("export")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        public IActionResult ExportAmrLogs()
        {
            return File(_service.ExportAmrLogs(), System.Net.Mime.MediaTypeNames.Application.Octet,
                $"logs_{DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")}.xlsx");
        }

        /// <summary>
        /// Gets the AMR 100 Batch by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Amr100Batch/{id:int}")]
        [ProducesResponseType(typeof(Amr100BatchModel), StatusCodes.Status200OK)]
        public IActionResult GetAmr100BatchById(int id)
        {
            return Ok(_service.GetAmr100BatchById(id));
        }

        /// <summary>
        /// Gets the AMR 100 Batch D by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Amr100BatchD/{id:int}")]
        [ProducesResponseType(typeof(Amr100BatchDModel), StatusCodes.Status200OK)]
        public IActionResult GetAmr100BatchDById(int id)
        {
            return Ok(_service.GetAmr100BatchDById(id));
        }

        /// <summary>
        /// Gets the AMR 100 Batch Dbd by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Amr100BatchDbd/{id:int}")]
        [ProducesResponseType(typeof(Amr100BatchDbdModel), StatusCodes.Status200OK)]
        public IActionResult GetAmr100BatchDbdById(int id)
        {
            return Ok(_service.GetAmr100BatchDbdById(id));
        }

        /// <summary>
        /// Gets the lists of Amr 100 Batch History.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Amr100BatchStatHistory")]
        [ProducesResponseType(typeof(Amr100BatchStatHistory), StatusCodes.Status200OK)]
        public IActionResult GetAmr100BatchStatHistory()
        {
            return Ok(_service.GetAmr100BatchStatHistory());
        }

        /// <summary>
        /// Gets the status history of batch by unique identifier.
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        [HttpGet("Amr100BatchStatHistory/{batchId:int}")]
        [ProducesResponseType(typeof(Amr100BatchStatHistoryModel), StatusCodes.Status200OK)]
        public IActionResult GetAmr100BatchStatHistoryById(int batchId)
        {
            return Ok(_service.GetAmr100BatchStatHistoryById(batchId));
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


        /// <summary>
        /// Posts the create AMR 100 Batch.
        /// </summary>
        /// <param name="amr100BatchDto">The amr 100 Batch data object.</param>
        /// <returns></returns
        [HttpPost("Amr100Batch")]
        [ProducesResponseType(typeof(Amr100Batch), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAmr100Batch(AddAmr100BatchDTO amr100BatchDto)
        {
            if (amr100BatchDto == null)
                throw new ArgumentNullException(nameof(amr100BatchDto));

            amr100BatchDto.StatusCode = (int)AmrStatusEnum.Open;
            var addedBatch = await _service.AddAmr100Batch(amr100BatchDto);

            await _service.AddAmr100BatchStatHistory(new Amr100BatchStatHistoryDTO()
            {
                BatchSeq = addedBatch.Id,
                StatusCode = (int)AmrStatusEnum.Open,
                StatusDate = DateTime.Now,
                CreatedBy = addedBatch.CreatedBy
            });

            return Ok(addedBatch);
        }

        /// <summary>
        /// Posts the create AMR 100 Batch D.
        /// </summary>
        /// <param name="amr100BatchDto">The amr 100 Batch data object.</param>`1
        [HttpPost("Amr100BatchD")]
        [ProducesResponseType(typeof(Amr100BatchD), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAmr100BatchD(AddAmr100BatchDDTO amr100batchdDto)
        {
            if (amr100batchdDto == null)
                throw new ArgumentNullException(nameof(amr100batchdDto));
            return Ok(await _service.AddAmr100BatchD(amr100batchdDto));
        }

        /// <summary>
        /// Posts the create AMR 100 Batch Dbd.
        /// </summary>
        /// <param name="amr100BatchDto">The amr 100 Batch data object.</param>
        [HttpPost("Amr100BatchDbd")]
        [ProducesResponseType(typeof(Amr100BatchD), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAmr100BatchDbd(AddAmr100BatchDbdDTO amr100batchdbdDto)
        {
            if (amr100batchdbdDto == null)
                throw new ArgumentNullException(nameof(amr100batchdbdDto));
            return Ok(await _service.AddAmr100BatchDbd(amr100batchdbdDto));
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

            return Ok(await _service.Update(dto));
        }

        /// <summary>
        /// Puts the update AMR for Date Sent Encoding
        /// </summary>
        /// <param name="dto">The amr data object.</param>
        /// <returns></returns>
        [HttpPut("encoding/{id:int}")]
        [ProducesResponseType(typeof(Amr), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateEncoding(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return Ok(await _service.UpdateEncoding(id));
        }

        // <summary>
        /// Puts the update AMR 100 Batch
        /// </summary>
        /// <param name="dto">The amr 100 batch data object.</param>
        /// <returns></returns>
        [HttpPut("Amr100Batch/{id:int}")]
        [ProducesResponseType(typeof(Amr100Batch), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAmr100Batch(UpdateAmr100BatchDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(await _service.UpdateAmr100Batch(dto));
        }

        // <summary>
        /// Puts the update AMR 100 Batch D
        /// </summary>
        /// <param name="dto">The amr 100 batch d data object.</param>
        /// <returns></returns>
        [HttpPut("Amr100BatchD/{id:int}")]
        [ProducesResponseType(typeof(Amr100BatchD), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAmr100BatchD(UpdateAmr100BatchDDTO dto)
        {
            if(dto == null)
                throw new ArgumentNullException(nameof (dto));
            return Ok(await _service.UpdateAmr100BatchD(dto));
        }

        // <summary>
        /// Puts the update AMR 100 Batch Dbd
        /// </summary>
        /// <param name="dto">The amr 100 batch dbd data object.</param>
        /// <returns></returns>
        [HttpPut("Amr100BatchDbd/{id:int}")]
        [ProducesResponseType(typeof(Amr100BatchDbd), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAmr100BatchDbd(UpdateAmr100BatchDbdDTO dto)
        {
            if(dto == null)
                throw new ArgumentNullException(nameof (dto));
            return Ok(await _service.UpdateAmr100BatchDbd(dto));
        }
        // <summary>
        /// Removes the broke quantity.
        /// </summary>
        /// <param name="dto">The amr 100 batch_d data object.</param>
        /// <returns></returns>
        [HttpPut("AmrResetQuantity")]
        [ProducesResponseType(typeof(Amr100BatchD), StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetQuantity()
        {
            return Ok(await _service.ResetQuantity());
        }

        // <summary>
        /// Resets the quantity and ColumnBreaks of 
        /// </summary>
        /// <param name="id">The batch object unique identifier.</param>
        /// <returns></returns>
        [HttpPut("remove-break")]
        [ProducesResponseType(typeof(Amr100BatchD), StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveBreak(int id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            return Ok(await _service.RemoveBreak(id));
        }

        /// <summary>
        /// Sets the status of the batch to new asset.
        /// </summary>
        /// <param name="id">The batch object unique identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPut("asset-approval")]
        [ProducesResponseType(typeof(Amr100Batch), StatusCodes.Status200OK)]
        public async Task<IActionResult> NewAssetApproval(int id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            return Ok(await _service.NewAssetApproval(id));
        }

        #endregion
    }
}  