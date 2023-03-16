using System;

namespace PracticaLINQ.Entities.DTO
{
    public class CustomersOrdersDTO
    {
        public string customerName { get; set; }
        public int orderID { get; set; }
        public string region { get; set; }
        public DateTime? orderDate { get; set; }
        public DateTime? shippDate { get; set; }
        public DateTime? requiredDate { get; set; }
        public decimal? freight { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }

    }
}
