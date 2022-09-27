using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppointmentSchedule.Pages.Account
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        private SignInManager<IdentityUser> signInManager;

        public LogoutModel(SignInManager<IdentityUser> signInMgr)
        {
            signInManager = signInMgr;
        }
        
        public async Task<RedirectResult> OnGet()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
