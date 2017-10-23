using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssms.DataClasses
{
    public class inventory
    {
        public int itemID { get; set; }
        public string EPC { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public inventory()
        {

        }
    }
}
