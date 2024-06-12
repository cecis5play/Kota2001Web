using Kota2001Web.Data;
using Kota2001Web.Data.Entities;
using Kota2001Web.Models;
using Microsoft.EntityFrameworkCore;

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
                    VModel = v.VModel,
                    RegNumber = v.RegNumber,
                    Thirdpartyliabilityinsurance = v.Thirdpartyliabilityinsurance,
                    Casko = v.Casko,
                    Vignette = v.Vignette,
                    Area = v.Area,
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
                    VModel = v.VModel,
                    RegNumber = v.RegNumber,
                    Thirdpartyliabilityinsurance = v.Thirdpartyliabilityinsurance,
                    Casko = v.Casko,
                    Vignette = v.Vignette,
                    Area = v.Area,
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

            vehicle.VModel = model.VModel;
            vehicle.RegNumber = model.RegNumber;
            vehicle.Thirdpartyliabilityinsurance = model.Thirdpartyliabilityinsurance;
            vehicle.Casko = model.Casko;
            vehicle.Vignette = model.Vignette;
            vehicle.Area = model.Area;
            vehicle.TypeId = model.VTypeId;

            this.context.SaveChanges();
        }
        public int Create(VehicleFormModel model)
        {
            var vehicle = new Vehicle
            {
                VModel = model.VModel,
                RegNumber = model.RegNumber,
                Thirdpartyliabilityinsurance = model.Thirdpartyliabilityinsurance,
                Casko = model.Casko,
                Vignette = model.Vignette,
                Area = model.Area,
                TypeId = model.VTypeId
            };

            this.context.Vehicles.Add(vehicle);
            this.context.SaveChanges();
            return vehicle.Id;
        }
        public IEnumerable<VTypeModel> getVModelTypes()
        {
            var vTypes = context.VTypes.Select(v => new VTypeModel
            {
                Id = v.Id,
                Name = v.Name,
            }).ToList();
            return vTypes;
        }
        public void Delete(int id)
        {
            var vehicle = this.context.Vehicles.First(h => h.Id == id);

            this.context.Vehicles.Remove(vehicle);
            this.context.SaveChanges();
        }
    }
}
