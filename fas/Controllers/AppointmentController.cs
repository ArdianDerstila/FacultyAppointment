using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FacultyAppointmentSystem.Data;
using FacultyAppointmentSystem.Models;
using FacultyAppointmentSystem.Services;

namespace FacultyAppointmentSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _repo;
        private readonly IDegetRepository _custRepo;
        private readonly ILendetRepository _servRepo;
        
        public AppointmentController(IAppointmentRepository repo,
            IDegetRepository custRepo, ILendetRepository servRepo)
        {
            _repo = repo;
            _custRepo = custRepo;
            _servRepo = servRepo;
        }

        // GET: Appointment
        public ActionResult Index()
        {
            return View(_repo.Appointments);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            if (_repo.isAppointmentAvailable(appointment))
            {
                if (_custRepo.ThisCustomerExists(appointment.dega_id))
                {
                    if (_custRepo.CustNameFitsId(appointment.dega_id, appointment.Dega))
                    {
                        if (_servRepo.ThisProviderExists(appointment.lenda_id))
                        {
                            if (_servRepo.ProvNameFitsId(appointment.lenda_id, appointment.Lendet))
                            {
                                _repo.Add(appointment);
                                return RedirectToAction(nameof(Index));
                            }
                            else
                            {
                                ModelState.AddModelError("Lendet",
                                   "Dega dhe Lenda qe plotesuat nuk ndodhet ne DB!!!");
                                return View();
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Lenda_id",
                                "Nuk Ndodhet nje lende e tille me kete Id..." +
                                "");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Dega",
                            "ID e Deges  dhe Dega nuk ndodhen ne dB. Provo perseri.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("dega_id",
                        "Nuk ekziston dege e tille me kete Id...");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Orari",
                    "Nuk mund te rzervoni ne kete orar.Rezervo nje orar tjeter");
                return View();
            }
        }
        
        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Appointment appointment)
        {
            try
            {
                // TODO: Add update logic here
                _repo.Update(id, appointment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.DeleteAppointment(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}