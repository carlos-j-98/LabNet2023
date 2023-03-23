using System.ComponentModel.DataAnnotations;

namespace Practica6.MVC.Models
{
    public class TerritoriesView
    {
        [StringLength(20)]
        public string ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int RegionID { get; set; }
    }
}