CREATE PROCEDURE spUpdateInvoice
    @InvoiceID INT,
    @CustomerID INT,
    @InvoiceDate DATETIME,
    @TotalAmount DECIMAL(18,2)
AS
BEGIN
    UPDATE Invoices
    SET 
        CustomerID = @CustomerID,
        InvoiceDate  = @InvoiceDate,
        TotalAmount  = @TotalAmount
    WHERE 
        InvoiceID = @InvoiceID;
END
GO