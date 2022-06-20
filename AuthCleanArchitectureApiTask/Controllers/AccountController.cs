using Application.Interfaces;
using Domain.Models.Roles;
using Domain.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{

    [Route("Account")]
    [ApiController]

    public class AccountController : Controller
    {
        private readonly IAccount _iaccount;
        public AccountController(IAccount iaccount)
        {
            _iaccount = iaccount;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(Register RegisterUserModel)
        {
            var result = await _iaccount.RegisterUser(RegisterUserModel);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginUser(Login loginUserModel)
        {
            var result = await _iaccount.LoginUser(loginUserModel);
            return Ok(result);
        }
     
    }
}
