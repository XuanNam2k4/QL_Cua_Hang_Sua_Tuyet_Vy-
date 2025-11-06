CREATE DATABASE Project_64131375
Go
USE Project_64131375

GO
CREATE TABLE LoaiSua (
  MaLoaiSua varchar(20) primary key,
  TenLoaiSua nvarchar(70) NOT NULL,
  AnhLoaiSua nvarchar(200)
)
GO
--Hãng Sãn Xuất
CREATE TABLE HangSanXuat (
  MaHSX varchar(20) primary key,
  TenHSX nvarchar(200) NOT NULL,
  DiaChi nvarchar(600) NOT NULL,
  SDT varchar(10) NOT NULL
)
GO
--Nhà Cung Cấp
CREATE TABLE NhaCungCap (
  MaNCC varchar(20) primary key,
  TenNCC nvarchar(200) NOT NULL,
  SDT varchar(10) NOT NULL,
  DiaChi nvarchar(600) NOT NULL,
  Email varchar(70)
)
GO

CREATE TABLE SanPhamSua (
  MaSua varchar(20) primary key,
  TenSua nvarchar(200) NOT NULL,
  MoTa nvarchar(4000) NOT NULL,
  AnhSua nvarchar(200) NOT NULL, 
  SoLuong int NOT NULL,
  HanSuDung nvarchar(70),
  DonGia int NOT NULL,
  MaLoaiSua varchar(20) foreign key references LoaiSua(MaLoaiSua),
  MaNCC varchar(20) foreign key references NhaCungCap(MaNCC),
  MaHSX varchar(20) foreign key references HangSanXuat(MaHSX)
)
GO

CREATE TABLE ChucVu (
  MaCV varchar(20) primary key,
  TenCV nvarchar(70) NOT NULL
)
GO

CREATE TABLE NhanVien (
  MaNV varchar(20) primary key,
  HoTenNV nvarchar(200) NOT NULL,
  AnhNV nvarchar(200) NOT NULL,
  SDT varchar(10) NOT NULL,
  Email varchar(70) NOT NULL,
  DiaChi nvarchar(600) NOT NULL,
  TenDN varchar(40) NOT NULL,
  MatKhau varchar(200) NOT NULL,
  MaCV varchar(20) foreign key references ChucVu(MaCV)
)
GO

CREATE TABLE KhachHang (
  MaKH varchar(20) primary key,
  HoTenKH nvarchar(200) NOT NULL,
  SDT varchar(10),
  Email varchar(70) NOT NULL,
  DiaChi nvarchar(600),
  TaiKhoan varchar(40),
  MatKhau varchar(200) NOT NULL,
  AnhKH nvarchar(200)
)
GO



CREATE TABLE HoaDon (
  MaHD varchar(20) primary key,
  NgayDH date NOT NULL,
  NgayGH date DEFAULT NULL,
  MaKH varchar(20) foreign key references KhachHang(MaKH),
  MaNV varchar(20) foreign key references NhanVien(MaNV),
  TongTien int,
  TinhTrangDuyet bit NOT NULL,
  TinhTrangDonHang bit NOT NULL
)
GO

CREATE TABLE CTHoaDon (
  MaHD varchar(20) foreign key references HoaDon(MaHD),
  MaSua varchar(20) foreign key references SanPhamSua(MaSua),
  SoLuongBan int NOT NULL,
  DonGiaBan int NOT NULL,
  primary key(MaHD, MaSua)
)
GO

CREATE TABLE ThamSo (
  MaTS varchar(20) primary key,
  TenTS nvarchar(200) NOT NULL,
  DVT nvarchar(20) NOT NULL,
  GiaTri nvarchar(20) NOT NULL,
  TrangThai bit NOT NULL
)
GO
INSERT INTO LoaiSua(MaLoaiSua,TenLoaiSua, AnhLoaiSua)
VALUES
	('SUATD', N'Sữa Người Tiểu Đường', 'anh_LS1.jpg' ),                                                                                                                                                         
	('SUABO', N'Sữa Bột', 'anh_LS2.jpg'),
	('SUAMB', N'Sữa Cho Mẹ Bầu', 'anh_LS3.jpg'),
	('SUACT', N'Sữa Người Cao Tuổi', 'anh_LS4.jpg'),
	('SUATU', N'Sữa Tươi', 'anh_LS5.jpg'),
	('SUACC', N'Sữa Tăng Chiều Cao', 'anh_LS6.jpg')
select * from LoaiSua
go

INSERT INTO HangSanXuat (MaHSX, TenHSX, DiaChi, SDT) 
VALUES
--1
('HSX001', N'CÔNG TY TNHH SỮA BỘT DINH DƯỠNG QUỐC TẾ ĐÔNG SANG', N'Số 15 Đường Trường Chinh, Quận Tân Bình, TP Hồ Chí Minh', '0913790560'),
--2
('HSX002', N'CÔNG TY TNHH SỮA BỘT QUỐC TẾ PHÁT DUYÊN ', N'Số 10 Đường Nguyễn Văn Cừ, Quận 9, TP Hồ Chí Minh', '0936226574'),
--3
('HSX003', N'CÔNG TY TNHH SỮA BỘT CAO TUỔI HÀ NAM', N'Số 5 Đường Lê Lợi, Thành phố Tam Kì, Quảng Nam', '0917896344'),
--4
('HSX004', N'CÔNG TY CỔ PHẦN SỮA BỘT HƯƠNG VIỆT', N'Số 20 Đường Nguyễn Thái Học, Thành phố Quy Nhơn Bình Định', '0977432711'),
--5
('HSX005', N'CÔNG TY TNHH SỮA BỘT DƯỠNG CHẤT HÀO QUANG', N'Số 29 Đường Lê Duẩn, Thành phố Đà Nẵng', '0917255491'),
--6
('HSX006', N'CÔNG TY TNHH SỮA BỘT QUỐC TẾ QUỐC HÀO', N'Khu Công nghiệp Tân Bình, TP Hồ Chí Minh', '0916622253'),
--7
('HSX007', N'CÔNG TY TNHH SỮA BỘT THẢO MỘC PHÚ HƯƠNG', N'Khu phố 1, Phường Dương Đông, TP Vũng Tàu,Bà Rịa Vũng Tàu', '0917649713'),
--8
('HSX008', N'CÔNG TY TNHH SỮA TIỆT TRÙNG XUẤT KHẨU TÂY NGUYÊN', N'Số 1 Đường Hùng Vương, Thành phố Buôn Ma Thuột, Đắk Lắk', '0914987752'),
--9
('HSX009', N'CÔNG TY TNHH SỮA BỘT TỐT CHO TRẺ EM NGỌC CẨM', N'Số 45 Đường Võ Văn Kiệt, Thành phố Hồ Chí Minh', '0923456789'),
--10
('HSX010', N'CÔNG TY TNHH SỮA DINH DƯƠNG QUỐC TẾ THÀNH ĐẠT', N'Số 10 Đường Hồng Hà, Quận Tân Bình, TP Hồ Chí Minh', '0943274468'),
--11
('HSX011', N'CÔNG TY TNHH SỮA BỘT SƠN BẮC', N'Thị trấn Phú Thứ ,Ba Vì Hà Nội', '0916357984'),
--12
('HSX012', N'CÔNG TY TNHH SỮA DINH DƯỠNG CHÍ THẮNG', N'Số 8 Đường Võ Văn Tần, Quận 3, TP Hồ Chí Minh', '0987543210'),
--13
('HSX013', N'CÔNG TY TNHH SỮA QUỐC TẾ THẢO PHÁT', N'Số 12 Đường Nguyễn Huệ, Quận 1, TP Hồ Chí Minh', '0978335501'),
--14
('HSX014', N'CÔNG TY TNHH SỮA DINH DƯỠNG HÒA BÌNH', N'Số 70 Đường Trần Hưng Đạo, Thành phố Hòa Bình', '0916392011'),
--15
('HSX015', N'CÔNG TY TNHH SỮA PHÁT TRIỂN THIÊN THẢO', N'Quốc lộ 1A, Xã Tân Hiệp, Huyện Long Thành, Đồng Nai', '0909375123'),
--16
('HSX016', N'CÔNG TY TNHH SỮA BỘT PHÚC HƯNG', N'Số 10 Đường Hoàng Diệu, Thành phố Hồ Chí Minh', '0986334570'),
--17
('HSX017', N'CÔNG TY TNHH SỮA BỘT TINH KHIẾT VIỆT NAM', N'Khu công nghiệp Sóng Thần, Bình Dương', '0915790345'),
--18
('HSX018', N'CÔNG TY TNHH SỮA TIỆT TRÙNG MINH TÙNG', N'Số 15 Đường Trường Sơn, Thành phố Quy Nhơn, Bình Định', '0908364521'),
--19
('HSX019', N'CÔNG TY TNHH DỊCH VỤ SỮA BA VÌ', N'Số 9 Đường Nguyễn Thị Minh Khai, Thành phố Hoà Bình', '0982211323'),
--20
('HSX020', N'CÔNG TY TNHH SỮA BỘT DƯỠNG CHẤT PHÚC AN', N'Số 67 Đường Nguyễn Trãi, Thành phố Bình Dương', '0945882367'),
--21
('HSX021', N'CÔNG TY TNHH SỮA BỘT THUẬN PHÁT ĐẶC BIỆT', N'Số 12 Phố Vĩnh Hưng, Quận Hai Bà Trưng, Hà Nội', '0912824586'),
--22
('HSX022', N'CÔNG TY TNHH SỮA PHÁT TRIỂN CÂN ĐỐI TÂM TÙNG', N'Số 9 Đường Trần Quang Khải, Quận 5, TP Hồ Chí Minh', '0937245876'),
--23
('HSX023', N'CÔNG TY TNHH SỮA BỘT ĐẬM ĐẶC PHÚ YÊN', N'Số 10 Đường Lê Duẩn, Thành phố Tuy Hòa, Phú Yên', '0942876532'),
--24
('HSX024', N'CÔNG TY TNHH SỮA QUỐC TẾ HÙNG DŨNG MIỀN TRUNG', N'Số 25 Đường Lý Thường Kiệt, Thành phố Huế', '0907668423'),
--25
('HSX025', N'CÔNG TY TNHH SỮA TƯƠI TINH KHIẾT PHƯƠNG TRANG', N'Số 10 Đường Nguyễn Thị Định, Thành phố Đà Nẵng', '0918262953'),
--26
('HSX026', N'CÔNG TY TNHH SỮA BỘT DƯỠNG CHẤT VINAMILK KIM CHI', N'Số 13 Đường Võ Văn Kiệt, TP Hồ Chí Minh', '0942764539'),
--27
('HSX027', N'CÔNG TY TNHH SỮA  VÀ DINH DƯỠNG AN LẠC', N'Số 11 Đường Nguyễn Trãi, Thành phố Hồ Chí Minh', '0913456789'),
--28
('HSX028', N'CÔNG TY TNHH SỮA BỘT TRẦN HÙNG', N'Số 20 Đường Điện Biên Phủ, Thành phố Pleiku, Gia Lai', '0931856765'),
--29
('HSX029', N'CÔNG TY TNHH SỮA TƯƠI SỨC SỐNG XANH HOA MINH', N'Số 1 Đường Tôn Đức Thắng, Thành phố Nha Trang, Khánh Hòa', '0942378431'),
--30
('HSX030', N'CÔNG TY TNHH SỮA BỘT MẸ BẦU CAO CẤP NHẬT MINH', N'Số 15 Đường Nguyễn Văn Linh, Thành phố Hà Nội', '0905281769');

