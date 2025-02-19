CREATE PROCEDURE spDeleteCustomer
    @CustomerID INT
AS
BEGIN
    DELETE FROM Customers
    WHERE CustomerID = @CustomerID;
END
GO