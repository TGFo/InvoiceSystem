CREATE PROCEDURE AddNewItem
    @Description VARCHAR(255),
    @ItemID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        IF LEN(@Description) = 0
            RAISERROR('Description cannot be empty.', 16, 1);

        INSERT INTO Item (Description)
        VALUES (@Description);

        SET @ItemID = SCOPE_IDENTITY(); -- Return the new ItemID
        RETURN 0; -- Success
    END TRY
    BEGIN CATCH
        PRINT 'Error: ' + ERROR_MESSAGE();
        RETURN -1; -- Error code
    END CATCH
END;