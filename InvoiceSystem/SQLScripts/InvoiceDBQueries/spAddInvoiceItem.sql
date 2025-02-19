CREATE PROCEDURE spAddInvoiceItem
    @InvoiceID INT,
    @ItemID INT,
    @Quantity INT
AS
BEGIN
    INSERT INTO InvoiceItems (InvoiceID, ItemID, Quantity)
    VALUES (@InvoiceID, @ItemID, @Quantity);
    SELECT SCOPE_IDENTITY() AS NewInvoiceItemID;
END
GO