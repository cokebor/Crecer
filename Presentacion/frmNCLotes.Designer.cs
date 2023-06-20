namespace Presentacion
{
    partial class frmNCLotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNCLotes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbDescontarSobrePrecioDeFacturacion = new System.Windows.Forms.CheckBox();
            this.cbFacturasViejas = new System.Windows.Forms.CheckBox();
            this.lblTipoComprobanteCliente = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSeleccionados = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cbSeleccion = new System.Windows.Forms.CheckBox();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoVendedor = new System.Windows.Forms.TextBox();
            this.lblNombreVendedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoDocumentoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteFacturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteConNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteConTodasNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteConTodasNC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Viejos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDescontarSobrePrecioDeFacturacion
            // 
            this.cbDescontarSobrePrecioDeFacturacion.AutoSize = true;
            this.cbDescontarSobrePrecioDeFacturacion.Location = new System.Drawing.Point(714, 117);
            this.cbDescontarSobrePrecioDeFacturacion.Name = "cbDescontarSobrePrecioDeFacturacion";
            this.cbDescontarSobrePrecioDeFacturacion.Size = new System.Drawing.Size(207, 17);
            this.cbDescontarSobrePrecioDeFacturacion.TabIndex = 427;
            this.cbDescontarSobrePrecioDeFacturacion.Text = "Descontar sobre precio de facturación";
            this.cbDescontarSobrePrecioDeFacturacion.UseVisualStyleBackColor = true;
            this.cbDescontarSobrePrecioDeFacturacion.Visible = false;
            this.cbDescontarSobrePrecioDeFacturacion.CheckedChanged += new System.EventHandler(this.cbDescontarSobrePrecioDeFacturacion_CheckedChanged);
            // 
            // cbFacturasViejas
            // 
            this.cbFacturasViejas.AutoSize = true;
            this.cbFacturasViejas.Location = new System.Drawing.Point(714, 81);
            this.cbFacturasViejas.Name = "cbFacturasViejas";
            this.cbFacturasViejas.Size = new System.Drawing.Size(146, 17);
            this.cbFacturasViejas.TabIndex = 426;
            this.cbFacturasViejas.Text = "Facturas Sistema Anterior";
            this.cbFacturasViejas.UseVisualStyleBackColor = true;
            this.cbFacturasViejas.CheckedChanged += new System.EventHandler(this.cbFacturasViejas_CheckedChanged);
            // 
            // lblTipoComprobanteCliente
            // 
            this.lblTipoComprobanteCliente.Location = new System.Drawing.Point(655, 47);
            this.lblTipoComprobanteCliente.Name = "lblTipoComprobanteCliente";
            this.lblTipoComprobanteCliente.Size = new System.Drawing.Size(206, 13);
            this.lblTipoComprobanteCliente.TabIndex = 425;
            this.lblTipoComprobanteCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(839, 568);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 424;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(740, 568);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 423;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(672, 536);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 422;
            this.label7.Text = "Total Descuentos:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(788, 535);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(131, 15);
            this.lblTotal.TabIndex = 421;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(335, 536);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 13);
            this.label15.TabIndex = 420;
            this.label15.Text = "Cantidad Seleccionados:";
            // 
            // lblSeleccionados
            // 
            this.lblSeleccionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionados.ForeColor = System.Drawing.Color.Maroon;
            this.lblSeleccionados.Location = new System.Drawing.Point(492, 535);
            this.lblSeleccionados.Name = "lblSeleccionados";
            this.lblSeleccionados.Size = new System.Drawing.Size(62, 15);
            this.lblSeleccionados.TabIndex = 419;
            this.lblSeleccionados.Text = "0";
            this.lblSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(419, 78);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 418;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar.BackgroundImage")));
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnValidar.Location = new System.Drawing.Point(456, 115);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(25, 25);
            this.btnValidar.TabIndex = 417;
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(294, 117);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(106, 20);
            this.txtDescuento.TabIndex = 415;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuento_KeyDown);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(231, 121);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 416;
            this.label6.Text = "Descuento:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.Codigo,
            this.CodigoTipoDocumentoCliente,
            this.Fecha,
            this.Comprobante,
            this.Numero,
            this.ImporteFacturado,
            this.ImporteConNC,
            this.ImporteConTodasNC,
            this.ImporteConTodasNC2,
            this.Descuento,
            this.Viejos});
            this.dgvDatos.Location = new System.Drawing.Point(15, 151);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(906, 372);
            this.dgvDatos.TabIndex = 414;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellDoubleClick);
            // 
            // cbSeleccion
            // 
            this.cbSeleccion.AutoSize = true;
            this.cbSeleccion.Location = new System.Drawing.Point(15, 119);
            this.cbSeleccion.Name = "cbSeleccion";
            this.cbSeleccion.Size = new System.Drawing.Size(110, 17);
            this.cbSeleccion.TabIndex = 413;
            this.cbSeleccion.Text = "Seleccionar Todo";
            this.cbSeleccion.UseVisualStyleBackColor = true;
            this.cbSeleccion.CheckedChanged += new System.EventHandler(this.cbSeleccion_CheckedChanged);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(294, 81);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 412;
            this.dtHasta.ValueChanged += new System.EventHandler(this.dtHasta_ValueChanged);
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(91, 81);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 411;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(231, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 410;
            this.label2.Text = "Hasta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(12, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 409;
            this.label5.Text = "Desde";
            // 
            // txtCodigoVendedor
            // 
            this.txtCodigoVendedor.Location = new System.Drawing.Point(92, 11);
            this.txtCodigoVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoVendedor.Name = "txtCodigoVendedor";
            this.txtCodigoVendedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoVendedor.TabIndex = 400;
            this.txtCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoVendedor.TextChanged += new System.EventHandler(this.txtCodigoVendedor_TextChanged);
            this.txtCodigoVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoVendedor_KeyDown);
            this.txtCodigoVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoVendedor_KeyPress);
            // 
            // lblNombreVendedor
            // 
            this.lblNombreVendedor.AutoSize = true;
            this.lblNombreVendedor.Location = new System.Drawing.Point(129, 16);
            this.lblNombreVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreVendedor.Name = "lblNombreVendedor";
            this.lblNombreVendedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreVendedor.TabIndex = 408;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 407;
            this.label3.Text = "Vendedor (F1):";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(823, 16);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 405;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(782, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 404;
            this.label1.Text = "Fecha:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(92, 46);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoCliente.TabIndex = 401;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(129, 51);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 403;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 402;
            this.label4.Text = "Cliente (F2):";
            // 
            // Seleccionado
            // 
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
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
            this.CodigoTipoDocumentoCliente.HeaderText = "CodigoTipoDocumentoCliente";
            this.CodigoTipoDocumentoCliente.Name = "CodigoTipoDocumentoCliente";
            this.CodigoTipoDocumentoCliente.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle8;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Comprobante
            // 
            this.Comprobante.DataPropertyName = "TipoDocumento";
            this.Comprobante.HeaderText = "Comprobante";
            this.Comprobante.Name = "Comprobante";
            this.Comprobante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle9;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ImporteFacturado
            // 
            this.ImporteFacturado.DataPropertyName = "ImporteFacturado";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "C2";
            this.ImporteFacturado.DefaultCellStyle = dataGridViewCellStyle10;
            this.ImporteFacturado.HeaderText = "Importe Facturado";
            this.ImporteFacturado.Name = "ImporteFacturado";
            this.ImporteFacturado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ImporteConNC
            // 
            this.ImporteConNC.DataPropertyName = "ImporteConNC";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "C2";
            this.ImporteConNC.DefaultCellStyle = dataGridViewCellStyle11;
            this.ImporteConNC.HeaderText = "Importe c/NC Dev.";
            this.ImporteConNC.Name = "ImporteConNC";
            this.ImporteConNC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ImporteConTodasNC
            // 
            this.ImporteConTodasNC.DataPropertyName = "ImporteConTodasNC";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "C2";
            this.ImporteConTodasNC.DefaultCellStyle = dataGridViewCellStyle12;
            this.ImporteConTodasNC.HeaderText = "Importe c/NC";
            this.ImporteConTodasNC.Name = "ImporteConTodasNC";
            this.ImporteConTodasNC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ImporteConTodasNC2
            // 
            this.ImporteConTodasNC2.DataPropertyName = "ImporteConTodasNC2";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "C2";
            this.ImporteConTodasNC2.DefaultCellStyle = dataGridViewCellStyle13;
            this.ImporteConTodasNC2.HeaderText = "Importe s/NC Esp.";
            this.ImporteConTodasNC2.Name = "ImporteConTodasNC2";
            this.ImporteConTodasNC2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Descuento
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "C2";
            this.Descuento.DefaultCellStyle = dataGridViewCellStyle14;
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            // 
            // Viejos
            // 
            this.Viejos.DataPropertyName = "Viejos";
            this.Viejos.HeaderText = "Viejos";
            this.Viejos.Name = "Viejos";
            this.Viejos.Visible = false;
            // 
            // frmNCLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(925, 607);
            this.Controls.Add(this.cbDescontarSobrePrecioDeFacturacion);
            this.Controls.Add(this.cbFacturasViejas);
            this.Controls.Add(this.lblTipoComprobanteCliente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblSeleccionados);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.cbSeleccion);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigoVendedor);
            this.Controls.Add(this.lblNombreVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label4);
            this.Name = "frmNCLotes";
            this.Load += new System.EventHandler(this.frmNCLotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoVendedor;
        public System.Windows.Forms.Label lblNombreVendedor;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFecha;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbSeleccion;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.TextBox txtDescuento;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnValidar;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblSeleccionados;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblTipoComprobanteCliente;
        private System.Windows.Forms.CheckBox cbFacturasViejas;
        private System.Windows.Forms.CheckBox cbDescontarSobrePrecioDeFacturacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoDocumentoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteFacturado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteConNC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteConTodasNC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteConTodasNC2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Viejos;
    }
}
