using Application.Interfaces;
using AutoMapper;
using Domain.Data;
using Domain.Models.Program;
using Domain.Models.Roles;
using Domain.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistance.context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositries
{
   
    public class Account : IAccount
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private DataContext _context;
        private readonly JwtSettings _settings;
        private IMapper _mapper;


        public Account(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IOptions<JwtSettings> settings, DataContext context, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _settings = settings.Value;
            _context = context;
            _mapper = mapper;
        }
 
        public async Task<IdentityResult> RegisterUser(Register RegisterUserModel)
        {
            var user = new ApplicationUser
            {
                UserName = RegisterUserModel.UserName,
                Email = RegisterUserModel.Email
            };

            var result = await _userManager.CreateAsync(user, RegisterUserModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, RegisterUserModel.Roles.Select(x => x.RoleName));
            }
           return result;
        }

        public async Task<String> LoginUser(Login loginUserModel)
        {
            var user = await _userManager.FindByEmailAsync(loginUserModel.Email);
            var userWithRole = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim("UserID", user.Id),
                new Claim("UserEmail", user.Email)
            };

            claims.AddRange(userWithRole.Select(role => new Claim(ClaimTypes.Role, role)));

            if (user != null && await _userManager.CheckPasswordAsync(user, loginUserModel.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            else
            {
                return "false";
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }


    }

}
