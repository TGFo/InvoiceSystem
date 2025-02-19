CREATE PROCEDURE spDeleteInvoiceItem
    @InvoiceItemID INT
AS
BEGIN
    DELETE FROM InvoiceItems
    WHERE InvoiceItemID = @InvoiceItemID;
END
GO