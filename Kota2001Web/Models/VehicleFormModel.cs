namespace Kota2001Web.Models
{
    public class VehicleFormModel
    {
        public VehicleFormModel()
        {
            VTypes = new List<VTypeModel>();
        }
        public int Id { get; set; }
        public string VModel { get; set; }
        public string RegNumber { get; set; }
        public DateTime? Thirdpartyliabilityinsurance { get; set; }
        public DateTime? Casko { get; set; }
        public DateTime? Vignette { get; set; }
        public string? Area { get; set; }
        public int VTypeId { get; set; }
        public IEnumerable<VTypeModel> VTypes { get; set; }
    }
}
