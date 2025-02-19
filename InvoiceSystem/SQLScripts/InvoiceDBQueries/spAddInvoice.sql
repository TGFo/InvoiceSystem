CREATE PROCEDURE spAddInvoice
    @CustomerID INT,
    @InvoiceDate DATETIME,
    @TotalAmount DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Invoices (CustomerID, InvoiceDate, TotalAmount)
    VALUES (@CustomerID, @InvoiceDate, @TotalAmount);

    SELECT SCOPE_IDENTITY() AS NewInvoiceID;
END
GO
