CREATE PROCEDURE spGetAllCustomers
AS
BEGIN
    SELECT *
    FROM 
        Customers;
END
GO