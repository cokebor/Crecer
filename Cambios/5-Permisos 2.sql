USE Crecer

declare @Empresa int

SELECT @Empresa=Codigo FROM Empresa
	INSERT INTO Permisos VALUES (1,8)
	INSERT INTO Permisos VALUES (2,8)
	INSERT INTO Permisos VALUES (3,8)
	INSERT INTO Permisos VALUES (4,8)
	INSERT INTO Permisos VALUES (5,8)
	INSERT INTO Permisos VALUES (1,21)
	INSERT INTO Permisos VALUES (2,21)
	INSERT INTO Permisos VALUES (5,21)
	INSERT INTO Permisos VALUES (1,53)
	INSERT INTO Permisos VALUES (2,53)
	INSERT INTO Permisos VALUES (3,53)
	INSERT INTO Permisos VALUES (4,53)
	INSERT INTO Permisos VALUES (5,53)
	INSERT INTO Permisos VALUES (1,67)
	INSERT INTO Permisos VALUES (2,67)
	INSERT INTO Permisos VALUES (3,67)
	INSERT INTO Permisos VALUES (5,67)
	INSERT INTO Permisos VALUES (1,20)
	INSERT INTO Permisos VALUES (2,20)
	INSERT INTO Permisos VALUES (3,20)
	INSERT INTO Permisos VALUES (5,20)
	INSERT INTO Permisos VALUES (1,54)
	INSERT INTO Permisos VALUES (2,54)
	INSERT INTO Permisos VALUES (3,54)
	INSERT INTO Permisos VALUES (4,54)
	INSERT INTO Permisos VALUES (5,54)
	INSERT INTO Permisos VALUES (1,65)
	INSERT INTO Permisos VALUES (2,65)
	INSERT INTO Permisos VALUES (3,65)
	INSERT INTO Permisos VALUES (5,65)
	INSERT INTO Permisos VALUES (1,27)
	INSERT INTO Permisos VALUES (2,27)
	INSERT INTO Permisos VALUES (5,27)
	INSERT INTO Permisos VALUES (2,71)

IF @Empresa=1
BEGIN
	INSERT INTO Permisos VALUES (1,28)
	INSERT INTO Permisos VALUES (2,28)
	INSERT INTO Permisos VALUES (5,28)
	INSERT INTO Permisos VALUES (1,14)
	INSERT INTO Permisos VALUES (2,14)
	INSERT INTO Permisos VALUES (5,14)
	INSERT INTO Permisos VALUES (1,29)
	INSERT INTO Permisos VALUES (2,29)
	INSERT INTO Permisos VALUES (5,29)
	INSERT INTO Permisos VALUES (2,9)
	INSERT INTO Permisos VALUES (4,9)
	INSERT INTO Permisos VALUES (1,17)
	INSERT INTO Permisos VALUES (2,17)
	INSERT INTO Permisos VALUES (5,17)
	INSERT INTO Permisos VALUES (1,19)
	INSERT INTO Permisos VALUES (2,19)
	INSERT INTO Permisos VALUES (5,19)
	INSERT INTO Permisos VALUES (1,22)
	INSERT INTO Permisos VALUES (2,22)
	INSERT INTO Permisos VALUES (3,22)
	INSERT INTO Permisos VALUES (5,22)
	

END
ELSE
BEGIN 
	INSERT INTO Permisos VALUES (1,37)
	INSERT INTO Permisos VALUES (2,37)
	INSERT INTO Permisos VALUES (3,37)
	INSERT INTO Permisos VALUES (5,37)
END






