using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using ST.HR.Domain.Entities;
using ST.HR.Services.Sql.Interfaces;

namespace ST.HR.UI.Core
{
    public class AuthService
    {
        private readonly IEmployeeService _employeeService;

        public AuthService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<LoginModel> Login(string username, string password, HttpContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch
            {
                //ignored
            }

            if (username == null || password == null)
                return new LoginModel()
                {
                    Message = "Username or password is null",
                    Successful = false
                };

            var user = await _employeeService.GetByPasswordHashAsync(username, password,
                cancellationToken);
            if (user == null)
            {
                return new LoginModel()
                {
                    Message = "Incorrect username or password",
                    Successful = false
                };
            }

            try
            {
                await RegistryCookies(user, context);
            }
            catch (Exception e)
            {
                return new LoginModel()
                {
                    Message = e.Message,
                    Successful = false
                };
            }

            return new LoginModel()
            {
                Message = "",
                Successful = true
            };
        }

        private static async Task RegistryCookies(Employee user, HttpContext context)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Administrator ? "Administrator" : "User")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = context.Request.Host.Value
            };

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public async Task Logout(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
