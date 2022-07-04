using FacultyAppointmentSystem.Data;
using FacultyAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacultyAppointmentSystem.Services
{
    public class LendetRepository : ILendetRepository
    {
        private readonly FContext _FContext;
        private readonly IReadOnly_FContext _readOnlySpaContext;
        public IQueryable<lenda> lendet => _FContext.lendet;

        public LendetRepository(FContext spaContext, IReadOnly_FContext readOnlySpaContext)
        {
            _FContext = spaContext;
            _readOnlySpaContext = readOnlySpaContext;
        }

        public void Add(lenda ln)
        {
            _FContext.lendet.Add(ln);
            _FContext.SaveChanges();
        }

        public void Update(int id, lenda ln)
        {
            ln.Id = id;
            _FContext.lendet.Update(ln);
            _FContext.SaveChanges();
        }

        //to delete from the list
        public void DeleteLenda(int id)
        {
            var index = _FContext.lendet.First(SelectProviderById(id));
            _FContext.lendet.Remove(index);
            _FContext.SaveChanges();
        }


        //List method to return service providers for one certain ln by day
        public List<Appointment> GetAppointmentsByProvider(int providerId)
        {
            return _FContext.Appointments
                .Where(x => x.lenda_id == providerId)
                .OrderBy(x => x.Orari)
                .ToList();
        }

        public lenda GetProvider(int id)
        {
            return _FContext.lendet.Single(SelectProviderById(id));
        }

        public bool ThisProviderExists(int id)
        {
            foreach(lenda serv in _FContext.lendet)
            {
                if (serv.Id == id)
                return true;
            }
            return false;
        }

        public bool ProvNameFitsId(int id, string name)
        {
            foreach (lenda serv in _FContext.lendet)
            {
                if (serv.Id == id && serv.Name == name)
                return true;
            }
            return false;
        }

        //Selector Functions
        private static Func<lenda, bool> SelectProviderById(int id)
        {
            return lendet => lendet.Id == id;
        }
    }
}
