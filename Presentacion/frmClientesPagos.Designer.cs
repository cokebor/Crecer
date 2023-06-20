using System;
using System.Windows.Forms;

namespace Presentacion
{
    partial class frmClientesPagos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientesPagos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.tcPagosClientes = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblRecibo = new System.Windows.Forms.Label();
            this.cbRecibos = new System.Windows.Forms.ComboBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.cbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbChequeRechazado = new System.Windows.Forms.CheckBox();
            this.cbTodosLosRecibos = new System.Windows.Forms.CheckBox();
            this.tpFormasDePago = new System.Windows.Forms.TabPage();
            this.ucFormasPagoVentas = new Presentacion.ucFormasPagoVentas();
            this.tpImpuestos = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNroComprobante = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAgente = new System.Windows.Forms.TextBox();
            this.dtFechaRetencion = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtCodigoImpuesto = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.dgvImpuestos = new System.Windows.Forms.DataGridView();
            this.CodigoImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroAgente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpImputacion = new System.Windows.Forms.TabPage();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoDocumentoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imputado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AAplicar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoImputacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.shapeContainer3 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblValores = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblAplicado = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.shapeContainer4 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.lblValorImpuesto = new System.Windows.Forms.Label();
            this.tcPagosClientes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpFormasDePago.SuspendLayout();
            this.tpImpuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).BeginInit();
            this.tpImputacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(472, 12);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 56;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(430, 14);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(40, 13);
            this.Label15.TabIndex = 59;
            this.Label15.Text = "Fecha:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(106, 11);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoCliente.TabIndex = 0;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(141, 14);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Cliente (F2):";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(451, 274);
            this.shapeContainer1.TabIndex = 108;
            this.shapeContainer1.TabStop = false;
            // 
            // tcPagosClientes
            // 
            this.tcPagosClientes.Controls.Add(this.tabPage1);
            this.tcPagosClientes.Controls.Add(this.tpFormasDePago);
            this.tcPagosClientes.Controls.Add(this.tpImpuestos);
            this.tcPagosClientes.Controls.Add(this.tpImputacion);
            this.tcPagosClientes.Location = new System.Drawing.Point(17, 44);
            this.tcPagosClientes.Name = "tcPagosClientes";
            this.tcPagosClientes.SelectedIndex = 0;
            this.tcPagosClientes.Size = new System.Drawing.Size(541, 300);
            this.tcPagosClientes.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblRecibo);
            this.tabPage1.Controls.Add(this.cbRecibos);
            this.tabPage1.Controls.Add(this.txtObservaciones);
            this.tabPage1.Controls.Add(this.cbTipoComprobante);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbChequeRechazado);
            this.tabPage1.Controls.Add(this.cbTodosLosRecibos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(533, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Comprobante";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblRecibo
            // 
            this.lblRecibo.AutoSize = true;
            this.lblRecibo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRecibo.Location = new System.Drawing.Point(22, 80);
            this.lblRecibo.Name = "lblRecibo";
            this.lblRecibo.Size = new System.Drawing.Size(44, 13);
            this.lblRecibo.TabIndex = 415;
            this.lblRecibo.Text = "Recibo:";
            this.lblRecibo.Visible = false;
            // 
            // cbRecibos
            // 
            this.cbRecibos.FormattingEnabled = true;
            this.cbRecibos.Location = new System.Drawing.Point(117, 77);
            this.cbRecibos.Name = "cbRecibos";
            this.cbRecibos.Size = new System.Drawing.Size(131, 21);
            this.cbRecibos.TabIndex = 1;
            this.cbRecibos.Visible = false;
            this.cbRecibos.SelectedIndexChanged += new System.EventHandler(this.cbRecibos_SelectedIndexChanged);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(23, 148);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(484, 75);
            this.txtObservaciones.TabIndex = 2;
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.FormattingEnabled = true;
            this.cbTipoComprobante.Location = new System.Drawing.Point(117, 47);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(131, 21);
            this.cbTipoComprobante.TabIndex = 0;
            this.cbTipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cbTipoComprobante_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 543;
            this.label8.Text = "Observaciones:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 413;
            this.label4.Text = "Tipo Comprobante:";
            // 
            // cbChequeRechazado
            // 
            this.cbChequeRechazado.AutoSize = true;
            this.cbChequeRechazado.Location = new System.Drawing.Point(169, 15);
            this.cbChequeRechazado.Name = "cbChequeRechazado";
            this.cbChequeRechazado.Size = new System.Drawing.Size(121, 17);
            this.cbChequeRechazado.TabIndex = 411;
            this.cbChequeRechazado.Text = "Cheque Rechazado";
            this.cbChequeRechazado.UseVisualStyleBackColor = true;
            this.cbChequeRechazado.Visible = false;
            // 
            // cbTodosLosRecibos
            // 
            this.cbTodosLosRecibos.AutoSize = true;
            this.cbTodosLosRecibos.Location = new System.Drawing.Point(11, 15);
            this.cbTodosLosRecibos.Name = "cbTodosLosRecibos";
            this.cbTodosLosRecibos.Size = new System.Drawing.Size(152, 17);
            this.cbTodosLosRecibos.TabIndex = 410;
            this.cbTodosLosRecibos.Text = "Mostrar Todos los Recibos";
            this.cbTodosLosRecibos.UseVisualStyleBackColor = true;
            this.cbTodosLosRecibos.Visible = false;
            this.cbTodosLosRecibos.CheckedChanged += new System.EventHandler(this.cbTodosLosRecibos_CheckedChanged);
            // 
            // tpFormasDePago
            // 
            this.tpFormasDePago.Controls.Add(this.ucFormasPagoVentas);
            this.tpFormasDePago.Location = new System.Drawing.Point(4, 22);
            this.tpFormasDePago.Name = "tpFormasDePago";
            this.tpFormasDePago.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormasDePago.Size = new System.Drawing.Size(533, 274);
            this.tpFormasDePago.TabIndex = 1;
            this.tpFormasDePago.Text = "Formas de Pago";
            this.tpFormasDePago.UseVisualStyleBackColor = true;
            // 
            // ucFormasPagoVentas
            // 
            this.ucFormasPagoVentas.Cheques = ((System.Collections.Generic.List<Entidades.Cheque>)(resources.GetObject("ucFormasPagoVentas.Cheques")));
            this.ucFormasPagoVentas.ChequesTerceros = ((System.Collections.Generic.List<Entidades.Cheque>)(resources.GetObject("ucFormasPagoVentas.ChequesTerceros")));
          

            // 
            // tpImpuestos
            // 
            this.tpImpuestos.Controls.Add(this.label5);
            this.tpImpuestos.Controls.Add(this.txtNroComprobante);
            this.tpImpuestos.Controls.Add(this.label7);
            this.tpImpuestos.Controls.Add(this.txtAgente);
            this.tpImpuestos.Controls.Add(this.dtFechaRetencion);
            this.tpImpuestos.Controls.Add(this.label9);
            this.tpImpuestos.Controls.Add(this.btnEliminarProducto);
            this.tpImpuestos.Controls.Add(this.btnAgregar);
            this.tpImpuestos.Controls.Add(this.label12);
            this.tpImpuestos.Controls.Add(this.lblImpuesto);
            this.tpImpuestos.Controls.Add(this.txtImporte);
            this.tpImpuestos.Controls.Add(this.txtCodigoImpuesto);
            this.tpImpuestos.Controls.Add(this.Label13);
            this.tpImpuestos.Controls.Add(this.dgvImpuestos);
            this.tpImpuestos.Location = new System.Drawing.Point(4, 22);
            this.tpImpuestos.Name = "tpImpuestos";
            this.tpImpuestos.Padding = new System.Windows.Forms.Padding(3);
            this.tpImpuestos.Size = new System.Drawing.Size(533, 274);
            this.tpImpuestos.TabIndex = 3;
            this.tpImpuestos.Text = "Impuestos";
            this.tpImpuestos.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 420;
            this.label5.Text = "Comp.:";
            // 
            // txtNroComprobante
            // 
            this.txtNroComprobante.Location = new System.Drawing.Point(366, 49);
            this.txtNroComprobante.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroComprobante.Name = "txtNroComprobante";
            this.txtNroComprobante.Size = new System.Drawing.Size(48, 20);
            this.txtNroComprobante.TabIndex = 411;
            this.txtNroComprobante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroComprobante_KeyDown);
            this.txtNroComprobante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroComprobante_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 419;
            this.label7.Text = "Nro. Agente:";
            // 
            // txtAgente
            // 
            this.txtAgente.Location = new System.Drawing.Point(255, 49);
            this.txtAgente.Margin = new System.Windows.Forms.Padding(2);
            this.txtAgente.Name = "txtAgente";
            this.txtAgente.Size = new System.Drawing.Size(58, 20);
            this.txtAgente.TabIndex = 410;
            this.txtAgente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAgente_KeyDown);
            this.txtAgente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgente_KeyPress);
            // 
            // dtFechaRetencion
            // 
            this.dtFechaRetencion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaRetencion.Location = new System.Drawing.Point(88, 49);
            this.dtFechaRetencion.Name = "dtFechaRetencion";
            this.dtFechaRetencion.Size = new System.Drawing.Size(86, 20);
            this.dtFechaRetencion.TabIndex = 409;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 418;
            this.label9.Text = "Fecha Ret.:";
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarProducto.BackgroundImage")));
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(423, 49);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 413;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(423, 13);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 412;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(297, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 417;
            this.label12.Text = "Importe:";
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.AutoSize = true;
            this.lblImpuesto.Location = new System.Drawing.Point(123, 18);
            this.lblImpuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(0, 13);
            this.lblImpuesto.TabIndex = 416;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(347, 15);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(68, 20);
            this.txtImporte.TabIndex = 408;
            this.txtImporte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtImporte_KeyDown);
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // txtCodigoImpuesto
            // 
            this.txtCodigoImpuesto.Location = new System.Drawing.Point(88, 16);
            this.txtCodigoImpuesto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoImpuesto.Name = "txtCodigoImpuesto";
            this.txtCodigoImpuesto.Size = new System.Drawing.Size(30, 20);
            this.txtCodigoImpuesto.TabIndex = 407;
            this.txtCodigoImpuesto.TextChanged += new System.EventHandler(this.txtCodigoImpuesto_TextChanged);
            this.txtCodigoImpuesto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoImpuesto_KeyDown);
            this.txtCodigoImpuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoImpuesto_KeyPress);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(17, 18);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(74, 13);
            this.Label13.TabIndex = 415;
            this.Label13.Text = "Impuesto (F7):";
            // 
            // dgvImpuestos
            // 
            this.dgvImpuestos.AllowUserToAddRows = false;
            this.dgvImpuestos.AllowUserToDeleteRows = false;
            this.dgvImpuestos.AllowUserToResizeRows = false;
            this.dgvImpuestos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvImpuestos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvImpuestos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvImpuestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImpuestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImpuestos.ColumnHeadersVisible = false;
            this.dgvImpuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoImpuesto,
            this.FechaImpuesto,
            this.Impuesto,
            this.Importe,
            this.CuentaContable,
            this.NroAgente,
            this.NroComprobante});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImpuestos.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvImpuestos.EnableHeadersVisualStyles = false;
            this.dgvImpuestos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvImpuestos.Location = new System.Drawing.Point(20, 85);
            this.dgvImpuestos.MultiSelect = false;
            this.dgvImpuestos.Name = "dgvImpuestos";
            this.dgvImpuestos.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImpuestos.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvImpuestos.RowHeadersVisible = false;
            this.dgvImpuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImpuestos.Size = new System.Drawing.Size(322, 97);
            this.dgvImpuestos.TabIndex = 414;
            // 
            // CodigoImpuesto
            // 
            this.CodigoImpuesto.HeaderText = "Codigo";
            this.CodigoImpuesto.Name = "CodigoImpuesto";
            this.CodigoImpuesto.ReadOnly = true;
            this.CodigoImpuesto.Visible = false;
            this.CodigoImpuesto.Width = 25;
            // 
            // FechaImpuesto
            // 
            dataGridViewCellStyle19.Format = "d";
            dataGridViewCellStyle19.NullValue = null;
            this.FechaImpuesto.DefaultCellStyle = dataGridViewCellStyle19;
            this.FechaImpuesto.HeaderText = "Fecha";
            this.FechaImpuesto.Name = "FechaImpuesto";
            this.FechaImpuesto.ReadOnly = true;
            this.FechaImpuesto.Width = 70;
            // 
            // Impuesto
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Impuesto.DefaultCellStyle = dataGridViewCellStyle20;
            this.Impuesto.HeaderText = "Impuesto";
            this.Impuesto.Name = "Impuesto";
            this.Impuesto.ReadOnly = true;
            this.Impuesto.Width = 150;
            // 
            // Importe
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "C2";
            dataGridViewCellStyle21.NullValue = null;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle21;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // CuentaContable
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CuentaContable.DefaultCellStyle = dataGridViewCellStyle22;
            this.CuentaContable.HeaderText = "CuentaContable";
            this.CuentaContable.Name = "CuentaContable";
            this.CuentaContable.ReadOnly = true;
            this.CuentaContable.Visible = false;
            this.CuentaContable.Width = 300;
            // 
            // NroAgente
            // 
            this.NroAgente.HeaderText = "NroAgente";
            this.NroAgente.Name = "NroAgente";
            this.NroAgente.ReadOnly = true;
            this.NroAgente.Visible = false;
            // 
            // NroComprobante
            // 
            this.NroComprobante.HeaderText = "NroComprobante";
            this.NroComprobante.Name = "NroComprobante";
            this.NroComprobante.ReadOnly = true;
            this.NroComprobante.Visible = false;
            // 
            // tpImputacion
            // 
            this.tpImputacion.Controls.Add(this.dgvDatos);
            this.tpImputacion.Location = new System.Drawing.Point(4, 22);
            this.tpImputacion.Name = "tpImputacion";
            this.tpImputacion.Padding = new System.Windows.Forms.Padding(3);
            this.tpImputacion.Size = new System.Drawing.Size(533, 274);
            this.tpImputacion.TabIndex = 2;
            this.tpImputacion.Text = "Imputación";
            this.tpImputacion.UseVisualStyleBackColor = true;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.CausesValidation = false;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.Fecha,
            this.Tipo,
            this.Codigo,
            this.CodigoTipoDocumentoCliente,
            this.Numero,
            this.Total2,
            this.Imputado,
            this.Pendiente,
            this.AAplicar,
            this.CodigoImputacion});
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle33;
            this.dgvDatos.Location = new System.Drawing.Point(0, 3);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dgvDatos.RowTemplate.Height = 20;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(533, 269);
            this.dgvDatos.TabIndex = 14;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            this.dgvDatos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDatos_CurrentCellDirtyStateChanged);
            this.dgvDatos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDatos_EditingControlShowing);
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            // 
            // Seleccionado
            // 
            this.Seleccionado.DataPropertyName = "Seleccionado";
            this.Seleccionado.FalseValue = "False";
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.IndeterminateValue = "";
            this.Seleccionado.Name = "Seleccionado";
            this.Seleccionado.TrueValue = "True";
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle26;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tipo.DefaultCellStyle = dataGridViewCellStyle27;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // CodigoTipoDocumentoCliente
            // 
            this.CodigoTipoDocumentoCliente.DataPropertyName = "CodigoTipoDocumentoCliente";
            this.CodigoTipoDocumentoCliente.HeaderText = "CodigoTipoDocumentoCliente";
            this.CodigoTipoDocumentoCliente.Name = "CodigoTipoDocumentoCliente";
            this.CodigoTipoDocumentoCliente.Visible = false;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle28;
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // Total2
            // 
            this.Total2.DataPropertyName = "Total";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Format = "C2";
            this.Total2.DefaultCellStyle = dataGridViewCellStyle29;
            this.Total2.HeaderText = "Total";
            this.Total2.Name = "Total2";
            // 
            // Imputado
            // 
            this.Imputado.DataPropertyName = "Imputado";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "C2";
            this.Imputado.DefaultCellStyle = dataGridViewCellStyle30;
            this.Imputado.HeaderText = "Imputado";
            this.Imputado.Name = "Imputado";
            // 
            // Pendiente
            // 
            this.Pendiente.DataPropertyName = "Saldo";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle31.Format = "C2";
            this.Pendiente.DefaultCellStyle = dataGridViewCellStyle31;
            this.Pendiente.HeaderText = "Pendiente";
            this.Pendiente.Name = "Pendiente";
            // 
            // AAplicar
            // 
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AAplicar.DefaultCellStyle = dataGridViewCellStyle32;
            this.AAplicar.HeaderText = "A Aplicar";
            this.AAplicar.Name = "AAplicar";
            // 
            // CodigoImputacion
            // 
            this.CodigoImputacion.DataPropertyName = "CodigoImputacion";
            this.CodigoImputacion.HeaderText = "CodigoImputacion";
            this.CodigoImputacion.Name = "CodigoImputacion";
            this.CodigoImputacion.Visible = false;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer1";
            this.shapeContainer2.Size = new System.Drawing.Size(451, 274);
            this.shapeContainer2.TabIndex = 108;
            this.shapeContainer2.TabStop = false;
            // 
            // shapeContainer3
            // 
            this.shapeContainer3.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer3.Name = "shapeContainer1";
            this.shapeContainer3.Size = new System.Drawing.Size(451, 274);
            this.shapeContainer3.TabIndex = 108;
            this.shapeContainer3.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(475, 416);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 545;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(382, 416);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 544;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 352);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 551;
            this.label1.Text = "Valores:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(21, 406);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 549;
            this.label14.Text = "Total:";
            // 
            // lblValores
            // 
            this.lblValores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValores.ForeColor = System.Drawing.Color.Maroon;
            this.lblValores.Location = new System.Drawing.Point(94, 350);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(127, 17);
            this.lblValores.TabIndex = 550;
            this.lblValores.Text = "0.00";
            this.lblValores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(95, 404);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(127, 17);
            this.lblTotal.TabIndex = 548;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAplicado
            // 
            this.lblAplicado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAplicado.ForeColor = System.Drawing.Color.Maroon;
            this.lblAplicado.Location = new System.Drawing.Point(368, 377);
            this.lblAplicado.Name = "lblAplicado";
            this.lblAplicado.Size = new System.Drawing.Size(100, 17);
            this.lblAplicado.TabIndex = 392;
            this.lblAplicado.Text = "0.00";
            this.lblAplicado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDisponible
            // 
            this.lblDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDisponible.ForeColor = System.Drawing.Color.Maroon;
            this.lblDisponible.Location = new System.Drawing.Point(368, 350);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(100, 17);
            this.lblDisponible.TabIndex = 391;
            this.lblDisponible.Text = "0.00";
            this.lblDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 379);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 603;
            this.label2.Text = "Aplicado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(262, 352);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 602;
            this.label6.Text = "Disponible:";
            // 
            // shapeContainer4
            // 
            this.shapeContainer4.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer4.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer4.Name = "shapeContainer1";
            this.shapeContainer4.Size = new System.Drawing.Size(457, 443);
            this.shapeContainer4.TabIndex = 108;
            this.shapeContainer4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 379);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 605;
            this.label10.Text = "Impuestos:";
            // 
            // lblValorImpuesto
            // 
            this.lblValorImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorImpuesto.ForeColor = System.Drawing.Color.Maroon;
            this.lblValorImpuesto.Location = new System.Drawing.Point(95, 377);
            this.lblValorImpuesto.Name = "lblValorImpuesto";
            this.lblValorImpuesto.Size = new System.Drawing.Size(127, 17);
            this.lblValorImpuesto.TabIndex = 604;
            this.lblValorImpuesto.Text = "0.00";
            this.lblValorImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmClientesPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(565, 456);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblValorImpuesto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDisponible);
            this.Controls.Add(this.lblAplicado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblValores);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.tcPagosClientes);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label3);
            this.Name = "frmClientesPagos";
            this.tcPagosClientes.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpFormasDePago.ResumeLayout(false);
            this.tpImpuestos.ResumeLayout(false);
            this.tpImpuestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).EndInit();
            this.tpImputacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dtFecha;
        internal System.Windows.Forms.Label Label15;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        public System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.TabControl tcPagosClientes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tpFormasDePago;
        private System.Windows.Forms.CheckBox cbChequeRechazado;
        
        private System.Windows.Forms.CheckBox cbTodosLosRecibos;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private System.Windows.Forms.Label lblRecibo;
        public System.Windows.Forms.ComboBox cbRecibos;
        public System.Windows.Forms.ComboBox cbTipoComprobante;
        private System.Windows.Forms.Label label4;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer3;
        private System.Windows.Forms.TabPage tpImputacion;
        public System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblValores;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblAplicado;
        public System.Windows.Forms.Label lblDisponible;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView dgvDatos;
        public ucFormasPagoVentas ucFormasPagoVentas;
        private DataGridViewCheckBoxColumn Seleccionado;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn CodigoTipoDocumentoCliente;
        private DataGridViewTextBoxColumn Numero;
        private DataGridViewTextBoxColumn Total2;
        private DataGridViewTextBoxColumn Imputado;
        private DataGridViewTextBoxColumn Pendiente;
        private DataGridViewTextBoxColumn AAplicar;
        private DataGridViewTextBoxColumn CodigoImputacion;
        private TabPage tpImpuestos;
        internal Label label5;
        public TextBox txtNroComprobante;
        internal Label label7;
        public TextBox txtAgente;
        internal DateTimePicker dtFechaRetencion;
        internal Label label9;
        private Button btnEliminarProducto;
        private Button btnAgregar;
        private Label label12;
        public Label lblImpuesto;
        public TextBox txtImporte;
        public TextBox txtCodigoImpuesto;
        internal Label Label13;
        internal DataGridView dgvImpuestos;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer4;
        private Label label10;
        private Label lblValorImpuesto;
        private DataGridViewTextBoxColumn CodigoImpuesto;
        private DataGridViewTextBoxColumn FechaImpuesto;
        private DataGridViewTextBoxColumn Impuesto;
        private DataGridViewTextBoxColumn Importe;
        private DataGridViewTextBoxColumn CuentaContable;
        private DataGridViewTextBoxColumn NroAgente;
        private DataGridViewTextBoxColumn NroComprobante;
    }
}
