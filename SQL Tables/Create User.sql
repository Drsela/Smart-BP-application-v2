INSERT INTO LoginDB (PasswordHash, FirstName, LastName)
VALUES (HASHBYTES('SHA2_512', 'Admin'),'Admin','Admin');

SELECT * FROM LoginDB