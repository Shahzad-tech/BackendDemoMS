using Domain.Models.Roles;

using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Account
{
    public class Register
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public List<AddRole> Roles { get; set; } = new List<AddRole>();
     
    }
}
