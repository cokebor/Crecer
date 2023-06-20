USE Crecer

UPDATE TiposDocumentosCaja SET Estado=0
UPDATE TiposDocumentosCliente SET Estado=0
UPDATE TiposDocumentosProveedores SET Estado=0

UPDATE Numeradores SET ESTADO=0


declare @Empresa int

SELECT @Empresa=Codigo FROM Empresa


UPDATE Numeradores SET NUMERO=1, PuntoVenta=@Empresa

update Numeradores set letra='P',estado=1
WHERE CODIGO=42

update Numeradores set letra='M',estado=1
WHERE CODIGO=19

UPDATE TiposDocumentosCliente SET ESTADO=1
WHERE Codigo IN (7,8)

update Numeradores set letra='C',estado=1
WHERE CODIGO=5

INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (7,3),(8,3)

UPDATE TiposDocumentosCliente SET ESTADO=1
WHERE Codigo IN (1)

update Numeradores set letra='C', ESTADO=1
WHERE CODIGO=1

update TiposDocumentosCliente set estado=1
where codigo=25

update Numeradores set letra='X', ESTADO=1
WHERE CODIGO=20

UPDATE TiposDocumentosCaja SET ESTADO=1
WHERE CODIGO=8

update Numeradores set letra='C', ESTADO=1
WHERE CODIGO=21

update TiposDocumentosCliente set estado=1
where codigo=6

update Numeradores set letra='S', ESTADO=1
WHERE CODIGO=4

-- Saldos Iniciales Proveedores
UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (17,18)

--Numerador RemitoProveedor, saldos iniciales clientes y proveedor
update numeradores set estado=1
where codigo in (18)

INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (17,1),(17,3),(17,4),(17,6),(18,1),(18,3),(18,4),(18,6)

-- Saldos Iniciales CLientes
update TiposDocumentosCliente set estado=1
WHERE codigo in (23,24)

update numeradores set estado=1
where codigo in (17)

INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (23,3),(24,3)

UPDATE TiposDocumentosCliente SET AfectaIVA='N', TipoDiscIVA='N', Electronico=0, ESTADO=1
WHERE CODIGO IN (11,12)

UPDATE TiposDocumentosCliente SET Descripcion='NC s/Stock Ctado.'
WHERE CODIGO=11

UPDATE TiposDocumentosCliente SET Descripcion='NC s/Stock Cta. Cte.'
WHERE CODIGO=12

update numeradores set estado=1, Letra='E'
where codigo in (9)

INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (11,3),(12,3)

update TiposDocumentosCliente set estado=1, AfectaIVA='N', Electronico=0,TipoDiscIVA='N', Descripcion='Nota de Débito Ctado'
where codigo=15

update TiposDocumentosCliente set estado=1, AfectaIVA='N', Electronico=0,TipoDiscIVA='N', Descripcion='Nota de Débito Cta Cte'
where codigo=16


INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (15,3),(16,3)

update  Numeradores set Letra='E', Estado=1
WHERE CODIGO=11

UPDATE TiposDocumentosCliente SET Descripcion='NC s/Stock Cta. Cte. L', estado=1
WHERE CODIGO=28

INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (28,3)

update TiposDocumentosCliente set electronico=0, estado=1, AFECTAIVA='N', TipoDiscIVA='N',AFECTASTOCK='AL',
Descripcion='NC c/Stock Ctado.', CodigoNumerador=9
where CODIGO=13

update TiposDocumentosCliente set electronico=0, estado=1, AFECTAIVA='N', TipoDiscIVA='N',AFECTASTOCK='AL',
Descripcion='NC c/Stock Cta. Cte.', CodigoNumerador=9
where CODIGO=14


INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (13,3),(14,3)


UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (1,2)

insert into TipoDocumentoProveedor_TipoInscripcion values (1,1),(2,1)

UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (3,4)

insert into TipoDocumentoProveedor_TipoInscripcion values (3,6),(4,6)

UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (23,24)

insert into TipoDocumentoProveedor_TipoInscripcion values (23,3),(24,3)

UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (7,8)

insert into TipoDocumentoProveedor_TipoInscripcion values (7,1),(8,1)


UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (9,10)

insert into TipoDocumentoProveedor_TipoInscripcion values (9,6),(10,6)


UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (25,26)

insert into TipoDocumentoProveedor_TipoInscripcion values (25,3),(26,3)

UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (11,12)

insert into TipoDocumentoProveedor_TipoInscripcion values (11,1),(12,1)

UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (13,14)

insert into TipoDocumentoProveedor_TipoInscripcion values (13,6),(14,6)

UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (27,28)

insert into TipoDocumentoProveedor_TipoInscripcion values (27,3),(28,3)

UPDATE TiposDocumentosProveedores SET ESTADO=1
WHERE CODIGO IN (15,20,21,22)

UPDATE Numeradores SET Estado=1
WHERE CODIGO IN (13,39,40,41)


INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (15,1),(15,3),(15,6)

UPDATE NUMERADORES SET ESTADO=1
WHERE CODIGO=0



UPDATE TiposDocumentosProveedores SET ESTADO=1, Letra='R'
WHERE CODIGO IN (5,6)

UPDATE Numeradores SET Estado=1
WHERE CODIGO IN (7,8)

INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (5,1),(5,3),(5,6),(6,1),(6,3),(6,6)

UPDATE TiposDocumentosCliente SET ESTADO=1
WHERE Codigo=20

UPDATE NUMERADORES SET ESTADO=1
WHERE CODIGO=14

INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (20,3)

UPDATE TiposDocumentosCliente set estado=1
where Codigo in (21,22)

UPDATE Numeradores SET ESTADO=1
WHERE CODIGO IN (15,16)

insert into TipoDocumentoCliente_TipoInscripcion values (21,3),(22,3)

UPDATE TiposDocumentosCliente set estado=1
where Codigo in (27)

UPDATE Numeradores SET ESTADO=1
WHERE CODIGO IN (24)

insert into TipoDocumentoCliente_TipoInscripcion values (27,3)

UPDATE TiposDocumentosCaja SET ESTADO=1
WHERE CODIGO=7

UPDATE Numeradores SET ESTADO=1
WHERE CODIGO IN (22)






--INSERT INTO TiposDocumentosProveedores VALUES (27,'Nota de Débito Ctado "B"','B','ND',0,'N','E','N','N',1)
--INSERT INTO TiposDocumentosProveedores VALUES (28,'Nota de Débito Cta Cte "B"','B','ND',0,'D','N','N','N',1)


update TiposDocumentosCaja set Estado=1
WHERE CODIGO=2

update Numeradores set estado=1
where codigo=23


update TiposDocumentosCaja set Estado=1
WHERE CODIGO in (5,6)

update Numeradores set estado=1
where codigo=26


update TiposDocumentosCaja set Estado=1
WHERE CODIGO in (1)

update Numeradores set estado=1
where codigo=43

update TiposDocumentosCaja set Estado=1
WHERE CODIGO in (4)

update Numeradores set estado=1
where codigo=25

update TiposDocumentosCaja set Estado=1, CodigoNumerador=44
WHERE CODIGO in (3)

update Numeradores set estado=1
where codigo=44

update Numeradores set estado=1
where codigo=27

/*
SELECT T.Codigo, T.Descripcion, N.Codigo, N.Descripcion, N.Letra
FROM TiposDocumentosCaja T
INNER JOIN Numeradores N
ON N.Codigo=T.CodigoNumerador
WHERE T.Estado=1


*/



