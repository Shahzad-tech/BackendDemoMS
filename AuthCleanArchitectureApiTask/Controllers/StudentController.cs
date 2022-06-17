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

     
        private readonly IStudent _iusers;
        public StudentController(IStudent iusers) {
            _iusers = iusers;     
        }
       
 
        [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterStudent(AddStudentFromFrontendDto studentmodelfromfrontend)
        {
            var result = await _iusers.RegisterStudent(studentmodelfromfrontend); 
            return Ok(result);
       
        }

       

        [Authorize(Roles = "Admin")]
        [HttpPost("GetStudents")]
        public ActionResult GetAllStudents(StudentSortConfigDto studentSortConfig) {
           
            var result = _iusers.GetAllStudents(studentSortConfig);
            return Ok(result);
        
        }

      

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateStudent/{id}")]
        public ActionResult UpdateStudent(int id, UpdateStudentDto updateStudentModel) {

            var response  = _iusers.UpdateStudent(id, updateStudentModel);
            return Ok(response);
        
        }
        [HttpGet("{id}")]
        public ActionResult GetStudentById(int id) {

            var response = _iusers.GetDtoStudentById(id);
            return Ok(response);
        }

    }
}
