using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DDAC.Models
{
    public class CruiseView
    {
        public int CruiseID { get; set; }
        public int DestinationID { get; set; }
        public int PortID { get; set; }
        public int ShipID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int Price { get; set; }
        public String DestinationName { get; set; }
        public String PortName { get; set; }
        public String ShipName { get; set; }

    }
}
