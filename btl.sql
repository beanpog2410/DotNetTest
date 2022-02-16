------
--USE master;  
--GO  
--IF DB_ID (N'MULTIPLE_CHOICE') IS NOT NULL  
--DROP DATABASE MULTIPLE_CHOICE;  
--GO  
--CREATE DATABASE MULTIPLE_CHOICE  
--COLLATE Vietnamese_100_CS_AS_KS_WS_SC_UTF8;  
--GO 


-- --------------------------------------------------------
--USE MULTIPLE_CHOICE

--CREATE TABLE [dbo].[AspNetUsers] (
--    [Id]                   NVARCHAR (128) NOT NULL,
--    [Email]                NVARCHAR (256) NULL,
--    [EmailConfirmed]       BIT            NOT NULL,
--    [PasswordHash]         NVARCHAR (MAX) NULL,
--    [SecurityStamp]        NVARCHAR (MAX) NULL,
--    [PhoneNumber]          NVARCHAR (MAX) NULL,
--    [PhoneNumberConfirmed] BIT            NOT NULL,
--    [TwoFactorEnabled]     BIT            NOT NULL,
--    [LockoutEndDateUtc]    DATETIME       NULL,
--    [LockoutEnabled]       BIT            NOT NULL,
--    [AccessFailedCount]    INT            NOT NULL,
--    [UserName]             NVARCHAR (256) NOT NULL,
--    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
--);


--GO
--CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
--    ON [dbo].[AspNetUsers]([UserName] ASC);

--CREATE TABLE [dbo].[AspNetUserClaims] (
--    [Id]         INT            IDENTITY (1, 1) NOT NULL,
--    [UserId]     NVARCHAR (128) NOT NULL,
--    [ClaimType]  NVARCHAR (MAX) NULL,
--    [ClaimValue] NVARCHAR (MAX) NULL,
--    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
--    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
--);


--GO
--CREATE NONCLUSTERED INDEX [IX_UserId]
--    ON [dbo].[AspNetUserClaims]([UserId] ASC);

--CREATE TABLE [dbo].[AspNetRoles] (
--    [Id]   NVARCHAR (128) NOT NULL,
--    [Name] NVARCHAR (256) NOT NULL,
--    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
--);


--GO
--CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
--    ON [dbo].[AspNetRoles]([Name] ASC);

--CREATE TABLE [dbo].[__MigrationHistory] (
--    [MigrationId]    NVARCHAR (150)  NOT NULL,
--    [ContextKey]     NVARCHAR (300)  NOT NULL,
--    [Model]          VARBINARY (MAX) NOT NULL,
--    [ProductVersion] NVARCHAR (32)   NOT NULL,
--    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC)
--);

--CREATE TABLE [dbo].[AspNetUserRoles] (
--    [UserId] NVARCHAR (128) NOT NULL,
--    [RoleId] NVARCHAR (128) NOT NULL,
--    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
--    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
--    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
--);


--GO
--CREATE NONCLUSTERED INDEX [IX_UserId]
--    ON [dbo].[AspNetUserRoles]([UserId] ASC);


--GO
--CREATE NONCLUSTERED INDEX [IX_RoleId]
--    ON [dbo].[AspNetUserRoles]([RoleId] ASC);

--CREATE TABLE [dbo].[AspNetUserLogins] (
--    [LoginProvider] NVARCHAR (128) NOT NULL,
--    [ProviderKey]   NVARCHAR (128) NOT NULL,
--    [UserId]        NVARCHAR (128) NOT NULL,
--    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
--    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
--);


--GO
--CREATE NONCLUSTERED INDEX [IX_UserId]
--    ON [dbo].[AspNetUserLogins]([UserId] ASC);


--
-- Cấu trúc bảng cho bảng 'users'
--
USE MULTIPLE_CHOICE

CREATE TABLE [users] (
  [id] [varchar](255) PRIMARY KEY  NOT NULL,
  --[username] [varchar](45) DEFAULT '' NOT NULL,
  --[Password] [varchar](1000) DEFAULT ''   NOT NULL,
  [name] [varchar](45) DEFAULT '' NULL,
  --[last_name] [varchar](45) DEFAULT '' NULL,
  [Email] [varchar](45) DEFAULT '' NULL,
  [phone] [varchar](45) DEFAULT '' NULL,
  [birthday] [datetime] DEFAULT '' NULL,
  [gender] [varchar](45) DEFAULT '' NULL,
  [student_number] [varchar](45) DEFAULT '' NULL,
  [avatar] [varchar](1000) DEFAULT '' NULL,
  [role_name] [varchar](45) DEFAULT 'users' NOT NULL,
  [active] [tinyint] DEFAULT 1 NOT NULL,
  --[is_login] [tinyint] DEFAULT 1 NULL,
)   ;

--
-- Đang đổ dữ liệu cho bảng users
--

