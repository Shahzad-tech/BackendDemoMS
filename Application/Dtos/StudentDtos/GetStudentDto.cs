using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.StudentDtos
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string LastProgram { get; set; }
        public string CurrentProgram { get; set; }
        public string Status { get; set; }
        public float CurrentGPA { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
