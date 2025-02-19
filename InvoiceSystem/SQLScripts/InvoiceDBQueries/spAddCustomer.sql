CREATE PROCEDURE spAddCustomer
    @Name NVARCHAR(100),
    @Address NVARCHAR(255),
    @ContactInfo NVARCHAR(100)
AS
BEGIN
    INSERT INTO Customers (Name, Address, ContactInfo)
    VALUES (@Name, @Address, @ContactInfo);
    SELECT SCOPE_IDENTITY() AS NewCustomerID;
END
GO