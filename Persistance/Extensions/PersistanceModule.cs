using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Persistance.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces;
using Persistance.Repositries;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Domain.Models.Account;
using Domain.Data;

namespace Persistance.Extensions
{
    public static class PersistanceModule
    {
        public static void ConfigurePersistance(this IServiceCollection services, IConfiguration configuration) {


            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("UserConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
           
            
            services.AddScoped<IStudent, Student>();
            services.AddScoped<IAccount, Account>();
            services.AddScoped<IProgram, Program>();
            services.AddScoped<IRole, Role>();
         
        }

        public static void ConfigureJWTinPersistance(this IServiceCollection services, IConfiguration configuration) {

            services.Configure<JwtSettings>(configuration.GetSection("ApplicationSettings"));   //Injecting Settings

            var key = Encoding.UTF8.GetBytes(configuration["ApplicationSettings:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                };
            });


        }

    }
}
