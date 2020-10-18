PRINT N'Creating Database';
GO
CREATE DATABASE ConsultaMedica
GO
USE ConsultaMedica
GO
SET ANSI_NULLS ON
GO
PRINT N'Creating ConsultaMedica.Patients...';  
GO
CREATE TABLE [dbo].[Patient] (
    [Id]        INT           NOT NULL IDENTITY(1, 1),
    [Name]      VARCHAR (100) NOT NULL,
    [Email]     VARCHAR (100) NOT NULL,
    [CPF]       VARCHAR (14)  NOT NULL,
    [BirthDate] DATE          NOT NULL,
    [Sex]       CHAR (1)      NOT NULL,
    [Phone]     VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
PRINT N'Inserting ConsultaMedica.Patients...';  
GO
INSERT INTO [dbo].[Patient] ([Name], [Email], [CPF], [BirthDate], [Sex], [Phone]) VALUES (N'Alex Salvador', N'alex@gmail.com', N'000.000.000-01', N'2001-01-01', N'M', N'(81) 9 8823-0132')
INSERT INTO [dbo].[Patient] ([Name], [Email], [CPF], [BirthDate], [Sex], [Phone]) VALUES (N'Marcia Alexandra Ribeiro', N'ale.ribeiro@hotmail.com', N'000.000.000-02', N'1998-08-11', N'F', N'(55) 9 8234-9123')
INSERT INTO [dbo].[Patient] ([Name], [Email], [CPF], [BirthDate], [Sex], [Phone]) VALUES (N'Rafael Garrucho', N'rafa.garrucho@gmail.com', N'000.000.000-03', N'1997-09-28', N'M', N'(51) 9 9323-3213')
GO
PRINT N'Creating ConsultaMedica.ExamType...';  
GO
CREATE TABLE [dbo].[ExamType]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Name] VARCHAR(100) NOT NULL, 
    [Description] VARCHAR(256) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO
PRINT N'Inserting ConsultaMedica.ExamType...';  
GO
INSERT INTO [dbo].[ExamType] ([Name], [Description]) VALUES (N'Hemograma', N'Descrição do exame do hemograma')
INSERT INTO [dbo].[ExamType] ([Name], [Description]) VALUES (N'Raio X', N'Descrição do exame de raio x')
GO
PRINT N'Creating ConsultaMedica.Exam...';  
GO
CREATE TABLE [dbo].[Exam]
(
	[Id] INT NOT NULL IDENTITY(1, 1), 
    [Name] VARCHAR(100) NOT NULL, 
    [Observations] VARCHAR(1000) NOT NULL, 
    [ExamTypeId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO
PRINT N'Creating ConsultaMedica.FK_ExamType_Exam_ExamTypeId...';  
GO  
ALTER TABLE [dbo].[Exam]  
    ADD CONSTRAINT [FK_ExamType_Exam_ExamTypeId] FOREIGN KEY ([ExamTypeId]) REFERENCES [dbo].[ExamType] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;  
GO
PRINT N'Inserting ConsultaMedica.Name...';  
GO
INSERT INTO [dbo].[Exam] ([Name], [Observations], [ExamTypeId]) VALUES (N'Nome do exame 1', N'Observações do exame 1', 1)
INSERT INTO [dbo].[Exam] ([Name], [Observations], [ExamTypeId]) VALUES (N'Nome do exame 2', N'Observações do exame 2', 2)
GO