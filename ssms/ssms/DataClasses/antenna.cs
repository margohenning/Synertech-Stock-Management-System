using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssms.DataClasses
{
    class antenna
    {
        public int antennaNumber { get; set; }
        public decimal txPower { get; set; }
        public decimal rxPower { get; set; }

        public antenna()
        {

        }
    }
}
