using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILibraryTypeService _libraryTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController(IUserService userService, ILibraryTypeService libraryTypeService)
        {
            _userService = userService;
            _libraryTypeService = libraryTypeService;
        }

        //[HttpPost]

        //CREATE ADD USER ENDPOINT



        [HttpGet("[action]")]
        public IEnumerable<User> Get()
        {
            return _userService.Get();
        }

        [HttpGet("[action]")]
        public IActionResult GetById([FromQuery] int id)
        {
            var entity = _userService.GetById(id);

            var user = new UserModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Position = _libraryTypeService.GetById(entity.PositionId).Name,
                Photo = entity.Photo
            };

            return Ok(user);
        }
    }
}