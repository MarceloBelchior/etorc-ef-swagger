IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Torc')
BEGIN
    CREATE DATABASE Torc;
END


Use Torc;
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Orders] (
    [OrderId] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [CustomerId] int NOT NULL,
    [Quantity] int NOT NULL,
    [Cost] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_rders] PRIMARY KEY ([OrderId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230611235008_InitialCreate', N'7.0.5');
GO

COMMIT;
GO

--Seed Product 1
insert into dbo.Products (  Name, Price)values('test one', 12.21);
 