using Application.Interfaces;
using Domain.Models.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("Roles")]
    [ApiController]

    public class RoleController : Controller
    {

        private readonly IRole _irole;
        public RoleController(IRole irole)
        {
            _irole = irole;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateRole")]
        public async Task<ActionResult> CreateRole(AddRole addrolemodel)
        {
            var result = await _irole.CreateRole(addrolemodel);
            return Ok(result);
        }
    }
}
