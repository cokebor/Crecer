

INSERT INTO Empresa (Codigo,NombreSucursal, RazonSocial,CUIT,Domicilio,Puesto, Domicilio2,IngresosBrutos,FechaInicioActividad,CuentaContableVentaSucursal, CuentaContableIvaDebitoSucursal, CuentaContableDebolucionMercaderiaSucursal,CuentaContableAjusteSucursal, CuentaContableCuentaCorrienteProveedores, CuentaContableCuentaCorrienteClientes) 
VALUES(1, 'WI�AY - Dep�sito', 'WI�AY S.A.','30-70761233-5','Ruta 19 Km. 7 1/2','Puesto 24','MERCADO DE ABASTO (Cba.)','54268521','2016/05',401010101,201020100,401010201,401010301,201010100,101020100);
/*INSERT INTO Empresa (Codigo,NombreSucursal, RazonSocial,CUIT,Domicilio,Puesto, Domicilio2,IngresosBrutos,FechaInicioActividad,CuentaContableVentaSucursal, CuentaContableIvaDebitoSucursal, CuentaContableDebolucionMercaderiaSucursal,CuentaContableAjusteSucursal, CuentaContableCuentaCorrienteProveedores, CuentaContableCuentaCorrienteClientes) 
VALUES(2, 'WIKI S.A.', 'WIKI S.A.','30-70992865-8','Ruta 19 Km. 7 1/2','Nave 3 Puesto 305/307','MERCADO DE ABASTO (Cba.)','270647821','05/2007',401010100,201020100,401010200,401010300,201010100,101020100);
*/
/*
INSERT INTO Empresa (Codigo,NombreSucursal, RazonSocial,CUIT,Domicilio,Puesto, Domicilio2,IngresosBrutos,FechaInicioActividad,CuentaContableVentaSucursal, CuentaContableIvaDebitoSucursal, CuentaContableDebolucionMercaderiaSucursal,CuentaContableAjusteSucursal, CuentaContableCuentaCorrienteProveedores, CuentaContableCuentaCorrienteClientes) 
VALUES(6, 'FRUTICOLA CENTRO SRL', 'FRUTICOLA CENTRO SRL','30-57077853-2','Ruta 19 Km. 7 1/2','Nave 3 Puesto 324','MERCADO DE ABASTO (Cba.)','200106296','01/07/1988',401010100,201020100,401010200,401010300,201010100,101020100);
*/
--INSERT INTO Empresa (Codigo, RazonSocial,CUIT, CuentaContableVentaSucursal,CuentaContableIvaDebitoSucursal) VALUES(7, 'WI�AY S.A.','30-70761233-5',11,401010105,2130205);



DECLARE @IDSUC AS INT
SELECT @IDSUC=Codigo FROM Empresa

IF @IDSUC=1 OR @IDSUC=2 OR @IDSUC=6
	BEGIN
		INSERT INTO Codigos VALUES ('Paises',1,999);
		INSERT INTO Codigos VALUES ('Comunicaciones',1,999)
		INSERT INTO Codigos VALUES ('Provincias',1,999)
		INSERT INTO Codigos VALUES ('Localidades',1,999)
		INSERT INTO Codigos VALUES ('Clientes',1,999)
		INSERT INTO Codigos VALUES ('Bancos',1,999)
		INSERT INTO Codigos VALUES ('TiposMovimientosBancarios',1,999)
	END

IF @IDSUC=3 
	BEGIN
		INSERT INTO Codigos VALUES ('Paises',3000,3999);
		INSERT INTO Codigos VALUES ('Comunicaciones',3000,3999);
		INSERT INTO Codigos VALUES ('Provincias',3000,3999);
		INSERT INTO Codigos VALUES ('Localidades',3000,3999);
		INSERT INTO Codigos VALUES ('Clientes',3000,3999);
		INSERT INTO Codigos VALUES ('Bancos',3000,3999);
		INSERT INTO Codigos VALUES ('TiposMovimientosBancarios',3000,3999);
	END
IF @IDSUC=4 
	BEGIN
		INSERT INTO Codigos VALUES ('Paises',4000,4999);
		INSERT INTO Codigos VALUES ('Comunicaciones',4000,4999);
		INSERT INTO Codigos VALUES ('Provincias',4000,4999);
		INSERT INTO Codigos VALUES ('Localidades',4000,4999);
		INSERT INTO Codigos VALUES ('Clientes',4000,4999);
		INSERT INTO Codigos VALUES ('Bancos',4000,4999);
		INSERT INTO Codigos VALUES ('TiposMovimientosBancarios',4000,4999);
	END
IF @IDSUC=5
	BEGIN
		INSERT INTO Codigos VALUES ('Paises',5000,5999);
		INSERT INTO Codigos VALUES ('Comunicaciones',5000,5999);
		INSERT INTO Codigos VALUES ('Provincias',5000,5999);
		INSERT INTO Codigos VALUES ('Localidades',5000,5999);
		INSERT INTO Codigos VALUES ('Clientes',5000,5999);
		INSERT INTO Codigos VALUES ('Bancos',5000,5999);
		INSERT INTO Codigos VALUES ('TiposMovimientosBancarios',5000,5999);
	END
IF @IDSUC=7 
	BEGIN
		INSERT INTO Codigos VALUES ('Paises',6000,6999);
		INSERT INTO Codigos VALUES ('Comunicaciones',6000,6999);
		INSERT INTO Codigos VALUES ('Provincias',6000,6999);
		INSERT INTO Codigos VALUES ('Localidades',6000,6999);
		INSERT INTO Codigos VALUES ('Clientes',6000,6999);
		INSERT INTO Codigos VALUES ('Bancos',6000,6999);
		INSERT INTO Codigos VALUES ('TiposMovimientosBancarios',6000,6999);
	END


INSERT INTO Novedades VALUES ('Paises', 0);
INSERT INTO Novedades VALUES ('Comunicaciones', 0);
INSERT INTO Novedades VALUES ('Obras Sociales', 0);
INSERT INTO Novedades VALUES ('Puestos', 0);
INSERT INTO Novedades VALUES ('Provincias', 0);
INSERT INTO Novedades VALUES ('Localidades', 0);
INSERT INTO Novedades VALUES ('Empleados', 0);
INSERT INTO Novedades VALUES ('Rubros de Productos',0);
INSERT INTO Novedades VALUES ('Productos',0);
INSERT INTO Novedades VALUES ('Proveedores',0);
INSERT INTO Novedades VALUES ('Clientes',0);
INSERT INTO Novedades VALUES ('Monedas',0);
INSERT INTO Novedades VALUES ('Bancos',0);
INSERT INTO Novedades VALUES ('TiposMovimientosBancarios',0);

INSERT INTO Paises VALUES (1, 'ARGENTINA',1,1);

INSERT INTO Comunicaciones VALUES (1,'Celular',1,1);
INSERT INTO Comunicaciones VALUES (2,'Fijo',1,1);
INSERT INTO Comunicaciones VALUES (3,'E-mail',1,1);

INSERT INTO GruposDeUsuarios VALUES (1,'Administraci�n',1);
INSERT INTO GruposDeUsuarios VALUES (2,'Sistemas',1);

INSERT INTO ObrasSociales VALUES (1,'P.R.E.M.E.',1,1);

INSERT INTO Puestos VALUES (1,'Sistemas',1,1);
INSERT INTO Puestos VALUES (2,'Vendedores',1,1);

INSERT INTO Provincias VALUES (1,'CORDOBA',1,1,1);

INSERT INTO Localidades VALUES (1,'CORDOBA CAPITAL',1,1,1);
INSERT INTO Localidades VALUES (2,'VILLA DE MARIA DEL RIO SECO',1,1,1);

