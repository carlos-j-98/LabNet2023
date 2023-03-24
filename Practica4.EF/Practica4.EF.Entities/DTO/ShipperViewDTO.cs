using System.ComponentModel.DataAnnotations;

namespace Practica4.EF.Entities.DTO
{
    public class ShipperViewDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
    }
}
