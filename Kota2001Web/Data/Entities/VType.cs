using System.ComponentModel.DataAnnotations;

namespace Kota2001Web.Data.Entities
{
    public class VType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
