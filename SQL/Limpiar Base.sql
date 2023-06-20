USE Frutar

DELETE FROM CajaInicial_Cheques

DELETE FROM CajaInicial_Efectivo

DELETE FROM CajaInicial

DELETE FROM PorcentajesIva

DELETE FROM VentasIniciales_Detalle

DELETE FROM VentasIniciales

DELETE FROM Mermas_D_Productos

DELETE FROM Mermas

DELETE FROM RemitoSucursal_D_Productos

DELETE FROM RemitoSucursal_M

DELETE FROM TipoRemitoSucursal

DELETE FROM CierresDeCaja

DELETE FROM FacturasCompras_SaldoInicial

DELETE FROM Facturas_SaldoInicial

DELETE FROM PagosClientes_Impuestos

DELETE FROM ImputacionesCliente

DELETE FROM PagosClientes_Cheques

DELETE FROM PagosClientes_Efectivo

DELETE FROM PagosClientes
--89
DELETE FROM FacturasCompras_Liquidaciones_Impuestos
--88
DELETE FROM FacturasCompras_Liquidaciones_Mermas
--87
DELETE FROM FacturasCompras_Liquidaciones_Redondeo
--86
DELETE FROM FacturasCompras_Liquidaciones_Comisiones
--85
--85
DELETE FROM Facturas_Liquidaciones_Impuestos
--84
DELETE FROM Facturas_Liquidaciones_Mermas
--83
DELETE FROM RemitoCliente_FacturaLiquidacion
--82
DELETE FROM Facturas_Liquidaciones_Productos
--81
DELETE FROM Facturas_Liquidaciones_Redondeo
--80
DELETE FROM Facturas_Liquidaciones_Comisiones
--79
DELETE FROM AfectacionDevolucionesCompras
--78
DELETE FROM Facturas_Descuentos
--77
delete from AfectacionDevoluciones
--76
DELETE FROM ImputacionesProveedor
--75
DELETE FROM PagosProveedores_Cheques
--74
DELETE FROM PagosProveedores_Efectivo
--73
DELETE FROM PagosProveedores

DELETE FROM MovimientoBancario_FacturaCompra

DELETE FROM MovimientoBancario_PagoProveedor

DELETE FROM Cheques_MovimientoBancarios

DELETE FROM MovimientosBancarios
--72
DELETE FROM TiposMovimientosBancarios
--71
DELETE FROM RemitoProveedor_FacturaCompra
--70
DELETE FROM FacturasCompras_Descuentos
--69
DELETE FROM FacturasCompras_Detalle;
--68
DELETE FROM FacturasCompras_Cheques
--67
DELETE FROM FacturasCompras_Efectivo
--66
DELETE FROM FacturasCompras_Impuestos;
--63
--61
--60
DELETE FROM CuentasBancarias;
--59
DELETE FROM TipoDocumentoProveedor_TipoInscripcion
--57
DELETE FROM Impuestos
--56
DELETE FROM AsientosTemp
--55
DELETE FROM Ejercicios
--54
DELETE FROM TiposDeAsientos
--53
DELETE FROM Asientos_Detalle
--52
DELETE FROM FormasDePago
--51
DELETE FROM Facturas_Cheques
--50
DELETE FROM EstadosValores_Cheques;
--49
DELETE FROM TiposEstadosValores;
--48
DELETE FROM Facturas_Efectivo
--47
DELETE FROM Facturas_Detalle
--46
DELETE FROM Facturas
--65
DELETE FROM FacturasCompras;

DELETE FROM TiposDocumentosProveedores
--64
DELETE FROM TiposImputaciones
--45
DELETE FROM Asientos
--44
DELETE FROM CHEQUES
--43
DELETE FROM BANCOS
--42
DELETE FROM MonedasCotizaciones
--41
DELETE FROM MONEDAS
--40
DELETE FROM RemitoCliente_D_Productos
--39
DELETE FROM RemitoCliente_M
--38
DELETE FROM TipoDocumentoCliente_TipoInscripcion
--37
DELETE FROM TiposDocumentosCliente
--36
DELETE FROM TipoDoc;
--35
DELETE FROM TipoRemitoCliente
--34
DELETE FROM CuentasContables
--33
DELETE FROM Clientes;
--32
DELETE FROM ComunicacionesPorCliente;
--31
DELETE FROM RemitoProveedor_D_Productos
--30
DELETE FROM MovStock_Lotes
---29
DELETE FROM Lotes
--28
DELETE FROM RemitoProveedor_M
--27
DELETE FROM Numeradores
--26
DELETE FROM TipoRemitoProveedor
--25
DELETE FROM Canales;
--24
DELETE FROM ComunicacionesPorProveedor;
--23
DELETE FROM Proveedores;
--22
DELETE FROM TipoInscripcion
--21
DELETE FROM CategoriasProveedor
--20
DELETE FROM Productos
--19
DELETE FROM RubrosProductos
--18
DELETE FROM PuestoCajas
--20-----------------------------
DELETE FROM Permisos;
--19
DELETE FROM Menus;
--18
DELETE FROM GruposMenus;
--17
DELETE FROM Usuarios;
DBCC CHECKIDENT (Usuarios, RESEED,0)
--16
DELETE FROM Egresos;
--15
DELETE FROM ComunicacionesPorEmpleado;
--14
DELETE FROM Empleados;
--13
DELETE FROM Localidades;
--12
DELETE FROM Provincias;
--11
DELETE FROM Puestos;
--10
DELETE FROM ObrasSociales;
--9
DELETE FROM GruposDeUsuarios;
--8
DELETE FROM Comunicaciones;
--7
DELETE FROM Paises;
--6
DELETE FROM Novedades;
--5
DELETE FROM Codigos;
--4
DELETE FROM Empresa;
--3
DELETE FROM Sucursales;
--2
DELETE FROM TiposLiquidaciones
--1
DELETE FROM TiposDeCompras;