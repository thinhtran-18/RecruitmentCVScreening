CREATE DATABASE RecruitmentCVScreeningDB;
GO
USE RecruitmentCVScreeningDB;
GO

CREATE TABLE Jobs (
    Id INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    RequiredSkills NVARCHAR(MAX),
    MinExperience INT NOT NULL
);

CREATE TABLE Candidates (
    Id INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) NOT NULL,
)

CREATE TABLE Applications (
    Id INT IDENTITY PRIMARY KEY,
    JobId INT NOT NULL,
    CandidateId INT NOT NULL,
    Score FLOAT NOT NULL,
    Status NVARCHAR(50) NOT NULL,

    CONSTRAINT FK_Application_Job
        FOREIGN KEY (JobId) REFERENCES Jobs(Id),

    CONSTRAINT FK_Application_Candidate
        FOREIGN KEY (CandidateId) REFERENCES Candidates(Id)
);

--                                                      Minh Database tạm:
-- 1. Tạo Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'RecruitmentCVScreeningDB')
BEGIN
    CREATE DATABASE RecruitmentCVScreeningDB;
END
GO

USE RecruitmentCVScreeningDB;
GO

-- 2. Xóa bảng cũ nếu tồn tại (theo thứ tự ngược lại để tránh lỗi Khóa ngoại)
IF OBJECT_ID('Applications', 'U') IS NOT NULL DROP TABLE Applications;
IF OBJECT_ID('Candidates', 'U') IS NOT NULL DROP TABLE Candidates;
IF OBJECT_ID('Jobs', 'U') IS NOT NULL DROP TABLE Jobs;
GO

-- 3. Tạo bảng Vị trí tuyển dụng (Jobs)
CREATE TABLE Jobs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    RequiredSkills NVARCHAR(MAX),
    MinExperience INT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- 4. Tạo bảng Ứng viên (Candidates)
CREATE TABLE Candidates (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) NOT NULL UNIQUE, -- Đảm bảo không trùng Email
    Phone NVARCHAR(20),
    Address NVARCHAR(500)
);

-- 5. Tạo bảng Đơn ứng tuyển (Applications) - Trọng tâm của Minh
CREATE TABLE Applications (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    JobId INT NOT NULL,
    CandidateId INT NOT NULL,
    Score FLOAT DEFAULT 0, -- Điểm số sau khi lọc CV
    Status NVARCHAR(50) NOT NULL DEFAULT N'Pending',
    AppliedDate DATETIME DEFAULT GETDATE(),

    -- Ràng buộc Khóa ngoại: Nếu xóa Job/Candidate thì báo lỗi (để bảo vệ dữ liệu)
    CONSTRAINT FK_App_Job FOREIGN KEY (JobId) REFERENCES Jobs(Id),
    CONSTRAINT FK_App_Candidate FOREIGN KEY (CandidateId) REFERENCES Candidates(Id),
    
    -- Ràng buộc Trạng thái: Chỉ cho phép nhập các giá trị này
    CONSTRAINT CHK_Status CHECK (Status IN (N'Pending', N'Interviewed', N'Rejected', N'Hired'))
);

-- 6. Tạo Index để tăng tốc độ Lọc (Filter) theo JobId và Status
CREATE INDEX IX_Applications_JobStatus ON Applications(JobId, Status);
GO

-- Thêm Jobs mẫu
INSERT INTO Jobs (Title, RequiredSkills, MinExperience) VALUES 
(N'Lập trình viên .NET', N'C#, SQL Server, WinForms', 1),
(N'Lập trình viên Java', N'Java Core, Spring Boot', 0),
(N'Thiết kế UI/UX', N'Figma, Adobe XD', 2);

-- Thêm Candidates mẫu
INSERT INTO Candidates (FullName, Email) VALUES 
(N'Nguyễn Văn A', 'nguyenvana@gmail.com'),
(N'Trần Thị B', 'tranthib@gmail.com'),
(N'Lê Văn C', 'levanc@gmail.com');

-- Thêm Applications mẫu (JOIN 3 bảng)
INSERT INTO Applications (JobId, CandidateId, Score, Status) VALUES 
(1, 1, 8.5, N'Pending'),
(1, 2, 7.0, N'Interviewed'),
(2, 3, 9.0, N'Hired');
GO

--                                              Lấy ID
SELECT Id, FullName FROM Candidates;
SELECT * FROM Jobs
