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

-- =============================================
-- Datos de prueba
-- =============================================

USE ProductApiDB;
GO

INSERT INTO Products
(
    Name,
    Status,
    Stock,
    Description,
    Price
)
VALUES
(
    'Laptop Lenovo ThinkPad',
    1,
    10,
    'Laptop Core i7 16GB RAM',
    3500.00
),
(
    'Mouse Logitech MX Master',
    1,
    50,
    'Mouse ergonomico inalambrico',
    350.00
),
(
    'Teclado Mecanico Redragon',
    1,
    30,
    'Teclado mecanico RGB',
    280.00
),
(
    'Monitor Samsung 24 pulgadas',
    0,
    15,
    'Monitor Full HD 24 pulgadas',
    800.00
),
(
    'Disco SSD Kingston 1TB',
    1,
    20,
    'SSD NVMe alta velocidad',
    450.00
);
GO

SELECT * FROM Products