using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppointmentSchedule.Data;
using AppointmentSchedule.Models;
using System.Security.Claims;

namespace AppointmentSchedule.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly AppointmentSchedule.Data.AppointmentScheduleContext _context;

        public IndexModel(AppointmentSchedule.Data.AppointmentScheduleContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {

            if (_context.Appointment != null)
            {
                var userEmail = User.FindFirstValue(ClaimTypes.Email);
                // Appointment = await _context.Appointment.ToListAsync();
                Appointment = await _context.Appointment.Where(x => x.UserEmail == userEmail).ToListAsync();
                
            }
            return Page();
        }
    }
}
