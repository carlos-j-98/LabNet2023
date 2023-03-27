using System.ComponentModel.DataAnnotations;

namespace Practica7.WebApi.Models
{
    public class TerritoriesView
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