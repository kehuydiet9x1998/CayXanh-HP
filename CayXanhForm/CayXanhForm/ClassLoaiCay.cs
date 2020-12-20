using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CayXanhForm
{
    class ClassLoaiCay
    {
        string MaLoai;
        string TenLoai;
        string GhiChu;

        public string MaLoai1 { get => MaLoai; set => MaLoai = value; }
        public string TenLoai1 { get => TenLoai; set => TenLoai = value; }
        public string GhiChu1 { get => GhiChu; set => GhiChu = value; }

        public ClassLoaiCay()
        {
            MaLoai = "NULL";
            TenLoai = "NULL";
            GhiChu = "NULL";
        }
        public ClassLoaiCay(string ma, string ten, string ghichu)
        {
            MaLoai = ma;
            TenLoai = ten;
            GhiChu = ghichu;
        }
        public DataTable HienThi()
        {
            KetNoi KN = new KetNoi();
            KN.MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = KetNoi.conn;
            command.CommandText = "select *from LoaiCay";
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
                command.CommandText = "insert into LoaiCay(MaLoai,TenLoai,GhiChu) values (@MaLoai,@TenLoai,@GhiChu)";
                command.Parameters.Add("@MaLoai", SqlDbType.VarChar).Value = MaLoai;
                command.Parameters.Add("@TenLoai", SqlDbType.NVarChar).Value = TenLoai;
                command.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = GhiChu;
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
                command.CommandText = "update LoaiCay set TenLoai= @TenLoai,GhiChu=@GhiChu where MaLoai=@MaLoai";
                command.Parameters.Add("@MaLoai", SqlDbType.VarChar).Value = MaLoai;
                command.Parameters.Add("@TenLoai", SqlDbType.NVarChar).Value = TenLoai;
                command.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = GhiChu;
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
                command.CommandText = "delete LoaiCay where MaLoai=@MaLoai";
                command.Parameters.Add("@MaLoai", SqlDbType.VarChar).Value = MaLoai;
                command.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        public DataTable TimKiem(string dkTimKiem)
        {
            KetNoi KN = new KetNoi();
            KN.MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = KetNoi.conn;
            command.CommandText = "select *from LoaiCay where LoaiCay.TenLoai like N'%"+dkTimKiem+"%' ";
            SqlDataReader rd = command.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            return tb;
        }

    }
}
