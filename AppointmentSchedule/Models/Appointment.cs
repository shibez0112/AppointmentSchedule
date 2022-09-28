using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedule.Models
{
    public class Appointment
    {
        
        public int ID { get; set; }

        public string UserEmail { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name ="Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

    }
}
