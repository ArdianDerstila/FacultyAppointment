using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FacultyAppointmentSystem.Models;
using FacultyAppointmentSystem.Services;
using FacultyAppointmentSystem.ViewModels;

namespace FacultyAppointmentSystem.Controllers
{
    public class LendetController : Controller
    {
        private readonly ILendetRepository repo;
        private readonly IDegetRepository custRepo;
        private readonly IAppointmentRepository appRepo;

        public LendetController(ILendetRepository _repo, 
            IDegetRepository _custRepo, IAppointmentRepository _appRepo)
        {
            repo = _repo;
            custRepo = _custRepo;
            appRepo = _appRepo;
        }

        // GET: lenda
        public ActionResult Index()
        {
            return View(repo.lendet);
        }

        // GET: lenda/Details/5
        public ActionResult Details(int id)
        {
            ServProAppVM servProAppVM = new ServProAppVM();
            servProAppVM.appointments = repo.GetAppointmentsByProvider(id);
            //call method to get appointments for this service ln

            servProAppVM.appointment = new Appointment();
            //allows us to get property names of class

            servProAppVM.serviceProvider = repo.GetProvider(id);
            //brings in current ln...

            servProAppVM.dg = custRepo.GetBrunch(id);
            //trying to bring in dg as well but...

            return View(servProAppVM);
        }

        // GET: lenda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lenda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")]lenda ln)
        {
            try
            {
                // TODO: Add insert logic here
                repo.Add(ln);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        // GET: lenda/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetProvider(id) );
        }

        // POST: lenda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, lenda ln)
        {
            try
            {
                // TODO: Add update logic here
                repo.Update(id, ln);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: lenda/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetProvider(id));
        }

        // POST: lenda/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repo.DeleteLenda(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ErrorView(Exception ex)
        {
            ModelState.AddModelError(string.Empty, "To be honest... we're not sure what happened here..." +
                "just like... try again or something? Idk. Press back? Google it?");
            return View();
        }
    }
}