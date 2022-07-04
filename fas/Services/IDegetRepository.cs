using System.Linq;
using FacultyAppointmentSystem.Models;

namespace FacultyAppointmentSystem.Services
{
    public interface IDegetRepository
    {
        IQueryable<Deget> Deget_F { get; }

        void Add(Deget dg);
        void DeleteDega(int id);
        Deget GetBrunch(int id);
        bool ThisCustomerExists(int id);
        bool CustNameFitsId(int id, string name);
        void Update(int id, Deget dg);
    }
}