using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FacultyAppointmentSystem.Models;
using FacultyAppointmentSystem.Services;

namespace FacultyAppointmentSystem.Controllers
{
    public class DegetController : Controller
    {
        private readonly IDegetRepository _repo;
        public DegetController(IDegetRepository repo)
        {
            _repo = repo;
        }
        // GET: Deget
        public ActionResult Index()
        {
            return View(_repo.Deget_F);
        }

        // GET: Deget/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetBrunch(id));
        }

        // GET: Deget/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deget/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")]Deget dg)
        {
            try
            {
                _repo.Add(dg);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        // GET: Deget/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetBrunch(id) );
        }

        // POST: Deget/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Deget dg)
        {
            try
            {
                // TODO: Add update logic here
                _repo.Update(id, dg);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Deget/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.GetBrunch(id));
        }

        // POST: Deget/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Deget collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.DeleteDega(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ErrorView(Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Unknown Error");
            return View();
        }
    }
}