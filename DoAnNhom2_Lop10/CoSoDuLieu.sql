
Create Database QLCDTP
go
use QLCDTP
go
-- - 1.Bảng dữ liệu về người đăng nhập:
Create Table TaiKhoan
(
  MaNV nchar(6) primary key,
  MatKhau nchar(20),
  HoTen nvarchar(40),
  ChiNhanh nvarchar(50),
  SoDT nvarchar(10),
  LoaiTK nvarchar(15)
)
go
insert into TaiKhoan values
('nv01','anhhuy123',N'Đặng Nguyễn Quang Huy',N'Thành Phố Thủ Đức,TP HCM','0395012039',N'Nhân Viên'),
('nv02','Cong12',N'Đỗ Ngọc Chí Công',N'Thành Phố Thủ Đức,TP HCM','0334012311',N'Nhân Viên'),
('nv03','Luan34',N'Trần Văn Luân',N'Thành Phố An Giang','0320128971',N'Quản Lý')

-- - 2. Bảng dữ liệu về Công Dân.
create table CongDan(
	cccd varchar(10),
	hoten nvarchar(30),
	gioitinh nvarchar(5),
	ngaysinh date,
	quequan nvarchar(50),
	thuongtru nvarchar(50),
	tamtru nvarchar(50),
	dantoc nvarchar(10),
	honnhan nvarchar(10),
	cccdCha varchar(10),
	cccdMe varchar(10),
	primary key (cccd)
);
insert into CongDan(cccd,hoten,gioitinh,ngaysinh,quequan,thuongtru,tamtru,dantoc,honnhan,cccdCha,cccdMe)
	values('123456789',N'Đỗ Nam',N'Nam','2002-12-1',N'Bình Định',N'Bình Định',N'Sài Gòn','Kinh',N'Độc Thân','000','111');
insert into CongDan(cccd,hoten,gioitinh,ngaysinh,quequan,thuongtru,tamtru,dantoc,honnhan,cccdCha,cccdMe)
	values('123456788',N'Nguyễn Thị Oanh',N'Nu','1975-12-2',N'Bình Định',N'Bình Định',N'Sài Gòn','Kinh',N'Độc Thân','','');
insert into CongDan(cccd,hoten,gioitinh,ngaysinh,quequan,thuongtru,tamtru,dantoc,honnhan,cccdCha,cccdMe)
	values('123456710',N'Đỗ Nam Hai',N'Nam','2002-12-1',N'Bình Định',N'Bình Định',N'Sài Gòn','Kinh',N'Độc Thân','','');
insert into CongDan(cccd,hoten,gioitinh,ngaysinh,quequan,thuongtru,tamtru,dantoc,honnhan,cccdCha,cccdMe)
	values('123456711',N'Do Thi Huye',N'Nu','2002-12-2',N'Bình Định',N'Bình Định',N'Sài Gòn','Kinh',N'Độc Thân','123456788','');
	insert into CongDan(cccd,hoten,gioitinh,ngaysinh,quequan,thuongtru,tamtru,dantoc,honnhan,cccdCha,cccdMe)
	values('000',N'Do Cha',N'Nam','2002-12-2',N'Bình Định',N'Bình Định',N'Sài Gòn','Kinh',N'Độc Thân','','');
insert into CongDan(cccd,hoten,gioitinh,ngaysinh,quequan,thuongtru,tamtru,dantoc,honnhan,cccdCha,cccdMe)
	values('111',N'Do Thi Me',N'Nu','2002-12-2',N'Bình Định',N'Bình Định',N'Sài Gòn','Kinh',N'Độc Thân','','');
insert into CongDan(cccd,hoten,gioitinh,ngaysinh,quequan,thuongtru,tamtru,dantoc,honnhan,cccdCha,cccdMe)
	values('123456715',N'Đỗ Test',N'Nam','2002-12-1',N'Bình Định',N'Bình Định',N'Sài Gòn','Kinh',N'Độc Thân','000','111');
