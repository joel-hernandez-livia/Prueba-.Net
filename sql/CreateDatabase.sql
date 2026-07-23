-- Nombre: Joel Hernandez Livia

-- =============================================
-- Crear Base de Datos
-- =============================================

CREATE DATABASE ProductApiDB;
GO

USE ProductApiDB;
GO

-- =============================================
-- Tabla Products
-- =============================================

CREATE TABLE Products
(
    ProductId INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_Products PRIMARY KEY,

    Name NVARCHAR(100) NOT NULL,

    Status TINYINT NOT NULL
        CONSTRAINT CK_Products_Status
        CHECK (Status IN (0,1)),

    Stock INT NOT NULL
        CONSTRAINT CK_Products_Stock
        CHECK (Stock >= 0),

    Description NVARCHAR(500) NOT NULL,

    Price DECIMAL(18,2) NOT NULL
        CONSTRAINT CK_Products_Price
        CHECK (Price >= 0),

    CreatedDate DATETIME2 NOT NULL
        CONSTRAINT DF_Products_CreatedDate
        DEFAULT(GETDATE()),
);
GO



SELECT * FROM Products