go
select * from HangSanXuat

INSERT INTO NhaCungCap(MaNCC, TenNCC, SDT, DiaChi, Email) VALUES
--1
('NCC001', N'CÔNG TY TNHH THƯƠNG MẠI SỮA VIỆT PHÁT', '0908221501', N'31/9A Nguyễn Trãi, Phường 4, Quận 3, Tp. Hồ Chí Minh', 'vietphatmilk@hcm.vnn.vn'),
--2
('NCC002', N'CÔNG TY TNHH SỮA TƯƠI DINH DƯỠNG HUY MẠNH', '0943552311', N'108 Hào Kiệt, Đống Đa, Hà Nội', 'huymanhmilk@yahoo.com.vn'),
--3
('NCC003', N'CÔNG TY TNHH GIA PHÚC SẢN XUẤT SỮA CHẤT LƯỢNG', '0973197591', N'113/B Nguyễn Thị Minh Khai, Phường 3, Quận 1, Tp. Hồ Chí Minh ', 'giaphucmilk@gmail.com'),
--4
('NCC004', N'CÔNG TY TNHH TM & DV – NHÀ PHÂN PHỐI SỮA TIẾN ĐẠT', '0966799535', N'Số 09 Đường Hòn Rớ, Phường 7,Tuy Hoà, Phú Yên', 'info@suatiendat.vn'),
--5
('NCC005', N'CÔNG TY SỮA TƯƠI DINH DƯỠNG HOÀNG MINH', '0919424952', N'46 Đống Khiết, Ba Đình, Hà Nội', 'hoangminhmilk1009@gmail.com'),
--6
('NCC006', N'CÔNG TY TNHH SỮA DINH DƯỠNG SỨC KHỎE DƯƠNG TÂM', '0912400332', N'363 Điện Biên Phủ, Phường 11, Quận Thủ Đức, Tp. Hồ Chí Minh', 'duongtammilk@yahoo.com'),
--7
('NCC007', N'CÔNG TY TNHH SỮA TIỆT TRÙNG VI LƯỢNG CÔNG PHƯỢNG', '0988200434', N'112 Mai Xuân Thưởng, Phường 6, Quận Liên Chiểu, Tp. Hồ Chí Minh', 'congphuongmilk@gmail.com'),
--8
('NCC008', N'CÔNG TY TNHH SẢN XUẤT SỮA MINH THẮNG', '0969702606', N'Số 3 Tôn Đức Thắng, Phương 4, TP. Tuy Hoà, Phú Yên', 'cskh.minhthangmilk@gmail.com'),
--9
('NCC009', N'CÔNG TY TNHH SỮA BỘT VÀ DINH DƯỠNG THÀNH TÂM', '0958186167', N'2/4 Nguyễn Trãi, Tp. Tam Kỳ, Quảng Nam', 'thanhtammilk@gmail.com'),
--10
('NCC010', N'CÔNG TY TNHH SỮA BỘT QUỐC TẾ DINH DƯỠNG MINH THANH', '0912266029', N'319 Ngô Đến, Phường 4, Quận 3, Tp. Hồ Chí Minh', 'info@hoaithanhmilk.com'),
--11
('NCC011', N'CÔNG TY TNHH SỮA VIỆT HOÀI THƯƠNG', '0976190561', N'Số 12, Đường 2 Tháng 4, Tp. Nha Trang, Khánh Hoà', 'hoaithuongmilk@gmail.com'),
--12
('NCC012', N'CÔNG TY TNHH SẢN XUẤT SỮA PHÁT TRIỂN TRẺ EM MẠNH THẮNG', '0953477231', N'Đường Củ Chi, Quận 5, TP Hồ Chí Minh', 'chithangmilk@gmail.com'),
--13
('NCC013', N'CÔNG TY TNHH SỮA VÀ DINH DƯỠNG MẠNH QUYẾT', '0915249683', N'45 Trường Chinh, Hà Nội', 'manhquyetmilk@gmail.com'),
--14
('NCC014', N'CÔNG TY TNHH SỮA BỘT VIỆT PHONG', '0913587791', N'74 Đường Xô Viết Nghệ Tĩnh, Đà Nẵng', 'vietphongmilk@yahoo.com.vn'),
--15
('NCC015', N'CÔNG TY TNHH THƯƠNG MẠI SỮA HỒNG HẢI', '0943258665', N'110 Nguyễn Hữu Thọ, Quận 7, TP Hồ Chí Minh', 'honghaimilk@gmail.com'),
--16
('NCC016', N'CÔNG TY TNHH  CỔ PHẦN SỮA DINH DƯỠNG ĐỨC MINH', '0921785640', N'39/7 Đường Tạ Quang Bửu, Hà Nội', 'ducminhmilk@milk.com'),
--17
('NCC017', N'CÔNG TY TNHH SỮA VÀ DINH DƯỠNG  MINH KHÁNH', '0975438679', N'89 Trần Hưng Đạo, TP Hồ Chí Minh', 'minhkhanhmilk@gmail.com'),
--18
('NCC018', N'CÔNG TY TNHH THƯƠNG MẠI SỮA BỘT THANH TIỀN', '0977654345', N'23 Lê Hồng Phong, TP Cần Thơ', 'thanhtienmilk@yahoo.com.vn'),
--19
('NCC019', N'CÔNG TY TNHH SẢN XUẤT SỮA QUỐC TOÀN', '0916584598', N'8 Nguyễn Đức Cảnh, Quận 6, TP Hồ Chí Minh', 'quoctoanmilk@gmail.com'),
--20
('NCC020', N'CÔNG TY TNHH SỮA DINH DƯỠNG MẠNH VŨ', '0915420105', N'15 Đường Hồng Bàng, Quận 5, TP Hồ Chí Minh', 'manhvumilk@gmail.com'),
--21
('NCC021', N'CÔNG TY TNHH SỮA DINH DƯỠNG QUỐC TUYỂN', '0924671458', N'10/5 Đường Ngô Quyền, TP. Hồ Chí Minh', 'quoctuyenmilk@gmail.com'),
--22
('NCC022', N'CÔNG TY TNHH SỮA DINH DƯỠNG VIỆT HOÀNG', '0977450892', N'32 Đường Hồ Tùng Mậu, Quận 10, TP Đà Lạt', 'viethoangmilk@gmail.com'),
--23
('NCC023', N'CÔNG TY TNHH SẢN XUẤT SỮA THU HỒNG', '0981100283', N'34 Nguyễn Văn Linh, Quận 1, TP Hồ Chí Minh', 'kimchimilk@gmail.com'),
--24
('NCC024', N'CÔNG TY TNHH THƯƠNG MẠI SỮA TƯƠI CƯỜNG KHÁNH', '0927895643', N'16 Nguyễn Trường Tộ, Quận 2, TP Hồ Chí Minh', 'cuongkhanhmilk@gmail.com'),
--25
('NCC025', N'CÔNG TY TNHH SỮA BỘT HOÀNG MẠNH', '0967992123', N'72 Lý Thái Tổ, Quận Tây Hồ, Hà Nội', 'hoangmanhmilk@yahoo.com.vn'),
--26
('NCC026', N'CÔNG TY TNHH SỮA DINH DƯỠNG BẢO ĐẠT', '0912454789', N'26 Nguyễn Lương Bằng, Quận 4, TP Cần Thơ', 'baodatmilk@gmail.com'),
--27
('NCC027', N'CÔNG TY TNHH SẢN XUẤT SỮA THƯƠNG MẠI TIẾN THÀNH', '0915481678', N'45/9 Đường Trần Phú, Quận 3, TP Hồ Chí Minh', 'tienthangmilk@gmail.com'),
--28
('NCC028', N'CÔNG TY TNHH SỮA TIÊU CHUẨN VIỆT TIẾN', '0987824389', N'32 Đường Lê Lợi, TP Tuy Hoà - Phú Yên', 'viettienmilk@gmail.com'),
--29
('NCC029', N'CÔNG TY TNHH SỮA DINH DƯỠNG QUỐC BẢO', '0917345678', N'90 Hoàng Diệu, Quận 8, TP Đà Nẵng', 'quocbaomilk@gmail.com'),
--30
('NCC030', N'CÔNG TY TNHH SỮA BỘT CÔNG TÂM', '0938172635', N'56/7 Đường Nguyễn Văn Cừ, TP Quảng Ninh', 'congtammilk@gmail.com');

select * from NhaCungCap


