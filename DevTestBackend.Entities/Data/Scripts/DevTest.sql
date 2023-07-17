USE [master]
GO

CREATE DATABASE [DevTest]
GO

USE [DevTest]
GO

CREATE TABLE [dbo].[Client] (
	[ClientID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[Email] VARCHAR(100) UNIQUE NOT NULL,
) 
GO

CREATE TABLE [dbo].[Address] (
	[AddressID] INT PRIMARY KEY IDENTITY,
	[Street] VARCHAR(100) NOT NULL,
	[City] VARCHAR(100) NOT NULL,
	[ClientID] INT NOT NULL,

	FOREIGN KEY([ClientID]) REFERENCES [Client]([ClientID])
)
GO

CREATE TABLE [dbo].[Perfil](
	[PerfilID] INT PRIMARY KEY IDENTITY,
	[Description] VARCHAR(100) NOT NULL,
	[ClientID] INT NOT NULL,

	FOREIGN KEY([ClientID]) REFERENCES [Client]([ClientID])
) 
GO