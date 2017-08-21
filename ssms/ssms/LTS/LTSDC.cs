using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ssms;
using ssms.LTS;

namespace ssms.LTS
{
    public class LTSDC : LTSBase, IDisposable
    {
        public LTSDC() : base(Properties.Settings.Default.ssmsConnectionString) { }

        public LTSDC(string ConnectionString) : base(ConnectionString) { }

        public static LTSDC Context
        {
            get { return new LTSDC(); }
        }
    }
}