INSERT INTO SanPhamSua(MaSua,TenSua,MoTa,AnhSua,SoLuong,HanSuDung,DonGia,MaLoaiSua,MaNCC,MaHSX) VALUES
--1
('SUATD001', N'Sữa CaloSure America+ Cho Người Tiểu Đường 800G', N'Là sữa có công thức dinh dưỡng chuyên biệt cho người đái tháo đường, giúp xây dựng chế độ dinh dưỡng ưu việt,
hỗ trợ kiểm soát đường huyết. Các dưỡng chất bổ sung đa dạng trong sữa Calosure America+ giúp tăng cường miễn dịch, tăng cườn sức khỏe tim mạch, bảo vệ cơ xương khớp và tăng cường 
sức khỏe phòng ngừa biến chứng cho người bệnh tiểu đường.Calosure America+ sử dụng hệ bột đường hấp thu chậm cao cấp để giúp hỗ trợ kiểm soát đường huyết sau khi ăn, kết hợp.
Sữa non ColosIgG 24h nhập khẩu từ Mỹ giúp Tăng cường miễn dịch và hệ dưỡng chất bổ sung ưu việt giúp Tăng cường sức khỏe tim mạch,bảo vệ sức khỏe toàn diện. Sản phẩm phù hợp
là bữa ăn bổ sung hàng ngày cho chế độ ăn của người tiểu đường, tiền tiểu đường.Sữa non là nguồn dinh dưỡng quý giá và duy nhất mà con người có được để bổ sung kháng thể IgG 
tự nhiên, giúp tăng cường miễn dịch ColosIgG 24h là sữa non thu trong vòng 24h đầu tiên sau sinh của bò khỏe mạnh tại các trang trại hạng A tại Mỹ nhập khẩu độc quyền bởi
Vitadairy.Kháng thể IgG là kháng thể mạnh mẽ nhất và quan trọng nhất của hệ miễn dịch. Kháng thể IgG tham gia loại bỏ vi khuẩn, virut bảovệ cơ thể khỏi bệnh tật,bảo vệ đường 
ruột, giúp phòng bệnh tiêu hóa.','anh1_SUATD.jpg',7,N' 1 năm',630000,'SUATD', 'NCC014', 'HSX010'),
--2
('SUATD002', N'Sữa Glucerna Úc Dành Cho Người Tiểu Đường 850G Abbott',N'là sữa dòng nhập khẩu chính hãng dành riêng cho thị trường Việt Nam và dòng Glucerna Úc dành riêng
cho thị trường Úc và được nhập khẩu nguyên lon. Mỗi dòng sản phẩm sẽ có những ưu điểm và nhược điểm mà người dùng có thể lựa chọn cho phù hợp. Theo đánh giá chung thì Glucerna
Úc có hương vị nhẹ dễ uống và giá cả rẻ hơn nhiều.Sữa Glucerna Úc được đánh giá là dinh dưỡng y học giúp ổn định đường huyết, bổ sung năng lượng, dưỡng chất phù hợp với bệnh
tiểu đường. Sử dụng sản phẩm hàng ngày sẽ giúp người bệnh phải kiêng khem nhiều có thể được cung cấp đầy đủ dưỡng chất từ đó giúp sức khỏe tốt hơn rất nhiều 28 loại vitamin và 
khoáng chất thiết yếu, bao gồm vitamin nhóm B, vitamin C và D, sắt, canxi và kẽm.Chất xơ prebiotic để hỗ trợ sức khỏe đường ruột.Sữa Glucerna Úc công thức mới cung cấp dinh
dưỡng đầy đủ và cân bằng để giúp quản lý mức đường huyết. Điều này làm cho nó trở thành lựa chọn cho những người bị tiền tiểu đường và tiểu đường, như một phần của kế hoạch 
quản lý bệnh tiểu đường bao gồm chế độ ăn uống và tập thể dục.', 'anh2_SUATD.jpg',8,N'2 năm', 795000,'SUATD', 'NCC022', 'HSX007'),
--3
('SUATD003', N'Sữa Glucerna 800g Abbott Cho Người Bệnh Tiểu Đường',N'là sản phẩm dinh dưỡng dầy đủ cân đối cho người đái tháo đường, tiền đái tháo đường và đái tháo đường thai 
kỳ. Công thức Glucerna được đặc chế giúp kiểm soát đường huyết, tăng cường sức khỏe tim mạch. Ngoài ra sản phẩm còn phù hợp cho phụ nữ đái tháo đường thai kỳ giúp ổn định đường
huyết, để mẹ tròn con vuông. Glucerna có thể dùng thay thế toàn phần bữa ăn chính hoặc để làm bữa ăn phụ.Công thức tiên tiến và hệ dưỡng chất mới với hệ bột đường tiên tiến 
có chỉ số đường huyết thấp và được tiêu hóa từ từ, hàm lượng Inositol tăng 4 lần (so với Glucerna cũ) hỗ trợ kiểm soát tốt đường huyết.Dinh dưỡng đầy đủ cân đối với 28 Vitamin 
và khoáng chất, tăng cường hàm lượng Vitamin D (+150%), sắt (+50%), Canxi (+30%), kẽm +25% so với Glucerna cũ.Vitamin D và Canxi giúp xây dựng và duy trì xương chắc khỏe, Kẽm 
và sắt hỗ trợ hệ miễn dịch.Hỗn hợp chất béo đặc chế giàu chất béo không no một nối đôi (MUFA) và chất béo không no nhiều nối đôi PUFA tốt cho tim mạch.Sản phẩm không chứa Gluten
và rất ít lactose nên phù hợp với người bất dung nạp lactose','anh3_SUATD.jpg',7,N'3 năm', 855000,'SUATD', 'NCC004','HSX019'),
--4
('SUATD004', N'Sữa DiabetCare Gold 900g Người Bệnh Đái Tháo Đường',N'là sữa có nguồn dinh dưỡng đặc biệt dành cho người bệnh tiểu đường, được nghiên cứu và phát triển bởi các chuyên
gia dinh dưỡng hàng đầu. Với công thức mới 3Care cung cấp đầy đủ dưỡng chất và năng lượng giúp ổn định đường huyết.Chỉ số đường huyết (GI) thấp = 31.5 theo kết quả kiểm nghiệm
lâm sàng do Trung tâm Dinh dưỡng thực hiện, đáp ứng khuyến nghị của IDF (Hội Đái tháo đường Hoa Kỳ).Ổn định đường huyết Isomaltulose là loại đường bột được tiêu hóa và hấp thu
từ từ vào cơ thể, không làm tăng đường huyết đột ngột, giúp duy trì đường huyết ổn định.Tăng sức đề kháng vitamin A, E, C, Zn là các thành phần quan trọng giúp cơ thể tăng 
cường sức đề kháng, chống lại sự tấn công của vi khuẩn gây bệnh giúp cơ thể khỏe mạnh, hạn chế quá trình tiến triển các biến chứng của bệnh đái tháo đường.Tốt cho tim mạch
MUFA, PUFA là các axít béo không no cần thiết giúp giảm nồng độ cholesterol & triglyceride trong máu, kiểm soát các bệnh viêm khớp, viêm nhiễm, huyết áp, giảm các nguy cơ bệnh 
lý về tim mạch. Giúp hệ tiêu hóa hoạt động khỏe mạnh, hấp thu tốt các dưỡng chất.','anh4_SUATD.jpg',6,N'2 năm', 505000,'SUATD', 'NCC003','HSX020'),
--5
('SUATD005', N'Sữa Gluvita Gold 900g Dinh Dưỡng Cho Người Bệnh Tiểu Đường',N'là sản phẩm cung cấp một chế độ ăn cân đối lành mạnh, giúp kiểm soát và ổn định đường huyết cho
người bị đái tháo đường hoặc tiền đái tháo đường.Gluvita Gold rất dễ tiêu hóa, đặc biệt được bổ sung các thành phần giúp bảo vệ hệ tim mạch và thị lực.Kiểm soát đường huyết
Hệ bột đường tiên tiến LGI có chỉ số đường huyết thấp được hấp thu từ từ giúp kiểm soát đường huyết sau khi uống và ổn định đường huyết lâu dài.Cải thiện tiêu hóa và hấp thu
Phức hợp đạm sữa, đạm đậu nành dễ hấp thu, cung cấp nguồn acid amin đa dạng.FOS/Inulin là các chất xơ hòa tan giúp làm chậm quá trình hấp thu đường, tăng sinh hệ vi 
khuẩn đường ruột, tăng miễn dịch và phòng ngừa táo bón.Tăng sức khỏe tim mạch.Các thành phần chất béo có lợi MUFA, PUFA giúp cải thiện mỡ máu, giảm LDL – Choleserol và phòng 
ngừa bệnh tim mạch.Phục hồi sức khỏe.Vitamin A, C, E kết hợp với Kẽm, Selen giúp tăng cường sức đề kháng, giảm mệt mỏi.Vitamin B1, B2, B6, B12 tăng cường chuyển hóa.
Bảo vệ thị lực giúp mắt luôn sáng khỏe, hạn chế tác động của lão hóa và hạn chế biến chứng trên mắt ở bệnh nhân đái tháo đường.Với người đái tháo đường, người rối loạn dung nạp
Glucose, áp dụng một chế độ ăn khoa học là yếu tố giúp kiểm soát đường huyết và nâng cao chất lượng sống.','anh5_SUATD.jpg',7,N'3 năm', 520000,'SUATD', 'NCC023','HSX001'),
--6 sữa bột
('SUABO001', N'Sữa Bột A2 Úc Nguyên Kem Full Cream Milk 850G', N'là dòng sản phẩm sữa dạng bột nhập khẩu 100% Úc với nguồn sữa tươi nguyên chất A2 tự nhiên thơm ngon bổ dưỡng.
Trong khi hầu hết các thương hiệu sữa bò ngày nay đều chứa hỗn hợp cả Protein A1 và A2 thì dòng sản phẩm A2 được sản xuất từ nguồn sữa đến từ những con bò thuần chủng, được chăn nuôi tự nhiên 
để chỉ sản xuất protein A2 tự nhiên và không có A1 – Đây là sự khác biệt lớn nhất có trong sữa tươi dạng bột A2 của Úc.Đặc biệt là trong sữa tươi A2 có chứa Beta Casein – dưỡng chất chiếm 1/3
trong tổng số Protein trong sữa có vai trò quan trọng giúp vận chuyển dưỡng chất và khoáng chất cần thiết như Canxi, photpho… đến các cơ quan như cơ bắp, xương, mô cơ giúp cho
cơ thể khỏe mạnh. Sản phẩm còn rất giàu vitamin và khoáng chất thiết yếu sẽ là nguồn dinh dưỡng quan trọng cho mọi thành viên trong gia đình khỏe mạnh, tinh thần minh mẫn.
Sữa tươi A2 nguyên kem siêu lành tính, phù hợp cho cả người uống sữa là đau bụng, đầy bụng, tiêu chảy, khó tiêu. Vì chứa 100% đạm A2, loại đạm dành cho cả người bụng yếu,
kém tiêu hoá. Thông thường sữa hiện nay chỉ chứa đạm A1, đây được coi là tác nhân gây ra đau bụng, gặp vấn đề tiêu hoá khi uống sữa.','anh1_SUABO.jpg',10,N'1 năm', 330000,'SUABO', 'NCC008','HSX006'),
--7
('SUABO002', N'Sữa NutriniDrink Powder Neutral 400g', N'là sữa giàu năng lượng, dinh dưỡng hoàn chỉnh và cân bằng cung cấp 1,5Kcal trên khối lượng nhỏ 1ml với hương
vị tuyệt vời và hiệu quả nhanh, phục hồi nhanh. Sản phẩm đã được chứng minh lâm sàng giúp cải thiện trọng lượng cơ thể của trẻ sau 28 ngày khi dùng 600kcal/ngày.Đối với những
trẻ suy dinh dưỡng vừa và nhẹ, 28 ngày là đủ để đạt được bắt kịp tăng trưởng. Nhưng với trường hợp nghiêm trọng hơn thì cần nhiều thời gian hơn.Sữa NutriniDrink giúp cho cơ 
thể có thể dung nạp tốt, ăn ngon miệng, với hệ tiêu hóa và sự ổn định được đánh giá tốt với tỷ lệ hài lòng cao: 80%.Đây là sẩn phẩm duy nhất có công thức bào chế trung tính 
có thể thêm trực tiếp vào thức ăn làm nên chế độ ăn cân bằng và khỏe mạnh cho trẻ có nguy cơ suy dinh dưỡng.NutriniDrink trung tính là sự lựa chọn không quan tâm đến hương 
vị (mùi vị rất nhẹ) nên có thể thêm vào trái cây, đồ uống, thúc ăn mặn và đồ tráng miệng để làm nên chế độ ăn cân bằng và khỏe mạnh.Những bệnh có liên quan đến suy dinh dưỡng 
cần bồi bổ và nâng cao sức khỏe, trẻ em từ 1 tuổi trở lên. Sản phẩm sữa có dinh dưỡng y tế đặc biệt dành cho việc quản lý chế độ ăn uống của những bệnh có liên quan đến
suy dinh dưỡng và kiệt sức, khó nhai, khó nuốt. Sản phẩm không chứa gluten, không chứa lactose và không chứa chất xơ.','anh2_SUABO.jpg',10,N'2 năm', 365000,'SUABO', 'NCC001','HSX008'),
--8
('SUABO003', N'Sữa OGGI Tăng Cân Cho Người Gầy 900G', N'là sữa giúp cơ thể tăng cân là phải đảm bảo tổng năng lượng cung cấp cho cơ thể lớn hơn năng lượng tiêu thụ. Năng lượng dư thừa
sẽ giúp sản sinh, tái tạo tế bào mô cơ, dự trữ mỡ mới có thể tăng cân được. Nhưng với những người đã gầy thì việc ăn uống một lượng nhiều hàng ngày lại không hề đơn giản, 
nên giải pháp lúc này là dùng sữa cao năng lượng, giàu dưỡng chất Oggi.Sữa Oggi là một sản phẩm dinh dưỡng cao năng lượng giúp bù đắp năng lượng thiếu hụt hàng ngày, tăng sức 
đề kháng, giúp ăn ngủ ngon tiêu hóa tốt từ đó giúp tăng cân hiệu quả. Sản phẩm đã được rất nhiều người gầy sử dụng hàng ngày đem lại hiệu quả tăng cân rất tốt!.Với công thức 
dinh dưỡng cao năng lượng, đậm độ dinh dưỡng 1.2Kcal/ml giúp tăng cân hiệu quả và duy trì cân nặng ổn định. Chất béo chuỗi trung bình MCT hấp thu nhanh và trực tiếp, giúp cung 
cấp năng lượng nhanh chóng và hiệu quả.Vitamin A, C, E, Kẽm, Selen giúp tăng cường sức đề kháng, hỗ trợ hoạt động của hệ miễn dịch, chống lại các tác nhân gây bệnh từ môi
trường, đem lại một cơ thể khỏe mạnh.Lysine, Vitamin nhóm B kích thích cảm giác ăn ngon miệng, thúc đẩy quá trình chuyển hóa dinh dưỡng trong cơ thể, giúp ăn ngon,
ngủ ngon.','anh3_SUABO.jpg',5,N'3 năm',340000,'SUABO', 'NCC006','HSX002'),
--9
('SUABO004', N'Sữa CALOKID Gold 900g', N'là dòng sữa sản phẩm cải tiến mới của Vitadairy giúp bé tăng cân khoa học, tiêu hóa tốt, phát triển trí não, tăng cường hệ miễn dịch
Trẻ trong giai đoạn từ 1-10 tuổi có các biểu hiện  suy dinh dưỡng biếng ăn chậm tăng cân cần một chế độ dinh dưỡng khoa học, không chỉ giúp bé cải thiện cân nặng
phù hợp ở từng giai đoạn phát triển, mà còn giúp giải quyết các khó khăn của bé ở đường tiêu hóa, giúp bé ăn uống tốt, tiêu hóa và hấp thu tốt, để bé mau chóng thoát
khỏi tình trạng suy dinh dưỡng, phát triển khỏe mạnh cả về thể chất và trí tuệ.Calokid Gold được thiết kế đĐậm độ dinh dưỡng linh hoạt từ 1.0-1.2kcal/ml đảm bảo cung cấp tới
600kcal-720kcal/ngày, giúp tăng cường dinh dưỡng hiệu quả để bé tăng cân khoa học ở từng giai đoạn phát triển. Kết hợp phức hợp đạm có giá trị sinh học cao Đạm Whey thủy phân,
Whey cô đặc và Đạm sữa giúp bé duy trì cân nặng ổn dịnh và phát triển khỏe mạnh.Trong sữa Calokid Gold được bổ sung hàm lượng cao DHA, Choline cần thiết cho sự hoàn thiện và phát 
triển cấu trú não bộ, thị giác, giúp bé nhanh nhẹn và thông minh kết hợp với sữa non ColosIgG 24h giúp bé tăng cường miễn dịch để chống lại các tác nhân gây bệnh, giúp bé khỏe mạnh và 
giảm tỷ lệ ốm bệnh. Kẽm, Selen, Vitamin A giúp tăng cường sức đề kháng và hỗ trợ hoạt động của hệ miễn dịch hiệu quả.','anh4_SUABO.jpg',7,N'3 năm',460000,'SUABO', 'NCC009','HSX009'),
--10
('SUABO005', N'Alpha Lipid SD2 giảm cân an toàn kiểm soát cân nặng', N'là thực phẩm cao cấp giúp cân bằng dinh dưỡng, quản lý cân nặng, nhanh chóng đem lại vóc dáng cân đối và thân hình lý tưởng.
 bạn đang thừa cân, béo phì, mất kiểm soát về cân nặng gây mất tự tin trong công việc và sinh hoạt hàng ngày thì xin chúc mừng bạn đã tìm đến đúng sản phẩm giúp kiểm soát cân nặng tốt nhất hiện nay. 
 Bạn sẽ nhanh chóng lấy lại vóc dáng cân đối, eo thon để thỏa sức mặc những bộ váy thon thả mà mình mong ước bấy lâu.Thực phẩm bổ sung Alpha Lipid SD2 sẽ đem đến một chế độ ăn 
 lành mạnh hoàn toàn từ thiên nhiên an toàn tuyệt đối từ đậu nành, trà sữa, phospholipid… của tập đoàn NewImage nổi tiếng hàng đầu thế giới đến từ New Zeland. Đây là sản phẩm 
 duy nhất trên thị trường ứng dụng công nghệ Alpha Lipid độc quyền giúp bao bọc thành phần dinh dưỡng để giúp cơ thể hấp thu tối đa dưỡng chất với một khẩu
 phần ăn nhỏ.Công nghệ Alpha Lipid tạo nên sự khác biệt hoàn toàn đối với các sản phẩm giảm cân khác. Điển hình cho sản phẩm nổi tiếng sữa non Alpha Lipid Lifeline đang được rất nhiều người
 trên toàn thế giới sử dụng và cho hiệu quả rất tốt về sức khỏe. Alpha Lipid SDII giúp chuyển hóa các chất dinh dưỡng trực tiếp trên ruột non vào máu và nuôi 
 dưỡng cơ thể.','anh5_SUABO.jpg',6,N'4 năm',1360000,'SUABO','NCC026','HSX005'),

 --sửa mẹ bầu
--11
('SUAMB001', N'Sữa Enfamama A+ DHA hương vani cho mẹ bầu và cho con bú 830g', N'là sự lựa chọn hoàn hảo giúp bổ sung nhu cầu dinh dưỡng của người mẹ trong giai đoạn mang thai và cho con 
bú để thai nhi khoẻ mạnh và phát triển trí não tối ưu.Sữa Enfamama A+ được kiểm trứng đáp ứng đầy đủ nhu cầu dinh dưỡng dành cho mẹ bầu và sau sinh. Hơn nữa, sản phẩm
còn giúp cung cấp hàm lượng cao DHA và các dưỡng chất thiết yếu như Choline, Axit folic hàm lượng cao giúp thai nhi phát triển trí não, giảm thiểu các nguy cơ ảnh hưởng
đến sự phát triển bào thai.Hệ chất xơ cao cấp giúp mẹ giảm bớt nỗi lo táo bón và hỗ trợ sức khỏe đường ruột mà nhiều mẹ bầu gặp phải. Hệ tiêu hóa khỏe mạnh sẽ giúp mẹ hấp thu 
tối đa nguồn dinh dưỡng đến từ Enfamama A+.Hàm lượng cao các dưỡng chất thiết yếu (Axit Folic, Canxi, Sắt, Vitamin D, B12…) giúp đáp ứng nhu cầu dinh dưỡng gia tăng trong giai 
đoạn mang thai và cho con bú.Sữa Enfamama A cải tiến bổ sung chất xơ giúp mẹ giảm bớt nỗi lo táo bón hỗ trợ sức khỏe đường ruột..Enfamama A chứa hệ dưỡng chất đặc biệt giúp
hỗ trợ mẹ mang thai và sự phát triển của trẻ khỏe mạnh. Axit Folic giúp ngăn ngừa nguy cơ dị tật ống thần kinh ở thai nhi, Chất sắt cho nhu cầu gia tăng nhanh trong suốt thai
kỳ. Chất sắt là thiết yếu cho sự hình thành tế bào hồng cầu của phụ nữ mang thai và thai nhi. Canxi giúp xương và răng chắc khỏe.Thời gian tốt nhất để sử dụng sữa Enfamama A+ 
là sau bữa ăn chính 2 giờ, hoặc trước khi đi ngủ 1 giờ. Khi đó cơ thể sẽ hấp thu tối đa dưỡng chất bổ sung cho cơ thể và cho thai nhi. ','anh1_SUAMB.jpg',7,N'2 năm',550000,'SUAMB','NCC011','HSX026'),
--12
('SUAMB002', N'Sữa bầu Similac Mom hương vani 400g', N'là sữa Similac Mom với hệ dưỡng chất IQ plus gồm lutein, vitamin E tự nhiên, DHA, cholin, acid folic, sắt cùng 24
vitamin và khoáng chất thiết yếu, giúp đáp ứng nhu cầu dinh dưỡng tăng cao trong suốt thời kỳ mang thai và cho con bú.Cung cấp dưỡng chất giúp phát triển não bộ hệ dưỡng 
chất IQ Plus độc đáo phối hợp khoa học của lutein, vitamin E tự nhiên và DHA cùng cholin, acid folic và sắt các dưỡng chất thiết yếu cho não bộ DHA và cholin: đáp ứng nhu cầu
tăng thêm, hỗ trợ phát triển não bộ.. Cung cấp 100% nhu cầu acid folic giúp giảm nguy cơ khuyết tật ống thần kinh.. Sắt: giảm thiểu nguy cơ thiếu máu do thiếu sắt trong thai kỳ.
Giúp hấp thu canxi tốt:. Chứa vitamin D và FOS chuỗi ngắn, đã được nghiên cứu lâm sàn chứng mình giúp canxi được hấp thu tốt hơn.Hàm lượng canxi cao đáp ứng nhu cầu gia tăng 
trong giai đoạn mang thai.Tăng cường sức đề kháng: hệ dưỡng chất đặc biệt IMMUNIFY gồm prebiotics, kẽm, các chất chống oxy hóa: vitamin C, E và selen giúp tăng cường sức đề kháng của cơ thể.
Giúp hệ tiêu hóa khỏe mạnh, ngăn ngừa táo bón: đặc biệt chưa FOS chuỗi ngắn (chất xơ -prebiotic) cải thiện nhu động đại tràng, giúp giảm tình trạng táo bón thường gặp trong thai kỳ.
Similac Mom đầu tiên được chứng minh lâm sàng ở Việt Nam cho thấy nhiều lợi ích cho phụ nữ có thai và cho con bú.','anh2_SUAMB.jpg',10,N'2 năm',235000,'SUAMB','NCC013','HSX012'),
--13
('SUAMB003', N'Sữa bầu Friso Gold Mum hương cam 900g ', N'là sữa cung cấp nguồn dinh dưỡng kép bởi công thức DualCare+ độc đáo cho mẹ và bé trong cả thai kỳ.Công thức DualCare+ 
được thiết kế để cung cấp các chất dinh dưỡng thiết yếu như protein, chất béo, vitamin và khoáng chất hỗ trợ mẹ có đủ năng lượng và sức khỏe trong quá trình mang thai và cho 
con bú, đồng thời đóng góp vào sự phát triển toàn diện của em bé.Sữa bầu bổ sung các dưỡng chất như axit folic, i-ốt, canxi, DHA, vitamin D, vitamin B12… tạo nền tảng vững 
chắc giúp hoàn thiện cấu trúc cơ thể và chức năng của não bộ, thị giác thai nhi.Hỗ trợ tiêu hóa, cung cấp năng lượng và giảm căng thẳng ở mẹ bầu nhờ magie, prebiotics, 
probiotics và các vitamin nhóm B.Sữa bầu Friso Gold Mum hương cam 900g chứa prebiotics và probiotics có lợi cho sức khỏe đường ruột, hỗ trợ hệ miễn dịch, cải thiện tiêu hóa 
giúp cơ thể hấp thụ chất dinh dưỡng tốt và chuyển hóa nguồn năng lượng ổn định.','anh3_SUAMB.jpg',7,N'3 năm',490000,'SUAMB','NCC012','HSX015'),
--14
('SUAMB004', N'Sữa bầu Morinaga hương trà sữa 800g ', N'là sữa bầu đến từ nhà Morinaga - thương hiệu uy tín của Nhật Bản, đảm bảo tiêu chuẩn chất lượng cao và an toàn
cho mẹ và bé.chứa tổ hợp các loại vitamin và khoáng chất cần thiết, bao gồm vitamin A, B, C, D, sắt, canxi, magie, axit folic,... giúp đáp ứng nhu cầu dinh dưỡng cho phụ 
nữ mang thai và cho con bú. Nhờ đó, sản phẩm giúp mẹ bầu duy trì sức khỏe tốt và hỗ trợ sự phát triển toàn diện của thai nhi.Sữa bầu Morinaga 800g chứa thành phần axit folic 
là một dưỡng chất quan trọng trong giai đoạn đầu thai kỳ, có vai trò tạo máu và ngăn ngừa dị tật ống thần kinh ở thai nhi. Axit folic kết hợp với hàm lượng sắt lớn giúp ngăn
ngừa tình trạng thiếu máu cho mẹ bầu (do thời điểm này nhu cầu sắt của mẹ thường tăng cao), đảm bảo cung cấp đủ oxy cho thai nhi, giúp mẹ và bé khỏe mạnh trong suốt thai kỳ.
Dòng sữa bầu sở hữu đa dạng các loại vitamin cần thiết như vitamin A, B1, B2, B6, B12, C, D,... không chỉ giúp mẹ có thai kỳ khỏe mạnh mà còn tăng cường dưỡng chất để đảm bảo
bé phát triển tốt từ giai đoạn trong bụng mẹ cho đến khi chào đời.Hàm lượng chất xơ dồi dào trong sữa bầu giúp phát triển hệ vi sinh đường ruột, ngăn ngừa táo bón và hỗ trợ tiêu hóa 
khỏe mạnh cho mẹ. Nhờ đó, mẹ có một thai kỳ thoải mái và dễ chịu.','anh4_SUAMB.jpg',9,N'3 năm',570000,'SUAMB','NCC007','HSX027'),
--15
('SUAMB005', N'Sữa bầu Anmum Materna hương vani 800g ', N' là sản phẩm của thương hiệu có xuất xứ từ New Zealand, tạo nên nền tảng dinh dưỡng vững chắc giúp thai kỳ khỏe mạnh,
mẹ tròn - con vuông.Sữa bổ sung hàm lượng lợi khuẩn đường ruột probiotics DR10 và chất xơ hỗ trợ hệ tiêu hóa khỏe mạnh, giúp mẹ hấp thu dưỡng chất tốt hơn, hạn chế tình
trạng táo bón và nâng cao khả năng miễn dịch của cơ thể.Điểm đặc biệt ở dòng sữa bầu này chính là sự kết hợp giữa DHA và GA-Connex (chứa ganglioside). Trong đó, DHA là 
dưỡng chất giúp hình thành các tế bào não, còn ganglioside có tác dụng kết nối các tế bào não. Nhờ vậy sữa có thể hỗ trợ tăng khả năng tiếp thu, ghi nhớ và xử lý thông tin
của não bộ, giúp bé yêu phát triển trí não ngay từ trong bụng mẹ.Sữa Anmum còn cung cấp nguồn dinh dưỡng cân bằng và đầy đủ với folate (cần thiết cho sự phát triển não bộ 
làm giảm nguy cơ khiếm khuyết ống thần kinh), canxi (giúp hệ xương chắc khỏe), sắt (đặc biệt quan trọng trong việc hình thành hồng cầu, hỗ trợ thể tích máu tăng 50% 
trong thai kỳ) và hơn 30 loại vitamin, khoáng chất giúp mẹ có thai kỳ khỏe mạnh.Sữa bầu Anmum còn được yêu thích nhờ có hương vani thơm ngon, vị ít béo và ít ngọt,
đảm bảo an toàn cho phụ nữ mang thai, không lo bị tiểu đường thai kỳ.','anh5_SUAMB.jpg',7,N'2 năm',465000,'SUAMB','NCC015','HSX013'),

--sữa cao tuổi
--16
('SUACT001', N'Sữa Ensure Úc 850G Abbott', N'là sữa được đặc chế với thành phần và công thức đặc biệt giúp cấp một chế độ dinh dưỡng hợp lý cân đối để duy trì một cơ thể khỏe mạnh.
Trong đó yếu tố quan trọng phải kể đến đó chính là giàu năng lượng, vitamin và khoáng chất cần thiết mà một cơ thể đang cần.Trong sữa Ensure có bổ sung hỗn hợp chất béo 
giàu MUFA, PUFA rất tốt cho tim mạch, đây là thành phần rất cần có đối với người ở độ tuổi trung và cao tuổi. Hệ tim mạch khỏe mạnh giúp cho cơ thể luôn ở trạng thái dễ chịu,
điều hòa mọi chức năng trong cơ thể.Chất xơ hòa tan FOS trong sữa Ensure Úc giúp cho hệ tiêu hóa khỏe mạnh, tránh các vấn đề tiêu hóa như táo bón, tiêu chảy ngoài ra còn giúp 
hấp thu tốt các dưỡng chất khác trong bữa ăn như: Canxi, Sắt,….Choline, Acid Oleic trong sữa giúp hỗ trợ sự hoạt động của hệ thần kinh để tăng cường trí nhớ, vấn đề mà người 
cao tuổi hay gặp phải. Đây cũng là một trong các tiêu chí mà các sản phẩm Ensure rất trú trọng để giúp cải thiện trí nhớ cho người cao tuổi.Ngoài ra trong sữa còn chứa rất 
nhiều các Vitamin và khoáng chất khác có giá trị sinh học cao như: Sắt, kẽm, Canxi, Magie, Vitamin D…. cần thiết cho một cơ thể khỏe mạnh. Đặc biệt trong sữa Ensure Úc
không chứa Gluten và đường Lactose, hàm lượng acid béo no và cholesterol thấp rất có lợi cho chế độ ăn lành mạnh.','anh1_SUACT.jpg',5,N'4 năm',790000,'SUACT','NCC017','HSX016'),
--17
('SUACT002', N'Sữa CaloSure America 800G Giàu Sữa Non Mỹ', N'là sữa thực phẩm dinh dưỡng Y học giàu sữa non giúp tăng cường miễn dịch, tốt cho tim mạch, dinh dưỡng toàn diện
cho người trung và cao tuổi.Tác động kép của Sterol esters thực vật giúp giảm mỡ máu xấu và Nattokinase hỗ trợ tan huyết khối, tăng lưu thông máu sẽ giúp hệ tim mạch khỏe mạnh, 
hỗ trợ giảm nguy cơ đột quỵ. Kết hợp Omega-3, Omega-6, MUFAs, PUFAs từ dầu hạt hướng dương, dầu hạt lanh, giúp xây dựng một chế độ ăn lành mạnh để phòng ngừa bệnh tim mạch 
và tăng.Bộ 3 dưỡng chất hoàn hảo HMB – giúp duy trì khối cơ Canxi – giúp tăng cường xương chắc khỏe; Glucosamine – thành phần có trong mô sụn và dịch khớp giúp khớp linh hoạt
Calosure America giúp củng cố và bảo vệ toàn diện hệ Cơ – Xương – Khớp khỏe mạnh lâu dài. Trong sữa Calosure America bổ sung dưỡng chất GABA chiết xuất từ mầm gạo lên men 
giúp giảm căng thẳng, cải thiện chất lượng giấc ngủ. Kết hợp Taurine giúp hỗ trợ hoạt động trí não, tăng cường sự minh mẫn và khả năng tập trung.Sũa giúp đường ruột ổn định, 
tăng hấp thu dinh dưỡng, hạn chế rối loạn tiêu hoá và phòng ngừa táo bón.','anh2_SUACT.jpg',8,N'3 năm',630000,'SUACT','NCC016','HSX017'),
--18
('SUACT003', N'Sữa Enplus Gold 900g Người Cao Tuổi, Người Ốm', N'là sữa có giải pháp dinh dưỡng cho người cao tuổi, người bệnh, người ăn uống kém.Nuti Enplus Gold là giải pháp dinh dưỡng tối ưu giúp người 
cao tuổi khỏe mạnh, trí tuệ minh mẫn, giúp người bệnh phục hồi nhanh, giúp người ăn uống kém ăn ngon miệng hơn để có một sức khỏe hoàn hảo tận hưởng niềm vui cuộc sống.Sản phầm
EnPlus Gold đã được kiểm nghiệm lâm sàng bỡi Viện Dinh dưỡng Quốc gia với công thức NUTRITION GOLD gồm các tính năng nổi bật.Tốt cho tim mạch: MUFA, PUFA giúp giảm cholesterol 
trong máu, giảm huyết áp, chống viêm nhiễm, giảm các nguy cơ bệnh lý về tim mạch.Trí óc minh mẫn Cholin hỗ trợ hoạt động não bộ giúp hạn chế và cải thiện các chứng bệnh giảm trí 
nhớ ở người cao tuổi.Giúp xương chắc khỏeCanxi, phospho, vitamin D3 tối ưu hóa quá trình khoáng hóa cho xương, giúp hệ xương vững chắc, phòng ngừa loãng xương.Ngăn ngừa táo bón
FOS/Inulin hỗ trợ hệ đường ruột khỏe mạnh, hấp thu hiệu quả các dưỡng chất, ngừa táo bón.Ngon miệng, ngon giấc Vitamin nhóm B, acid folic, sắt, kẽm, Magie, Selen tăng cảm giác
ngon miệng, tăng sức đề kháng và có giấc ngủ ngon.Sản phẩm đã được kiểm nghiệm lâm sàng bỡi Viện Dinh dưỡng Quốc gia cho thấy có sự cải thiện tình trạng dinh dưỡng rõ rệt, cải thiện tình trạng 
thiếu máu, thiếu Vitamin A, thiếu kẽm, giảm táo bón và rối loạn tiêu hóa ở người trung niên và cao tuổi.','anh3_SUACT.jpg',6,N'2 năm',480000,'SUACT','NCC018','HSX003'),
--19
('SUACT004', N'Sữa Eurofit Gold 900g Người Cao Tuổi', N'là sữa có dinh dưỡng bổ sung giúp người cao tuổi phục hồi sức khỏe nhanh, tiêu hóa tốt, phòng bệnh tim mạch và loãng xương, 
tăng cường trí nhớ và giảm stress.Sữa Eurofit Gold là sản phẩm dinh dưỡng cao năng lượng được sản xuất trên dây truyền công nghệ hiện đại của Eneright và phân phối bởi
 sản phẩm có nguyên liệu nhập khẩu từ NewZeland.Sữa Eurofit Gold công thức tiên tiến được chứng nhận bởi bộ Y Tế Việt Nam dành cho người trưởng thành, đặc biệt thích hợp với 
 người trung và cao tuổi, giảm nguy cơ loãng xương, thiếu canxi, người ốm cần phục hồi sức khỏe.Sản phẩm giúp cung cấp năng lượng dinh dưỡng dễ hấp thu, đa dạng các vitamin
 và khoáng chất dùng để thay thế bữa ăn phụ hoặc bổ sung cho chế độ ăn hàng ngày thiếu vi chất dinh dưỡng. Sử dụng sữa Eurofit Gold hàng ngày giúp tiêu hóa tốt, 
 tăng cường sức khỏe, vui khỏe mỗi ngày.Hỗ trợ não bộ, tăng trí nhớ và giảm stress Palatinose thành phần đường hấp thu và phóng thích chậm, giúp điều hòa nồng độ dưỡng chất
 trong máu, ưu tiên cung cấp dinh dưỡng ổn định, từ từ cho hoạt động của não bộ và giúp tăng cường sự tỉnh táo, giảm stress','anh4_SUACT.jpg',9,N'4 năm',900000,'SUACT','NCC019','HSX004'),
--20
('SUACT005', N'Sữa Anlene Gold 3 Khoẻ hương Vani 800g ', N'là sữa có công thức Movepro mới giúp chăm sóc tốt cho cơ, xương, khớp cho người cao tuổi.Cuộc sống càng hiện đại, 
những giây phút sống vui khỏe bên người thân và bạn bè càng là những điều ta cần nhất. Nhưng đôi lúc, cơ thể lại tỏ dấu hiệu “lão hóa” khiến cuộc vui bị gián đoạn.Vì thế, 
hãy uống Anlene 3 Khoẻ mỗi ngày với Canxi cho Xương chắc, Đạm giúp Cơ săn chắc và Collagen cho Khớp linh hoạt để những phút giây chơi đùa cùng con, “phiêu” theo từng điệu nhạc
và chạy đều chân mỗi sáng được diễn ra trọn vẹn đầy hứng khởi.Vitamin D với ngoài chức năng cải thiện khả năng hấp thụ Canxi còn hỗ trợ kích thích sự phát triển của cơ bắp.
Sữa Anlene với hàm lượng vitamin D phù hợp chính là sự lựa chọn hoàn hảo.Collagen thành phần quan trọng cấu tạo nên sụn khớp,Vitamin C, E những chất chống oxi hóa mạnh,
giúp bảo vệ các tế bào, cơ và khớp trong cơ thể khỏi quá trình bị oxi hóa.Protein đóng vai trò rất quan trọng trong việc duy trì và phát triển cơ và xương trong 
cơ thể','anh5_SUACT.jpg',6,N'2 năm',320000,'SUACT','NCC020','HSX020'),
--sữa tươi
--21
('SUATU001', N'Sữa Óc Chó Hàn Quốc Hạnh Nhân Đậu Đen 190ml Thùng 24 hộp', N'là sữa có hương vị thơm ngon, ngọt bùi, rất dễ uống, hợp khẩu vị với cả gia đình đặc biệt là mẹ bầu.
Sữa óc chó Hàn Quốc là thức uống 3 trong 1 được chiết suất từ nguồn dinh dưỡng thiên nhiên kết hợp giữa 3 loại hạt Óc chó, Hạnh Nhân và Đậu đen rất giàu dinh dưỡng. 
Bên trong sữa có màu nâu nhạt, có mùi thơm của hạt óc chó xen lẫn hạnh nhân cùng đậu đen hòa quyện vào nhau tạo nên một thức uống rất là tuyệt vời, giàu dinh dưỡng. 
Sự kết hợp hoàn hảo của 3 loại hạt Óc chó, hạnh nhân, đậu đen cung cấp hầu hết chất dinh dưỡng, vitamin và khoáng chất cần thiết cho cơ thể. Chính vì vậy mà sữa óc
chó Hàn Quốc đang là lựa chọn hàng đầu và được sử dụng rất phổ biến hiện nay.Sản phẩm sữa óc chó nổi tiếng của Hàn Quốc giờ đây đã có tại Việt Nam với nhiều công dụng 
tuyệt vời bổ sung dinh dưỡng phù hợp cho mọi lứa tuổi đặc biệt là phụ nữ mang thai, sau sinh, người trung và cao tuổi cần bồi bổ sức khỏe các chất dinh dưỡng có trong quả 
óc chó. Quả óc chó chứa axit béo Omega-3, giàu chất xơ, vitamin B, magiê, vitamin E giúp bảo vệ hệ tim mạch, bảo vệ động mạch do có nhiều chất béo chưa bão hoà. Tăng cường
sức khỏe cho não bộ, hệ thần kinh .Ngoài ra, hạnh nhân là ngưồn cung cấp dồi dào về vitamin E, calcium, phosphor, sắt và magnesium. Nó còn chứa kẽm, selenium, đồng và niacin, 
hạnh nhân có nhiểu chất bổ dưỡng nhất.Nước đậu đen hạnh nhân óc chó Hàn Quốc là nguồn cung cấp Isulin cao cho bệnh nhân bị mắc bệnh
tiểu đường.','anh1_SUATU.jpg',8,N'1 năm',320000,'SUATU','NCC024','HSX014'),
--22
('SUATU002', N'Sữa tươi Devondale nguyên kem 200ml 24 hộp/thùng', N'là sữa có chứa Canxi cùng nhiều vitamin và khoáng chất là một loại thực phẩm tự nhiên tốt cho sức khoẻ. 
Các chất dinh dưỡng này rất quan trọng cho hệ thống tuần hoàn khoẻ mạnh, ngoài ra còn có hệ thống thần kinh, miễn dịch, thị giác, chức năng của cơ bắp và dây thần kinh, 
cho một làn da khỏe mạnh, cung cấp năng lượng, sự phát triển và phục hồi của các cơ quan trong cơ thể.Sữa nguyên kem với tất cả chất dinh dưỡng tự nhiên mang hương vị
thơm ngon, béo ngậy sẽ khiến cả gia đình yêu thích.Sữa tươi nguyên chất 100% được xử lý bằng công nghệ tiệt trùng và đồng hoá.Không có thành phần sữa bột pha nước.Sản phẩm được
nhập khẩu trực tiếp với chất lượng Úc.Nguồn cung cấp Canxi, Protein và Vitamin A.Có hộp 1L cho cả gia đình và hộp 200mL tiện dụng.Phù hợp cho trẻ từ 1 tuổi trở lên.Thương hiệu Devondale đến từ 
Úc đã cho ra đời dòng sữa nước dành riêng cho cá bé, không chỉ đầy đủ chất dinh dưỡng mà còn giúp các bé dễ uống hơn.','anh2_SUATU.jpg',9,N'12 tháng',290000,'SUATU','NCC002','HSX022'),
--23
('SUATU003', N'Thùng 48 hộp sữa tươi tiệt trùng Dutch Lady có đường 180 ml', N'là dòng sữa không sử dụng chất bảo quản, không màu hóa học, an toàn vượt chuẩn 11 lần.
Sữa cô gái hà lan với nguồn nguyên liệu được sản xuất theo quy trình nghiêm ngặt và kiểm soát chất lượng theo tiêu chuẩn quốc tế.Sữa tươi có đường cung cấp protein, phốt pho, 
vitamin B2 và B12 cùng nhiều vitamin và khoáng chất cần thiết cho trẻ.Sữa tươi đến từ nhà Dutch Lady thơm ngon, chất lượng nên được các bậc phụ huynh ưu tiên lựa chọn
sử dụng sản phẩm khi con từ 1 tuổi.','anh3_SUATU.jpg',7,N'18 tháng',307000,'SUATU','NCC005','HSX029'),
--24
('SUATU004', N'Thùng 48 hộp sữa tươi tiệt trùng TH true MILK ít đường 180 ml ', N'là thương hiệu sản xuất tại Việt Nam về sữa bò tươi nguyên chất với chất lượng
theo những tiêu chuẩn hàng đầu.Sữa tươi không sử dụng thêm hương liệu, không sử dụng chất bảo quản, đảm bảo an toàn, ba mẹ yên tâm lựa chọn cho bé.Sữa tươi tự nhiên dành cho bé
từ 1 tuổi với hương vị thơm ngon được đóng theo hộp kèm ống hút tiện lợi, mỗi lốc 4 hộp, bố mẹ dễ dàng mang theo khi đi xa.Sữa TH true MILK ít đường với thành phần giàu vitamin 
(A, D, B1, B2) và khoáng chất (canxi, kẽm), hỗ trợ bé phát triển về mặt thể chất (chiều cao, cân nặng) cũng như hệ tư duy, trí não.Thùng 48 hộp sữa tươi TH true MILK
ít đường 180 ml vị sữa bò tươi thơm ngon hoàn toàn nguyên chất đến từ các trang trại của TH.Quy trình đóng gói khép kín, hiện đại với các 
nguyên liệu đầu vào và chất lượng đầu ra luôn được kiểm tra nghiêm ngặt, đảm bảo an toàn thực phẩm đúng theo tiêu chuẩn ISO. ','anh4_SUATU.jpg',6,N'2 năm',420000,'SUATU','NCC021','HSX028'),
--25
('SUATU005', N'Thùng 48 hộp sữa tươi tiệt trùng Dalat Milk ít đường 180 ml ', N'là dòng sữa của thương hiệu Dalat Milk là sữa được lấy từ những vùng 
cao nguyên chăn nuôi bò sữa nổi tiếng, đảm bảo vệ sinh an toàn cho người tiêu dùng.Ứng dụng công nghệ cao tạo nên hộp sữa tươi Dalat Milk chuẩn hóa với hương tự nhiên dễ uống.
Sữa tươi cung cấp chất dinh dưỡng thiết yếu như canxi, vitamin và các khoáng chất dành cho bé từ 1 tuổi.Thùng 48 hộp sữa tươi Dalat Milk ít đường 180 ml là sản phẩm từ 
thương hiệu Dalat Milk, được sản xuất hoàn toàn tại Việt Nam.','anh5_SUATU.jpg',7,N'2 năm',450000,'SUATU','NCC027','HSX025'),

--sữa tăng chiều cao
--26
('SUACC001', N'Sữa HIUP chính hãng tăng chiều cao cho trẻ Hộp 650g', N'là sữa với công thức từ Hoa Kỳ chứa đa dạng dinh dưỡng tốt cho quá trình phát triển chiều cao của trẻ từ 3 đến
15 tuổi, đặc biệt là thành phần Aquamin F, sữa non, bộ ba canxi, vitamin D3 và vitamin K2,… Sữa bột HIUP được sản xuất và đóng gói bởi Công ty TNHH Sản Xuất DP Công Nghệ 
Cao NanoFrance với dây chuyền công nghệ hiện đại, đạt chuẩn FDA Hoa Kỳ.Hỗ trợ trẻ phát triển tối ưu về cân nặng lẫn chiều cao với hệ xương khớp chắc khỏe, trong lâu dài sẽ thay
đổi ngoại hình nổi bật, nhờ vậy càng thuận lợi trong các hoạt động thể dục thể thao và mở ra nhiều cơ hội sự nghiệp tương lai.Hỗ trợ tăng cường thể chất với cơ bắp khỏe mạnh
và năng lượng tràn đầy cho những ngày học tập, vui chơi năng động.Hỗ trợ hệ tiêu hóa hoạt động trơn tru để có thể giảm được tình trạng táo bón kéo dài, kích thích trẻ ăn ngon,
ăn nhiều và cơ thể cũng hấp thu được dưỡng chất từ thực phẩm nhiều hơn.Hỗ trợ não bộ và thị giác đều phát triển, giúp trẻ nhanh trí tiếp thu học hỏi kiến thức mới từ thế
giới xung quanh.Hỗ trợ hoàn thiện hệ miễn dịch tự nhiên để trẻ có khả năng chống lại vi khuẩn, virus phổ biến trong môi trường sống.','anh1_SUACC.jpg',6,N'2 năm',890000,'SUACC','NCC010','HSX011'),
--27
('SUACC002', N'Sữa bột IQLac Pro Hỗ Trợ Tăng Chiều Cao Vượt Trội  Hộp 900g', N'là sữa hỗ trợ tăng sức đề kháng và cải thiện sức khỏe hệ tiêu hóa, 
giúp trẻ ăn ngon, ít ốm vặt và phát triển hệ xương tối đa cho trẻ.Sữa bột IQLac Pro phát triển chiều cao là sản phẩm dinh dưỡng, cung cấp các vitamin và khoáng chất thiết yếu, 
giúp hệ tiêu hóa luôn khỏe mạnh và hỗ trợ tăng sức đề kháng, tăng chiều cao tối đa cho trẻ. Sản phẩm dùng cho trẻ từ 2 – 9 tuổi.Canxin, vitamin D3, Photpho: Đây là những thành
phần cơ bản cấu tạo nên hệ xương và răng. Việc bổ sung canxi, vitamin D3, Photpho mang lại hệ xương và răng chắc khỏe, giúp trẻ cao lớn, hỗ trợ tăng khả năng miễn dịch, ổn định
hệ thần kinh, giúp trẻ ngủ sâu giấc.Chất xơ FOS Ggiúp sản sinh lợi khuẩn đường ruột, giúp trẻ ăn ngon, dễ tiêu hóa và dễ dàng hấp thụ dinh dưỡng, giảm tình trạng táo bón ở trẻ.
Vitamin A, C, E, Kẽm và Selen: Hỗ trợ tăng cường sức đề kháng, giúp chống lại các tác nhân gây bệnh từ môi trường.Vitamin nhóm B bổ sung vitamin và khoáng chất cho cơ thể,
hỗ trợ tăng khả năng hấp thụ và chuyển hóa thức ăn trong cơ thể, giúp trẻ ăn ngon, ngủ ngon.','anh2_SUACC.jpg',6,N'2 năm',335000,'SUACC','NCC025','HSX021'),
--28
('SUACC003', N'Wibig Sữa Bột Hỗ Trợ Tăng Chiều Cao Hộp 650G',N'là dòng sữa sản phẩm hỗ trợ phát triển chiều cao, tăng đề kháng, phát triển não bộ và ăn ngon miệng hơn cho trẻ 3-18 tuổi.
Với thành phần thiên nhiên như sữa non, Vitamin D3, Vitamin C… không chất bảo quản an toàn cho cơ thể trẻ.Vitamin A hỗ trợ tăng cường hệ miễn dịch, duy trì sức khỏe mắt, giúp phát triển và duy trì xương.
Linoleic acid (Omega 6) hỗ trợ chức năng não bộ, giúp chống lại vi khuẩn và giảm viêm nhiễm.Lysine hỗ trợ cải thiện các mô, cơ bắp, cải thiện hệ miễn dịch
cho trẻ.Hỗ trợ cung cấp các dưỡng chất thiết yếu, bổ sung vitamin và khoáng chất cho cơ thể trẻ.Trẻ em trên 3-18 tuổi.Trẻ kén ăn, còi xương thấp bé.Trẻ thường bị rối loạn 
tiêu hóa, táo bón ','anh3_SUACC.jpg',7,N'3 năm',790000,'SUACC','NCC030','HSX024'),
--29
('SUACC004', N'Sữa Abbott Grow 2+ 850g ', N'bổ sung dưỡng chất đầy đủ cân đối giúp trẻ phát triển chiều cao và trí não.Để đáp ứng nhu cầu tăng trưởng
cao của trẻ trong suốt giai đoạn phát triển quan trọng từ 2 tuổi, hàng ngày con cần được bổ sung đầy đủ và cân đối các dưỡng chất cần thiết.Sữa Abbott Grow 2 với công thức
giàu dưỡng chất, hương vị thơm ngon, được thiết kế một cách khoa học hỗ trợ sự phát triển tốt của trẻ trong suốt giai đoạn quan trọng này.Giúp trẻ phát triển xương và
chiều cao sữa Abbott Grow 4 là nguồn dinh dưỡng tốt cung cấp đầy đủ với hàm lượng cao canxi, phospho, vitamin D – đây là các nguyên liệu cần thiết để xây dựng và phát 
triển hệ xương chắc khỏe.Bổ sung taurin hỗ trợ phát triển trí não và thị giác. 28 vitamin và khoáng chất có trong AbGrow 4 cùng với chế độ ăn hợp lý và cân đối hàng ngày,
giúp đáp ứng các nhu cầu dinh dưỡng cần thiết cho sự phát triển tốt của trẻ. Các nguyên tố siêu vi lượng selen, crôm, molybden duy nhất có trong công thức Abbott Grow 4 ngoài
việc hỗ trợ nâng cao sức đề kháng của cơ thể, còn tham gia điều hòa chức năng chuyển hóa năng lượng của cơ thể, giúp trẻ lớn nhanh và khỏe mạnh.Các chất chống oxi hóa
giúp bảo vệ các tế bào của cơ thể chống lại tác động có hại của các gốc tự do','anh4_SUACC.jpg',8,N'2 năm',345000,'SUACC','NCC029','HSX023'),
--30
('SUACC005', N'Sữa Vitagrow 0+ 900G', N'là sữa được bổ sung 100% hàm lượng Canxi từ sữa kết hợp Vitamin D và Mk7 với tỷ lệ cân đối, từ đó giúp hệ xương 
răng của bé được hoàn thiện và luôn chắc khỏe, phát huy hết tiềm năng chiều cao tối ưu.Tăng cân khỏe mạnh.Sản phẩm cung cấp nguồn năng lượng cao, hàm lượng đạm và chất béo 
dễ hấp thu, qua đó bổ sung đầy đủ dinh dưỡng giúp trẻ tăng cân đều và phát triển toàn diện diện.Ngoài ra kết hợp với nguồn vitamin và khoáng chất đa dạng giúp thúc đẩy quá 
trình chuyển hóa cơ thể được tốt hơn, phòng ngừa chứng thiếu hụt Vitamin ở trẻ.Phát triển trí não, thị giác.Sữa Vitagrow có bổ sung hàm lượng DHA, Choline, Taurine 
là hệ dưỡng chất thiết yếu, đóng vai trò quan trọng cho sự phát triển và hoạt động của hệ não bộ, thị giác, giúp trẻ có một đôi mắt sáng và trí tuệ thông minh.Phòng chống 
táo bón.Chất xơ FOS trong sữa Vitagrow 0+ ở dạng hòa tan có vai trò giúp ổn định hệ vi sinh đường ruột hỗ trợ hệ tiêu hóa luôn khỏe mạnh và ngăn ngừa táo bón ở trẻ.
Tăng cường miễn dịch.Nucleotides là một thành phần tự nhiên trong sữa mẹ đóng vai trò quan trọng trong việc tối ưu hoá các phản ứng miễn dịch khi trẻ được tiêm phòng 
vaccine kết hợp với Kẽm và Selen sẽ giúp Điều hòa hoạt động và thúc đẩy chức năng hệ miễn dịch, giúp trẻ có sức đề kháng tốt, hạn chế các bệnh nhiễm khuẩn 
thông thường.','anh5_SUACC.jpg',9,N'3 năm',435000,'SUACC','NCC028','HSX030')


SELECT * 
from SanPhamSua
  


GO
INSERT INTO ChucVu(MaCV,TenCV) 
VALUES
	('BH', N'Nhân viên bán hàng'),
	('QL', N'Quản lý')

go
select * from ChucVu
--chức năng này chỉ dành cho người quản lý với nhân viên bán hàng mới vào được trang tài khoản mật khẩu (trang admin) 
--chức năng này không thể vào trang đăng nhập tài khoản mật khẩu của khách hàng
 --mật khẩu trang admin 4 người dưới đây ta nhập mật khẩu sau khi ta gõ TenDN là ->  ta sẽ gõ mật khẩu là : 1234567
 -- gõ tên đăng nhập ví dụ 5 người dưới đây ta ví dụ lấy 1 người như NV00001:lấy tên này bỏ vào ô tên đăng nhập  -->  Namdeptrai2406
 -- sau khi nhập tài khoản mật khẩu ta sẽ vào trang admin 
INSERT INTO NhanVien(MaNV,HoTenNV,AnhNV,SDT, Email, DiaChi,TenDN, MatKhau, MaCV) VALUES
('NV00001', N'Huỳnh Xuân Nam','anh1.jpg','0947138175','xuannam1234zz@gmail.com' , N'05A Trần Phú Chí Thạnh Tuy An - Phú Yên','Namdeptrai2406', 'fcea920f7412b5da7be0cf42b8c93759',  'QL'),
('NV00002', N'Phạm Huyền Chi','anh2.jpg', '0927899463','chiphxinhdep@gmail.com' , N'05A Nguyễn Thị Loan Chí Thạnh Tuy An - Phú Yên','Chixinhdep0204', 'fcea920f7412b5da7be0cf42b8c93759', 'BH'),
('NV00003', N'Nguyễn Lê Thuỷ Tiên', 'anh3.jpg','0937221590','tiennltdethuong@gmail.com' , N'1/4 Duy Tân Tuy Hoà - Phú Yên','Tiendethuong0403', 'fcea920f7412b5da7be0cf42b8c93759', 'BH'),
('NV00004', N'Huỳnh Ngọc Thảo Giang','anh4.jpg', '0954936577','gianghnbeautiful@gmail.com' , N'1/4 Trần Nhân Tông Tuy Hoà - Phú Yên','Giangkixi0505', 'fcea920f7412b5da7be0cf42b8c93759', 'BH')
select * from NhanVien
Go

--chức năng này đăng nhập tài khoản mật khẩu của khách hàng đã được lưu trong dữ liệu:
INSERT INTO KhachHang(MaKH, HoTenKH, SDT, Email, DiaChi, TaiKhoan, MatKhau, AnhKH) 
VALUES
('KH00001', N'Nguyễn Hữu Thắng', '0977649152', 'nguyenhuuthangoptimus@gmail.com', N'2/4 Mai Xuân Thưởng ,Nha Trang - Khánh Hòa', 'huuthang123', 'fcea920f7412b5da7be0cf42b8c93759',null),
('KH00002', N'Trần Bình Trọng', '0945598375', 'tranbinhtrongzena@gmail.com', N'Trần Quý Cáp ,Tuy Hoà - Phú Yên', 'trongtran1204', 'fcea920f7412b5da7be0cf42b8c93759',null),
('KH00003', N'Trần Hoài Thanh', '0923510098', 'tranhoaithanhyasuo@gmail.com', N'2/4 Tháp Bà , Nha Trang - Khánh Hoà', 'hoaithanh2309', 'fcea920f7412b5da7be0cf42b8c93759',null),
('KH00004', N'Huỳnh Tấn Tiên', '0966540308', 'huynhtantientara@gmail.com', N'1/4 Bà Triệu ,Tuy Hoà - Phú Yên', 'tantien0513', 'fcea920f7412b5da7be0cf42b8c93759',null),
('KH00005', N'Bùi Thanh Tú', '0925240419', 'thanhtubui@gmail.com', N'30/4 Phan Châu Trinh , Quy Nhơn - Bình Định ', 'tubui0509', 'fcea920f7412b5da7be0cf42b8c93759',null),
('KH00006', N'Nguyễn Phương Đình Đình', '0929979134', 'phuongdinh2k4@gmail.com', N'2/4 Hòn Chồng Tông ,Nha Trang - Khánh Hoà', 'phuongdinh0511', 'fcea920f7412b5da7be0cf42b8c93759',null), 
('KH00007', N'Nguyễn Trúc Loan', '0917920505', 'loannguyen2k5@gmail.com', N'170AB Nguyễn Trãi Cầu Rồng, Đà Nẵng', 'trucloan1909', 'fcea920f7412b5da7be0cf42b8c93759',null)
select * from KhachHang
go

INSERT INTO HoaDon (MaHD, NgayDH, NgayGH, MaKH, MaNV, TongTien, TinhTrangDuyet, TinhTrangDonHang) VALUES
('HD00001', '2024-11-05', '2024-11-08', 'KH00002', 'NV00002',1045000, 1, 0),
('HD00002', '2024-06-07', '2024-06-10', 'KH00003', 'NV00003',1042000, 1, 1),
('HD00003', '2024-03-03', '2024-03-06', 'KH00005', 'NV00001',780000, 0, 0),
('HD00004', '2024-07-02', '2024-07-15', 'KH00004', 'NV00003',550000, 1, 1),
('HD00005', '2024-04-12', '2024-04-20', 'KH00006', 'NV00001',678000, 0, 0),
('HD00006', '2024-06-06', '2024-06-09', 'KH00005', 'NV00003',600000, 1, 1),
('HD00007', '2024-02-12', '2024-02-15', 'KH00001', 'NV00002',1470000, 1, 0),
('HD00008', '2024-06-20', '2024-06-23', 'KH00004', 'NV00003',340000, 1, 0),
('HD00009', '2024-04-25', '2024-04-30', 'KH00002', 'NV00004',435000, 1, 0),
('HD00010', '2024-05-11', '2024-05-17', 'KH00007', 'NV00002',550000, 1, 1),
('HD00011', '2024-01-15', '2024-01-18', 'KH00006', 'NV00003',678000, 0, 0),
('HD00012', '2024-09-07', '2024-09-11', 'KH00004', 'NV00004',1890000, 1, 1),
('HD00013', '2024-10-05', '2024-10-10', 'KH00007', 'NV00002',560000, 0, 0),
('HD00014', '2024-08-22', '2024-08-25', 'KH00001', 'NV00004',315000, 1, 1)

select * from HoaDon



go
INSERT INTO CTHoaDon(MaHD, MaSua, SoLuongBan, DonGiaBan) VALUES
('HD00001', 'SUATD002', 1, 795000),
('HD00001', 'SUATD003', 1,855000),
('HD00001', 'SUATD004', 2, 505000),
('HD00002', 'SUABO003', 3, 340000),
('HD00002', 'SUABO005', 1,1360000),
('HD00003', 'SUATD002', 2, 795000),
('HD00003', 'SUABO003', 1, 340000),
('HD00003', 'SUATU004', 1,420000),
('HD00004', 'SUATD005', 3,520000 ),
('HD00004', 'SUATU005', 2, 450000),
('HD00005', 'SUABO001', 1, 330000),
('HD00005', 'SUATD003', 1,855000 ),
('HD00006', 'SUABO002', 2, 365000),
('HD00006', 'SUABO005', 1,1360000 ),
('HD00007', 'SUATD004', 3,505000 ),
('HD00007', 'SUATU004', 1, 420000),
('HD00008', 'SUABO003', 3, 340000),
('HD00008', 'SUATD003', 1, 855000),
('HD00009', 'SUATD005', 1, 520000),
('HD00009', 'SUATU001', 3,320000),

('HD00010', 'SUATU002', 1, 290000),
('HD00010', 'SUAMB001', 2, 550000),

('HD00011', 'SUATU004', 2, 420000),
('HD00011', 'SUAMB002', 1,235000),

('HD00012', 'SUACC001', 1,890000),
('HD00012', 'SUACC002', 1,335000),

('HD00013', 'SUATD002', 1, 795000),
('HD00013', 'SUAMB005',1, 465000),

('HD00014', 'SUABO002', 1, 365000),
('HD00014', 'SUATD001', 2, 630000)

go
select * from CTHoaDon
INSERT INTO ThamSo (MaTS, TenTS, DVT, GiaTri, TrangThai) VALUES
('TS001',N'Số lượng nhập hàng tối đa', N'Cái', '100',1)

 select * from ThamSo

go
select * from ThamSo

















CREATE PROCEDURE SanPhamSua_TimKiem
    @MaSua varchar(10)=NULL,
	@TenSua nvarchar(100)=NULL,
	@HanSuDung nvarchar(50)= NULL,
	@DonGiaMin varchar(30)=NULL,
	@DonGiaMax varchar(30)=NULL,
	@MaLoaiSua nvarchar(10)=NULL,
	@MaNCC nvarchar(10)=NULL,
	@MaHSX nvarchar(10)=NULL,	
	@SoLuong nvarchar(70)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM SanPhamSua
       WHERE  (1=1)
       '
IF @MaSua IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaSua LIKE ''%'+@MaSua+'%'')
              '
IF @TenSua IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TenSua LIKE N''%' + @TenSua + '%'')
			  '
IF @HanSuDung IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (HanSuDung LIKE N''%'+@HanSuDung+'%'')
			 '
IF @DonGiaMin IS NOT NULL and @DonGiaMax IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (DonGia Between Convert(int,'''+@DonGiaMin+''') AND Convert(int, '''+@DonGiaMax+'''))
             '
IF @MaLoaiSua IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaLoaiSua LIKE ''%'+@MaLoaiSua+'%'')
              '
IF @MaNCC IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaNCC LIKE ''%'+@MaNCC+'%'')
              '
IF @MaHSX IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaHSX LIKE ''%'+@MaHSX+'%'')
              '
IF @SoLuong IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (SoLuong = Convert(int,'''+@SoLuong+'''))
              '
	EXEC SP_EXECUTESQL @SqlStr
END
go




CREATE PROCEDURE NhaCungCap_TimKiem
    @MaNCC varchar(10)=NULL,
	@TenNCC nvarchar(100)=NULL,
	@SDT nvarchar(10)= NULL,
	@Email nvarchar(50)=NULL,
	@DiaChi nvarchar(500)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM NhaCungCap
       WHERE  (1=1)
       '
IF @MaNCC IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaNCC LIKE ''%'+@MaNCC+'%'')
              '
IF @TenNCC IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TenNCC LIKE N''%' + @TenNCC + '%'')
			  '
IF @SDT IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (SDT LIKE N''%'+@SDT+'%'')
			 '
IF @Email IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (Email LIKE N''%'+@Email+'%'')
			 '
IF @DiaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (DiaChi LIKE N''%'+@DiaChi+'%'')
			 '         
	EXEC SP_EXECUTESQL @SqlStr
END
go









CREATE PROCEDURE LoaiSua_TimKiem
    @MaLoaiSua varchar(10)=NULL,
	@TenLoaiSua nvarchar(50)=NULL

AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM LoaiSua
       WHERE  (1=1)
       '
IF @MaLoaiSua IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaLoaiSua LIKE ''%'+@MaLoaiSua+'%'')
              '
IF @TenLoaiSua IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TenLoaiSua LIKE N''%' + @TenLoaiSua + '%'')
			  ' 
	EXEC SP_EXECUTESQL @SqlStr
END
go



CREATE PROCEDURE HangSanXuat_TimKiem
    @MaHSX varchar(10)=NULL,
	@TenHSX nvarchar(50)=NULL,
	@DiaChi nvarchar(500)=NULL,
	@SDT nvarchar(10)= NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM HangSanXuat
       WHERE  (1=1)
       '
IF @MaHSX IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaHSX LIKE ''%'+@MaHSX+'%'')
              '
IF @TenHSX IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TenHSX LIKE N''%' + @TenHSX + '%'')
			  '   
IF @DiaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (DiaChi LIKE N''%'+@DiaChi+'%'')
			 '  
IF @SDT IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (SDT LIKE N''%'+@SDT+'%'')
			 '
	EXEC SP_EXECUTESQL @SqlStr
END
go
CREATE PROCEDURE KhachHang_TimKiem
	@MaKH varchar(10) = NULL,
	@HoTenKH nvarchar(100) = NULL,
	@SDT nvarchar(10) = NULL,
	@Email nvarchar(50) = NULL,
	@DiaChi nvarchar(500) = NULL,
	@TaiKhoan nvarchar(30) = NULL

AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM KhachHang
       WHERE  (1=1)
       '
IF @MaKH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaKH LIKE ''%'+@MaKH+'%'')
              '
IF @HoTenKH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoTenKH LIKE N''%' + @HoTenKH + '%'')
			  '
IF @SDT IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (SDT LIKE N''%'+@SDT+'%'')
			 '
IF @Email IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (Email LIKE N''%'+@Email+'%'')
			 '
IF @DiaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (DiaChi LIKE N''%'+@DiaChi+'%'')
              '
IF @TaiKhoan IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (TaiKhoan LIKE N''%'+@TaiKhoan+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END
go
-- tìm kiếm nhân viên
CREATE PROCEDURE NhanVien_TimKiem
	@MaNV varchar(10) = NULL,
	@HoTenNV nvarchar(100) = NULL,
	@SDT nvarchar(10) = NULL,
	@Email nvarchar(50) = NULL,
	@DiaChi nvarchar(500) = NULL,
	@TenDN nvarchar(30) = NULL,
	@MaCV varchar(10) = NULL

AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM NhanVien
       WHERE  (1=1)
       '
IF @MaNV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaNV LIKE ''%'+@MaNV+'%'')
              '
IF @HoTenNV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoTenNV LIKE N''%' + @HoTenNV + '%'')
			  '
IF @SDT IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (SDT LIKE N''%'+@SDT+'%'')
			 '
IF @Email IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (Email LIKE N''%'+@Email+'%'')
			 '
IF @DiaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (DiaChi LIKE N''%'+@DiaChi+'%'')
              '
IF @TenDN IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (TenDN LIKE N''%'+@TenDN+'%'')
              '
IF @MaCV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaCV LIKE ''%'+@MaCV+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END








-- dang lam tim kiem hoa don







--EXEC GetSalesReport '2022-12-14' , '2022-12-14'


GO






CREATE PROCEDURE GetSalesReport
    @FromDate date = NULL,
    @ToDate date = NULL
AS
BEGIN
    SELECT  SanPhamSua.TenSua, SanPhamSua.MaSua, NhaCungCap.TenNCC, LoaiSua.TenLoaiSua, HangSanXuat.TenHSX,SanPhamSua.DonGia, SanPhamSua.SoLuong AS TON, 
            SUM(CTHoaDon.SoLuongBan) as SoLuongBan, 
            SUM(CTHoaDon.SoLuongBan * CTHoaDon.DonGiaBan) as Gia
    FROM SanPhamSua
    JOIN CTHoaDon ON SanPhamSua.MaSua = CTHoaDon.MaSua
    JOIN NhaCungCap on SanPhamSua.MaNCC = NhaCungCap.MaNCC 
    JOIN LoaiSua on LoaiSua.MaLoaiSua = SanPhamSua.MaLoaiSua
    JOIN HangSanXuat on HangSanXuat.MaHSX = SanPhamSua.MaHSX
    JOIN HoaDon ON HoaDon.MaHD = CTHoaDon.MaHD
    WHERE HoaDon.TinhTrangDonHang = CAST('1' AS BIT) 
        AND (HoaDon.NgayGH >= ISNULL(@FromDate, HoaDon.NgayGH) 
        AND HoaDon.NgayGH <= ISNULL(@ToDate, HoaDon.NgayGH))
    GROUP BY SanPhamSua.TenSua, SanPhamSua.MaSua, SanPhamSua.SoLuong, NhaCungCap.TenNCC, LoaiSua.TenLoaiSua, HangSanXuat.TenHSX,SanPhamSua.DonGia;
END
select * from SanPhamSua
