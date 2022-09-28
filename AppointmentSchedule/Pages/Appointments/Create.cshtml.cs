using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppointmentSchedule.Data;
using AppointmentSchedule.Models;
using System.Security.Claims;

namespace AppointmentSchedule.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly AppointmentSchedule.Data.AppointmentScheduleContext _context;

        public CreateModel(AppointmentSchedule.Data.AppointmentScheduleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/AcessDenied");
            }

            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/AcessDenied");
            }
          if (!ModelState.IsValid)
            {
                return Page();
            }
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            Appointment.UserEmail = userEmail;

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
