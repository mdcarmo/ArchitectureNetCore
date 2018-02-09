using ArchitectureNetCore.Domain.Entities;
using ArchitectureNetCore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureNetCore.Web.Controllers
{
    public class TruckHybridController : Controller
    {
        private readonly ITruckRepositoryEF _repoEF;
        private readonly ITruckRepositoryDapper _repoDapper;

        public TruckHybridController(ITruckRepositoryEF repoEF,
                                      ITruckRepositoryDapper repoDapper)
        {
            _repoEF = repoEF;
            _repoDapper = repoDapper;
        }

        public IActionResult Index() =>
            View(_repoDapper.GetAll());
        
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var autor = _repoDapper.GetById(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }
        
        public IActionResult Create() =>
            View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,WheelConfiguration,Power,Weight,Observation")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                _repoEF.Add(truck);
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        // GET: Autor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var truck = _repoDapper.GetById(id);
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
                    _repoEF.Update(truck);
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

            var truck = _repoDapper.GetById(id);
            if (truck == null)
                return NotFound();

            return View(truck);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var autor = _repoDapper.GetById(id);
            _repoEF.Remove(autor);
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(int id) =>
            _repoDapper.GetById(id) != null;
    }
}