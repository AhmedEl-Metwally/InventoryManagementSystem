

DBCC CHECKIDENT ('Suppliers', RESEED, 0);
DBCC CHECKIDENT ('Categories', RESEED, 0);
DBCC CHECKIDENT ('Products', RESEED, 0);
DBCC CHECKIDENT ('LowStockAlerts', RESEED, 0);
DBCC CHECKIDENT ('Transactions', RESEED, 0);

INSERT INTO Suppliers (Name, CompanyName, PhoneNumber)
VALUES 
('Tech World Egypt', 'Tech Global Group', '01012345678'),
('Delta Electronics', 'Delta Systems', '01122334455'),
('Cairo Trading Co', 'Cairo Trade', '01299887766');

INSERT INTO Categories (Name, Description)
VALUES 
('Smartphones', 'Mobile devices and tablets'),
('Laptops', 'High-end computers'),
('Accessories', 'Cables and Peripherals');

INSERT INTO Products (Name, Description, Price, QuantityInStock, CreatedAt, UpdatedAt, CategoryId, SupplierId)
VALUES 
('iPhone 15 Pro', 'Apple Titanium body phone', 1200.00, 50, GETDATE(), GETDATE(), 1, 1),
('Samsung S24 Ultra', 'AI enabled flagship', 1100.00, 30, GETDATE(), GETDATE(), 1, 2),
('MacBook Pro M3', 'Powerful Apple laptop', 2500.00, 10, GETDATE(), GETDATE(), 2, 1),
('Dell XPS 15', 'High-end Windows laptop', 1800.00, 5, GETDATE(), GETDATE(), 2, 3),
('Logitech Mouse', 'Wireless gaming mouse', 80.00, 100, GETDATE(), GETDATE(), 3, 3);

INSERT INTO LowStockAlerts (Threshold, AlertSent, Date, ProductId)
VALUES (10, 0, GETDATE(), 4); 


INSERT INTO Transactions (Quantity, Type, Date, TotalAmount, ProductId)
VALUES 
(5, 2, GETDATE(), 6000.00, 1), 
(2, 1, GETDATE(), 2200.00, 2); 