namespace Kota2001Web.Models
{
    public class VehicleDetailViewModel
    {
        public int Id { get; set; }
        public string VModel { get; set; }
        public string RegNumber { get; set; }
        public DateTime? Thirdpartyliabilityinsurance { get; set; }
        public DateTime? Casko { get; set; }
        public DateTime? Vignette { get; set; }
        public string? Area { get; set; }
        public string VType { get; set; }
    }
}
