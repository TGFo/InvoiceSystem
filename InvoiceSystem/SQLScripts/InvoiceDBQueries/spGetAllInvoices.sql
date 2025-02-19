CREATE PROCEDURE spGetAllInvoices
AS
BEGIN
    SELECT *
    FROM 
        Invoices;
END
GO