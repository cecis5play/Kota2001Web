﻿using Kota2001Web.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kota2001Web.Models
{
    public class VehicleViewModel
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
//[Key]
//public int Id { get; set; }
//[Required]
//[MaxLength(50)]
//public string Model { get; set; }
//[Required]
//[MaxLength(11)]
//public string RegNumbeer { get; set; }
//public DateTime? Thirdpartyliabilityinsurance { get; set; }
//public DateTime? Casko { get; set; }
//public DateTime? Vignette { get; set; }
//[ForeignKey(nameof(Type))]
//public int TypeId { get; set; }
//public VType Type { get; set; }