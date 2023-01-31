-- CREATE DATABASE
CREATE DATABASE TestDB;
GO
USE TestDB;

-- CREATE TABLES
CREATE TABLE Diagnostics (
    Id int NOT NULL    IDENTITY    PRIMARY KEY,
    Operation varchar(255),
    Results int,
    Created DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

GO

-- CREATE PROCEDURES
CREATE PROCEDURE dbo.SP_DiagnosticsData (@Operation varchar(255), @Results int)
AS
BEGIN
    INSERT INTO Diagnostics(Operation, Results)
    VALUES (@Operation, @Results)
END;
GO