INSERT INTO Empleados VALUES (1,1,'Bordarampe', 'Jorge', 1,'28775160', 'M','22/10/1981', 'Marcelo T de Alvear 334', 'Centro', '5000', 2, '01/05/2010', '20-28775160-6', 1, 2,0,1,1,1);

INSERT INTO Usuarios VALUES (1,2,'coke','NdXdcB0Vb6nokJa2+OmGaw==','-6703919',1);


INSERT INTO GruposMenus VALUES (1,'Sistema');
INSERT INTO GruposMenus VALUES (2,'Administraci�n');
INSERT INTO GruposMenus VALUES (3,'Bancos')
INSERT INTO GruposMenus VALUES (4,'RR.HH.');
INSERT INTO GruposMenus VALUES (5,'Compras');

INSERT INTO GruposMenus VALUES (6,'Stock');		
INSERT INTO GruposMenus VALUES (7,'Ventas');    
INSERT INTO GruposMenus VALUES (8,'Valores');
INSERT INTO GruposMenus VALUES (9,'Sucursales');

INSERT INTO GruposMenus VALUES (10,'Contabilidad'); 
--INSERT INTO GruposMenus VALUES (8,'Informes');
INSERT INTO GruposMenus VALUES (11,'Seguridad');


INSERT INTO Menus VALUES (1,'Salir',1);
INSERT INTO Menus VALUES (2,'Paises',2);
INSERT INTO Menus VALUES (3,'Comunicaciones',2);
INSERT INTO Menus VALUES (4,'Grupos De Usuarios',11);
INSERT INTO Menus VALUES (5,'Obras Sociales',4);
INSERT INTO Menus VALUES (6,'Puestos',4);
INSERT INTO Menus VALUES (7,'Provincias',2);
INSERT INTO Menus VALUES (8,'Localidades',2);
INSERT INTO Menus VALUES (9,'Empleados',4);
INSERT INTO Menus VALUES (10,'Generar Backup sin Cerrar Caja',1);
INSERT INTO Menus VALUES (11,'Usuarios',11);
INSERT INTO Menus VALUES (12,'Permisos',11);
INSERT INTO Menus VALUES (13,'Rubros de Productos',2);
INSERT INTO Menus VALUES (14,'Productos',2);
INSERT INTO Menus VALUES (15,'Cambiar Clave',11);
INSERT INTO Menus VALUES (16,'Cerrar Sesion',1);
INSERT INTO Menus VALUES (17,'Proveedores',5);
INSERT INTO Menus VALUES (18,'Numeradores',2);
INSERT INTO Menus VALUES (19,'Remitos de Proveedores',5);
INSERT INTO Menus VALUES (20,'Clientes',7);
INSERT INTO Menus VALUES (21,'Tipos de Documentos de Clientes',2);
INSERT INTO Menus VALUES (22,'Remitos de Clientes',7);
INSERT INTO Menus VALUES (23,'Monedas',2);
INSERT INTO Menus VALUES (24,'Actualizaci�n automatica de Novedades',1);
INSERT INTO Menus VALUES (25,'Bancos',3);
INSERT INTO Menus VALUES (26,'Comprobantes de Venta',7);
INSERT INTO Menus VALUES (27,'Ejercicios Economicos',10);
INSERT INTO Menus VALUES (28,'Impuestos',2);
INSERT INTO Menus VALUES (29,'Tipos de Documentos de Proveedores',2);
INSERT INTO Menus VALUES (30,'Listado de Empleados',4);
INSERT INTO Menus VALUES (31,'Listado de Productos',1);
INSERT INTO Menus VALUES (32,'Listado de Proveedores',5);
INSERT INTO Menus VALUES (33,'Informe de Remitos de Proveedores',5);
INSERT INTO Menus VALUES (34,'Informe de Remitos de Clientes',7);
INSERT INTO Menus VALUES (35,'Facturas de Compras',5);
/*INSERT INTO Menus VALUES (36, 'Informes',4)
INSERT INTO Menus VALUES (37, 'Informes',1)*/
INSERT INTO Menus VALUES (36, 'Cuentas Bancarias',3)
INSERT INTO Menus VALUES (37, 'Comprobantes de Venta Manuales',7);
INSERT INTO Menus VALUES (38, 'Tipos Movimientos Bancarios',3);
INSERT INTO Menus VALUES (39, 'Informes de Asientos',10);
INSERT INTO Menus VALUES (40, 'Listado de IVA',10);
INSERT INTO Menus VALUES (41, 'Pagos',5);
INSERT INTO Menus VALUES (42, 'Anulaci�n de Comprobantes',7);
INSERT INTO Menus VALUES (43, 'Notas de Cr�dito',7)
INSERT INTO Menus VALUES (44, 'Por Devoluci�n de Mercader�a',7);
INSERT INTO Menus VALUES (45, 'Por Ajuste de Precio',7);
INSERT INTO Menus VALUES (46, 'Notas de D�bito',7);
INSERT INTO Menus VALUES (47, 'Liquidaci�n de Remitos de Clientes',7);
INSERT INTO Menus VALUES (48, 'Liquidaci�n de Remitos de Proveedores',5);
INSERT INTO Menus VALUES (49, 'Pagos',7);
INSERT INTO Menus VALUES (50, 'Informe de Ventas por Producto',1);
INSERT INTO Menus VALUES (51, 'Informe de Comprobantes de Venta',1);
INSERT INTO Menus VALUES (52, 'Cargar Saldo Inicial',7);
INSERT INTO Menus VALUES (53, 'Consulta de Stock',6);
INSERT INTO Menus VALUES (54, 'Listado de Clientes',7);
INSERT INTO Menus VALUES (55, 'Informe de Saldos de Cuentas Corrientes de Clientes',1);
INSERT INTO Menus VALUES (56, 'Cargar Saldo Inicial',5);
INSERT INTO Menus VALUES (57, 'Informe de Saldos de Cuentas Corrientes de Proveedores',1);
INSERT INTO Menus VALUES (58, 'Anulaci�n de Comprobantes',5);
INSERT INTO Menus VALUES (59, 'Informe de Ventas por Producto Detallado',1);
INSERT INTO Menus VALUES (60, 'Cierre de Caja',8);
INSERT INTO Menus VALUES (61, 'Movimientos Cuenta Corriente Cliente',7);
INSERT INTO Menus VALUES (62, 'Movimientos Cuenta Corriente Proveedor',5);
INSERT INTO Menus VALUES (63, 'Informe de Stock',1)
INSERT INTO Menus VALUES (64, 'Restaurar Backup',1);
INSERT INTO Menus VALUES (65, 'Distribuci�n de Gu�as',9);
INSERT INTO Menus VALUES (66, 'Informe de Envios de Mercaderia',9);
INSERT INTO Menus VALUES (67, 'Mermas',6);
INSERT INTO Menus VALUES (68, 'Informe de Ventas por Lote',1);
INSERT INTO Menus VALUES (69, 'Integraci�n de datos',1);
INSERT INTO Menus VALUES (70, 'Informe de Mermas',1);

/*
IF @IDSUC=1 OR @IDSUC=2 OR @IDSUC=6
	BEGIN

		
	END
	*/
