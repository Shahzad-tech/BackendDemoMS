using Application.Dtos.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AccountDtos
{
    public  class RegisterUserDto
    {
        public String Email { get; set; }
        public String Password { get; set; }
        public List<RoleResponse> Role { get; set; } = new List<RoleResponse>();
    }
}
