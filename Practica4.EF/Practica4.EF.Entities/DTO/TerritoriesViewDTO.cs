using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
