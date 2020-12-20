using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CayXanhForm
{
    class LichSuCay
    {
        string malichsu;
        string tunoi;
        string dennoi;
        string ketqua;

        public string Malichsu { get => malichsu; set => malichsu = value; }
        public string Tunoi { get => tunoi; set => tunoi = value; }
        public string Dennoi { get => dennoi; set => dennoi = value; }
        public string Ketqua { get => ketqua; set => ketqua = value; }

        public LichSuCay(string malichsu, string tunoi, string dennoi, string ketqua)

        {
            this.malichsu = malichsu;
            this.tunoi = tunoi;
            this.dennoi = dennoi;
            this.ketqua = ketqua;
        }
        public LichSuCay(string tunoi, string dennoi, string ketqua)

        {
            this.tunoi = tunoi;
            this.dennoi = dennoi;
            this.ketqua = ketqua;
        }
        public static DataTable HienThi()
        {
            KetNoi KN = new KetNoi();
            KN.MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = KetNoi.conn;
            command.CommandText = "select *from LichSuCay";
            SqlDataReader rd = command.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            return tb;
        }
        public void Them()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = KetNoi.conn;
                command.CommandText = "insert into LichSuCay(TuNoi,DenNoi,KetQua) values (@TuNoi, @DenNoi, @KetQua)";
                command.Parameters.Add("@TuNoi", SqlDbType.VarChar).Value = tunoi;
                command.Parameters.Add("@DenNoi", SqlDbType.NVarChar).Value = dennoi;
                command.Parameters.Add("@KetQua", SqlDbType.NVarChar).Value = ketqua;
                command.ExecuteNonQuery();
            }
            catch
            {

            }
        
    }
        public void Sua()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = KetNoi.conn;
                command.CommandText = "update LichSuCay set TuNoi=@TuNoi,DenNoi=@DenNoi,KetQua=@KetQua where MaLichSu=@MaLichSu";
                command.Parameters.Add("@MaLichSu", SqlDbType.VarChar).Value = malichsu;
                command.Parameters.Add("@TuNoi", SqlDbType.NVarChar).Value = tunoi;
                command.Parameters.Add("@DenNoi", SqlDbType.NVarChar).Value = dennoi;
                command.Parameters.Add("@KetQua", SqlDbType.NVarChar).Value = ketqua;
                command.ExecuteNonQuery();
            }
            catch
            {

            }
        }
        public void Xoa()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = KetNoi.conn;
                command.CommandText = "delete LichSuCay where MaLichSu = @MaLichSu ";
                command.Parameters.Add("@MaLichSu", SqlDbType.VarChar).Value = malichsu;
                command.Parameters.Add("@TuNoi", SqlDbType.NVarChar).Value = tunoi;
                command.Parameters.Add("@DenNoi", SqlDbType.NVarChar).Value = dennoi;
                command.Parameters.Add("@KetQua", SqlDbType.NVarChar).Value = ketqua;
                command.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        public static DataTable TimKiem(string dkTimKiem)
        {
            KetNoi KN = new KetNoi();
            KN.MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = KetNoi.conn;
            command.CommandText = "select *from LichSuCay where LichSuCay.KetQua like N'%" + dkTimKiem + "%' ";
            SqlDataReader rd = command.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            return tb;
        }
    }
}
