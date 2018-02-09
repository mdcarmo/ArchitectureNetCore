using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchitectureNetCore.Domain.Entities;
using ArchitectureNetCore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureNetCore.Web.Controllers
{
    public class TruckDapperController : Controller
    {
        private readonly ITruckRepositoryDapper _repo;

        public TruckDapperController(ITruckRepositoryDapper truckRepositoryDapper) =>
            _repo = truckRepositoryDapper;
        
        public IActionResult Index() =>
            View(_repo.GetAll());

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var truck = _repo.GetById(id);
            if (truck == null)
                return NotFound();

            return View(truck);
        }
        
        // GET: Autor/Create
        public IActionResult Create() =>
            View();

        // POST: Autor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,WheelConfiguration,Power,Weight,Observation")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(truck);
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        // GET: Autor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var truck = _repo.GetById(id);
            if (truck == null)
                return NotFound();

            return View(truck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,WheelConfiguration,Power,Weight,Observation")] Truck truck)
        {
            if (id != truck.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(truck);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckExists(truck.ID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var truck = _repo.GetById(id);
            if (truck == null)
                return NotFound();

            return View(truck);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var truck = _repo.GetById(id);
            _repo.Remove(truck);
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(int id) =>
            _repo.GetById(id) != null;

    }
}