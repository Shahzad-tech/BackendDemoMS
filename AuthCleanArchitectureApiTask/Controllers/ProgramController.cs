using Application.Dtos.ProgramDto;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{


    [Route("Program")]
    [ApiController]
    public class ProgramController : Controller
    {

        private readonly IProgram _iprogram;

        public ProgramController(IProgram iprogram)
        {
            _iprogram = iprogram;
        }

        
        [Authorize(Roles = "Admin")]
        [HttpPost("Register")] 
        public ActionResult RegisterProgram(RegisterProgramDto programDto)
        {
            var result = _iprogram.RegisterProgram(programDto);
            return Ok(result);
        }

        
        [Authorize(Roles = "Admin,Student")]
        [HttpGet("GetProgram")]
        public ActionResult GetPrograms()
        {
            var result = _iprogram.GetPrograms();
            return Ok(result);
        }

    }
}
