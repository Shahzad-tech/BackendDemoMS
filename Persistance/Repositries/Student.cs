using Domain.Data;
using Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Persistance.context;
using Application.Dtos.StudentDtos;
using AutoMapper;
using Domain.Models.Student;

namespace Persistance.Repositries
{
    public class Student : IStudent
    {
    
        private readonly UserManager<ApplicationUser> _userManager;
        private DataContext _context;
        private IMapper _mapper;
        public Student(UserManager<ApplicationUser> userManager, DataContext context, IMapper mapper)
        {
           
            _userManager = userManager;
           
            _context = context;
            _mapper = mapper;
        
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public async Task<IdentityResult> RegisterStudent(AddStudentFromFrontendDto studentmodelfromfrontend)
        {
                var user = new ApplicationUser
                   {
                        UserName = studentmodelfromfrontend.UserName,
                        Email = studentmodelfromfrontend.Email,
                        UniRollNumber = studentmodelfromfrontend.UniRollNo

                    };

                var result = await _userManager.CreateAsync(user, studentmodelfromfrontend.Password);
                
                if (result.Succeeded){ await _userManager.AddToRoleAsync(user,"Student"); }
                
                //this.SaveChanges();
               
                var userData = _userManager.GetUserIdAsync(user);
                var model = _mapper.Map<Students>(studentmodelfromfrontend);
                model.UserId = userData.Result;
                await _context.Students.AddAsync(model);
                this.SaveChanges();

            return result;

               
        }

        public List<GetStudentDto> GetAllStudents(StudentSortConfigDto studentSortConfig)
        {
            var result = studentSortConfig.direction == "asc" ? _context.Students.OrderBy(x => x.CreatedDate).ToList()
            : studentSortConfig.direction == "desc" ? _context.Students.OrderByDescending(x => x.CreatedDate).ToList()
            : _context.Students.ToList();

            return _mapper.Map<List<GetStudentDto>>(result);

        }

        public bool UpdateStudent(int id, UpdateStudentDto updateStudentModel)
        {
            var model = this.GetStudentById(id);
            _mapper.Map(updateStudentModel, model);
            return(this.SaveChanges());
        
        }

        public Students GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public GetStudentDto GetDtoStudentById(int id)
        {
            var model = this.GetStudentById(id);
            return _mapper.Map<GetStudentDto>(model);
        }
    }
}
