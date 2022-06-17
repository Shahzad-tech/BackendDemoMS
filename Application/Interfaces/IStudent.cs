using Application.Dtos.StudentDtos;
using Domain.Models.Student;
using Microsoft.AspNetCore.Identity;


namespace Application.Interfaces
{
    public interface IStudent
    {
        
        Task<IdentityResult> RegisterStudent(AddStudentFromFrontendDto studentmodelfromfrontend);   
        List<GetStudentDto> GetAllStudents(StudentSortConfigDto studentSortConfig);
        bool UpdateStudent(int id, UpdateStudentDto updateStudentModel);
        Students GetStudentById(int id);
        GetStudentDto GetDtoStudentById(int id);
        bool SaveChanges();

    }
}
