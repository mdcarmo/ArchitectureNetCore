using ArchitectureNetCore.Domain.Entities;
using ArchitectureNetCore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureNetCore.Web.Controllers
{
    public class TruckEFController : Controller
    {
        private readonly ITruckRepositoryEF _repo;

        public TruckEFController(ITruckRepositoryEF truckRepositoryEF) =>
            _repo = truckRepositoryEF;
        
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

        // GET: Autor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var truck = _repo.GetById(id);
            if (truck == null)
                return NotFound();

            return View(truck);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var autor = _repo.GetById(id);
            _repo.Remove(autor);
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(int id) =>
            _repo.GetById(id) != null;
    }
}