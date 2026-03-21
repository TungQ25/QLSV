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