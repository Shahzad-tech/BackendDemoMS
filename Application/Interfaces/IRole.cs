using Domain.Models.Roles;
using Microsoft.AspNetCore.Identity;


namespace Application.Interfaces
{
    public interface IRole
    {
        Task<IdentityResult> CreateRole(AddRole addrolemodel);
    }
}
