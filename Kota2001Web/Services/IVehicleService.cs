using Kota2001Web.Models;

namespace Kota2001Web.Services
{
    public interface IVehicleService
    {
        public IEnumerable<VehicleViewModel> GetAll();

        public VehicleDetailViewModel GetVehiclesDetails(int id);

        bool Exists(int id);
        void Edit(VehicleFormModel model);
    }
}
