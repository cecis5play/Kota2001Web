using Kota2001Web.Data.Entities;
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
        public IActionResult All(string searchString)
        {
            var vehicles = service.GetAll();
            if (searchString != null)
            {
                vehicles = vehicles
                    .Where(n => n.RegNumber.ToLower().Contains(searchString.ToLower()) || n.VModel.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }
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

            var vTypes = service.getVModelTypes();
            var vehicleModel = new VehicleFormModel()
            {
                Id = vehicle.Id,
                VModel = vehicle.VModel,
                RegNumber = vehicle.RegNumber,
                Thirdpartyliabilityinsurance = vehicle.Thirdpartyliabilityinsurance,
                Casko = vehicle.Casko,
                Vignette = vehicle.Vignette,
                Area = vehicle.Area,
                VTypes = vTypes,
            };

            return View(vehicleModel);
        }
        [HttpPost]
        public IActionResult Edit(VehicleFormModel model, int id)
        {
            if (!this.service.Exists(id))
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            this.service.Edit(model);

            return RedirectToAction(nameof(VehiclesDetails), new { id = id});

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            if (!this.service.Exists(id))
            {
                return BadRequest();
            }

            var vehicle = this.service.GetVehiclesDetails(id);

            var model = new VehicleDetailViewModel()
            {
                Id = vehicle.Id,
                VModel = vehicle.VModel,
                RegNumber = vehicle.RegNumber
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(VehicleDetailViewModel model)
        {
            if (!this.service.Exists(model.Id))
            {
                return BadRequest();
            }

            this.service.Delete(model.Id);

            return RedirectToAction(nameof(All)); 
        }

        [HttpGet]
        public IActionResult Add()
        {

            var vTypes = service.getVModelTypes();
            var vehicleModel = new VehicleFormModel()
            {
                VTypes = vTypes,
            };

            return View(vehicleModel);
        }
        [HttpPost]
        public IActionResult Add(VehicleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           var newVehicle = this.service.Create(model);
           

            return RedirectToAction(nameof(VehiclesDetails), new { id = newVehicle });

        }
    }
}
