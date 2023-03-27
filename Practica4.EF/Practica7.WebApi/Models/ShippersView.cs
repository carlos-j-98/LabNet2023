using System.ComponentModel.DataAnnotations;

namespace Practica7.WebApi.Models
{
    public class ShippersView
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
    }
}