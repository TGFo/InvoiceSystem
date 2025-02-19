-- Create the database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'InvoiceDB')
BEGIN
    CREATE DATABASE InvoiceDB;
END
GO

USE InvoiceDB;
GO

-- Create the Customers table
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255) NULL,
    ContactInfo NVARCHAR(100) NULL
);
GO

-- Create the Invoices table
CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    InvoiceDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Invoices_Customers FOREIGN KEY (CustomerID)
        REFERENCES Customers(CustomerID)
);
GO

-- Create the Items table (master list of items)
CREATE TABLE Items (
    ItemID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL
);
GO

-- Create the InvoiceItems table that references Invoices and Items
CREATE TABLE InvoiceItems (
    InvoiceItemID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceID INT NOT NULL,
    ItemID INT NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT FK_InvoiceItems_Invoices FOREIGN KEY (InvoiceID)
        REFERENCES Invoices(InvoiceID)
        ON DELETE CASCADE,
    CONSTRAINT FK_InvoiceItems_Items FOREIGN KEY (ItemID)
        REFERENCES Items(ItemID)
);
GO
