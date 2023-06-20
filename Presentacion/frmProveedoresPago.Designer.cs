using System;
using System.Windows.Forms;

namespace Presentacion
{
    partial class frmProveedoresPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedoresPago));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.tcPagosProveedores = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRecibo = new System.Windows.Forms.Label();
            this.cbRecibos = new System.Windows.Forms.ComboBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.cbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbChequeRechazado = new System.Windows.Forms.CheckBox();
            this.cbTodosLosRecibos = new System.Windows.Forms.CheckBox();
            this.cbLiquidaciones = new System.Windows.Forms.CheckBox();
            this.tpFormasDePago = new System.Windows.Forms.TabPage();
            this.ucFormasPagoCompras = new Presentacion.ucFormasPagoCompras(false);
            this.tpImputacion = new System.Windows.Forms.TabPage();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoDocumentoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imputado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AAplicar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoImputacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.shapeContainer3 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelRet = new System.Windows.Forms.Label();
            this.lblRetenciones = new System.Windows.Forms.Label();
            this.lblRetencionesIVA = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblValores = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblAplicado = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblRetencionMunicipal = new System.Windows.Forms.Label();
            this.tcPagosProveedores.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpFormasDePago.SuspendLayout();
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
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(108, 11);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoProveedor.TabIndex = 55;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Location = new System.Drawing.Point(141, 14);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Proveedor (F6):";
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
            // tcPagosProveedores
            // 
            this.tcPagosProveedores.Controls.Add(this.tabPage1);
            this.tcPagosProveedores.Controls.Add(this.tpFormasDePago);
            this.tcPagosProveedores.Controls.Add(this.tpImputacion);
            this.tcPagosProveedores.Location = new System.Drawing.Point(17, 44);
            this.tcPagosProveedores.Name = "tcPagosProveedores";
            this.tcPagosProveedores.SelectedIndex = 0;
            this.tcPagosProveedores.Size = new System.Drawing.Size(541, 300);
            this.tcPagosProveedores.TabIndex = 60;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.lblRecibo);
            this.tabPage1.Controls.Add(this.cbRecibos);
            this.tabPage1.Controls.Add(this.txtObservaciones);
            this.tabPage1.Controls.Add(this.cbTipoComprobante);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbChequeRechazado);
            this.tabPage1.Controls.Add(this.cbTodosLosRecibos);
            this.tabPage1.Controls.Add(this.cbLiquidaciones);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(533, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Comprobante";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(25, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(305, 13);
            this.label9.TabIndex = 544;
            this.label9.Text = "Seleccionar Forma de Pago y Imputar para aplicar Retenciones";
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
            this.cbRecibos.TabIndex = 414;
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
            this.txtObservaciones.TabIndex = 542;
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.FormattingEnabled = true;
            this.cbTipoComprobante.Location = new System.Drawing.Point(117, 47);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(131, 21);
            this.cbTipoComprobante.TabIndex = 412;
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
            this.cbChequeRechazado.Location = new System.Drawing.Point(293, 15);
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
            this.cbTodosLosRecibos.Location = new System.Drawing.Point(135, 15);
            this.cbTodosLosRecibos.Name = "cbTodosLosRecibos";
            this.cbTodosLosRecibos.Size = new System.Drawing.Size(152, 17);
            this.cbTodosLosRecibos.TabIndex = 410;
            this.cbTodosLosRecibos.Text = "Mostrar Todos los Recibos";
            this.cbTodosLosRecibos.UseVisualStyleBackColor = true;
            this.cbTodosLosRecibos.Visible = false;
            this.cbTodosLosRecibos.CheckedChanged += new System.EventHandler(this.cbTodosLosRecibos_CheckedChanged);
            // 
            // cbLiquidaciones
            // 
            this.cbLiquidaciones.AutoSize = true;
            this.cbLiquidaciones.Location = new System.Drawing.Point(23, 15);
            this.cbLiquidaciones.Name = "cbLiquidaciones";
            this.cbLiquidaciones.Size = new System.Drawing.Size(91, 17);
            this.cbLiquidaciones.TabIndex = 409;
            this.cbLiquidaciones.Text = "Liquidaciones";
            this.cbLiquidaciones.UseVisualStyleBackColor = true;
            this.cbLiquidaciones.CheckedChanged += new System.EventHandler(this.cbLiquidaciones_CheckedChanged);
            // 
            // tpFormasDePago
            // 
            this.tpFormasDePago.Controls.Add(this.ucFormasPagoCompras);
            this.tpFormasDePago.Location = new System.Drawing.Point(4, 22);
            this.tpFormasDePago.Name = "tpFormasDePago";
            this.tpFormasDePago.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormasDePago.Size = new System.Drawing.Size(533, 274);
            this.tpFormasDePago.TabIndex = 1;
            this.tpFormasDePago.Text = "Formas de Pago";
            this.tpFormasDePago.UseVisualStyleBackColor = true;
            // 
            // ucFormasPagoCompras
            // 
            this.ucFormasPagoCompras.Cheques = ((System.Collections.Generic.List<Entidades.Cheque>)(resources.GetObject("ucFormasPagoCompras.Cheques")));
            this.ucFormasPagoCompras.ChequesPropios = ((System.Collections.Generic.List<Entidades.Cheque>)(resources.GetObject("ucFormasPagoCompras.ChequesPropios")));
            this.ucFormasPagoCompras.CodigoRecibo = 0;
            this.ucFormasPagoCompras.Dolares = 0D;
            this.ucFormasPagoCompras.Efectivo = 0D;
            this.ucFormasPagoCompras.Efectivos = ((System.Collections.Generic.List<Entidades.Factura_Efectivo>)(resources.GetObject("ucFormasPagoCompras.Efectivos")));
            this.ucFormasPagoCompras.FormularioInicial = null;
            this.ucFormasPagoCompras.Location = new System.Drawing.Point(0, 0);
            this.ucFormasPagoCompras.Name = "ucFormasPagoCompras";
            this.ucFormasPagoCompras.Proveedor = null;
            this.ucFormasPagoCompras.Size = new System.Drawing.Size(521, 267);
            this.ucFormasPagoCompras.TabIndex = 0;
            this.ucFormasPagoCompras.TipoDoc = "RC";
            this.ucFormasPagoCompras.Tranferencias = ((System.Collections.Generic.List<Entidades.Tranferencia>)(resources.GetObject("ucFormasPagoCompras.Tranferencias")));
            this.ucFormasPagoCompras.valores = 0D;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.Fecha,
            this.Tipo,
            this.Codigo,
            this.CodigoTipoDocumentoProveedor,
            this.Numero,
            this.Total2,
            this.Imputado,
            this.Pendiente,
            this.AAplicar,
            this.CodigoImputacion,
            this.Iva,
            this.Neto});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDatos.Location = new System.Drawing.Point(0, 3);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDatos.RowTemplate.Height = 20;
            this.dgvDatos.Size = new System.Drawing.Size(533, 269);
            this.dgvDatos.TabIndex = 14;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            this.dgvDatos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDatos_CurrentCellDirtyStateChanged);
            this.dgvDatos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDatos_EditingControlShowing);
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            // 
            // Seleccionado
            // 
            this.Seleccionado.DataPropertyName = "Seleccionado";
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            // 
            // Fecha
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Tipo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tipo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // CodigoTipoDocumentoProveedor
            // 
            this.CodigoTipoDocumentoProveedor.HeaderText = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.Name = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.Visible = false;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle4;
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // Total2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Total2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total2.HeaderText = "Total";
            this.Total2.Name = "Total2";
            // 
            // Imputado
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.Imputado.DefaultCellStyle = dataGridViewCellStyle6;
            this.Imputado.HeaderText = "Imputado";
            this.Imputado.Name = "Imputado";
            // 
            // Pendiente
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            this.Pendiente.DefaultCellStyle = dataGridViewCellStyle7;
            this.Pendiente.HeaderText = "Pendiente";
            this.Pendiente.Name = "Pendiente";
            // 
            // AAplicar
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AAplicar.DefaultCellStyle = dataGridViewCellStyle8;
            this.AAplicar.HeaderText = "A Aplicar";
            this.AAplicar.Name = "AAplicar";
            // 
            // CodigoImputacion
            // 
            this.CodigoImputacion.HeaderText = "CodigoImputacion";
            this.CodigoImputacion.Name = "CodigoImputacion";
            this.CodigoImputacion.Visible = false;
            // 
            // Iva
            // 
            this.Iva.HeaderText = "Iva";
            this.Iva.Name = "Iva";
            this.Iva.Visible = false;
            // 
            // Neto
            // 
            this.Neto.HeaderText = "Neto";
            this.Neto.Name = "Neto";
            this.Neto.Visible = false;
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
            this.btnCancelar.Location = new System.Drawing.Point(475, 426);
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
            this.btnConfirmar.Location = new System.Drawing.Point(382, 426);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 544;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 400);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 547;
            this.label7.Text = "Ret. Ganancias:";
            // 
            // labelRet
            // 
            this.labelRet.AutoSize = true;
            this.labelRet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRet.Location = new System.Drawing.Point(22, 376);
            this.labelRet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRet.Name = "labelRet";
            this.labelRet.Size = new System.Drawing.Size(59, 13);
            this.labelRet.TabIndex = 600;
            this.labelRet.Text = "Ret. IVA:";
            // 
            // lblRetenciones
            // 
            this.lblRetenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetenciones.ForeColor = System.Drawing.Color.Maroon;
            this.lblRetenciones.Location = new System.Drawing.Point(113, 398);
            this.lblRetenciones.Name = "lblRetenciones";
            this.lblRetenciones.Size = new System.Drawing.Size(100, 17);
            this.lblRetenciones.TabIndex = 546;
            this.lblRetenciones.Text = "0.00";
            this.lblRetenciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRetencionesIVA
            // 
            this.lblRetencionesIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetencionesIVA.ForeColor = System.Drawing.Color.Maroon;
            this.lblRetencionesIVA.Location = new System.Drawing.Point(113, 374);
            this.lblRetencionesIVA.Name = "lblRetencionesIVA";
            this.lblRetencionesIVA.Size = new System.Drawing.Size(100, 17);
            this.lblRetencionesIVA.TabIndex = 601;
            this.lblRetencionesIVA.Text = "0.00";
            this.lblRetencionesIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.label14.Location = new System.Drawing.Point(272, 352);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 549;
            this.label14.Text = "Total:";
            // 
            // lblValores
            // 
            this.lblValores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValores.ForeColor = System.Drawing.Color.Maroon;
            this.lblValores.Location = new System.Drawing.Point(113, 350);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(100, 17);
            this.lblValores.TabIndex = 550;
            this.lblValores.Text = "0.00";
            this.lblValores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(336, 350);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 548;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAplicado
            // 
            this.lblAplicado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplicado.ForeColor = System.Drawing.Color.Maroon;
            this.lblAplicado.Location = new System.Drawing.Point(336, 374);
            this.lblAplicado.Name = "lblAplicado";
            this.lblAplicado.Size = new System.Drawing.Size(100, 17);
            this.lblAplicado.TabIndex = 392;
            this.lblAplicado.Text = "0.00";
            this.lblAplicado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDisponible
            // 
            this.lblDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.ForeColor = System.Drawing.Color.Maroon;
            this.lblDisponible.Location = new System.Drawing.Point(336, 398);
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
            this.label2.Location = new System.Drawing.Point(272, 376);
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
            this.label6.Location = new System.Drawing.Point(271, 400);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 602;
            this.label6.Text = "Disponible:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(22, 424);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 13);
            this.label21.TabIndex = 605;
            this.label21.Text = "Ret. Munic.:";
            // 
            // lblRetencionMunicipal
            // 
            this.lblRetencionMunicipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblRetencionMunicipal.ForeColor = System.Drawing.Color.Maroon;
            this.lblRetencionMunicipal.Location = new System.Drawing.Point(113, 422);
            this.lblRetencionMunicipal.Name = "lblRetencionMunicipal";
            this.lblRetencionMunicipal.Size = new System.Drawing.Size(100, 17);
            this.lblRetencionMunicipal.TabIndex = 604;
            this.lblRetencionMunicipal.Text = "0.00";
            this.lblRetencionMunicipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmProveedoresPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(565, 460);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblRetencionMunicipal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDisponible);
            this.Controls.Add(this.lblAplicado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblValores);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelRet);
            this.Controls.Add(this.lblRetenciones);
            this.Controls.Add(this.lblRetencionesIVA);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.tcPagosProveedores);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.label3);
            this.Name = "frmProveedoresPago";
            this.tcPagosProveedores.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpFormasDePago.ResumeLayout(false);
            this.tpImputacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dtFecha;
        internal System.Windows.Forms.Label Label15;
        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        public System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.TabControl tcPagosProveedores;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tpFormasDePago;
        private System.Windows.Forms.CheckBox cbChequeRechazado;
        private System.Windows.Forms.CheckBox cbTodosLosRecibos;
        private System.Windows.Forms.CheckBox cbLiquidaciones;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelRet;
        private System.Windows.Forms.Label lblRetenciones;
        private System.Windows.Forms.Label lblRetencionesIVA;
        private ucFormasPagoCompras ucFormasPagoCompras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblValores;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblAplicado;
        public System.Windows.Forms.Label lblDisponible;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoDocumentoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Imputado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn AAplicar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoImputacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neto;
        private Label label9;
        public Label label21;
        private Label lblRetencionMunicipal;
    }
}
