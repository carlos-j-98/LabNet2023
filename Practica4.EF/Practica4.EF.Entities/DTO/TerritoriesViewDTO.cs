using System.ComponentModel.DataAnnotations;

namespace Practica4.EF.Entities.DTO
{
    public class TerritoriesViewDTO
    {
        [Key]
        [StringLength(20)]
        public string ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int RegionID { get; set; }
    }
}
