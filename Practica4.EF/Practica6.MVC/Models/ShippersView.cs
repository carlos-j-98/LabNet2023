using System.ComponentModel.DataAnnotations;

namespace Practica6.MVC.Models
{
    public class ShippersView
    {
        public int ID { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
    }
}