insert into CongDan(cccd,hoten,gioitinh,ngaysinh,quequan,thuongtru,tamtru,dantoc,honnhan,cccdCha,cccdMe)
	values('123456716',N'Nguyễn Thị Thu',N'Nu','1975-12-2',N'Bình Định',N'Bình Định',N'Sài Gòn','Kinh',N'Độc Thân','','');


--chèn thêm cột tiền lương
alter table CongDan add TienLuong float
--chèn thêm cột QuocTich
alter table CongDan add QuocTich nvarchar(15)

-- - 3.Bảng dữ liệu về Khai Sinh.
Create Table KhaiSinh
(
  MaSoTo int primary key,
  HovaTen nvarchar(50),
  GioiTinh nvarchar(20),
  NgayThangNamSinh date,
  DanToc nvarchar(15),
  QuocTich nvarchar(10),
  NoiSinh nvarchar(30),
  HoTenCha nvarchar(50),
  DanTocCha nvarchar(15),
  QuocTichCha nvarchar(10),
  HoTenMe nvarchar(50),
  DanTocMe nvarchar(15),
  QuocTichMe nvarchar(10),
  NguoiDangKy nvarchar(50),
  CCCDCha varchar(10) references CongDan(cccd),
  CCCDMe varchar(10) references CongDan(cccd) ,
  NgayThangNamDK date,
  cccdCanBo varchar(10)  references CongDan(cccd)
)
insert into KhaiSinh (MaSoTo, HovaTen, GioiTinh, NgayThangNamSinh, DanToc, QuocTich, NoiSinh, HoTenCha, DanTocCha, QuocTichCha, HoTenMe,
DanTocMe, QuocTichMe, NguoiDangKy,CCCDCha,CCCDMe) 
values
(1, N'Nguyễn Văn A', N'Nam', '01-02-2003', N'Kinh', N'Việt Nam', N'Hà Nội', N'Nguyễn Văn B', N'Kinh', N'Việt Nam', N'Phạm Thị C', N'Kinh', N'Việt Nam', N'Đỗ Test'
,'123456711','123456715')

update KhaiSinh set NgayThangNamDK='2003-05-02'
update KhaiSinh set cccdCanBo='123456715'

update CongDan set QuocTich=N'Việt Nam'
update CongDan Set TienLuong=150000
update CongDan set honnhan=N'Kết Hôn' where cccd='113426729';

-- - 4. Bảng Dữ Liệu về Hôn Nhân.

Create Table HonNhan
(
   cccdNguoiChong varchar(10) not null references CongDan(cccd),
   cccdNguoiVo varchar(10)  not null references CongDan(cccd),
   NgayDangKy date,
   NoiDangKy nvarchar(30),
   CCCDNguoiDangKy varchar(10)
   primary key(cccdNguoiChong,cccdNguoiVo)
)
-- - 5. Bang Du Lieu Khai Tu. 
create table CongDanTu(
	cccd varchar(10) primary key,
	ngaymat nvarchar(10),
	nguyennhan nvarchar(100),
	ngaydk nvarchar(4),
	thangdk nvarchar(4),
	namdk nvarchar(4),
	cccdCanbo varchar(10) references CongDan(cccd),
	NoiDangKy nvarchar(25)
);
insert into CongDanTu(cccd,ngaymat,nguyennhan,ngaydk,thangdk,namdk,cccdCanbo,NoiDangKy)
values('123456711','2003-03-22',N'mất tích','12','05','2023','123456711','TPHCM')

-- -6. Bang Du Lieu Ve SoHoKhau
Create Table SoHoKhau
(
  MsHoKhau nchar(20) ,
  MaSoTo int primary key,
  cccd varchar(10) references CongDan(cccd),
  DoUuTien int
)
alter table SoHoKhau add
	Ngay int,
	Thang int,
	Nam int,
	CCCDNguoiDangKy varchar(10) references CongDan(cccd),
	SoDangKy varchar (10)
