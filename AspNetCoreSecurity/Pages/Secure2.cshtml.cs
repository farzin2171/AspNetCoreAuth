using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreSecurity.Pages
{
    [Authorize("ManageCustomers")]
    public class Secure2Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
