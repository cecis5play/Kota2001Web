using Kota2001Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kota2001Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VType> VTypes { get; set; }
        public Vehicle firstvehicle { get; set; } = null;
        public Vehicle seccondvehicle { get; set; } = null;
        public Vehicle thirdvehicle { get; set; } = null;
        public VType firsttype { get; set; } = null;
        public VType seccondtype { get; set; } = null;
        protected override void OnModelCreating(ModelBuilder builder)
        {

            SeedVehicles();
            builder.Entity<Vehicle>()
                .HasData(this.firstvehicle,
                        this.seccondvehicle,
                        this.thirdvehicle);
            SeedTypes();
            builder.Entity<VType>()
                .HasData(this.firsttype,
                        this.seccondtype);
            base.OnModelCreating(builder);
        }

        private void SeedVehicles()
        {
            this.firstvehicle = new Vehicle()
            {
                Id = 1,
                VModel = "Toyota",
                RegNumber = "CA 4444 PC",
                Thirdpartyliabilityinsurance = new DateTime(2023, 12, 27),
                Casko = new DateTime(2025, 3, 19),
                Vignette = new DateTime(2024, 6, 2),
                TypeId = 1,
            };
            this.seccondvehicle = new Vehicle()
            {
                Id = 2,
                VModel = "Honda Jazz",
                RegNumber = "CB 6001 KX",
                Thirdpartyliabilityinsurance = new DateTime(2025, 11, 30),
                Casko = new DateTime(2026, 12, 10),
                Vignette = new DateTime(2027, 6, 20),
                TypeId = 2,
            };
            this.thirdvehicle = new Vehicle()
            {
                Id = 3,
                VModel = "Toyota",
                RegNumber = "CA 1654 PC",
                Thirdpartyliabilityinsurance = new DateTime(2026, 8, 21),
                Casko = new DateTime(2023, 12, 27),
                Vignette = new DateTime(2027, 2, 9),
                TypeId = 1,
            };
        }
        private void SeedTypes()
        {
            this.firsttype = new VType()
            {
                Id = 1,
                Name = "Truck",
            };
            this.seccondtype = new VType()
            {
                Id = 2,
                Name = "Car"
            };

        }
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
