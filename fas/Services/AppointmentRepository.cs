using FacultyAppointmentSystem.Controllers;
using FacultyAppointmentSystem.Data;
using FacultyAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacultyAppointmentSystem.Services
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly FContext _FContext;
        private readonly IReadOnly_FContext _readOnlySpaContext;
        public IQueryable<Appointment> Appointments => _FContext.Appointments;

        public AppointmentRepository(FContext spaContext, IReadOnly_FContext readOnlySpaContext)
        {
            _FContext = spaContext;
            _readOnlySpaContext = readOnlySpaContext;
        }

        public bool isAppointmentAvailable(Appointment ProposedApp)
        {
            foreach (Appointment x in _FContext.Appointments )
            {
                if (x.Orari.ToString("{0:MM/dd/yyyy h:mm tt}") ==
                    ProposedApp.Orari.ToString("{0:MM/dd/yyyy h:mm tt}"))
                {
                    if (x.lenda_id == ProposedApp.lenda_id)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public void Add(Appointment appointment)
        {
            _FContext.Appointments.Add(appointment);
            _FContext.SaveChanges();
        }

        public Appointment GetAppointment(int id)
        {
            return _FContext.Appointments.FirstOrDefault(SelectAppointmentById(id));
        }

        public void DeleteAppointment(int id)
        {
            var index = _FContext.Appointments.First(SelectAppointmentById(id));
            _FContext.Appointments.Remove(index);
            _FContext.SaveChanges();
        }

        public void Update(int id, Appointment appointment)
        {
            appointment.Id = id;
            _FContext.Appointments.Update(appointment);
            _FContext.SaveChanges();
        }

        //Selector Functions
        private static Func<Appointment, bool> SelectAppointmentById(int id)
        {
            return App => App.Id == id;
        }
    }
}