--INSERT INTO [users] (id, username, Password, first_name, last_name, Email, phone, birthday, gender, student_number, avatar, role_name, active, last_login, is_login, created_date, updated_date) VALUES
--(1, 'users1', '12345678', 'Tường', 'Nguyễn', 'nct682000@gmail.com', '0948822116', '2000-08-06 10:20:25', 'Nam', '1851050178', NULL, 'users', 1, '2021-12-27 10:20:25', 1, NULL, NULL),
--(2, 'users2', '12345678', 'Cường', 'Nguyễn', 'qwe123@gmail.com', '0123456789', '2021-12-27 13:30:07', 'Nam', '1851050014', NULL, 'users', 1, '2021-12-27 13:30:07', 1, NULL, NULL),
--(3, 'users3', '12345678', 'Thành', 'Châu', 'asd123@gmail.com', '0123456789', '2021-12-27 13:31:58', 'Giới tính khác', '1851050130', NULL, 'users', 1, '2021-12-27 13:31:58', 1, NULL, NULL),
--(4, 'users4', '12345678', 'Tựu', 'Châu', 'zxc123@gmail.com', '0123456789', '2021-12-27 13:33:50', 'Nữ', '1851050179', NULL, 'users', 1, '2021-12-27 13:33:50', 1, NULL, NULL),
--(5, 'userstest', '$2y$10$vAWClOauFgm9U5/rQ2vCGO5LJ6TOoBKeI43P7hxLS4RofDdlIg6LK', 'Thưởng', 'Nguyễn', 'abcde@ou.edu.vn', '0123456789', '2000-01-01 00:00:00', 'Nam', '0123912841274', 'images (11).jpg', 'users', 1, '2021-12-29 15:28:35', 0, '2021-12-29 15:28:35', '2021-12-29 15:28:35');


--
-- Cấu trúc bảng cho bảng 'subject'
--

CREATE TABLE [subject] (
  [id] [int] PRIMARY KEY NOT NULL IDENTITY(1,1),
  [name] [varchar](255)   NOT NULL
)   ;

--
-- Đang đổ dữ liệu cho bảng 'subject'
--

INSERT INTO [subject] (name) VALUES
('Lập Trình Web'),
('Chuyên Đề');

--
-- Cấu trúc bảng cho bảng 'exam'
--

CREATE TABLE [dbo].[exam] (
  [id] [int] PRIMARY KEY NOT NULL IDENTITY(1,1),
  [name] [varchar](50)   NOT NULL,
  [execution_time] [int] NULL,
  [start_time] [datetime] NULL,
  [expire_time] [datetime] NULL,
  [password] [varchar](50)  DEFAULT NULL,
  [active] [tinyint] NOT NULL,
  [created_date] [datetime] DEFAULT NULL,
  [updated_date] [datetime] DEFAULT NULL,
  [subject_id] [int] FOREIGN KEY REFERENCES dbo.subject(id),
  [users_id] [varchar](255) FOREIGN KEY REFERENCES dbo.users(id),
)   ;

--
-- Đang đổ dữ liệu cho bảng 'exam'
--

--INSERT INTO [exam]( id ,  name ,  execution_time ,  start_time ,  expire_time ,  password ,  active ,  created_date ,  updated_date ,  subject_id ,  users_id ) VALUES
--(1, 'Thi giữ kì', 45, '2021-12-27 12:39:14', '2021-12-31 14:51:45', NULL, 0, '2021-12-27 12:39:14', '2021-12-27 12:39:14', 1, 2),
--(2, 'Bài thi giữa kì', 60, '2021-12-29 18:30:00', '2021-12-31 11:00:00', '12345678', 1, '2021-12-28 08:23:46', '2021-12-28 08:23:46', 2, 2),
--(3, 'Bài thi cuối kì', 90, '2021-12-29 08:30:00', '2021-12-31 08:30:00', '12345678', 1, '2021-12-28 15:28:10', '2021-12-28 15:28:11', 1, 2);



--
-- Cấu trúc bảng cho bảng 'question'
--

CREATE TABLE [question] (
  [id] [int] PRIMARY KEY NOT NULL IDENTITY(1,1),
  [content] [varchar](255)   NOT NULL,
  [created_date] [datetime] DEFAULT NULL,
  [updated_date] [datetime] DEFAULT NULL,
  [exam_id] [int] FOREIGN KEY REFERENCES dbo.exam(id),
)   ;

--
-- Đang đổ dữ liệu cho bảng 'question'
--

--INSERT INTO [question] (id, content, created_date, updated_date, exam_id) VALUES
--(1, 'Đây là câu hỏi số 1?', '2021-12-28 10:14:38', '2021-12-28 10:14:38', 3),
--(2, 'Đây là câu hỏi số 2?', '2021-12-28 16:36:26', '2021-12-28 16:36:26', 3),
--(3, 'Đây là câu hỏi số 3?', '2021-12-28 16:38:29', '2021-12-28 16:38:29', 3),
--(4, 'Đây là câu hỏi số 4?', '2021-12-28 16:39:02', '2021-12-28 16:39:02', 3),
--(5, 'Đây là câu hỏi số 5?', '2021-12-28 16:41:20', '2021-12-28 16:41:20', 3),
--(6, '1 + 1 = ?', '2021-12-28 16:42:01', '2021-12-28 16:42:01', 2),
--(7, 'Điền vào chỗ trống: 5 ... 5 = 10.', '2021-12-28 16:44:46', '2021-12-28 16:44:46', 2),
--(8, 'Thành có non không?', '2021-12-29 15:47:24', '2021-12-29 15:47:24', 2);



--
-- Cấu trúc bảng cho bảng 'answer'
--

CREATE TABLE [dbo].[answer] (
  [id] [int] PRIMARY KEY NOT NULL IDENTITY(1,1),
  [content] [varchar](255)   NOT NULL,
  [is_true] [tinyint] NOT NULL,
  [created_date] [datetime] DEFAULT NULL,
  [updated_date] [datetime] DEFAULT NULL,
  [question_id] [int] FOREIGN KEY REFERENCES dbo.question(id),
)   ;


--
-- Cấu trúc bảng cho bảng 'scores'
--

CREATE TABLE [scores] (
  [users_id] [varchar](255) FOREIGN KEY REFERENCES dbo.users(id),
  [exam_id] [int] FOREIGN KEY REFERENCES dbo.exam(id),
  [scores] [int] NOT NULL,
  [submited_date] [datetime] DEFAULT NULL
)   ;