INSERT INTO Permisos VALUES (2,1);
INSERT INTO Permisos VALUES (2,2);
INSERT INTO Permisos VALUES (2,3);
INSERT INTO Permisos VALUES (2,4);
INSERT INTO Permisos VALUES (2,5);
INSERT INTO Permisos VALUES (2,6);
INSERT INTO Permisos VALUES (2,7);
INSERT INTO Permisos VALUES (2,8);
INSERT INTO Permisos VALUES (2,9);
INSERT INTO Permisos VALUES (2,10);
INSERT INTO Permisos VALUES (2,11);
INSERT INTO Permisos VALUES (2,12);
INSERT INTO Permisos VALUES (2,13);
INSERT INTO Permisos VALUES (2,14);
INSERT INTO Permisos VALUES (2,15);
INSERT INTO Permisos VALUES (2,16);
INSERT INTO Permisos VALUES (2,17);
INSERT INTO Permisos VALUES (2,18);
INSERT INTO Permisos VALUES (2,19);	
INSERT INTO Permisos VALUES (2,20);
INSERT INTO Permisos VALUES (2,21);
INSERT INTO Permisos VALUES (2,22);
INSERT INTO Permisos VALUES (2,23);
INSERT INTO Permisos VALUES (2,24);
INSERT INTO Permisos VALUES (2,25);
INSERT INTO Permisos VALUES (2,26);
INSERT INTO Permisos VALUES (2,27);
INSERT INTO Permisos VALUES (2,28);
INSERT INTO Permisos VALUES (2,29);
INSERT INTO Permisos VALUES (2,30);
INSERT INTO Permisos VALUES (2,31);
INSERT INTO Permisos VALUES (2,32);
INSERT INTO Permisos VALUES (2,33);
INSERT INTO Permisos VALUES (2,34);
INSERT INTO Permisos VALUES (2,35);
INSERT INTO Permisos VALUES (2,36);
INSERT INTO Permisos VALUES (2,37);
INSERT INTO Permisos VALUES (2,38);
INSERT INTO Permisos VALUES (2,39);
INSERT INTO Permisos VALUES (2,40);
INSERT INTO Permisos VALUES (2,41);
INSERT INTO Permisos VALUES (2,42);
INSERT INTO Permisos VALUES (2,43);
INSERT INTO Permisos VALUES (2,44);
INSERT INTO Permisos VALUES (2,45);
INSERT INTO Permisos VALUES (2,46);
INSERT INTO Permisos VALUES (2,47);
INSERT INTO Permisos VALUES (2,48);
INSERT INTO Permisos VALUES (2,49);
INSERT INTO Permisos VALUES (2,50);
INSERT INTO Permisos VALUES (2,51);
INSERT INTO Permisos VALUES (2,52);
INSERT INTO Permisos VALUES (2,53);
INSERT INTO Permisos VALUES (2,54);
INSERT INTO Permisos VALUES (2,55);
INSERT INTO Permisos VALUES (2,56);
INSERT INTO Permisos VALUES (2,57);
INSERT INTO Permisos VALUES (2,58);
INSERT INTO Permisos VALUES (2,59);
INSERT INTO Permisos VALUES (2,60);
INSERT INTO Permisos VALUES (2,61);
INSERT INTO Permisos VALUES (2,62);
INSERT INTO Permisos VALUES (2,63);
INSERT INTO Permisos VALUES (2,64);
INSERT INTO Permisos VALUES (2,65);
INSERT INTO Permisos VALUES (2,66);
INSERT INTO Permisos VALUES (2,67);
INSERT INTO Permisos VALUES (2,68);
INSERT INTO Permisos VALUES (2,69);
INSERT INTO Permisos VALUES (2,70);



INSERT INTO PuestoCajas VALUES (1, 'Caja 1');
INSERT INTO PuestoCajas VALUES (2, 'Caja 2');

INSERT INTO CategoriasProveedor VALUES (1,'Sin retencion',0.00,0.00,0,0);
INSERT INTO CategoriasProveedor VALUES (2,'Alquileres o arrendamientos de bienes muebles',1200.00,6.00,0,0);
INSERT INTO CategoriasProveedor VALUES (3,'Enajenaci�n de bienes muebles y bienes de cambio',12000.00,2.00,0,0);
INSERT INTO CategoriasProveedor VALUES (4,'Fletes',1200.00,0.00,0,1);

INSERT INTO TipoInscripcion VALUES (1,'Resp. Inscripto', 'RI')
INSERT INTO TipoInscripcion VALUES (2,'Resp. No Inscripto', 'NI')
INSERT INTO TipoInscripcion VALUES (3,'Consumidor Final', 'CF')
INSERT INTO TipoInscripcion VALUES (4,'Excento', 'EX')
INSERT INTO TipoInscripcion VALUES (5,'No Responsable', 'NR')
INSERT INTO TipoInscripcion VALUES (6,'Monotributista', 'MON')

INSERT INTO Canales VALUES (1, 'Consignaci�n')
INSERT INTO Canales VALUES (2, 'Compra Directa')

INSERT INTO TipoRemitoProveedor VALUES (1,'Remito (Alta)', 'AL');
--INSERT INTO TipoRemitoProveedor VALUES (2,'Remito (Baja)', 'BA');


INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
VALUES (0,'Ninguno','',1,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
VALUES (1,'Remitos de Clientes','R',1,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado)  --Poner Punto de Venta Electronico
VALUES (2,'Facturas Electronicas "A"','A',2,1,1)
INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado)  --Poner Punto de Venta Electronico
VALUES (3,'Facturas Electronicas "B"','B',2,1,1)

	INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
	VALUES (4,'Remitos de Sucursales','R',1,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) --Poner de Acuerdo a Factureros
