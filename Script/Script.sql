/****** Object:  Database [QuanLyBan_ChoThueNha2020]    Script Date: 3/11/2020 ******/

CREATE DATABASE [QuanLyBan_ChoThueNha2020]
go
USE [QuanLyBan_ChoThueNha2020]
GO

CREATE TYPE [dbo].[SoDienThoai] FROM [nchar](10) NOT NULL
go
--Tạo bảng CHI NHANH
CREATE TABLE [dbo].[ChiNhanh](
 MaChiNhanh nchar(10) not null,
 Duong nvarchar(30) not null,
 Quan nvarchar(30) not null,
 KhuVuc nvarchar(30) not null,
 ThanhPho nvarchar(30) not null,
 SDT_CN SoDienThoai not null,
 Fax nvarchar(25) not null,
 CONSTRAINT PK_ChiNhanh PRIMARY KEY(MaChiNhanh)
 )
go
--Tạo bảng NHAN VIEN
CREATE TABLE [dbo].[NhanVien](
 MaNhanVien nchar(10) not null,
 TenNhanVien nvarchar(50) not null,
 DiaChi_NV nvarchar(60) not null,
 SDT_NV SoDienThoai not null,
 GioiTinh nvarchar(3) check (GioiTinh IN ('Nam',N'Nữ')),
 NgaySinh date not null,
 Luong money not null,
 MaChiNhanh nchar(10) not null,
 TenTaiKhoan nchar(20) not null,
 CONSTRAINT PK_NhanVien	PRIMARY KEY(MaNhanVien)
 )
go
--Tạo bảng CHU NHA
CREATE TABLE [dbo].[ChuNha](
 MaChuNha nchar(10) not null,
 TenChuNha nvarchar(50) not null,
 DiaChi_ChuNha nvarchar(60) not null, 
 SDT_ChuNha SoDienThoai not null,
 TenTaiKhoan nchar(20) not null,
 CONSTRAINT PK_ChuNha PRIMARY KEY(MaChuNha)
 )
go
--Tạo bảng NHA
CREATE TABLE [dbo].[Nha](
 MaNha nchar(10) not null,
 Duong nvarchar(30) not null,
 Quan nvarchar(30) not null,
 KhuVuc nvarchar(30) not null,
 ThanhPho nvarchar(30) not null,
 MaLoaiNha nchar(10) not null,
 SoLuongPhong tinyint not null,
 NgayDang date not null,
 NgayHetHan date not null,
 TinhTrang bit not null, -- 1 la đã thuê / mua  --------  0 là còn trống
 SoLuotXem int not null,
 MaChuNha nchar(10) not null,
 MaNhanVien nchar(10) not null,
 MaChiNhanh nchar(10) not null,
 CONSTRAINT PK_Nha PRIMARY KEY(MaNha)
 )
--Tạo bảng NHA THUE VÀ NHA BAN kế thừa từ NHA----
CREATE TABLE [dbo].[NhaThue](
 MaNhaThue nchar(10) not null,
 TienThueMotThang money not null,
 CONSTRAINT PK_NhaThue PRIMARY KEY(MaNhaThue)
 )
CREATE TABLE [dbo].[NhaBan](
 MaNhaBan nchar(10) not null,
 GiaBan money not null,
 DieuKien nvarchar(100),
 CONSTRAINT PK_NhaBan PRIMARY KEY(MaNhaBan)
 )
--------------


--Tạo bảng LOAI NHA
CREATE TABLE [dbo].[LoaiNha](
 MaLoaiNha nchar(10) not null,
 TenLoaiNha nvarchar(50) not null,
 CONSTRAINT PK_LoaiNha PRIMARY KEY(MaLoaiNha)
 )


--Tạo bảng KHACH HANG
CREATE TABLE [dbo].[KhachHang](
 MaKhachHang nchar(10) not null,
 TenKhachHang nvarchar(50) not null,
 Duong nvarchar(30) not null,
 Quan nvarchar(30) not null,
 KhuVuc nvarchar(30) not null,
 ThanhPho nvarchar(30) not null,
 SDT_KH SoDienThoai not null,
 MaChiNhanh nchar(10) not null,
 TenTaiKhoan nchar(20) not null, 
 CONSTRAINT PK_KhachHang PRIMARY KEY(MaKhachHang)
 )

