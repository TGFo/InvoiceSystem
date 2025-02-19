CREATE PROCEDURE spGetInvoiceById
    @InvoiceID INT
AS
BEGIN
    SELECT 
        *
    FROM 
        Invoices
    WHERE 
        InvoiceID = @InvoiceID;
END
GO