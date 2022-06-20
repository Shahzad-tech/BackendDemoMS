using Application.Dtos.ProgramDto;
using Application.Dtos.StudentDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{

    [Route("Student")]
    [ApiController]

    public class StudentController : Controller
    {


        private readonly IStudent _istudents;
        public StudentController(IStudent iusers) {
            _istudents = iusers;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterStudent(AddStudentFromFrontendDto studentmodelfromfrontend)
        {
            var result = await _istudents.RegisterStudent(studentmodelfromfrontend);
            return Ok(result);

        }



        [Authorize(Roles = "Admin")]
        [HttpPost("GetStudents")]
        public ActionResult GetAllStudents(StudentSortConfigDto studentSortConfig) {

            var result = _istudents.GetAllStudents(studentSortConfig);
            return Ok(result);

        }



        [Authorize(Roles = "Admin,Student")]
        [HttpPut("UpdateStudent/{id}")]
        public ActionResult UpdateStudent(int id, UpdateStudentDto updateStudentModel) {

            var response = _istudents.UpdateStudent(id, updateStudentModel);
            return Ok(response);

        }
        [HttpGet("{id}")]
        public ActionResult GetStudentById(int id) {

            var response = _istudents.GetDtoStudentById(id);
            return Ok(response);
        }

        [HttpGet("GetStudentByIdentity/{id}")]
        public ActionResult GetStudentDataByIdentityId(string id) {

            var response = _istudents.GetStudentDataByIdentityId(id);
            return Ok(response);
        
        }

    }
}
