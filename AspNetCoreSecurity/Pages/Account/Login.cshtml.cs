using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AspNetCoreSecurity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!string.IsNullOrWhiteSpace(UserName) && UserName == Password)
            {
                var claims = new List<Claim>
                {
                    new ("sub","123"),
                    new ("name","Farzin"),
                    new ("role","admin")
                };

                var props = new AuthenticationProperties
                {
                    Items =
                    {
                        { "token" , "abc" }
                    }
                };

                var ci = new ClaimsIdentity(claims, "pwd", "name", "role");
                var cp = new ClaimsPrincipal(ci);

                await HttpContext.SignInAsync(cp,props);
                
                //https://yourwebsite.com/secert?returnUrl=https://hackerwebsite.come/stealpassword
                return LocalRedirect(ReturnUrl);
            }
            return Page();
        }
    }
}
