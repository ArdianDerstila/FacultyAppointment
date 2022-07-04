using System.Linq;
using FacultyAppointmentSystem.Models;

namespace FacultyAppointmentSystem.Services
{
    public interface IAppointmentRepository
    {
        IQueryable<Appointment> Appointments { get; }

        void Add(Appointment appointment);
        void DeleteAppointment(int id);
        Appointment GetAppointment(int id);
        bool isAppointmentAvailable(Appointment ProposedApp);
        void Update(int id, Appointment appointment);
    }
}