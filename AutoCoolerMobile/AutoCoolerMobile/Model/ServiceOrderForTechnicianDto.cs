using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoolerMobile.Model
{
    public class ServiceOrderForTechnicianDto
    {
        //Company
        public int CompanyId { get; set; }

        //Customer
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        //Vehicle
        public int VehicleId { get; set; }
        public string Plate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        //ServiceOrder
        public int ServiceOrderId { get; set; }
        public string Type { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Activities { get; set; }
        public string? Observations { get; set; }
        public int Status { get; set; }
        public int? TechnicianId { get; set; }

        //OrderStatus
        public string StatusName { get; set; }
    }
}