VALUES (5,'Facturas Manuales "A"','A',1,1,1)
INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) --Poner de Acuerdo a Factureros
VALUES (6,'Facturas Manuales "B"','B',1,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
VALUES (7,'Recibos de Proveedores','R',1,1,1)
INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
VALUES (8,'Contra Recibos de Proveedores','R',1,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado)  --Poner Punto de Venta Electronico
VALUES (9,'Notas de Cr�dito "A"','A',2,1,1)
INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado)  --Poner Punto de Venta Electronico
VALUES (10,'Notas de Cr�dito "B"','B',2,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado)  --Poner Punto de Venta Electronico
VALUES (11,'Notas de D�bito "A"','A',2,1,1)
INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado)  --Poner Punto de Venta Electronico
VALUES (12,'Notas de D�bito "B"','B',2,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) -- Punto de Venta de Liquidaciones de Priveedores y Numerador
VALUES (13,'Liquidaci�n "A"','A',1,1,1)
INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) -- Punto de Venta de Liquidaciones de Proveedores y Numerador
VALUES (14,'Liquidaci�n "B"','B',1,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
VALUES (15,'Recibos de Clientes','R',1,1,1)
INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
VALUES (16,'Contra Recibos de Clientes','R',1,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
VALUES (17,'Saldo Inicial de Clientes','S',1,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
VALUES (18,'Saldo Inicial de Proveedores','S',1,1,1)

INSERT INTO Numeradores (Codigo, Descripcion, Letra, PuntoVenta, Numero, Estado) 
VALUES (19,'Mermas','M',1,1,1)

DECLARE @SUC AS INT
SELECT @SUC=Codigo
FROM Empresa

INSERT INTO CuentasContables VALUES ('100000000', 'ACTIVO', 'D', 1,0,0,0,0);
INSERT INTO CuentasContables VALUES ('101000000', 'ACTIVO CORRIENTE', 'D', 1,1,0,0,0);
INSERT INTO CuentasContables VALUES ('101010000', 'DISPONIBILIDADES', 'D', 1,1,1,0,0);

INSERT INTO CuentasContables VALUES ('101010100', 'CAJA', 'D', 1,1,1,1,0);	--Ingresos en efectivo
--IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
--BEGIN
INSERT INTO CuentasContables VALUES ('101010101', 'Caja Moneda Local', 'D', 1,1,1,1,1);
INSERT INTO CuentasContables VALUES ('101010102', 'Caja Moneda Extranjera', 'D', 1,1,1,1,2);
/*INSERT INTO CuentasContables VALUES ('1110102', 'Caja Nave 7', 'D', 1,1,1,1,2);
INSERT INTO CuentasContables VALUES ('1110103', 'Caja Villa Maria', 'D', 1,1,1,1,3);
INSERT INTO CuentasContables VALUES ('1110104', 'Caja Rio CUarto', 'D', 1,1,1,1,4);
INSERT INTO CuentasContables VALUES ('1110105', 'Caja Sucursal 6', 'D', 1,1,1,1,5);*/
--END
INSERT INTO CuentasContables VALUES ('101010200', 'VALORES A DEPOSITAR', 'D', 1,1,1,2,0);	--Ingresos en cheques
IF @SUC=2 OR @SUC=6
BEGIN
INSERT INTO CuentasContables VALUES ('101010201', 'Valores a Depositar', 'D', 1,1,1,2,1);
END
IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
BEGIN
INSERT INTO CuentasContables VALUES ('101010201', 'Valores a Depositar Central', 'D', 1,1,1,2,1);
INSERT INTO CuentasContables VALUES ('101010202', 'Valores a Depositar Nave 7', 'D', 1,1,1,2,2);
INSERT INTO CuentasContables VALUES ('101010203', 'Valores a Depositar Villa Maria', 'D', 1,1,1,2,3);
INSERT INTO CuentasContables VALUES ('101010204', 'Valores a Depositar Rio Cuarto', 'D', 1,1,1,2,4);
INSERT INTO CuentasContables VALUES ('101010205', 'Valores a Depositar Sucursal 6', 'D', 1,1,1,2,5);
END
INSERT INTO CuentasContables VALUES ('101010300', 'BANCO', 'D', 1,1,1,3,0);		
INSERT INTO CuentasContables VALUES ('101010301', 'Banco Santander Rio', 'D', 1,1,1,3,1);
INSERT INTO CuentasContables VALUES ('101010302', 'Banco Macro', 'D', 1,1,1,3,2);

INSERT INTO CuentasContables VALUES ('101020000', 'CREDITOS POR VENTAS', 'D', 1,1,2,0,0);	--Ingreso en cta cte
/*IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
	BEGIN
		INSERT INTO CuentasContables VALUES ('101020100', 'DEUDORES POR VENTA', 'D', 1,1,2,1,0);
	END
IF @SUC=2 OR @SUC=6
BEGIN*/
	INSERT INTO CuentasContables VALUES ('101020100', 'Deudores por Ventas', 'D', 1,1,2,1,0);
--END
/*IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
	BEGIN
		INSERT INTO CuentasContables VALUES ('101020101', 'Deudores por Ventas Central', 'D', 1,1,2,1,1);
		INSERT INTO CuentasContables VALUES ('101020102', 'Deudores por Ventas Nave 7', 'D', 1,1,2,1,2);
		INSERT INTO CuentasContables VALUES ('101020103', 'Deudores por Ventas Villa Maria', 'D', 1,1,2,1,3);
		INSERT INTO CuentasContables VALUES ('101020104', 'Deudores por Ventas Rio CUarto', 'D', 1,1,2,1,4);
		INSERT INTO CuentasContables VALUES ('101020105', 'Deudores por Ventas Sucursal 6', 'D', 1,1,2,1,5);
	END
	*/
INSERT INTO CuentasContables VALUES ('101040000', 'BIENES DE CAMBIO', 'D', 1,1,4,0,0);
INSERT INTO CuentasContables VALUES ('101040100', 'Mercaderia de Reventa', 'D', 1,1,4,1,0);

INSERT INTO CuentasContables VALUES ('101050000', 'OTROS CREDITOS', 'D', 1,1,5,0,0);
INSERT INTO CuentasContables VALUES ('101050100', 'AFIP - IVA Credito Fiscal', 'D', 1,1,5,1,0);
INSERT INTO CuentasContables VALUES ('101050200', 'AFIP - IVA Retenciones y Percepciones', 'D', 1,1,5,2,0);
INSERT INTO CuentasContables VALUES ('101050300', 'DGR - Retenc. y Perc. de IIBB', 'D', 1,1,5,3,0);
/*INSERT INTO CuentasContables VALUES ('1130100', 'AFIP - Antic. Imp Gcias', 'D', 1,1,3,1,0);

INSERT INTO CuentasContables VALUES ('1130300', 'AFIP - IVA Saldo a Favor', 'D', 1,1,3,3,0);
INSERT INTO CuentasContables VALUES ('1130400', 'AFIP - Imp. s/Creditos Brios 34%', 'D', 1,1,3,4,0);
INSERT INTO CuentasContables VALUES ('1130500', 'AFIP - Retenciones de Gcias.', 'D', 1,1,3,5,0);
INSERT INTO CuentasContables VALUES ('1130700', 'ANSES - Asignaciones no Comp.', 'D', 1,1,3,7,0);
INSERT INTO CuentasContables VALUES ('1130900', 'Derecho Consecion Puesto', 'D', 1,1,3,9,0);
INSERT INTO CuentasContables VALUES ('1131000', 'AA Derecho Consecion Puesto', 'D', 1,1,3,10,0);
*/


INSERT INTO CuentasContables VALUES ('102000000', 'ACTIVO NO CORRIENTE', 'D', 1,2,0,0,0);
INSERT INTO CuentasContables VALUES ('102010000', 'BIENES DE USO', 'D', 1,2,1,0,0);
INSERT INTO CuentasContables VALUES ('102010100', 'Muebles y Utiles - Valor de Origen', 'D', 1,2,1,1,0);
INSERT INTO CuentasContables VALUES ('102010200', 'Muebles y Utiles - Depreciaci�n Acumulada', 'D', 1,2,1,2,0);
INSERT INTO CuentasContables VALUES ('102010300', 'Instalaciones - Valor de Origen', 'D', 1,2,1,3,0);
INSERT INTO CuentasContables VALUES ('102010400', 'Instalaciones - Depreciaci�n Acumulada', 'D', 1,2,1,4,0);
INSERT INTO CuentasContables VALUES ('102010500', 'Rodados - Valor de Origen', 'D', 1,2,1,5,0);
INSERT INTO CuentasContables VALUES ('102010600', 'Rodados - Depreciaci�n Acumulada', 'D', 1,2,1,6,0);
INSERT INTO CuentasContables VALUES ('102010700', 'Inmuebles - Valor de Origen', 'D', 1,2,1,7,0);
INSERT INTO CuentasContables VALUES ('102010800', 'Inmuebles - Depreciaci�n Acumulada', 'D', 1,2,1,8,0);
INSERT INTO CuentasContables VALUES ('102010900', 'Maquinaria - Valor de Origen', 'D', 1,2,1,9,0);
INSERT INTO CuentasContables VALUES ('102011000', 'Maquinaria - Depreciaci�n Acumulada', 'D', 1,2,1,10,0);
INSERT INTO CuentasContables VALUES ('102011100', 'Camara - Valor de Origen', 'D', 1,2,1,11,0);
INSERT INTO CuentasContables VALUES ('102011200', 'Camara - Depreciaci�n Acumulada', 'D', 1,2,1,12,0);
INSERT INTO CuentasContables VALUES ('102011300', 'Sist. Informatico - Valor de Origen', 'D', 1,2,1,13,0);
INSERT INTO CuentasContables VALUES ('102011400', 'Sist. Informatico - Depreciaci�n Acumulada', 'D', 1,2,1,14,0);
INSERT INTO CuentasContables VALUES ('102011500', 'Valor Llave - Valor de Origen', 'D', 1,2,1,15,0);
INSERT INTO CuentasContables VALUES ('102011600', 'Valor Llave - Depreciaci�n Acumulada', 'D', 1,2,1,16,0);
INSERT INTO CuentasContables VALUES ('102011700', 'Gtos de Org y Preop - Valor de Origen', 'D', 1,2,1,17,0);
INSERT INTO CuentasContables VALUES ('102011800', 'Gtos de Org y Preop - Depreciaci�n Acumulada', 'D', 1,2,1,18,0);

  --PASIVO
INSERT INTO CuentasContables VALUES ('200000000', 'PASIVO', 'A', 2,0,0,0,0);
INSERT INTO CuentasContables VALUES ('201000000', 'PASIVO CORRIENTE', 'A', 2,1,0,0,0);
INSERT INTO CuentasContables VALUES ('201010000', 'DEUDAS COMERCIALES', 'A', 2,1,1,0,0);
INSERT INTO CuentasContables VALUES ('201010100', 'Proveedores', 'A', 2,1,1,1,0);
INSERT INTO CuentasContables VALUES ('201010200', 'Liquidaciones a Pagar', 'A', 2,1,1,2,0);

/*INSERT INTO CuentasContables VALUES ('2110100', 'Alquileres por Pagar', 'A', 2,1,1,1,0);

INSERT INTO CuentasContables VALUES ('2110300', 'Valores Girados a Pagar', 'A', 2,1,1,3,0);
INSERT INTO CuentasContables VALUES ('2110400', 'Productores en Consignacion', 'A', 2,1,1,4,0);
INSERT INTO CuentasContables VALUES ('2120000', 'REMUNERACIONES Y CARGA SOCIAL', 'A', 2,1,2,0,0);
INSERT INTO CuentasContables VALUES ('2120100', 'Sueldos a Pagar', 'A', 2,1,2,1,0);
INSERT INTO CuentasContables VALUES ('2120200', 'Anses a Pagar', 'A', 2,1,2,2,0);
INSERT INTO CuentasContables VALUES ('2120300', 'Sindicato a Pagar', 'A', 2,1,2,3,0);*/
INSERT INTO CuentasContables VALUES ('201020000', 'DEUDAS FISCALES', 'A', 2,1,2,0,0);
/*INSERT INTO CuentasContables VALUES ('2130100', 'AFIP - Imp. a las Ganancias a Pagar', 'A', 2,1,3,1,0);*/
/*IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
	BEGIN
		INSERT INTO CuentasContables VALUES ('201020100', 'AFIP - IVA DEBITO FISCAL', 'A', 2,1,2,1,0);
	END
IF @SUC=2 OR @SUC=6
	BEGIN*/
		INSERT INTO CuentasContables VALUES ('201020100', 'AFIP - IVA D�bito Fiscal', 'A', 2,1,2,1,0);
/*	END
IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
BEGIN
	INSERT INTO CuentasContables VALUES ('201020101', 'AFIP - IVA D�bito Fiscal Central', 'A', 2,1,2,1,1);
	INSERT INTO CuentasContables VALUES ('201020102', 'AFIP - IVA D�bito Fiscal Nave 7', 'A', 2,1,2,1,2);
	INSERT INTO CuentasContables VALUES ('201020103', 'AFIP - IVA D�bito Fiscal Villa Maria', 'A', 2,1,2,1,3);
	INSERT INTO CuentasContables VALUES ('201020104', 'AFIP - IVA D�bito Fiscal Rio CUarto', 'A', 2,1,2,1,4);
	INSERT INTO CuentasContables VALUES ('201020105', 'AFIP - IVA D�bito Fiscal Sucursal 6', 'A', 2,1,2,1,5);
END*/

INSERT INTO CuentasContables VALUES ('201020200', 'AFIP - IVA Retenciones y Percepciones', 'A', 2,1,2,2,0);
INSERT INTO CuentasContables VALUES ('201020300', 'DGR - Retenc. y Perc. de IIBB', 'A', 2,1,2,3,0);
/*
INSERT INTO CuentasContables VALUES ('2130400', 'AFIP - Participacion Soc. a Pagar', 'A', 2,1,3,4,0);
INSERT INTO CuentasContables VALUES ('2130500', 'AFIP - IVA a Pagar', 'A', 2,1,3,5,0);
INSERT INTO CuentasContables VALUES ('2130600', 'Concesion Mercado a Pagar', 'A', 2,1,3,6,0);
INSERT INTO CuentasContables VALUES ('2130700', 'AFIP - Retenciones a Pagar', 'A', 2,1,3,7,0);
INSERT INTO CuentasContables VALUES ('2130800', 'Otros Impuestos a Pagar', 'A', 2,1,3,8,0);
INSERT INTO CuentasContables VALUES ('2130900', 'DGR - Ing. Brutos a Pagar', 'A', 2,1,3,9,0);
INSERT INTO CuentasContables VALUES ('2131000', 'Imp. Munic. a Pagar', 'A', 2,1,3,10,0);
INSERT INTO CuentasContables VALUES ('2131100', 'Plan de Pago B749687', 'A', 2,1,3,11,0);
INSERT INTO CuentasContables VALUES ('2131200', 'Plan de Pago B749905', 'A', 2,1,3,12,0);
INSERT INTO CuentasContables VALUES ('2131300', 'Plan de Pago Obra Social', 'A', 2,1,3,13,0);
INSERT INTO CuentasContables VALUES ('2140000', 'CUENTAS PARTICULARES', 'A', 2,1,4,0,0);
INSERT INTO CuentasContables VALUES ('2140100', 'Socio', 'A', 2,1,4,1,0);


  --PATRIMONIO NETO

INSERT INTO CuentasContables VALUES ('3000000', 'PATRIMONIO NETO', 'A', 3,0,0,0,0);
INSERT INTO CuentasContables VALUES ('3100000', 'PATRIMONIO', 'A', 3,1,0,0,0);
INSERT INTO CuentasContables VALUES ('3110000', 'CAPITAL', 'A', 3,1,1,0,0);
INSERT INTO CuentasContables VALUES ('3110100', 'Capital Social', 'A', 3,1,1,1,0);
INSERT INTO CuentasContables VALUES ('3110200', 'Ajuste de Capital', 'A', 3,1,1,2,0);
INSERT INTO CuentasContables VALUES ('3120000', 'GANANCIAS RESERVADAS', 'A', 3,1,2,0,0);
INSERT INTO CuentasContables VALUES ('3120100', 'Reserva Legal', 'A', 3,1,2,1,0);
INSERT INTO CuentasContables VALUES ('3130000', 'RESULTADOS', 'A', 3,1,3,0,0);
INSERT INTO CuentasContables VALUES ('3130100', 'Resultados No Asignados', 'A', 3,1,3,1,0);
INSERT INTO CuentasContables VALUES ('3130200', 'Resultados del Ejercicio', 'A', 3,1,3,2,0);
INSERT INTO CuentasContables VALUES ('3140000', 'AJUSTES AL PATRIMONIO', 'A', 3,1,4,0,0);
INSERT INTO CuentasContables VALUES ('3140100', 'Revaluo Tecnico', 'A', 3,1,4,1,0);

*/
  --INGRESOS

INSERT INTO CuentasContables VALUES ('400000000', 'INGRESOS', 'A', 4,0,0,0,0);
INSERT INTO CuentasContables VALUES ('401000000', 'RESULTADOS POSITIVOS', 'A', 4,1,0,0,0);
INSERT INTO CuentasContables VALUES ('401010000', 'INGRESOS POR COMERCIALIZACION', 'A', 4,1,1,0,0);
IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
BEGIN
	INSERT INTO CuentasContables VALUES ('401010100', 'VENTAS', 'A', 4,1,1,1,0);
END
IF @SUC=2 OR @SUC=6
BEGIN
	INSERT INTO CuentasContables VALUES ('401010100', 'Ventas', 'A', 4,1,1,1,0);
END
IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
BEGIN
	INSERT INTO CuentasContables VALUES ('401010101', 'Ventas Central', 'A', 4,1,1,1,1);
	INSERT INTO CuentasContables VALUES ('401010102', 'Ventas Nave 7', 'A', 4,1,1,1,2);
	INSERT INTO CuentasContables VALUES ('401010103', 'Ventas Villa Maria', 'A',4,1,1,1,3);
	INSERT INTO CuentasContables VALUES ('401010104', 'Ventas Rio Cuarto', 'A', 4,1,1,1,4);
	INSERT INTO CuentasContables VALUES ('401010105', 'Ventas Sucursal 6', 'A', 4,1,1,1,5);
END

IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
BEGIN
	INSERT INTO CuentasContables VALUES ('401010200', 'DEVOLUCION DE MERCADDERIA', 'A', 4,1,1,2,0);
END
IF @SUC=2 OR @SUC=6
BEGIN
	INSERT INTO CuentasContables VALUES ('401010200', 'Devoluci�n de Mercaderia', 'A', 4,1,1,2,0);
END
IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
BEGIN
	INSERT INTO CuentasContables VALUES ('401010201', 'Devoluci�n de Mercaderia Central', 'A', 4,1,1,2,1);
	INSERT INTO CuentasContables VALUES ('401010202', 'Devoluci�n de Mercaderia Nave 7', 'A', 4,1,1,2,2);
	INSERT INTO CuentasContables VALUES ('401010203', 'Devoluci�n de Mercaderia Villa Maria', 'A',4,1,1,2,3);
	INSERT INTO CuentasContables VALUES ('401010204', 'Devoluci�n de Mercaderia Rio Cuarto', 'A', 4,1,1,2,4);
	INSERT INTO CuentasContables VALUES ('401010205', 'Devoluci�n de Mercaderia Sucursal 6', 'A', 4,1,1,2,5);
END

IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
BEGIN
	INSERT INTO CuentasContables VALUES ('401010300', 'AJUSTE DE PRECIO', 'A', 4,1,1,3,0);
END
IF @SUC=2 OR @SUC=6
BEGIN
	INSERT INTO CuentasContables VALUES ('401010300', 'Ajuste de Precio', 'A', 4,1,1,3,0);
END
IF @SUC=1 OR @SUC=3 OR @SUC=4 OR @SUC=5 OR @SUC=7
BEGIN
	INSERT INTO CuentasContables VALUES ('401010301', 'Ajuste de Precio Central', 'A', 4,1,1,3,1);
	INSERT INTO CuentasContables VALUES ('401010302', 'Ajuste de Precio Nave 7', 'A', 4,1,1,3,2);
	INSERT INTO CuentasContables VALUES ('401010303', 'Ajuste de Precio Villa Maria', 'A',4,1,1,3,3);
	INSERT INTO CuentasContables VALUES ('401010304', 'Ajuste de Precio Rio Cuarto', 'A', 4,1,1,3,4);
	INSERT INTO CuentasContables VALUES ('401010305', 'Ajuste de Precio Sucursal 6', 'A', 4,1,1,3,5);
END

INSERT INTO CuentasContables VALUES ('401020000', 'OTROS INGRESOS','A',4,1,2,0,0);
--INSERT INTO CuentasContables VALUES ('401010400', 'OTROS INGRESOS','A',4,1,1,4,0);
--INSERT INTO CuentasContables VALUES ('401020100', 'Redondeo','A',4,1,2,1,0);
--INSERT INTO CuentasContables VALUES ('401010401', 'Redondeo','A',4,1,1,4,1);
INSERT INTO CuentasContables VALUES ('401020100', 'Comisiones', 'A', 4,1,2,1,0);
--INSERT INTO CuentasContables VALUES ('401010402', 'Comisiones', 'A', 4,1,1,4,2);



  --EGRESOS

INSERT INTO CuentasContables VALUES ('500000000', 'EGRESOS', 'D', 5,0,0,0,0);
INSERT INTO CuentasContables VALUES ('501000000', 'RESULTADOS NEGATIVOS', 'D', 5,1,0,0,0);
/*

INSERT INTO CuentasContables VALUES ('5110600', 'Gastos de Produccion', 'D', 5,1,1,6,0);*/
INSERT INTO CuentasContables VALUES ('501010000', 'COMPRAS', 'D', 5,1,1,0,0);
INSERT INTO CuentasContables VALUES ('501010100', 'Compra Mercad. de Reventa', 'D', 5,1,1,1,0);
INSERT INTO CuentasContables VALUES ('501010200', 'Liquido Producto', 'D', 5,1,1,2,0);
--INSERT INTO CuentasContables VALUES ('501010300', 'Variaci�n de Stock', 'D', 5,1,1,3,0);

INSERT INTO CuentasContables VALUES ('501020000', 'GASTOS', 'D', 5,1,2,0,0);
INSERT INTO CuentasContables VALUES ('501020100', 'Fletes', 'D', 5,1,2,1,0);
INSERT INTO CuentasContables VALUES ('501020200', 'Sueldos y Jornales', 'D', 5,1,2,2,0);
INSERT INTO CuentasContables VALUES ('501020300', 'Cargas Sociales', 'D', 5,1,2,3,0);
INSERT INTO CuentasContables VALUES ('501020400', 'Sindicato', 'D', 5,1,2,4,0);
INSERT INTO CuentasContables VALUES ('501020500', 'Contribuciones ART', 'D', 5,1,2,5,0);
INSERT INTO CuentasContables VALUES ('501020600', 'Mantenimiento', 'D', 5,1,2,6,0);
INSERT INTO CuentasContables VALUES ('501020700', 'Telefono', 'D', 5,1,2,7,0);
INSERT INTO CuentasContables VALUES ('501020800', 'Electricidad', 'D', 5,1,2,8,0);
INSERT INTO CuentasContables VALUES ('501020900', 'Honorarios Pagados', 'D', 5,1,2,9,0);
INSERT INTO CuentasContables VALUES ('501021000', 'Imprenta', 'D', 5,1,2,10,0);
INSERT INTO CuentasContables VALUES ('501021100', 'Libreria', 'D', 5,1,2,11,0);
INSERT INTO CuentasContables VALUES ('501021200', 'Alquiler Camara', 'D', 5,1,2,12,0);
INSERT INTO CuentasContables VALUES ('501021300', 'Seguridad', 'D', 5,1,2,13,0);
INSERT INTO CuentasContables VALUES ('501021400', 'Internet', 'D', 5,1,2,14,0);
INSERT INTO CuentasContables VALUES ('501021500', 'Publicidad', 'D', 5,1,2,15,0);
INSERT INTO CuentasContables VALUES ('501021600', 'Combustible', 'D', 5,1,2,16,0);
INSERT INTO CuentasContables VALUES ('501021700', 'Climatizaci�n', 'D', 5,1,2,17,0);
INSERT INTO CuentasContables VALUES ('501021800', 'Ropa de Trabajo', 'D', 5,1,2,18,0);
INSERT INTO CuentasContables VALUES ('501021900', 'Capacitaci�n', 'D', 5,1,2,19,0);
INSERT INTO CuentasContables VALUES ('501022000', 'Servicios Mercado de Abasto', 'D', 5,1,2,20,0);
INSERT INTO CuentasContables VALUES ('501022100', 'Alquileres', 'D', 5,1,2,21,0);
INSERT INTO CuentasContables VALUES ('501022200', 'Seguros Pagados', 'D', 5,1,2,22,0);
/*
INSERT INTO CuentasContables VALUES ('5120100', 'Amort. Ejercicio', 'D', 5,1,2,1,0);
INSERT INTO CuentasContables VALUES ('5120300', 'Imp. Tasas y Contr.', 'D', 5,1,2,3,0);
INSERT INTO CuentasContables VALUES ('5120400', 'Imp. s/Ing. Brutos', 'D', 5,1,2,4,0);
INSERT INTO CuentasContables VALUES ('5120500', 'Contribucion s/Mercados', 'D', 5,1,2,5,0);
INSERT INTO CuentasContables VALUES ('5120800', 'Seguros Pagados', 'D', 5,1,2,8,0);
INSERT INTO CuentasContables VALUES ('5120900', 'Rec. y Act. Impositivas', 'D', 5,1,2,9,0);
INSERT INTO CuentasContables VALUES ('5121000', 'Gastos Bancarios', 'D', 5,1,2,10,0);
INSERT INTO CuentasContables VALUES ('5121100', 'Int. Comerciales', 'D', 5,1,2,11,0);
INSERT INTO CuentasContables VALUES ('5121200', 'Imp. s/Partic. Sociales', 'D', 5,1,2,13,0);
INSERT INTO CuentasContables VALUES ('5121400', 'Imp s/Debitos', 'D', 5,1,2,14,0);
INSERT INTO CuentasContables VALUES ('5121800', 'Gtos Generales', 'D', 5,1,2,18,0);
INSERT INTO CuentasContables VALUES ('5122100', 'Tasa Com. Industria', 'D', 5,1,2,21,0);
INSERT INTO CuentasContables VALUES ('5122200', 'Impuesto a las Ganancias', 'D', 5,1,2,22,0);
INSERT INTO CuentasContables VALUES ('5122300', 'Int. Bancarios', 'D', 5,1,2,23,0);
INSERT INTO CuentasContables VALUES ('5122400', 'Intereses Finan. y Resarst.', 'D', 5,1,2,24,0);

*/
INSERT INTO TipoRemitoCliente VALUES (1,'Remito (Salida)', 'BA',1);
--INSERT INTO TipoRemitoCliente VALUES (2,'Remito (Ingreso)', 'AL',1);

INSERT INTO Impuestos VALUES (1,'Retenciones IVA',201020200,'C',1)
INSERT INTO Impuestos VALUES (2,'Retenciones IIBB.',201020300,'C',1)

INSERT INTO TipoDoc values ('RM', 'Remitos');
INSERT INTO TipoDoc values ('FA', 'Facturas');
INSERT INTO TipoDoc values ('RC', 'Recibos');
INSERT INTO TipoDoc values ('CR', 'Contra Recibos');
INSERT INTO TipoDoc values ('NC', 'Notas de Cr�dito');
INSERT INTO TipoDoc values ('ND', 'Notas de D�bito');
INSERT INTO TipoDoc values ('LQ', 'Liquidaciones');
INSERT INTO TipoDoc values ('SI', 'Saldo Inicial');

INSERT INTO TiposDocumentosCliente VALUES (1,'Remito', 'RM', 1,'N', 'N', 'N', 'N',0,1)
INSERT INTO TiposDocumentosCliente VALUES (2,'Factura Ctado "A"', 'FA', 2,'N', 'I', 'D', 'P',1,1)
INSERT INTO TiposDocumentosCliente VALUES (3,'Factura Cta Cte "A"', 'FA', 2,'D', 'N', 'D', 'P',1,1)
INSERT INTO TiposDocumentosCliente VALUES (4,'Factura Ctado "B"', 'FA', 3,'N', 'I', 'D', 'L',1,1)
INSERT INTO TiposDocumentosCliente VALUES (5,'Factura Cta Cte "B"', 'FA', 3,'D', 'N', 'D', 'L',1,1)
INSERT INTO TiposDocumentosCliente VALUES (6,'Remito Sucursal', 'RM', 4,'N', 'N', 'N', 'N',0,1)
INSERT INTO TiposDocumentosCliente VALUES (7,'Factura Ctado "A" Manual', 'FA', 5,'N', 'I', 'D', 'P',0,1)
INSERT INTO TiposDocumentosCliente VALUES (8,'Factura Cta Cte "A" Manual', 'FA', 5,'D', 'N', 'D', 'P',0,1)
INSERT INTO TiposDocumentosCliente VALUES (9,'Factura Ctado "B" Manual', 'FA', 6,'N', 'I', 'D', 'L',0,1)
INSERT INTO TiposDocumentosCliente VALUES (10,'Factura Cta Cte "B" Manual', 'FA', 6,'D', 'N', 'D', 'L',0,1)
INSERT INTO TiposDocumentosCliente VALUES (11,'Nota de Cr�dito Ctado "A"', 'NC', 9,'N', 'E', 'C', 'P',1,1)
INSERT INTO TiposDocumentosCliente VALUES (12,'Nota de Cr�dito Cta Cte "A"', 'NC', 9,'C', 'N', 'C', 'P',1,1)
INSERT INTO TiposDocumentosCliente VALUES (13,'Nota de Cr�dito Ctado "B"', 'NC', 10,'N', 'E', 'C', 'L',1,1)
INSERT INTO TiposDocumentosCliente VALUES (14,'Nota de Cr�dito Cta Cte "B"', 'NC', 10,'C', 'N', 'C', 'L',1,1)
INSERT INTO TiposDocumentosCliente VALUES (15,'Nota de D�bito Ctado "A"', 'ND', 11,'N', 'I', 'D', 'P',1,1)
INSERT INTO TiposDocumentosCliente VALUES (16,'Nota de D�bito Cta Cte "A"', 'ND', 11,'D', 'N', 'D', 'P',1,1)
INSERT INTO TiposDocumentosCliente VALUES (17,'Nota de D�bito Ctado "B"', 'ND', 12,'N', 'I', 'D', 'L',1,1)
INSERT INTO TiposDocumentosCliente VALUES (18,'Nota de D�bito Cta Cte "B"', 'ND', 12,'D', 'N', 'D', 'L',1,1)
INSERT INTO TiposDocumentosCliente VALUES (19,'Liquidaci�n "A"', 'LQ', 0,'D', 'N', 'D', 'P',0,1)
INSERT INTO TiposDocumentosCliente VALUES (20,'Liquidaci�n "B"', 'LQ', 0,'D', 'N', 'D', 'L',0,1)
INSERT INTO TiposDocumentosCliente VALUES (21,'Recibo', 'RC', 15,'C', 'I', 'N', 'N',0,1)
INSERT INTO TiposDocumentosCliente VALUES (22,'Contra Recibo', 'CR', 16,'D', 'E', 'N', 'N',0,1)
INSERT INTO TiposDocumentosCliente VALUES (23,'Saldo Inicial D�bito', 'SI', 17,'D', 'N', 'N', 'N',0,1)
INSERT INTO TiposDocumentosCliente VALUES (24,'Saldo Inicial Cr�dito', 'SI', 17,'C', 'N', 'N', 'N',0,1)

INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (2,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (3,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (4,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (5,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (7,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (8,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (9,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (10,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (11,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (12,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (13,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (14,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (15,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (16,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (17,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (18,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (19,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (20,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (21,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (21,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (22,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (22,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (23,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (23,6);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (24,1);
INSERT INTO TipoDocumentoCliente_TipoInscripcion VALUES (24,6);

INSERT INTO Monedas VALUES (1, 'Pesos',1,1);
INSERT INTO Monedas VALUES (2, 'Dolares',1,1);

INSERT INTO MonedasCotizaciones VALUES (1,'29/10/2016',1,1);
INSERT INTO MonedasCotizaciones VALUES (2,'29/10/2016',15.4,1);

IF @SUC=1 OR @SUC=2 OR @SUC=6
BEGIN

	INSERT INTO FormasDePago VALUES(1,'CONTADO',101010101,1,1,1,1);
	INSERT INTO FormasDePago VALUES(2,'CUENTA CORRIENTE',101020100,0,1,1,0);
	INSERT INTO FormasDePago VALUES(3,'CHEQUE DE TERCEROS',101010201,1,1,0,1);
END
IF @SUC=3
BEGIN
	INSERT INTO FormasDePago VALUES(1,'CONTADO',101010101,1,1,1,1);
	INSERT INTO FormasDePago VALUES(2,'CUENTA CORRIENTE',101020100,0,1,1,0);
	INSERT INTO FormasDePago VALUES(3,'CHEQUE DE TERCEROS',101010202,1,1,0,1);
END
IF @SUC=4
BEGIN
	INSERT INTO FormasDePago VALUES(1,'CONTADO',101010101,1,1,1,1);
	INSERT INTO FormasDePago VALUES(2,'CUENTA CORRIENTE',101020100,0,1,1,0);
	INSERT INTO FormasDePago VALUES(3,'CHEQUE DE TERCEROS',101010203,1,1,0,1);
END
IF @SUC=5
BEGIN
	INSERT INTO FormasDePago VALUES(1,'CONTADO',101010101,1,1,1,1);
	INSERT INTO FormasDePago VALUES(2,'CUENTA CORRIENTE',101020100,0,1,1,0);
	INSERT INTO FormasDePago VALUES(3,'CHEQUE DE TERCEROS',101010204,1,1,0,1);
END
IF @SUC=7
BEGIN
	INSERT INTO FormasDePago VALUES(1,'CONTADO',101010101,1,1,1,1);
	INSERT INTO FormasDePago VALUES(2,'CUENTA CORRIENTE',101020100,0,1,1,0);
	INSERT INTO FormasDePago VALUES(3,'CHEQUE DE TERCEROS',101010205,1,1,0,1);
END

INSERT INTO FormasDePago VALUES(4,'CUENTA CORRIENTE',201010100,1,0,0,0);
INSERT INTO FormasDePago VALUES(5,'TRANFERENCIA BANCARIA',101010300,1,0,0,1);
INSERT INTO FormasDePago VALUES(6,'CHEQUE PROPIO',101010300,1,0,0,1);

INSERT INTO TiposDeAsientos VALUES (1,'Ventas','Facturas de ventas correspondientes al')
INSERT INTO TiposDeAsientos VALUES (2,'Cobros','')
INSERT INTO TiposDeAsientos VALUES (3,'Notas de Credito','')
INSERT INTO TiposDeAsientos VALUES (4,'Notas de Debito','')

INSERT INTO TiposDocumentosProveedores VALUES (1,'Factura Ctado "A"', 'FA',0, 'N', 'E', 'D', 'P',1)
INSERT INTO TiposDocumentosProveedores VALUES (2,'Factura Cta Cte "A"', 'FA',0, 'D', 'N', 'D', 'P',1)
INSERT INTO TiposDocumentosProveedores VALUES (3,'Factura Ctado "C"', 'FA',0, 'N', 'E', 'N', 'N',1)
INSERT INTO TiposDocumentosProveedores VALUES (4,'Factura Cta Cte "C"', 'FA',0, 'D', 'N', 'N', 'N',1)
--INSERT INTO TiposDocumentosProveedores VALUES (5,'Recibo', 'RC',7, 'D', 'E', 'N', 'N',1)
--INSERT INTO TiposDocumentosProveedores VALUES (6,'Contra Recibo', 'CR',8, 'C', 'I', 'N', 'N',1)
INSERT INTO TiposDocumentosProveedores VALUES (5,'Recibo', 'RC',7, 'C', 'E', 'N', 'N',1)
INSERT INTO TiposDocumentosProveedores VALUES (6,'Contra Recibo', 'CR',8, 'D', 'I', 'N', 'N',1)
INSERT INTO TiposDocumentosProveedores VALUES (7,'Nota de Cr�dito Ctado "A"', 'NC',0, 'N', 'I', 'C', 'P',1)
INSERT INTO TiposDocumentosProveedores VALUES (8,'Nota de Cr�dito Cta Cte "A"', 'NC',0, 'C', 'N', 'C', 'P',1)
INSERT INTO TiposDocumentosProveedores VALUES (9,'Nota de Cr�dito Ctado "C"', 'NC',0, 'N', 'I', 'N', 'N',1)
INSERT INTO TiposDocumentosProveedores VALUES (10,'Nota de Cr�dito Cta Cte "C"', 'NC',0, 'C', 'N', 'N', 'N',1)
INSERT INTO TiposDocumentosProveedores VALUES (11,'Nota de D�bito Ctado "A"', 'ND',0, 'N', 'E', 'D', 'P',1)
INSERT INTO TiposDocumentosProveedores VALUES (12,'Nota de D�bito Cta Cte "A"', 'ND',0, 'D', 'N', 'D', 'P',1)
INSERT INTO TiposDocumentosProveedores VALUES (13,'Nota de D�bito Ctado "C"', 'ND',0, 'N', 'E', 'N', 'N',1)
INSERT INTO TiposDocumentosProveedores VALUES (14,'Nota de D�bito Cta Cte "C"', 'ND',0, 'D', 'N', 'N', 'N',1)
INSERT INTO TiposDocumentosProveedores VALUES (15,'Liquidaci�n "A"', 'LQ',13, 'D', 'N', 'D', 'P',1)
INSERT INTO TiposDocumentosProveedores VALUES (16,'Liquidaci�n "B"', 'LQ',14, 'D', 'N', 'D', 'L',1)
INSERT INTO TiposDocumentosProveedores VALUES (17,'Saldo Inicial D�bito', 'SI', 18,'D', 'N', 'N', 'N',1)
INSERT INTO TiposDocumentosProveedores VALUES (18,'Saldo Inicial Cr�dito', 'SI', 18,'C', 'N', 'N', 'N',1)

INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (1,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (2,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (3,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (4,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (5,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (5,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (6,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (6,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (7,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (8,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (9,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (10,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (11,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (12,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (13,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (14,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (15,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (16,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (17,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (17,6);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (18,1);
INSERT INTO TipoDocumentoProveedor_TipoInscripcion VALUES (18,6);




INSERT INTO TiposEstadosValores VALUES ('CA', 'En Cartera');
INSERT INTO TiposEstadosValores VALUES ('DE', 'Depositado');
INSERT INTO TiposEstadosValores VALUES ('FS', 'Fuera de Sistema');
INSERT INTO TiposEstadosValores VALUES ('PR', 'En Proveedor');
INSERT INTO TiposEstadosValores VALUES ('RE', 'Rechazado');

IF @SUC!=6 AND @SUC!=2
BEGIN
	INSERT INTO Sucursales (Codigo, Descripcion, RazonSocial, CUIT,Domicilio,Puesto,Domicilio2,IngresosBrutos,FechaInicioActividad) 
	VALUES (1, 'Deposito','WI�AY S.A.','30-70761233-5','Ruta 19 Km. 7 1/2','Puesto 24','MERCADO DE ABASTO (Cba.)','','');
	INSERT INTO Sucursales VALUES (3, 'Nave 7','','','','','','','');
	INSERT INTO Sucursales VALUES (4, 'Villa Maria','','','','','','','');
	INSERT INTO Sucursales VALUES (5, 'Rio Cuarto','','','','','','','');
	INSERT INTO Sucursales VALUES (7, 'Sucursal 6','','','','','','','');
END

INSERT INTO TiposDeCompras VALUES ('BU', 'Bienes de uso');
INSERT INTO TiposDeCompras VALUES ('BC', 'Bienes de cambio');
INSERT INTO TiposDeCompras VALUES ('G', 'Gastos');

INSERT INTO TiposImputaciones VALUES ('F', 'Falta')
INSERT INTO TiposImputaciones VALUES ('T', 'Total')
INSERT INTO TiposImputaciones VALUES ('P', 'Parcial')


INSERT INTO TiposLiquidaciones VALUES ('F', 'Falta')
INSERT INTO TiposLiquidaciones VALUES ('T', 'Total')
INSERT INTO TiposLiquidaciones VALUES ('P', 'Parcial')

INSERT INTO TipoRemitoSucursal VALUES (1,'Remito (Salida)', 'BA',4);
INSERT INTO TipoRemitoSucursal VALUES (2,'Remito (Alta)', 'AL',4);