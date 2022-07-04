using FacultyAppointmentSystem.Data;
using FacultyAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacultyAppointmentSystem.Services
{
    public class Deget_Repository : IDegetRepository
    {
        private readonly FContext _FContext;
        private readonly IReadOnly_FContext _readOnlySpaContext;

        public Deget_Repository(FContext spaContext, IReadOnly_FContext readOnlySpaContext)
        {
            _FContext = spaContext;
            _readOnlySpaContext = readOnlySpaContext;
        }


        public IQueryable<Deget> Deget_F => _FContext.Deget_F.AsQueryable();

     

        //method allows me to add dg to my list
        public void Add(Deget dg)
        {
            _FContext.Deget_F.Add(dg);
            _FContext.SaveChanges();
        }

        public void Update(int id, Deget dg)
        {
            dg.Id = id;
            _FContext.Deget_F.Update(dg);
            _FContext.SaveChanges();
        }

        //to delete from the list
        public void DeleteDega(int id)
        {
            var index = _FContext.Deget_F.First(SelectCustomerById(id));
            _FContext.Deget_F.Remove(index);
            _FContext.SaveChanges();
        }

        public Deget GetBrunch(int id)
        {
            return _FContext.Deget_F.FirstOrDefault(SelectCustomerById(id));
        }

        public bool ThisCustomerExists(int id)
        {
            foreach(Deget cust in _FContext.Deget_F)
            {
                if(cust.Id == id)
                return true;
            }
            return false;
        }

        public bool CustNameFitsId(int id, string name)
        {
            foreach (Deget cust in _FContext.Deget_F)
            {
                if (cust.Id == id && cust.Name == name)
                return true;
            }
            return false;
        }

        //Selector Functions
        private static Func<Deget, bool> SelectCustomerById(int id)
        {
            return Deget => Deget.Id == id;
        }
    }
}
