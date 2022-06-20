using Application.Interfaces;
using Domain.Models.Roles;
using Microsoft.AspNetCore.Identity;

namespace Persistance.Repositries
{
    public class Role : IRole
    {
        private readonly RoleManager<IdentityRole> _roleManager;
    
        public Role(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRole(AddRole addrolemodel)
        {

            {
                var identityRole = new IdentityRole
                {
                    Name = addrolemodel.RoleName
                };
                var result = await _roleManager.CreateAsync(identityRole);
                return result;
            }
        }

    }
}
