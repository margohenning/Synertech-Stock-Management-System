using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssms.DataClasses
{
    public class antenna
    {
        public int antennaID { get; set; }
        public int antennaNumber { get; set; }
        public decimal txPower { get; set; }
        public decimal rxPower { get; set; }

        public antenna()
        {

        }
    }
}
