CREATE PROCEDURE spGetCustomerById
    @CustomerID INT
AS
BEGIN
    SELECT 
        *
    FROM 
        Customers
    WHERE 
        CustomerID = @CustomerID;
END
GO