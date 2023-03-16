using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQ.Entities.DTO
{
    public class CustomersOrdersDTO
    {
        public string contactName { get; set; }
        public string region { get; set; }
        public DateTime? orderDate { get; set; }
    }
}
