using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDAC.Models
{
    public class HistoryView
    {
        public int UserID { get; set; }
        public int CruiseID { get; set; }
        public String DestinationName { get; set; }
        public String PortName { get; set; }
        public String ShipName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
    }
}
