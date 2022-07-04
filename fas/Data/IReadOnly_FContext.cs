using FacultyAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyAppointmentSystem.Data
{
    public interface IReadOnly_FContext
    {
        IQueryable<Appointment> Appointments { get; }
        IQueryable<Deget> Deget_F { get; }
        IQueryable<lenda> lendet { get; }
    }
}
