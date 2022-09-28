using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedule.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        [BindProperty]
        [Required]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        public string? Email { get; set; } = string.Empty;


        public RegisterModel(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                    new IdentityUser { UserName = this.Username, Email = this.Email };
                IdentityResult result = await userManager.CreateAsync(user, this.Password);
                if (result.Succeeded)
                {
                    return Redirect("/Account/Login");
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return Page();
        }
    }
}
