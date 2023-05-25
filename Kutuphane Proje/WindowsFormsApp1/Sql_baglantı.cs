using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class Sql_baglantı
    {
        public static string adim; 

        public SqlConnection baglan;
        public SqlCommand komut;
        public void Baglantı()
        {
            baglan = new SqlConnection(@"Data Source=.;Initial Catalog=Kutuphane;Trusted_Connection = True");
            baglan.Open();
            komut = new SqlCommand();
            komut.Connection = baglan;
            
        }

        

    }
}
