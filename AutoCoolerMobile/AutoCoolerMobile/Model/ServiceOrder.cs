using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoolerMobile.Model
{
    public class ServiceOrder
    {  
        public int ServiceOrderId { get; set; }        
        public string Type { get; set; } = null!;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string? Activities { get; set; } = null!;
        public string? Observations { get; set; }        
        public int Status { get; set; }        
        public int CompanyId { get; set; }
        public int VehicleId { get; set; }
        public int? TechnicianId { get; set; }        
    }
}
