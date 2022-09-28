using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedule.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {
        private UserManager<IdentityUser> userManager;

        [BindProperty]
        [Required]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        public string RetypePassword { get; set; } = string.Empty;

        public ChangePasswordModel(UserManager<IdentityUser> userMgr) {
            userManager = userMgr;
        }

        public async Task<IActionResult> OnGet()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/AcessDenied");
            }
            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/AcessDenied");
            }
            if (ModelState.IsValid) {
                if (Password == RetypePassword) {

                    var userEmail = User.FindFirstValue(ClaimTypes.Email);
                    var user = await userManager.FindByEmailAsync(userEmail);
                    if (user != null) {
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);
                        IdentityResult result = await userManager.ResetPasswordAsync(user, token, Password);
                        if (result.Succeeded) {
                            return Redirect("/");
                        }
                    }
                    ModelState.AddModelError("", "Retype Password is incorrect");
                }
            }
            return Page();
        }
    }
}
