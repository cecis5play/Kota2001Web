using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kota2001Web.Data.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string VModel { get; set; }
        [Required]
        [MaxLength(11)]
        public string RegNumber { get; set; }
        public DateTime? Thirdpartyliabilityinsurance { get; set; }
        public DateTime? Casko { get; set; }
        public DateTime? Vignette { get; set; }
        public string? Area { get; set; }
        [ForeignKey(nameof(VType))]
        public int TypeId { get; set; }
        public VType VType { get; set; }


    }
}
