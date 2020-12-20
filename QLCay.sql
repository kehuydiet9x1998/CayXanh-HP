create database QLCayXanh
use QLCayXanh
create table LoaiCay(
MaLoai varchar(20) not null primary key,
TenLoai nvarchar(50) not null,
GhiChu nvarchar(100)
)

create table LichSuCay(
MaLichSu int identity(1,1) not null primary key,
TuNoi nvarchar(100) not null ,
DenNoi nvarchar(100) not null,
KetQua nvarchar(100) not null
)

create table Cay(
MaCay varchar(20) not null primary key,
TenCay nvarchar(50) not null,
TuoiCay int,
MaLoai varchar(20) not null,
MaLichSu int,
GhiChu nvarchar(200),

constraint fk_MaLoai_Cay
foreign key (Maloai)
references LoaiCay(MaLoai),

constraint fk_LSCay_Cay
foreign key (MaLichSu)
references LichSuCay(MaLichSu)
)

insert into LoaiCay(MaLoai,TenLoai,GhiChu)
values ('CayCT',N'Cây cổ thụ',N'Cây từ 100 đến 300 tuôi')

select *from LoaiCay

insert into LichSuCay(TuNoi,DenNoi,KetQua)
values (N'NhaCC',N'Dường Lạch Tray',N'NhaCC -> Dường Lạch Tray')

alter table Cay add NgayTrong date

insert into Cay(MaCay,TenCay,TuoiCay,NgayTrong,MaLoai,MaLichSu,GhiChu)
values ('CXC',N'Cây xà cừ',1,'12/28/2019','CayCT','1',' ')

select MaCay,TenCay,TuoiCay,NgayTrong,LoaiCay.TenLoai,LichSuCay.KetQua as N'Lich su' from Cay,LoaiCay,LichSuCay
where Cay.MaLoai = LoaiCay.MaLoai and Cay.MaLichSu = LichSuCay.MaLichSu
group by MaCay,TenCay,TuoiCay,NgayTrong,LoaiCay.MaLoai,LichSuCay.KetQua


select MaCay,TenCay,TuoiCay,NgayTrong,LoaiCay.TenLoai,LichSuCay.KetQua as N'Lich su', Cay.GhiChu 
from Cay,LoaiCay,LichSuCay
where Cay.MaLoai = LoaiCay.MaLoai and Cay.MaLichSu = LichSuCay.MaLichSu

select *from LoaiCay where LoaiCay.TenLoai like N'%T%'