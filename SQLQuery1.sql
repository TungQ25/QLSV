use QuanLySinhVien

CREATE TABLE Account
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NULL,
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE Khoa
(
    MaKhoa NVARCHAR(20) PRIMARY KEY,
    TenKhoa NVARCHAR(50) NOT NULL
);

CREATE TABLE Lop
(
    MaLop NVARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(50) NOT NULL,
    MaKhoa NVARCHAR(20) NOT NULL,
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

CREATE TABLE SinhVien
(
    MSSV NVARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    MaLop NVARCHAR(20),
    GioiTinh NVARCHAR(10),
    TrangThai NVARCHAR(50),
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
);

INSERT INTO Account (Username, Password, Role, IsActive)
VALUES
('admin', '123456', 'Admin', 1),
('qtung', '123', 'Admin', 1),
('user1', 'abc123', 'User', 1);

INSERT INTO Khoa (MaKhoa, TenKhoa)
VALUES
('CNTT', N'Công nghệ thông tin'),
('KT', N'Kỹ thuật'),
('KTE', N'Kinh tế'),
('KH', N'Khoa học');

INSERT INTO Lop (MaLop, TenLop, MaKhoa)
VALUES
('CNTT1', 'CNTT1', 'CNTT'),
('CNTT2', 'CNTT2', 'CNTT'),
('CNTT3', 'CNTT3', 'CNTT'),
('CNTT4', 'CNTT4', 'CNTT'),

('KT1', 'KT1', 'KT'),
('KT2', 'KT2', 'KT'),
('KT3', 'KT3', 'KT'),
('KT4', 'KT4', 'KT'),

('KTE1', 'KTE1', 'KTE'),
('KTE2', 'KTE2', 'KTE'),
('KTE3', 'KTE3', 'KTE'),
('KTE4', 'KTE4', 'KTE'),

('KH1', 'KH1', 'KH'),
('KH2', 'KH2', 'KH'),
('KH3', 'KH3', 'KH'),
('KH4', 'KH4', 'KH');

INSERT INTO SinhVien(MaKhoa, TenKhoa)
VALUES
('CNTT', N'Công nghệ thông tin'),
('KT', N'Kỹ thuật'),
('KTE', N'Kinh tế'),
('KH', N'Khoa học');

INSERT INTO SinhVien (MSSV, HoTen, NgaySinh, MaLop, GioiTinh, TrangThai)
VALUES
('SV001', N'Nguyễn Văn An',  '2004-01-15', 'CNTT1', N'Nam', N'Đang học'),
('SV002', N'Trần Thị Bình',  '2004-03-22', 'CNTT2', N'Nữ',  N'Đang học'),
('SV003', N'Lê Văn Cường',   '2003-11-10', 'CNTT3', N'Nam', N'Nghỉ học'),
('SV004', N'Phạm Thị Dung',  '2004-07-05', 'CNTT4', N'Nữ',  N'Đang học'),

('SV005', N'Hoàng Văn Em',   '2004-02-18', 'KT1',   N'Nam', N'Đang học'),
('SV006', N'Ngô Thị Hà',     '2004-05-30', 'KT2',   N'Nữ',  N'Đang học'),
('SV007', N'Đỗ Văn Khánh',   '2003-09-12', 'KT3',   N'Nam', N'Nghỉ học'),
('SV008', N'Vũ Thị Lan',     '2004-12-01', 'KT4',   N'Nữ',  N'Đang học'),

('SV009', N'Bùi Văn Minh',   '2004-04-09', 'KTE1',  N'Nam', N'Đang học'),
('SV010', N'Phan Thị Ngọc',  '2003-08-17', 'KTE2',  N'Nữ',  N'Đang học'),
('SV011', N'Tạ Văn Phúc',    '2004-06-14', 'KTE3',  N'Nam', N'Nghỉ học'),
('SV012', N'Lý Thị Quỳnh',   '2004-10-25', 'KTE4',  N'Nữ',  N'Đang học'),

('SV013', N'Nguyễn Văn Sơn', '2004-01-28', 'KH1',   N'Nam', N'Đang học'),
('SV014', N'Trần Thị Thu',   '2003-12-19', 'KH2',   N'Nữ',  N'Đang học'),
('SV015', N'Lê Văn Uy',      '2004-09-03', 'KH3',   N'Nam', N'Nghỉ học'),
('SV016', N'Phạm Thị Vy',    '2004-11-11', 'KH4',   N'Nữ',  N'Đang học');