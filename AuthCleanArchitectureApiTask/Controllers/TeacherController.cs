using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("Teacher")]
    [ApiController]
    public class TeacherController : Controller
    {
       
        [HttpPost("GetStudents")]
        public ActionResult GetAllTeacher()
        {
            return Ok();

        }
    }
}
