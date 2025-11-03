using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAppLogistica.Models
{
    public class Package
    {
        public string TrackingId { get; set; }
        public string Status { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public List<TrackingEvent> History { get; set; }
    }
}
