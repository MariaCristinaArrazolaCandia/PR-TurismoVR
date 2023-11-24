using Azure.Core;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using Turismo_API.Data;
using Turismo_API.Models.Custom;
using Turismo_API.Services.Interfaces;

namespace Turismo_API.Controllers
{
    [Route("Turismo/[controller]")]
    [ApiController]
    public class AccessController : Controller
    {
        private readonly ILoginService _loginService;
        public AccessController(ILoginService loginService) 
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]UserRequest user)
        {
            user.password = _loginService.EncryptPassword(user.password);
            var resultAuth = await _loginService.Login(user);
            if (resultAuth == null)
                return Unauthorized();

            return Ok(resultAuth);
        }

        //FALTA RECUPERACION DE CONTRASEÑA
        [HttpPost]
        [Route("Recovery")]
        public async Task<IActionResult> Recovery([FromBody]UserRequest user)
        {
            var resultAuth = await _loginService.GetCode(user.email, user.userName);

            if (!resultAuth)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordDTO changePassword)
        {
            var resultAuth = await _loginService.ChangePassword(changePassword);

            if (!resultAuth)
                return BadRequest();

            return Ok();
        }
    }
}
