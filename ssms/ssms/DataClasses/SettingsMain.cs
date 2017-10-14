using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssms.DataClasses
{
    public class SettingsMain
    {
        //Margo
        public int SettingsID { get; set; }
        public string SettingsName { get; set; }
        public bool SettingsSelect { get; set; }

        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }

        public List<ReaderMain> Readers = new List<ReaderMain>();

        public SettingsMain()
        {
            
        }

        //Margo
        public int TotalAmountAntennas()
        {
            int result = 0;
            for(int x = 0; x < Readers.Count; x++)
            {
                result = result + Readers[x].NumAntennas;
            }
            return result;
        }
    }
}
