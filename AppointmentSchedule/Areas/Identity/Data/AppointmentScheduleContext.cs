using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppointmentSchedule.Models;

namespace AppointmentSchedule.Data;

public class AppointmentScheduleContext : IdentityDbContext<IdentityUser>
{
    public AppointmentScheduleContext(DbContextOptions<AppointmentScheduleContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<AppointmentSchedule.Models.Appointment> Appointment { get; set; }
}
