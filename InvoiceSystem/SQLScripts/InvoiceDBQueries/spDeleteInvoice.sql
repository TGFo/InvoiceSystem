CREATE PROCEDURE spDeleteInvoice
    @InvoiceID INT
AS
BEGIN
    DELETE FROM Invoices
    WHERE InvoiceID = @InvoiceID;
END
GO