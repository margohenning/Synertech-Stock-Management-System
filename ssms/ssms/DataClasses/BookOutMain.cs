using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssms.DataClasses
{
    class BookOutMain
    {
        public int BookOutID { get; set; }
        public string Reason { get; set; }
        public string Project { get; set; }
        public DateTime Date { get; set; }



        public int UserID { get; set; }
        public string UserIdentityNumber { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }

        
        public int itemID { get; set; }
        public string EPC { get; set; }
        public bool ItemStatus { get; set; }


        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }


        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public int BarcodeID { get; set; }
        public string BarcodeNumber { get; set; }

        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }



        public BookOutMain()
        {

        }
    }
}
