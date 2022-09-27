using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppointmentSchedule.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<IdentityUser> signInManager;

        public LogoutModel(SignInManager<IdentityUser> signInMgr)
        {
            signInManager = signInMgr;
        }

        public async Task<RedirectResult> OnGet()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/AcessDenied");
            }
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
