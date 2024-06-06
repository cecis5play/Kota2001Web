using Kota2001Web.Models;
using Kota2001Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kota2001Web.Controllers
{
    public class VehicleController : Controller
    {

        private readonly IVehicleService service;

        public VehicleController(IVehicleService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {
            var vehicles = service.GetAll();


            return View(vehicles);
        }
        public IActionResult VehiclesDetails(int id)
        {
            var model = service.GetVehiclesDetails(id);

            if (model == null)
            {
                return BadRequest();
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var vehicle = this.service.GetVehiclesDetails(id);

            if (!this.service.Exists(id))
            {
                return BadRequest();
            }

            var vehicleModel = new VehicleFormModel()
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                RegNumber = vehicle.RegNumber,
                Thirdpartyliabilityinsurance = vehicle.Thirdpartyliabilityinsurance,
                Casko = vehicle.Casko,
                Vignette = vehicle.Vignette,
                VType = vehicle.VType
            };

            return View(vehicleModel);
        }
        [HttpPost]
        public IActionResult Edit(VehicleFormModel model, int id)
        {
            if (!this.service.Exists(id))
            {
                return this.View();
            }

            this.service.Edit(model);

            return RedirectToAction(nameof(VehiclesDetails), id);

        }
    }
}