-- Trong Bang So Ho Khau Cap Nhat Them Dat O
alter table SoHoKhau add
	DatO nvarchar(20)
alter table SoHoKhau add
NoiDangKy nvarchar(20)

insert into SoHoKhau(MsHoKhau,MaSoTo,cccd,DoUuTien,Ngay,Thang,Nam,CCCDNguoiDangKy,SoDangKy)
			values('1234',3,'111',1,11,11,2003,'123456710','04');
insert into SoHoKhau(MsHoKhau,MaSoTo,cccd,DoUuTien,Ngay,Thang,Nam,CCCDNguoiDangKy,SoDangKy)
			values('1234',9,'123456711',2,1,11,2003,'123456710','04');

update SoHoKhau set DatO=N'330 LDH VN'
update SoHoKhau set NoiDangKy=N'TP.HCM'

-- - 7. Bảng cơ sơ dữ liệu về TamTru

Create Table TamTru
(
   MaSoTo nvarchar(10) primary key,
   HoTen nvarchar(20),
   NgaySinh date,
   ThuongTru  nvarchar(30),
   TamTru nvarchar(30),
   CMND nvarchar(10),
   Lydo nvarchar(50),
   TenCanBo nvarchar(50),
   NoiDangKy nvarchar(50),
   NgayDangKy date,
   NgayKetThuc date ,
)

INSERT INTO TamTru (MaSoTo, HoTen, NgaySinh, ThuongTru, TamTru, CMND, Lydo, TenCanBo, NoiDangKy, NgayDangKy, NgayKetThuc)
VALUES 
('TT001', 'Nguyen Van A', '1990-01-01', '123 Nguyen Trai, Q1', '456 Le Loi, Q1', '123456789', 'Cong tac', 'Tran Thi An', 'Quan 1, TP. Ho Chi Minh', '2022-01-01', '2022-06-30'),
('TT002', 'Tran Van B', '1995-02-02', '789 Nguyen Hue, Q2', '101 Nguyen Thai Hoc, Q2', '123456711', 'Nghi hoc', 'Le Thi Binh', 'Quan 2, TP. Ho Chi Minh', '2022-02-01', '2022-07-31'),
('TT003', 'Pham Thi C', '1998-03-03', '111 Tran Hung Dao, Q3', '222 Nguyen Cong Tru, Q3', '123456710', 'Om dau', 'Nguyen Van C', 'Quan 3, TP. Ho Chi Minh', '2022-03-01', '2022-08-31'),
('TT004', 'Le Van D', '2000-04-04', '333 Nam Ky Khoi Nghia, Q4', '444 Vo Van Tan, Q4', '456789012', 'Di du lich', 'Pham Thi D', 'Quan 4, TP. Ho Chi Minh', '2022-04-01', '2022-09-30'),
('TT005', 'Hoang Thi E', '1993-05-05', '555 Nguyen Thi Minh Khai, Q5', '666 Ly Thuong Kiet, Q5', '567890123', 'Sinh hoat', 'Tran Van E', 'Quan 5, TP. Ho Chi Minh', '2022-05-01', '2022-10-31'),
('TT006', 'Nguyen Van F', '1988-06-06', '777 Tran Hung Dao, Q6', '888 Cao Thang, Q6', '678901234', 'Kham suc khoe', 'Le Thi F', 'Quan 6, TP. Ho Chi Minh', '2022-06-01', '2022-11-30'),
('TT007', 'Tran Thi G', '1999-07-07', '999 Nguyen Dinh Chieu, Q7', '111 Duong Dinh Nghe, Q7', '789012345', 'Lam viec', 'Pham Van G', 'Quan 7, TP. Ho Chi Minh', '2022-07-01', '2022-12-31');

