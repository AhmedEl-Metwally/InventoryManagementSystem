INSERT INTO Roles (Id, [Name], [NormalizedName], [ConcurrencyStamp])
VALUES 
(NEWID(), 'Admin', 'ADMIN', NEWID()),
(NEWID(), 'Manager', 'MANAGER', NEWID()),
(NEWID(), 'Staff', 'STAFF', NEWID());