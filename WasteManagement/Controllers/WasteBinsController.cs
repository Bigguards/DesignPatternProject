using Microsoft.AspNetCore.Mvc;
using WasteManagement.Models;
using WasteManagement.Facade;
using WasteManagement.Observers;
using WasteManagement.Repositories;
namespace WasteManagement.Controllers
{
    public class WasteBinsController : Controller
    {
        private readonly WasteManagementFacade _facade;

        public WasteBinsController(WasteManagementFacade facade)
        {
            _facade = facade;
        }

        public IActionResult Index()
        {
            var wasteBins = _facade.GetAllWasteBins();
            return View(wasteBins);
        }

        public IActionResult Details(int id)
        {
            var wasteBin = _facade.GetWasteBinById(id);
            if (wasteBin == null)
            {
                return NotFound();
            }
            return View(wasteBin);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WasteBin wasteBin)
        {
            if (ModelState.IsValid)
            {
                _facade.AddWasteBin(wasteBin);
                return RedirectToAction(nameof(Index));
            }
            return View(wasteBin);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var wasteBin = _facade.GetWasteBinById(id);
            if (wasteBin == null)
            {
                return NotFound();
            }
            return View(wasteBin);
        }

        [HttpPost]
        public IActionResult Edit(WasteBin wasteBin)
        {
            if (ModelState.IsValid)
            {
                _facade.UpdateWasteBin(wasteBin);
                return RedirectToAction(nameof(Index));
            }
            return View(wasteBin);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var wasteBin = _facade.GetWasteBinById(id);
            if (wasteBin == null)
            {
                return NotFound();
            }
            return View(wasteBin);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _facade.DeleteWasteBin(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
