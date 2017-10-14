using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssms.DataClasses
{
    public class ReaderMain
    {
        //Margo
        public int ReaderID { get; set; }
        public string IPaddress { get; set; }
        public int NumAntennas { get; set; }
        public List<LTS.Antenna> antennas = new List<LTS.Antenna>();

        public ReaderMain()
        {

        }
    }
}
