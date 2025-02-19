CREATE PROCEDURE spUpdateCustomer
    @CustomerID INT,
    @Name NVARCHAR(100),
    @Address NVARCHAR(255),
    @ContactInfo NVARCHAR(100)
AS
BEGIN
    UPDATE Customers
    SET Name = @Name,
        Address = @Address,
        ContactInfo = @ContactInfo
    WHERE CustomerID = @CustomerID;
END
GO