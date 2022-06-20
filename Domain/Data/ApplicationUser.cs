using Domain.Models.Student;
using Microsoft.AspNetCore.Identity;

namespace Domain.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? UniRollNumber { get; set; }
        public virtual Students Student  {get; set;}

    }
}
