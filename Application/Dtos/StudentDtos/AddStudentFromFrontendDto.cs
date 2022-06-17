using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.StudentDtos
{
    public class AddStudentFromFrontendDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UniRollNo { get; set; }

        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string LastProgram { get; set; }
        public string CurrentProgram { get; set; }
        public string Status { get; set; }
        public float CurrentGPA { get; set; }
        
    }
}
