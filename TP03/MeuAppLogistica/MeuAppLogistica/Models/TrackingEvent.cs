using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuAppLogistica.Models
{
    public class TrackingEvent
    {
        public DateTime Timestamp { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
