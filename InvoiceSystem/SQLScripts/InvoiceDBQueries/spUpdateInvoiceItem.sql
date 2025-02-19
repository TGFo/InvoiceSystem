CREATE PROCEDURE spUpdateInvoiceItem
    @InvoiceItemID INT,
    @InvoiceID INT,
    @ItemID INT,
    @Quantity INT
AS
BEGIN
    UPDATE InvoiceItems
    SET InvoiceID = @InvoiceID,
        ItemID = @ItemID,
        Quantity = @Quantity
    WHERE InvoiceItemID = @InvoiceItemID;
END
GO