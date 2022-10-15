using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje
{
    class Veritabani
    {
        string adres = "Data Source=MELIHYıLDıZ;Initial Catalog=İcerikEditoru;Integrated Security=True";
        SqlConnection baglan;



        public SqlConnection BaglantiAc()
        {
            baglan = new SqlConnection(adres);

            //eger baglantı kapalıysa açar
            if (baglan.State == System.Data.ConnectionState.Closed)
            {
                baglan.Open();
                return baglan;
            }
            else
            {
                return null;
            }

        }

        public void BaglantiKapat()
        {
            //kapalıysa kapartır.
            if (baglan.State == System.Data.ConnectionState.Open)
            {
                baglan.Close();
            }

        }



    }
}
