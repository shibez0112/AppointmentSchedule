using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedule.Pages.Account
{
    public class LoginModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        
        [BindProperty]
        [Required]
        public string? Username { get; set; }
        
        [BindProperty]
        [Required]
        public string? Password { get; set; }

        public LoginModel(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                await userManager.FindByNameAsync(Username);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    Password, false, false)).Succeeded)
                    {
                        return Redirect("/");
                    }
                }
                ModelState.AddModelError("", "Invalid name or password");
            }
            return Page();
        }

    }
}