--Tạo bảng HOP DONG
CREATE TABLE [dbo].[HopDong](
 MaHopDong nchar(10) not null,
 MaKhachHang nchar(10) not null,
 MaNha nchar(10) not null,
 NgayKyHopDong date not null,
 CONSTRAINT PK_HopDong PRIMARY KEY(MaHopDong)
 )
--Tạo bảng HOP DONG THUE VA MUA
CREATE TABLE [dbo].[HopDongThue](
 MaHopDongThue nchar(10) not null,
 NgayBatDau date not null,
 NgayHetHan date not null,
 CONSTRAINT PK_HopDongThue PRIMARY KEY(MaHopDongThue)
 )
CREATE TABLE [dbo].[HopDongMua](
 MaHopDongMua nchar(10) not null,
 GiaMua money not null,
 CONSTRAINT PK_HopDongMua PRIMARY KEY(MaHopDongMua)
 )


--Tạo bảng TIEU CHI
CREATE TABLE [dbo].[TieuChiChonNha](
 STT int not null,
 MaKhachHang nchar(10) not null,
 MaLoaiNha nchar(10),
 KhuVuc nvarchar(50),
 SoLuongPhong tinyint,
 GiaMin money,
 GiaMax money,
 YeuCauThueMua nvarchar(5) check (YeuCauThueMua IN(N'Thuê',N'Mua')),
 CONSTRAINT PK_TieuChi PRIMARY KEY(STT,MaKhachHang)
 )

--Tạo bảng LICH SU XEM NHA

CREATE TABLE [dbo].[LichSuXemNha](
 MaKhachHang nchar(10) not null,
 MaNha nchar(10) not null,
 NgayXemNha date not null,
 NhanXet nvarchar(100),
 CONSTRAINT PK_LichSuXemNha PRIMARY KEY(MaKhachHang,MaNha,NgayXemNha) 
 )

CREATE TABLE [dbo].[TaiKhoan](
 TenTaiKhoan nchar(20) not null,
 MatKhau nchar(20) not null,
 LoaiTaiKhoan int check (LoaiTaiKhoan IN(1,2,3,4)) not null -- 1_Admin 
															-- 2_Nhân Viên 
															-- 3_Người thuê / mua
															-- 4_Chủ Nhà
 CONSTRAINT PK_TaiKhoan PRIMARY KEY(TenTaiKhoan) 
 )
--KHOA NGOAI 
-------NhanVien
alter table NhanVien
add constraint FK_NV_ChiNhanh foreign key(MaChiNhanh) references ChiNhanh(MaChiNhanh)
alter table NhanVien
add constraint FK_NV_TaiKhoan foreign key(TenTaiKhoan) references TaiKhoan(TenTaiKhoan)


-------KhachHang
alter table KhachHang
add constraint FK_KH_ChiNhanh foreign key(MaChiNhanh) references ChiNhanh(MaChiNhanh)
alter table KhachHang
add constraint FK_KH_TaiKhoan foreign key(TenTaiKhoan) references TaiKhoan(TenTaiKhoan)


------HopDong

alter table HopDong
add constraint FK_HD_KH foreign key(MaKhachHang) references KhachHang(MaKhachHang)
alter table HopDong
add constraint FK_HD_Nha foreign key(MaNha) references Nha(MaNha)

alter table HopDongThue
add constraint FK_HDThue_HD foreign key(MaHopDongThue) references HopDong(MaHopDong)
alter table HopDongMua
add constraint FK_HDMua_HD foreign key(MaHopDongMua) references HopDong(MaHopDong)

----------Nha

alter table Nha
add constraint FK_Nha_LoaiNha foreign key(MaLoaiNha) references LoaiNha(MaLoaiNha)
alter table Nha
add constraint FK_Nha_ChuNha foreign key(MaChuNha) references ChuNha(MaChuNha)
alter table Nha
add constraint FK_Nha_NhanVien foreign key(MaNhanVien) references NhanVien(MaNhanVien)
alter table Nha
add constraint FK_Nha_ChiNhanh foreign key(MaChiNhanh) references ChiNhanh(MaChiNhanh)

