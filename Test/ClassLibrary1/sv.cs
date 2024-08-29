using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class sv
    {   
        public int ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string CITY { get; set; }
        public int AGE { get; set; }
        public string CLASS { get; set; }        

    }

    public class Tblsv
    {
        public int TBLSV_ID { get; set; }
        public int TBLSV_AGE { get; set; }
    }
}
