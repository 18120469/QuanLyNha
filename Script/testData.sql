use QuanLyBan_ChoThueNha2020
go

---Chi Nhánh
insert into ChiNhanh values('1234567891',N'Lê Văn Chí',N'Thủ Đức','1',N'Hồ Chí Minh','0935652852','123456789')
insert into ChiNhanh values('1234567892',N'Đặng Văn Bi',N'Thủ Đức','1',N'Hồ Chí Minh','0935652352','123456788')
insert into ChiNhanh values('1234567893',N'Đặng Văn Ngân','Thủ Đức','1',N'Hồ Chí Minh','0933652652','123456787')
insert into ChiNhanh values('1234567894',N'Nguyễn Văn Cừ',N'5','2',N'Hồ Chí Minh','0935659852','123456786')
insert into ChiNhanh values('1234567895',N'Sư Vạn Hạnh',N'5','2',N'TP Hồ Chí Minh','0935352852','123456785')
go

--Tài Khoản
insert into TaiKhoan values('Namvippro','123456',2)
insert into TaiKhoan values('Sy','123456',2)
insert into TaiKhoan values('Phuc','123456',2)
insert into TaiKhoan values('Phuong','123456',2)
insert into TaiKhoan values('Son','123456',2)

insert into TaiKhoan values('Namvippro1','123',3)
insert into TaiKhoan values('Sy1','123',3)
insert into TaiKhoan values('Phuc1','123',3)
insert into TaiKhoan values('Phuong1','123',3)
insert into TaiKhoan values('Son1','123',3)

insert into TaiKhoan values('Namvippro2','1',4)
insert into TaiKhoan values('Sy2','1',4)
insert into TaiKhoan values('Phuc2','1',4)
insert into TaiKhoan values('Phuong2','1',4)
insert into TaiKhoan values('Son2','1',4)
go

--Nhân Viên

insert into NhanVien values('1',N'Nguyễn Hoài Nam',N'Đăk Nông','0522095351','Nam','2000-8-21',1000,'1234567891','Namvippro')
insert into NhanVien values('2',N'Cao Xuân Hồng Phúc',N'Phú Yên','052075366','Nam','2000-1-21',500,'1234567892','Phuc')
insert into NhanVien values('3',N'Phạm Minh Sỹ',N'Bình Định','0522095357','Nam','2000-2-21',1000,'1234567893','Sy')
insert into NhanVien values('4',N'Pham Thị Bích Phượng',N'Bà Rịa - Vũng Tàu','052205698',N'Nữ','2000-3-21',1000,'1234567894','Phuong')
insert into NhanVien values('5',N'Võ Nguyễn Hồng Sơn',N'Tiền Giang','0522099851','Nam','2000-4-21',1000,'1234567895','Son')
go

--Chủ Nhà

insert into ChuNha values('1',N'Nam',N'Đăk Nông','0522095351','Namvippro2')
insert into ChuNha values('2',N'Phúc',N'Phú Yên','082075366','Phuc2')
insert into ChuNha values('3',N'Sỹ',N'Bình Định','0922095357','Sy2')
insert into ChuNha values('4',N'Phượng',N'Bà Rịa - Vũng Tàu','0522095355','Phuong2')
insert into ChuNha values('5',N'Sơn',N'Đăk Nông','0522099851','Son2')
go

--Khách Hàng
insert into KhachHang values('1',N'Hoài Nam',N'Lê Văn Chí',N'Thủ Đức','1',N'Hồ Chí Minh','0522095351','1234567891','Namvippro1')
insert into KhachHang values('2',N'Minh Sỹ',N'Đặng Văn Bi',N'Thủ Đức','1',N'Hồ Chí Minh','0935652352','1234567892','Sy1')
insert into KhachHang values('3',N'Bích Phượng',N'Đặng Văn Ngân','Thủ Đức','1',N'Hồ Chí Minh','0933652652','1234567892','Phuong1')
insert into KhachHang values('4',N'Hồng Sơn',N'Nguyễn Văn Cừ',N'5','2',N'Hồ Chí Minh','0935659852','1234567892','Son1')
insert into KhachHang values('5',N'Hồng Phúc',N'Sư Vạn Hạnh',N'5','2',N'TP Hồ Chí Minh','0935352852','1234567892','Phuc1')
go

-- Loại Nhà
insert into LoaiNha values('1',N'Biệt Thự')
insert into LoaiNha values('2',N'Nhà Cấp 1')
insert into LoaiNha values('3',N'Nhà Cấp 2')
insert into LoaiNha values('4',N'Nhà Cấp 3')
insert into LoaiNha values('5',N'Nhà Cấp 4')
go

--Tiêu Chí Chọn Nhà
insert into TieuChiChonNha values(1,'1','1','2',5,500,1000,'Mua')
insert into TieuChiChonNha values(2,'1','1','2',5,5,10,'Thuê')
insert into TieuChiChonNha values(1,'2','2','1',5,3,4,'Thuê')
insert into TieuChiChonNha values(1,'3','3','1',5,300,400,'Mua')
insert into TieuChiChonNha values(1,'4','4','2',5,100,150,'Mua')
insert into TieuChiChonNha values(1,'5','5','2',5,2,5,'Thuê')
go