alter table NhaThue
add constraint FK_NhaThue_Nha foreign key(MaNhaThue) references Nha(MaNha)
alter table NhaBan
add constraint FK_NhaBan_Nha foreign key(MaNhaBan) references Nha(MaNha)

----TieuChi

alter table TieuChiChonNha
add constraint FK_TieuChi_KH foreign key(MaKhachHang) references KhachHang(MaKhachHang)
alter table TieuChiChonNha
add constraint FK_TieuChi_LoaiNha foreign key(MaLoaiNha) references LoaiNha(MaLoaiNha)

----LichSuXemNha
alter table LichSuXemNha
add constraint FK_LSXN_KH foreign key(MaKhachHang) references KhachHang(MaKhachHang)
alter table LichSuXemNha
add constraint FK_LSXN_Nha foreign key(MaNha) references Nha(MaNha)


-----Chu nha
alter table ChuNha
add constraint FK_ChuNha_TaiKhoan foreign key(TenTaiKhoan) references TaiKhoan(TenTaiKhoan)



---------------Trigger
--------------NHA
----NgayDang < NgayHetHan

go
create trigger Trigger_NgayDang_NgayHetHan
on Nha
for insert, update
as
begin
		if exists(select * from inserted where NgayDang > NgayHetHan)
		begin
			raiserror(N'Lỗi: Ngày đăng phải trước ngày hết hạn. Vui lòng nhập lại',16,1)
		end
end



----SoLuongPhong lon hon 0
go
create rule Rule_SoLuongPhong
as
@SoLuongPhong >= 1;
go
exec sp_bindrule 'Rule_SoLuongPhong','Nha.SoLuongPhong'
----SoLuotXem lon hon bang 0
go 
create rule Rule_SoLuotXem
as
@SoLuotXem >=0;
go 
exec sp_bindrule 'Rule_SoLuotXem','Nha.SoLuotXem'
---- Tang/giam so luot xem khi them xoa sua LICHSUXEMNHA
go
create trigger Trigger_TangSoLuotXem
on LichSuXemNha
after update,insert,delete
as
begin
declare @temp nchar(10)
declare @temp2 nchar(10)
	if not exists(select * from inserted) -- delete
		begin
			set @temp2 = (select deleted.MaNha from deleted)
			update Nha
			set SoLuotXem = SoLuotXem - 1 
			where Nha.MaNha = @temp2
		end
	else 
	begin
		if not exists(select * from deleted) -- insert
		begin
			set @temp = (select inserted.MaNha from inserted)
			update Nha 
			set SoLuotXem = SoLuotXem + 1 where Nha.MaNha = @temp
		end
		else 
		begin
			if update(MaNha)
			begin 
				if exists(select * from Nha, inserted where inserted.MaNha = Nha.MaNha)
					begin 
						set @temp = (select inserted.MaNha from inserted)
						update Nha 
						set SoLuotXem = SoLuotXem + 1 where Nha.MaNha = @temp

						set @temp2 = (select deleted.MaNha from deleted)
						update Nha
						set SoLuotXem = SoLuotXem - 1 where Nha.MaNha = @temp2
					end
			end
		end
	end
end

-- Ngày xem nhà phải sau ngày đăng và trước ngày hết hạn lICHSUXEMNHA
go
create trigger Trigger_NgayXemNha_NgayDang_NgayHetHan
on LichSuXemNha
for insert, update
as
begin
		if exists(select * from inserted i,Nha where i.NgayXemNha < Nha.NgayDang and i.MaNha = Nha.MaNha)
		begin
			raiserror(N'Lỗi: Ngày xem nhà phải sau ngày đăng. Vui lòng nhập lại',16,1)
		end
		if exists(select * from inserted i,Nha where i.NgayXemNha > Nha.NgayHetHan and i.MaNha = Nha.MaNha)
		begin
			raiserror(N'Lỗi: Ngày xem nhà phải trước ngày hết hạn. Vui lòng nhập lại',16,1)
		end
end
 

 -- Neu tinh trạng nhà là 1 thì không được xem nhà. LICHSUXEMNHA
 go
