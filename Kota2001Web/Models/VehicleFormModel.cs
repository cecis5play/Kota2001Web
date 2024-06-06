namespace Kota2001Web.Models
{
    public class VehicleFormModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string RegNumber { get; set; }
        public DateTime? Thirdpartyliabilityinsurance { get; set; }
        public DateTime? Casko { get; set; }
        public DateTime? Vignette { get; set; }
        public string VType { get; set; }
    }
}
