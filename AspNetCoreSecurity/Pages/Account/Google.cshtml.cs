using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreSecurity.Pages.Account
{
    [AllowAnonymous]
    public class GoogleModel : PageModel
    {
        public  IActionResult OnGet(string ReturnUrl)
        {

            if(!Url.IsLocalUrl(ReturnUrl))
            {
                throw new Exception("Invalid url");
            }
            var props = new AuthenticationProperties
            {
                RedirectUri = ReturnUrl
            };
            return Challenge(props, "google");
        }
    }
}
