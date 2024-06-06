using Kota2001Web.Data;
using Kota2001Web.Models;

namespace Kota2001Web.Services
{
    public class VehicleService : IVehicleService
    {
        public readonly ApplicationDbContext context;
        public VehicleService(ApplicationDbContext context)
        {
                this.context = context;
        }
        public IEnumerable<VehicleViewModel> GetAll()
        {
           var vehicles = context.Vehicles
                .OrderBy(v => v.Thirdpartyliabilityinsurance)
                .OrderBy(v => v.Casko)
                .OrderBy(v => v.Vignette)
                .Select(v => new VehicleViewModel 
                { 
                    Id = v.Id,
                    Model = v.Model,
                    RegNumber = v.RegNumber,
                    Thirdpartyliabilityinsurance = v.Thirdpartyliabilityinsurance,
                    Casko = v.Casko,
                    Vignette = v.Vignette,
                    VType = v.VType.Name

                })                
                .ToList();

            return vehicles;
        }

        public VehicleDetailViewModel GetVehiclesDetails(int id)
        {
            var model = context.Vehicles.Where(v => v.Id == id)
                .Select(v => new VehicleDetailViewModel
                {
                    Id = id,
                    Model = v.Model,
                    RegNumber = v.RegNumber,
                    Thirdpartyliabilityinsurance = v.Thirdpartyliabilityinsurance,
                    Casko = v.Casko,
                    Vignette = v.Vignette,
                    VType = v.VType.Name
                })
                .FirstOrDefault();
            return model;
        }


        public bool Exists(int id)
           => this.context.Vehicles.Any(v => v.Id == id);

        public void Edit(VehicleFormModel model)
        {
            var vehicle = this.context.Vehicles.Where(v => v.Id == model.Id).First();

            vehicle.Model = model.Model;
            vehicle.RegNumber = model.RegNumber;
            vehicle.Thirdpartyliabilityinsurance = model.Thirdpartyliabilityinsurance;
            vehicle.Casko = model.Casko;
            vehicle.Vignette = model.Vignette;
            vehicle.VType.Name = model.VType;

            this.context.SaveChanges();
        }
    }
}