--Nha
insert into Nha values ('1',N'An Dương Vương',N'Bình Chánh','3',N'Hồ Chí Minh','1',6,GETDATE(),GETDATE()+30,0,0,'2','1','1234567891')
insert into Nha values ('2',N'Tân Kỳ Tân Quý',N'Bình Tân','3',N'Hồ Chí Minh','2',6,GETDATE(),GETDATE()+30,0,0,'1','2','1234567892')
insert into Nha values ('3',N'Tôn Đức Thắng',N'Thủ Đức','3',N'Hồ Chí Minh','2',6,GETDATE(),GETDATE()+30,0,0,'3','3','1234567893')
insert into Nha values ('4',N'Đinh Bộ Lĩnh',N'Bình Chánh','1',N'Hồ Chí Minh','3',6,GETDATE(),GETDATE()+30,0,0,'5','4','1234567894')
insert into Nha values ('5',N'Ngô Quyền',N'5','1',N'Hồ Chí Minh','4',3,GETDATE(),GETDATE()+30,0,0,'4','5','1234567895')
insert into Nha values ('6',N'Nguyễn Huệ',N'3','2',N'Hồ Chí Minh','5',3,GETDATE(),GETDATE()+30,0,0,'4','5','1234567895')
insert into Nha values ('7',N'Mai An Tiêm',N'7','1',N'Hồ Chí Minh','3',4,GETDATE(),GETDATE()+30,0,0,'5','4','1234567894')
insert into Nha values ('8',N'Hoàng Văn Thụ',N'Bình Chánh','1',N'Hồ Chí Minh','3',8,GETDATE(),GETDATE()+30,0,0,'5','4','1234567894')
insert into Nha values ('9',N'Kinh Dương Vương',N'Phú Nhuận','3',N'Hồ Chí Minh','1',9,GETDATE(),GETDATE()+30,0,0,'2','1','1234567891')
insert into Nha values ('10',N'Lý Thường Kiệt',N'10','2',N'Hồ Chí Minh','1',9,GETDATE(),GETDATE()+30,0,0,'2','1','1234567891')
update Nha set TinhTrang = 0
go

--Nhà Thuê
insert into NhaThue values ('1',3)
insert into NhaThue values ('3',4)
insert into NhaThue values ('4',6)
insert into NhaThue values ('8',11)
insert into NhaThue values ('9',12)
insert into NhaThue values ('10',15)
go

--Nhà Bán 
insert into NhaBan values ('2',300,'không cần')
insert into NhaBan values ('5',400,'phải đặt cọc trước')
insert into NhaBan values ('6',800,'không cần')
insert into NhaBan values ('7',700,'không cân')
go
--Lịch Sử Xem Nhà
insert into LichSuXemNha values('1','1',GETDATE(),N'nhà tạm được')
insert into LichSuXemNha values('1','2',GETDATE(),'')
insert into LichSuXemNha values('1','3',GETDATE(),N'nhà đẹp')
insert into LichSuXemNha values('1','4',GETDATE(),N'nhà tạm được')
insert into LichSuXemNha values('1','5',GETDATE(),N'nội thất quá cũ')

insert into LichSuXemNha values('2','9',GETDATE(),N'an ninh không được tốt')
insert into LichSuXemNha values('2','10',GETDATE(),'')
insert into LichSuXemNha values('2','6',GETDATE(),N'nhà đẹp')
insert into LichSuXemNha values('2','4',GETDATE(),N'nhà tạm được')
insert into LichSuXemNha values('2','8',GETDATE(),N'khu vực xung quanh ồn ào ')

insert into LichSuXemNha values('3','5',GETDATE(),N'nền nhà thấp')
insert into LichSuXemNha values('3','10',GETDATE(),'')
insert into LichSuXemNha values('4','2',GETDATE(),N'nhà đẹp')
insert into LichSuXemNha values('4','3',GETDATE(),N'nhà xuống cấp')
insert into LichSuXemNha values('5','7',GETDATE(),N'khu vực xung quanh ồn ào ')

--Hợp Đồng

insert into HopDong values('1','1','2',GETDATE()+1)
insert into HopDong values('2','2','3',GETDATE()+1)
insert into HopDong values('3','3','7',GETDATE()+1)
insert into HopDong values('4','4','10',GETDATE()+1)
go

--Hợp Đồng Mua
insert into HopDongMua values('1',300)
go

--Hợp Đồng Thuê
insert into HopDongThue values('2',GETDATE()+3,GETDATE()+63)
insert into HopDongThue values('3',GETDATE()+10,GETDATE()+100)
insert into HopDongThue values('4',GETDATE()+5,GETDATE()+370)
go
