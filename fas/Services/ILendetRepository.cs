using System.Collections.Generic;
using System.Linq;
using FacultyAppointmentSystem.Models;

namespace FacultyAppointmentSystem.Services
{
    public interface ILendetRepository
    {
        IQueryable<lenda> lendet { get; }

        void Add(lenda ln);
        void DeleteLenda(int id);
        List<Appointment> GetAppointmentsByProvider(int providerId);
        lenda GetProvider(int id);
        bool ThisProviderExists(int id);
        bool ProvNameFitsId(int id, string name);
        void Update(int id, lenda ln);
    }
}