-- -8: Bảng cơ sở dữ liệu về lịch sử tạm trú.
Create Table LichSuTamTru
(
   SoThuTu int primary key identity,
   MasoTo nvarchar(20),
   HoTen nvarchar(20),
   NgaySinh date,
   ThuongTru  nvarchar(30),
   TamTru nvarchar(30),
   CMND nvarchar(15),
   Lydo nvarchar(50),
   TenCanBo nvarchar(50),
   NoiDangKy nvarchar(50),
   NgayDangKy date ,
   NgayKetThuc date,
)

--9: Bảng cơ sở dữ liệu về Hộ Chiếu
CREATE TABLE Hochieu (
  ID INT PRIMARY KEY NOT NULL,
  SoDoc VARCHAR(20) NOT NULL,
  NgayCap DATE NOT NULL,
  NoiCap VARCHAR(100) NOT NULL,
  SoDienThoai VARCHAR(20) NOT NULL,
  CCCD varchar(10) references CongDan(cccd)
)
-- Chèn dữ liệu vào bảng nhankhau_hochieu
INSERT INTO Hochieu(ID, SoDoc, NgayCap, NoiCap,CCCD, SoDienThoai)
VALUES 
(1, 'HD123456', '2022-03-15', 'TP.HCM','123456711', '0901234567'),
(2, 'HD654321', '2022-04-20', 'Ha Noi','123456715', '0987654321'),
(3, 'HD789456', '2022-02-05', 'Da Nang','123456789', '0912345678'),
(4, 'HD159753', '2022-03-01', 'Can Tho', '123456716', '0888888888');
go
CREATE TABLE nhatky (
  Stt int primary key,
  ID INT  NOT NULL,
  noiden NVARCHAR(50) NOT NULL,
  ngaydi DATE NOT NULL,
  ngayden DATE NOT NULL,
  FOREIGN KEY (ID) REFERENCES Hochieu(ID)
);
INSERT INTO   nhatky (Stt,ID, noiden, ngaydi, ngayden) 
VALUES 
(1,1, 'Japan', '2022-02-01', '2022-02-07'), 
(2,1, 'South Korea', '2022-02-08', '2022-02-14'), 
(3,2, 'United States', '2022-03-10', '2022-03-25'), 
(4,2, 'Canada', '2022-03-26', '2022-03-30'), 
(5,3, 'Australia', '2022-01-01', '2022-01-10'), 
(6,3, 'New Zealand', '2022-01-11', '2022-01-15')


-- 10. Bảng cơ sở dữ liệu về thuế.
CREATE TABLE LoaiThue (
   MaLoaiThue int PRIMARY KEY,
   TenLoaiThue nvarchar(50),
   MucThue float,
   NgayThangNamDK date,
   NoiDangKy nvarchar(30),
   CCCDCanbo varchar(10) references CongDan(cccd)
);
CREATE TABLE HoaDonThue (
   MaHoaDon int PRIMARY KEY,
   MaCD varchar(10) REFERENCES CongDan(CCCD),
   MaLoaiThue int REFERENCES LoaiThue(MaLoaiThue),
   NgayLapHoaDon date,
   SoTienThue float
);
INSERT INTO LoaiThue (MaLoaiThue, TenLoaiThue, MucThue,NgayThangNamDK,NoiDangKy,CCCDCanbo)
VALUES 
(1, N'Thuế thu nhập cá nhân', 0.1,'2003-02-01',N'Sóc Trăng','123456715'),
(2, N'Thuế giá trị gia tăng', 0.05,'2003-02-01',N'Hồ Chí Minh','123456715'), 
(3, N'Thuế thu nhập doanh nghiệp',0.02,'2003-02-01',N'Hà Nội','123456715');
INSERT INTO HoaDonThue (MaHoaDon, MaCD, MaLoaiThue, NgayLapHoaDon, SoTienThue)
VALUES
(6, '123456789', 2, '2022-04-20', 500000);
