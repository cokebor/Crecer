USE Crecer

declare @Empresa int

SELECT @Empresa=Codigo FROM Empresa
	INSERT INTO Permisos VALUES (1,132)
	INSERT INTO Permisos VALUES (2,132)
	INSERT INTO Permisos VALUES (3,132)
	INSERT INTO Permisos VALUES (4,132)
	INSERT INTO Permisos VALUES (5,132)
	INSERT INTO Permisos VALUES (1,113)
	INSERT INTO Permisos VALUES (2,113)
	INSERT INTO Permisos VALUES (3,113)
	INSERT INTO Permisos VALUES (5,113)
	INSERT INTO Permisos VALUES (1,103)
	INSERT INTO Permisos VALUES (2,103)
	INSERT INTO Permisos VALUES (2,103)
	INSERT INTO Permisos VALUES (3,103)
	INSERT INTO Permisos VALUES (5,103)
	INSERT INTO Permisos VALUES (1,131)
	INSERT INTO Permisos VALUES (2,131)
	INSERT INTO Permisos VALUES (3,131)
	INSERT INTO Permisos VALUES (5,131)
	INSERT INTO Permisos VALUES (1,39)
	INSERT INTO Permisos VALUES (2,39)
	INSERT INTO Permisos VALUES (3,39)
	INSERT INTO Permisos VALUES (5,39)

IF @Empresa=1
BEGIN

	INSERT INTO Permisos VALUES (1,125)
	INSERT INTO Permisos VALUES (2,125)
	INSERT INTO Permisos VALUES (5,125)
	INSERT INTO Permisos VALUES (1,104)
	INSERT INTO Permisos VALUES (2,104)
	INSERT INTO Permisos VALUES (5,104)
	INSERT INTO Permisos VALUES (1,115)
	INSERT INTO Permisos VALUES (2,115)
	INSERT INTO Permisos VALUES (5,115)
	INSERT INTO Permisos VALUES (1,114)
	INSERT INTO Permisos VALUES (2,114)
	INSERT INTO Permisos VALUES (5,114)
	INSERT INTO Permisos VALUES (1,126)
	INSERT INTO Permisos VALUES (2,126)
	INSERT INTO Permisos VALUES (5,126)
	INSERT INTO Permisos VALUES (1,89)
	INSERT INTO Permisos VALUES (2,89)
	INSERT INTO Permisos VALUES (5,89)
	INSERT INTO Permisos VALUES (1,122)
	INSERT INTO Permisos VALUES (2,122)
	INSERT INTO Permisos VALUES (4,122)
	INSERT INTO Permisos VALUES (5,122)
	INSERT INTO Permisos VALUES (1,120)
	INSERT INTO Permisos VALUES (2,120)
	INSERT INTO Permisos VALUES (5,120)
	INSERT INTO Permisos VALUES (2,143)
	INSERT INTO Permisos VALUES (5,143)
	select 1
END
ELSE
BEGIN 
	/*INSERT INTO Permisos VALUES (3,60)
	INSERT INTO Permisos VALUES (3,78)*/
	select 1
END





