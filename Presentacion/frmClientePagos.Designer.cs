using Controles2;


namespace Presentacion
{
    partial class frmClientePagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientePagos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtFechaRetencion = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTodosLosRecibos = new System.Windows.Forms.CheckBox();
            this.lblRecibo = new System.Windows.Forms.Label();
            this.cbRecibos = new System.Windows.Forms.ComboBox();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtCodigoImpuesto = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroAgente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImputacion = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFormaDePago = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.Label15 = new System.Windows.Forms.Label();
            this.cbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAgente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNroComprobante = new System.Windows.Forms.TextBox();
            this.cbChequeRechazado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFechaRetencion
            // 
            this.dtFechaRetencion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaRetencion.Location = new System.Drawing.Point(80, 210);
            this.dtFechaRetencion.Name = "dtFechaRetencion";
            this.dtFechaRetencion.Size = new System.Drawing.Size(86, 20);
            this.dtFechaRetencion.TabIndex = 9;
            this.dtFechaRetencion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFechaRetencion_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 402;
            this.label2.Text = "Fecha Ret.:";
            // 
            // cbTodosLosRecibos
            // 
            this.cbTodosLosRecibos.AutoSize = true;
            this.cbTodosLosRecibos.Location = new System.Drawing.Point(22, 38);
            this.cbTodosLosRecibos.Name = "cbTodosLosRecibos";
            this.cbTodosLosRecibos.Size = new System.Drawing.Size(152, 17);
            this.cbTodosLosRecibos.TabIndex = 400;
            this.cbTodosLosRecibos.Text = "Mostrar Todos los Recibos";
            this.cbTodosLosRecibos.UseVisualStyleBackColor = true;
            this.cbTodosLosRecibos.Visible = false;
            this.cbTodosLosRecibos.CheckedChanged += new System.EventHandler(this.cbTodosLosRecibos_CheckedChanged);
            // 
            // lblRecibo
            // 
            this.lblRecibo.AutoSize = true;
            this.lblRecibo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRecibo.Location = new System.Drawing.Point(256, 66);
            this.lblRecibo.Name = "lblRecibo";
            this.lblRecibo.Size = new System.Drawing.Size(44, 13);
            this.lblRecibo.TabIndex = 399;
            this.lblRecibo.Text = "Recibo:";
            this.lblRecibo.Visible = false;
            // 
            // cbRecibos
            // 
            this.cbRecibos.FormattingEnabled = true;
            this.cbRecibos.Location = new System.Drawing.Point(306, 63);
            this.cbRecibos.Name = "cbRecibos";
            this.cbRecibos.Size = new System.Drawing.Size(131, 21);
            this.cbRecibos.TabIndex = 3;
            this.cbRecibos.Visible = false;
            this.cbRecibos.SelectedIndexChanged += new System.EventHandler(this.cbRecibos_SelectedIndexChanged);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarProducto.BackgroundImage")));
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(415, 210);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 13;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(415, 174);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(289, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 397;
            this.label12.Text = "Importe:";
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.AutoSize = true;
            this.lblImpuesto.Location = new System.Drawing.Point(115, 179);
            this.lblImpuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(0, 13);
            this.lblImpuesto.TabIndex = 396;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(339, 176);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(68, 20);
            this.txtImporte.TabIndex = 8;
            this.txtImporte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtImporte_KeyDown);
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // txtCodigoImpuesto
            // 
            this.txtCodigoImpuesto.Location = new System.Drawing.Point(80, 177);
            this.txtCodigoImpuesto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoImpuesto.Name = "txtCodigoImpuesto";
            this.txtCodigoImpuesto.Size = new System.Drawing.Size(30, 20);
            this.txtCodigoImpuesto.TabIndex = 7;
            this.txtCodigoImpuesto.TextChanged += new System.EventHandler(this.txtCodigoImpuesto_TextChanged);
            this.txtCodigoImpuesto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoImpuesto_KeyDown);
            this.txtCodigoImpuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoImpuesto_KeyPress);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(9, 179);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(74, 13);
            this.Label13.TabIndex = 395;
            this.Label13.Text = "Impuesto (F7):";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.ColumnHeadersVisible = false;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Fecha,
            this.Impuesto,
            this.Importe,
            this.CuentaContable,
            this.NroAgente,
            this.NroComprobante});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvDatos.Location = new System.Drawing.Point(36, 246);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(322, 97);
            this.dgvDatos.TabIndex = 394;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
            this.Codigo.Width = 25;
            // 
            // Fecha
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 70;
            // 
            // Impuesto
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Impuesto.DefaultCellStyle = dataGridViewCellStyle3;
            this.Impuesto.HeaderText = "Impuesto";
            this.Impuesto.Name = "Impuesto";
            this.Impuesto.ReadOnly = true;
            this.Impuesto.Width = 150;
            // 
            // Importe
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle4;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // CuentaContable
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CuentaContable.DefaultCellStyle = dataGridViewCellStyle5;
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
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(361, 405);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImputacion
            // 
            this.btnImputacion.Enabled = false;
            this.btnImputacion.Location = new System.Drawing.Point(75, 137);
            this.btnImputacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnImputacion.Name = "btnImputacion";
            this.btnImputacion.Size = new System.Drawing.Size(118, 26);
            this.btnImputacion.TabIndex = 5;
            this.btnImputacion.Text = "IMPUTACION";
            this.btnImputacion.UseVisualStyleBackColor = true;
            this.btnImputacion.Click += new System.EventHandler(this.btnImputacion_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(114, 97);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(321, 20);
            this.txtObservaciones.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 389;
            this.label1.Text = "Observaciones:";
            // 
            // btnFormaDePago
            // 
            this.btnFormaDePago.Enabled = false;
            this.btnFormaDePago.Location = new System.Drawing.Point(268, 137);
            this.btnFormaDePago.Margin = new System.Windows.Forms.Padding(2);
            this.btnFormaDePago.Name = "btnFormaDePago";
            this.btnFormaDePago.Size = new System.Drawing.Size(118, 26);
            this.btnFormaDePago.TabIndex = 6;
            this.btnFormaDePago.Text = "FORMAS DE PAGO";
            this.btnFormaDePago.UseVisualStyleBackColor = true;
            this.btnFormaDePago.Click += new System.EventHandler(this.btnFormaDePago_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(275, 372);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 387;
            this.label14.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(330, 370);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 386;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(262, 405);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 14;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(351, 11);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 1;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(309, 15);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(40, 13);
            this.Label15.TabIndex = 54;
            this.Label15.Text = "Fecha:";
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.FormattingEnabled = true;
            this.cbTipoComprobante.Location = new System.Drawing.Point(114, 63);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(131, 21);
            this.cbTipoComprobante.TabIndex = 2;
            this.cbTipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cbTipoComprobante_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Tipo Comprobante:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(114, 11);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoCliente.TabIndex = 0;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Location = new System.Drawing.Point(147, 15);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Cliente (F2):";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(457, 443);
            this.shapeContainer1.TabIndex = 108;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 448;
            this.lineShape1.Y1 = 127;
            this.lineShape1.Y2 = 127;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 404;
            this.label5.Text = "Nro. Agente:";
            // 
            // txtAgente
            // 
            this.txtAgente.Location = new System.Drawing.Point(247, 210);
            this.txtAgente.Margin = new System.Windows.Forms.Padding(2);
            this.txtAgente.Name = "txtAgente";
            this.txtAgente.Size = new System.Drawing.Size(58, 20);
            this.txtAgente.TabIndex = 10;
            this.txtAgente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAgente_KeyDown);
            this.txtAgente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgente_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 406;
            this.label6.Text = "Comp.:";
            // 
            // txtNroComprobante
            // 
            this.txtNroComprobante.Location = new System.Drawing.Point(358, 210);
            this.txtNroComprobante.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroComprobante.Name = "txtNroComprobante";
            this.txtNroComprobante.Size = new System.Drawing.Size(48, 20);
            this.txtNroComprobante.TabIndex = 11;
            this.txtNroComprobante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroComprobante_KeyDown);
            this.txtNroComprobante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroComprobante_KeyPress);
            // 
            // cbChequeRechazado
            // 
            this.cbChequeRechazado.AutoSize = true;
            this.cbChequeRechazado.Location = new System.Drawing.Point(197, 38);
            this.cbChequeRechazado.Name = "cbChequeRechazado";
            this.cbChequeRechazado.Size = new System.Drawing.Size(121, 17);
            this.cbChequeRechazado.TabIndex = 407;
            this.cbChequeRechazado.Text = "Cheque Rechazado";
            this.cbChequeRechazado.UseVisualStyleBackColor = true;
            this.cbChequeRechazado.Visible = false;
            // 
            // frmClientePagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(457, 443);
            this.Controls.Add(this.cbChequeRechazado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNroComprobante);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAgente);
            this.Controls.Add(this.dtFechaRetencion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTodosLosRecibos);
            this.Controls.Add(this.lblRecibo);
            this.Controls.Add(this.cbRecibos);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblImpuesto);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.txtCodigoImpuesto);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImputacion);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFormaDePago);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.cbTipoComprobante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shapeContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmClientePagos";
            this.Load += new System.EventHandler(this.frmProveedoresPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreProveedor;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbTipoComprobante;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        internal System.Windows.Forms.Label Label15;
        public System.Windows.Forms.Button btnConfirmar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnFormaDePago;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtObservaciones;
        public System.Windows.Forms.Button btnImputacion;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lblImpuesto;
        public System.Windows.Forms.TextBox txtImporte;
        public System.Windows.Forms.TextBox txtCodigoImpuesto;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblRecibo;
        public System.Windows.Forms.ComboBox cbRecibos;
        private System.Windows.Forms.CheckBox cbTodosLosRecibos;
        internal System.Windows.Forms.DateTimePicker dtFechaRetencion;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtAgente;
        internal System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtNroComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroAgente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroComprobante;
        private System.Windows.Forms.CheckBox cbChequeRechazado;
    }
}
