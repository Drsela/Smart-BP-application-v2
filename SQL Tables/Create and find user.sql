--INSERT INTO LoginDBWithHash (PasswordHash, FirstName, LastName)
--VALUES (HASHBYTES('SHA2_512', 'PW'),'Benjamin','Mikkelsen');

SELECT * FROM LoginDBWithHash WHERE UserID='102' AND PasswordHash=HASHBYTES('SHA2_512','PW')
