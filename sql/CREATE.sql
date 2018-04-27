CREATE DATABASE Serilog
GO
USE Serilog
GO
CREATE TABLE [Logs] (
   [Id] int IDENTITY(1,1) NOT NULL,
   [Message] nvarchar(max) NULL,
   [MessageTemplate] nvarchar(max) NULL,
   [Level] nvarchar(128) NULL,
   [TimeStamp] datetimeoffset(7) NOT NULL, 
   [Exception] nvarchar(max) NULL,
   [Properties] xml NULL,
   [LogEvent] nvarchar(max) NULL
)