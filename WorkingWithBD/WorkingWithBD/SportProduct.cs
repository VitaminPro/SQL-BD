using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace WorkingWithBD
{

   public class  SportProduct
    {
        public int ID
        {
            get;set;
        }

        public string Name
        {
            get; set;
        }

        public decimal Price
        {
            get;set;
        }

    }
  

}

