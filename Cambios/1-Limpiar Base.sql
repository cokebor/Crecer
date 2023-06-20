USE CRECER
--A
delete from AfectacionDevoluciones

delete from AfectacionDevolucionesCompras

delete from AfectacionDevolucionesVentasIniciales

delete from asientos

delete from Asientos_Ajustes

delete from Asientos_Cheques

delete from Asientos_Detalle

delete from AsientosAgrupados

delete from AsientosAgrupados_Detalle

delete from asientostemp

--B
DELETE FROM BancoRechazos

DELETE FROM BancoRechazos_Cheques

--C
DELETE FROM Caja

DELETE FROM Caja_Cheques

DELETE FROM Caja_ChequesPasados

DELETE FROM Caja_DebitoCredito

DELETE FROM Caja_Devengamientos

DELETE FROM Caja_Efectivo

DELETE FROM Caja_FacturasCompras

DELETE FROM Caja_LibreDisponibilidad

DELETE FROM Caja_PagosClientes

DELETE FROM CajaInicial

DELETE FROM CajaInicial_Cheques

DELETE FROM CajaInicial_Efectivo

DELETE FROM Cajas_Pasadas

DELETE FROM CambiosCheques

deleTE FROM CambiosCheques_ChequesRechazados

delete from CambiosChequesProveedores

delete from CambiosChequesProveedores_Cheques

delete from CambiosChequesProveedores_ChequesRechazados

delete from CambiosChequesProveedores_Efectivo

delete from CambiosChequesProveedores_MovimientosBancarios

DELETE FROM Cheques

delete from Cheques_MovimientoBancarios

delete from CierresDeCaja

delete from Clientes

delete from ComunicacionesPorCliente

delete from ComunicacionesPorEmpleado

delete from ComunicacionesPorProveedor

delete from Conciliaciones

delete from Conciliaciones_Facturas

delete from Conciliaciones_Gastos

delete from Conciliaciones_Impuestos

--D
delete from DebitoCredito_Pasados

delete from DescuentosPorCliente

delete from DevengamientoDetalle

delete from Devengamientos

delete from DevolucionesAProveedor

--E
delete from Egresos

delete from Ejercicios

delete from empleados

delete from EstadosValores_Cheques

--F
DELETE FROM Facturas

DELETE FROM Facturas_Cheques

DELETE FROM Facturas_ChequesRechazados

DELETE FROM Facturas_Descuentos

DELETE FROM Facturas_DescuentosDetalle

DELETE FROM Facturas_DescuentosEspeciales

DELETE FROM Facturas_DescuentosEspecialesDetalle

DELETE FROM Facturas_DescuentosEspecialesDetalleAjustes

DELETE FROM Facturas_Detalle

DELETE FROM Facturas_Detalles

DELETE FROM Facturas_Efectivo

DELETE FROM Facturas_GastosMotivos

DELETE FROM Facturas_Impuestos

DELETE FROM Facturas_Liquidaciones_Comisiones

DELETE FROM Facturas_Liquidaciones_Impuestos

DELETE FROM Facturas_Liquidaciones_Mermas

DELETE FROM Facturas_Liquidaciones_Productos

DELETE FROM Facturas_Liquidaciones_Redondeo

DELETE FROM Facturas_Observaciones

DELETE FROM Facturas_SaldoInicial

DELETE FROM FacturasCompras

DELETE FROM FacturasCompras_Cheques

DELETE FROM FacturasCompras_ChequesRechazados

DELETE FROM FacturasCompras_Descuentos

DELETE FROM FacturasCompras_Detalle

DELETE FROM FacturasCompras_Efectivo

DELETE FROM FacturasCompras_GastosMotivos

DELETE FROM FacturasCompras_Impuestos

DELETE FROM FacturasCompras_Liquidaciones_Comisiones

DELETE FROM FacturasCompras_Liquidaciones_Impuestos

DELETE FROM FacturasCompras_Liquidaciones_Mermas

DELETE FROM FacturasCompras_Liquidaciones_Redondeo

delete from FacturasCompras_Observaciones

DELETE FROM FacturasCompras_SaldoInicial

DELETE FROM FacturasCompras_Ventas

DELETE FROM FacturasViejas

DELETE FROM FacturasViejas_Descuentos

DELETE FROM FacturasViejas_Detalle

DELETE FROM FechaCambioDatosClientes

DELETE FROM FechaCambioDatosProveedores

DELETE FROM FechaInicioPercepcion

DELETE FROM FechaInicioRetencion

DELETE FROM Fondos

DELETE FROM FondosComunes

DELETE FROM FondosComunesRescatados

--I
DELETE FROM ImputacionesCliente

DELETE FROM ImputacionesProveedor

DELETE FROM Inversiones

DELETE FROM InversionesPlazosFijos

--L

DELETE FROM Lotes

DELETE FROM LotesViejos

--M
DELETE FROM Mermas

DELETE FROM Mermas_D_Productos

DELETE FROM MovimientoBancario_Caja

DELETE FROM MovimientoBancario_FacturaCompra

DELETE FROM MovimientoBancario_Inversiones

DELETE FROM MovimientoBancario_PagoCliente

DELETE FROM MovimientoBancario_PagoProveedor

DELETE FROM MovimientosBancarios

DELETE FROM MovimientosBancarios_FondoComun

DELETE FROM MovStock_Lotes

--P
DELETE FROM PagoProveedores_Tranferencias

DELETE FROM PagosClientes

DELETE FROM PagosClientes_Cheques

DELETE FROM PagosClientes_DebitoCredito

DELETE FROM PagosClientes_Efectivo

DELETE FROM PagosClientes_Impuestos

DELETE FROM PagosClientes_Observaciones

DELETE FROM PagosClientes_Tranferencias

DELETE FROM PagosProveedores

DELETE FROM PagosProveedores_Cheques

DELETE FROM PagosProveedores_DebitoCredito

DELETE FROM PagosProveedores_Efectivo

DELETE FROM PagosProveedores_Impuestos

DELETE FROM PagosProveedores_Observaciones

DELETE from Permisos

TRUNCATE TABLE PreciosLotes

DELETE FROM PrestamosBancarios

DELETE FROM PrestamosBancariosPagos

DELETE FROM PrestamosBancariosPagos_Facturas

DELETE FROM PrestamosBancariosTablaAmortizacion

DELETE FROM Productos

DELETE FROM Proveedores where codigo>5

UPDATE Proveedores SET DEUDA=0

delete from PuestoCaja_Usuario

--r

delete from RemitoCliente_D_Productos

delete from RemitoCliente_FacturaLiquidacion

delete from RemitoCliente_M

delete from RemitoProveedor_D_Productos

delete from RemitoProveedor_FacturaCompra

delete from RemitoProveedor_M

delete from RemitoSucursal_D_Productos

delete from RemitoSucursal_M

delete from RubrosProductos

--S

delete FROM SucursalesClientes

delete from TipoDocumentoCliente_TipoInscripcion

delete from TipoDocumentoProveedor_TipoInscripcion

--T
DELETE FROM Tranferencias_Pasadas

--U

DELETE FROM Usuarios where Codigo>1

--V
DELETE FROM VentasIniciales

DELETE FROM VentasIniciales_Detalle



--select * from Numeradores
