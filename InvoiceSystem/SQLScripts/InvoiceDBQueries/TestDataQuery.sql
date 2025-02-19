-- Insert test data for the Items table
INSERT INTO Items (Name, UnitPrice)
VALUES 
    ('Widget A', 50.00),
    ('Widget B', 75.00),
    ('Service A', 150.00),
    ('Product X', 200.00),
    ('Product Y', 300.00);
GO

-- Insert test data for the Customers table
INSERT INTO Customers (Name, Address, ContactInfo)
VALUES
    ('John Doe', '123 Main St, Anytown, USA', 'john@example.com'),
    ('Jane Smith', '456 Oak Ave, Othertown, USA', 'jane@example.com'),
    ('Acme Corp', '789 Industrial Rd, Metropolis, USA', 'info@acme.com');
GO

-- Insert test data for the Invoices table
-- Assumes CustomerIDs 1, 2, and 3 exist from the Customers table
INSERT INTO Invoices (CustomerID, InvoiceDate, TotalAmount)
VALUES
    (1, '2025-01-15', 250.00),
    (2, '2025-01-18', 450.50),
    (3, '2025-01-20', 1025.75);
GO

-- Insert test data for the InvoiceItems table
-- Assumes InvoiceIDs and ItemIDs from previous inserts:
-- Invoice 1 (CustomerID 1) uses Widget A (ItemID 1) and Widget B (ItemID 2)
-- Invoice 2 (CustomerID 2) uses Service A (ItemID 3) and Widget B (ItemID 2)
-- Invoice 3 (CustomerID 3) uses Product X (ItemID 4) and Product Y (ItemID 5)
INSERT INTO InvoiceItems (InvoiceID, ItemID, Quantity)
VALUES
    (1, 1, 2),   -- Invoice 1: Widget A, quantity 2
    (1, 2, 3),   -- Invoice 1: Widget B, quantity 3
    (2, 3, 1),   -- Invoice 2: Service A, quantity 1
    (2, 2, 2),   -- Invoice 2: Widget B, quantity 2
    (3, 4, 5),   -- Invoice 3: Product X, quantity 5
    (3, 5, 2);   -- Invoice 3: Product Y, quantity 2
GO