create trigger Trigger_XemNha
on LichSuXemNha
for insert, update
as
begin
		if exists(select * from inserted i,Nha where i.MaNha = Nha.MaNha and Nha.TinhTrang = 1)
		begin
			raiserror(N'Lỗi: Nhà đã được bán/thuê. Vui lòng xem nhà khác !!!!!!',16,1)
		end
end




 -- Ngày kí hợp đồng phải sau ngày đăng
go
create trigger Trigger_NgayKyHopDong_NgayDang
on HopDong
for insert, update
as
begin
		if exists(select * from inserted i,Nha where i.NgayKyHopDong < Nha.NgayDang and i.MaNha = Nha.MaNha)
		begin
			raiserror(N'Lỗi: Ngày kí hợp đồng phải sau ngày đăng. Vui lòng nhập lại',16,1)
		end
		
end

-- Nếu tình trạng nhà là 1 thì không được tạo hợp đồng.!!
 go
create trigger Trigger_TaoHopDong
on HopDong
for insert, update
as
begin
		if exists(select * from inserted i,Nha where i.MaNha = Nha.MaNha and Nha.TinhTrang = 1)
		begin
			raiserror(N'Lỗi: Nhà đã được bán/thuê, không thể lập hợp đồng. Vui lòng kiếm nhà khác !!!!!!',16,1)
		end
end

--Khi thêm xóa, SỬA 1 Hợp đồng, thuộc tính Tình trạng trong bảng Nhà thay đổi
go
create trigger Trigger_TinhTrangNha
on Nha
after update,insert,delete
as
begin
declare @temp nchar(10)
declare @temp2 nchar(10)
	if not exists(select * from inserted) -- delete
		begin
			set @temp2 = (select deleted.MaNha from deleted)
			update Nha
			set TinhTrang=0
			where Nha.MaNha = @temp2
		end
	else 
	begin
		if not exists(select * from deleted) -- insert
		begin
			set @temp = (select inserted.MaNha from inserted)
			update Nha 
			set TinhTrang=1
			where Nha.MaNha = @temp
		end
		else 
		begin
			if update(MaNha)
			begin 
				if exists(select * from Nha, inserted where inserted.MaNha = Nha.MaNha)
					begin 
						set @temp = (select inserted.MaNha from inserted)
						update Nha 
						set TinhTrang=1
						where Nha.MaNha = @temp

						set @temp2 = (select deleted.MaNha from deleted)
						update Nha
						set TinhTrang=0 
						where Nha.MaNha = @temp2
					end
			end
		end
	end
end


-- Tieu Chi: Gia cao nhat >= gia thap nhat  
go
create trigger Trigger_GiaMinMaxTieuChi
on TieuChiChonNha
for insert, update
as
begin
		if exists(select * from inserted where GiaMin is not null and GiaMax is not null and GiaMax < GiaMin)
		begin
			raiserror(N'Lỗi: Giá cao nhất phải lớn hơn hoặc bằng giá thấp nhất !!! VUI LÒNG NHẬP LẠI',16,1)
		end

end

-- Tieu chi:Khi xóa 1 Tiêu chí chọn nhà thì những Tiêu chí có STT
--lớn hơn có cùng MaKhachHang tự động giảm 1 

go
create trigger Trigger_CapNhatSTT_TieuChi
on TieuChiChonNha
for delete 
as
begin
	declare @temp nchar(10)
	declare @stt int
	set @temp = (select deleted.MaKhachHang from deleted)
	set @stt = (select deleted.STT from deleted)
	update TieuChiChonNha set STT = STT - 1 where @temp = TieuChiChonNha.MaKhachHang and STT > @stt
end
go
--Nha: NgayDang phải nhỏ hơn hoặc bằng ngày hiện tại.
create trigger [dbo].[Trigger_NgayDang]
on [dbo].[Nha]
for insert,update
as 
begin 
if exists(select * from inserted where NgayDang >= cast(GETDATE()as date))
		begin
			raiserror(N'Loi: Ngay đang phai nho hon ngay hien tai. Vui long nhap lai',16,1)
			
		end
		
end




