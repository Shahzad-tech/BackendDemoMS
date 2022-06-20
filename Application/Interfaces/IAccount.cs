using Domain.Models.Roles;
using Domain.Models.Account;
using Microsoft.AspNetCore.Identity;


namespace Application.Interfaces
{
    public interface IAccount
    {
        Task<IdentityResult> RegisterUser(Register RegisterUserModel);
        Task<String> LoginUser(Login loginUserModel);
        bool SaveChanges();
    }
}
