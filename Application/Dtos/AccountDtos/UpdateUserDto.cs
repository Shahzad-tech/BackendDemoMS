using Application.Dtos.Roles;


namespace Application.Dtos.AccountDtos
{
    public class UpdateUserDto
    {
        public String id { get; set; }
        public String Password { get; set; }
        public List<RoleResponse> Role { get; set; } = new List<RoleResponse>();


    }
}
