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

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Tự động tăng ID
    Username NVARCHAR(50) NOT NULL UNIQUE, -- Tên đăng nhập (không được trùng)
    Password NVARCHAR(50) NOT NULL -- Mật khẩu
);
GO

INSERT INTO Users (Username, Password) 
VALUES ('admin', '123456'); 
GO