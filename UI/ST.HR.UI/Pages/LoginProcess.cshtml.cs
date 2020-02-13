using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ST.HR.UI.Core;

namespace ST.HR.UI.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly AuthService _authService;

        public LoginModel(AuthService authService)
        {
            _authService = authService;
        }
        
        public string ReturnUrl { get; set; }
        
        public async Task<IActionResult> OnGetAsync(string username, string password)
        {
            await _authService.Logout(HttpContext);

            var loginModel = await _authService.Login(username, password, HttpContext);
            if (!loginModel.Successful)
            {
                var returnUrl = Url.Content("/login/" + loginModel.Message);
                return LocalRedirect(returnUrl);
            }
            else
            {
                var returnUrl = Url.Content("~/");
                return LocalRedirect(returnUrl);
            }
        }
    }
}