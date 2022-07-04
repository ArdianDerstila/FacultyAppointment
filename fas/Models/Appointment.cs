using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FacultyAppointmentSystem.Services;

namespace FacultyAppointmentSystem.Models
{
    public class Appointment
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt}")]
        public DateTime Orari { get; set; }

        public int Id { get; set; }
        public string Pershkrimi { get; set; }
        public int dega_id { get; set; }
        public int lenda_id { get; set; }
        public string Dega { get; set; }
        public string Lendet { get; set; }

        public Appointment()
        {
            
            
        }
    }
}
