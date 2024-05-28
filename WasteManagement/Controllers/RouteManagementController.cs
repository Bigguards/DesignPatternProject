using Microsoft.AspNetCore.Mvc;
using WasteManagement.Facade;
using WasteManagement.Models;

namespace WasteManagement.Controllers
{
    public class RouteManagementController : Controller
    {
        private readonly WasteManagementFacade _facade;

        public RouteManagementController(WasteManagementFacade facade)
        {
            _facade = facade;
        }

        public IActionResult Index()
        {
            var routes = _facade.GetRoutes();
            return View(routes);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var route = _facade.GetCollection(id);
        
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        [HttpPost]
        public IActionResult Edit(WasteCollection route)
        {
            if (ModelState.IsValid)
            {
                _facade.UpdateRoute(route.WasteBinId);
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }
    }
}
