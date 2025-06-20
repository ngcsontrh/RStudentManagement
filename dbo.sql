/*
 Navicat Premium Dump SQL

 Source Server         : mssql-localhost
 Source Server Type    : SQL Server
 Source Server Version : 16004195 (16.00.4195)
 Source Host           : localhost:1433
 Source Catalog        : RStudentManagement
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16004195 (16.00.4195)
 File Encoding         : 65001

 Date: 20/06/2025 11:12:23
*/


-- ----------------------------
-- Table structure for EventLog
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog]') AND type IN ('U'))
	DROP TABLE [dbo].[EventLog]
GO

CREATE TABLE [dbo].[EventLog] (
  [Id] uniqueidentifier  NOT NULL,
  [EventType] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Description] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CreatedAt] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[EventLog] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Mail
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Mail]') AND type IN ('U'))
	DROP TABLE [dbo].[Mail]
GO

CREATE TABLE [dbo].[Mail] (
  [Id] uniqueidentifier  NOT NULL,
  [Email] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Title] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Body] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CreatedAt] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Mail] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Student
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type IN ('U'))
	DROP TABLE [dbo].[Student]
GO

CREATE TABLE [dbo].[Student] (
  [Id] uniqueidentifier  NOT NULL,
  [Code] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [FullName] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DateOfBirth] datetime2(7)  NULL,
  [Address] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Email] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CreatedAt] datetime2(7)  NULL,
  [Class] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Student] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table EventLog
-- ----------------------------
ALTER TABLE [dbo].[EventLog] ADD CONSTRAINT [PK__EventLog__3214EC075772921A] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Mail
-- ----------------------------
ALTER TABLE [dbo].[Mail] ADD CONSTRAINT [PK__Mail__3214EC074DE711C6] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Student
-- ----------------------------
ALTER TABLE [dbo].[Student] ADD CONSTRAINT [PK__Student__3214EC07641A34BA] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

