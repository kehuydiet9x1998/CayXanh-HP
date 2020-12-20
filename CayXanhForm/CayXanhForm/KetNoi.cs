using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CayXanhForm
{
    class KetNoi
    {
        public 
        String ChuoiKetNoi = @"Data Source=DESKTOP-9ARUNVT\SQLEXPRESS;Initial Catalog=QLCayXanh;Integrated Security=True";
        public static SqlConnection conn = null;
        public void MoKetNoi()
        {
            if (conn == null)
            {
                conn = new SqlConnection(ChuoiKetNoi);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
    }
}
