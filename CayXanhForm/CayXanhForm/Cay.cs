using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhForm
{
    class Cay
    {
        string MaCay;
        string TenCay;
        string TuoiCay;
        string MaLoai;
        string LichSu;
        string NgayTrong;
        string GhiChu;

        public string MaCay1 { get => MaCay; set => MaCay = value; }
        public string TenCay1 { get => TenCay; set => TenCay = value; }
        public string TuoiCay1 { get => TuoiCay; set => TuoiCay = value; }
        public string MaLoai1 { get => MaLoai; set => MaLoai = value; }
        public string LichSu1 { get => LichSu; set => LichSu = value; }
        public string NgayTrong1 { get => NgayTrong; set => NgayTrong = value; }
        public string GhiChu1 { get => GhiChu; set => GhiChu = value; }


        public Cay(string MaCay, string TenCay, string TuoiCay , string MaLoai , string LichSu , string NgayTrong, string GhiChu)
        {
            this.MaCay = MaCay;
            this.TenCay = TenCay;
            this.TuoiCay = TuoiCay;
            this.MaLoai = MaLoai;
            this.LichSu = LichSu;
            this.NgayTrong = NgayTrong;
            this.GhiChu = GhiChu;
        }
        public static DataTable HienThi()
        {
            KetNoi KN = new KetNoi();
            KN.MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = KetNoi.conn;
            command.CommandText = "select MaCay,TenCay,TuoiCay,NgayTrong,LoaiCay.TenLoai,LichSuCay.KetQua as N'Lich su', Cay.GhiChu from Cay,LoaiCay,LichSuCay where Cay.MaLoai = LoaiCay.MaLoai and Cay.MaLichSu = LichSuCay.MaLichSu";
            SqlDataReader rd = command.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            return tb;
        }
        public static DataTable HienThiCBB(string causql)
        {
            KetNoi KN = new KetNoi();
            KN.MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = KetNoi.conn;
            command.CommandText =causql;
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
                command.CommandText = "insert into Cay(MaCay,TenCay,TuoiCay,NgayTrong,MaLoai,MaLichSu,GhiChu) values (@MaCay,@TenCay,@TuoiCay,@NgayTrong,@MaLoai,@MaLichSu,@GhiChu)";
                command.Parameters.Add("@MaCay", SqlDbType.VarChar).Value = MaCay;
                command.Parameters.Add("@TenCay", SqlDbType.NVarChar).Value = TenCay;
                command.Parameters.Add("@TuoiCay", SqlDbType.Int).Value = TuoiCay;
                command.Parameters.Add("@NgayTrong", SqlDbType.Date).Value = NgayTrong;
                command.Parameters.Add("@MaLoai", SqlDbType.VarChar).Value = MaLoai;
                command.Parameters.Add("@MaLichSu", SqlDbType.Int).Value = LichSu;
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
                command.CommandText = "update Cay set TenCay=@TenCay,TuoiCay=@TuoiCay,NgayTrong=@NgayTrong,MaLoai=@MaLoai,MaLichSu=@MaLichSu,GhiChu=@GhiChu where MaCay=@MaCay ";
                command.Parameters.Add("@MaCay", SqlDbType.VarChar).Value = MaCay;
                command.Parameters.Add("@TenCay", SqlDbType.NVarChar).Value = TenCay;
                command.Parameters.Add("@TuoiCay", SqlDbType.Int).Value = TuoiCay;
                command.Parameters.Add("@NgayTrong", SqlDbType.Date).Value = NgayTrong;
                command.Parameters.Add("@MaLoai", SqlDbType.VarChar).Value = MaLoai;
                command.Parameters.Add("@MaLichSu", SqlDbType.Int).Value = LichSu;
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
                command.CommandText = "delete Cay where MaCay=@MaCay ";
                command.Parameters.Add("@MaCay", SqlDbType.VarChar).Value = MaCay;
                command.Parameters.Add("@TenCay", SqlDbType.NVarChar).Value = TenCay;
                command.Parameters.Add("@TuoiCay", SqlDbType.Int).Value = TuoiCay;
                command.Parameters.Add("@NgayTrong", SqlDbType.Date).Value = NgayTrong;
                command.Parameters.Add("@MaLoai", SqlDbType.VarChar).Value = MaLoai;
                command.Parameters.Add("@MaLichSu", SqlDbType.Int).Value = LichSu;
                command.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = GhiChu;
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
            command.CommandText = "select *from Cay where Cay.TenCay like N'%" + dkTimKiem + "%' ";
            SqlDataReader rd = command.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            return tb;
        }
    }

}
