CREATE PROCEDURE spGetInvoiceItems
    @InvoiceID INT
AS
BEGIN
    SELECT 
        ii.InvoiceItemID,
        i.ItemID,
        i.Name AS ItemName,
        i.UnitPrice,
        ii.Quantity,
        (ii.Quantity * i.UnitPrice) AS TotalPrice
    FROM InvoiceItems ii
    INNER JOIN Items i ON ii.ItemID = i.ItemID
    WHERE ii.InvoiceID = @InvoiceID;
END
GO