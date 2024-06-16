using AuthDemo.Application.Interfaces;
using AuthDemoApi.Helper;
using AuthDemoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AuthDemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        #region ===[ Private Members ]=============================================================

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        #endregion

        #region ===[ Constructor ]=================================================================

        /// <summary>
        /// Initialize UsersController by injecting an object type of IUnitOfWork
        /// </summary>
        public UsersController(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this._unitOfWork = unitOfWork;
            this._appSettings = appSettings.Value;
        }

        #endregion

        #region ===[ Public Methods ]==============================================================

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var user = await _unitOfWork.Users.AuthenticateUser(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var token = Common.GenerateJwtToken(user.Id, _appSettings);

            var response = new AuthenticateResponse
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = token,
            };

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.Users.GetAll();
            return Ok(users);
        }

        #endregion
    }
}