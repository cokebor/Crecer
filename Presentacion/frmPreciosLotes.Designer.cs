namespace Presentacion
{
    partial class frmPreciosLotes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbSoloPoductosConSaldoEnSucursales = new System.Windows.Forms.CheckBox();
            this.cbCanal = new System.Windows.Forms.ComboBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.cbPrecioAFacturar = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Canal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantVendida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioDeseado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNombreCanal = new System.Windows.Forms.Label();
            this.lblCanal = new System.Windows.Forms.Label();
            this.txtCodigoCanal = new System.Windows.Forms.TextBox();
            this.cbCanales = new System.Windows.Forms.CheckBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtCodigoLote = new System.Windows.Forms.TextBox();
            this.lblNombreLote = new System.Windows.Forms.Label();
            this.cbLotes = new System.Windows.Forms.CheckBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.cbProductos = new System.Windows.Forms.CheckBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.cbProveedores = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSoloPoductosConSaldoEnSucursales
            // 
            this.cbSoloPoductosConSaldoEnSucursales.AutoSize = true;
            this.cbSoloPoductosConSaldoEnSucursales.Location = new System.Drawing.Point(11, 121);
            this.cbSoloPoductosConSaldoEnSucursales.Name = "cbSoloPoductosConSaldoEnSucursales";
            this.cbSoloPoductosConSaldoEnSucursales.Size = new System.Drawing.Size(219, 17);
            this.cbSoloPoductosConSaldoEnSucursales.TabIndex = 128;
            this.cbSoloPoductosConSaldoEnSucursales.Text = "Solo Productos con Saldo en Sucursales";
            this.cbSoloPoductosConSaldoEnSucursales.UseVisualStyleBackColor = true;
            // 
            // cbCanal
            // 
            this.cbCanal.FormattingEnabled = true;
            this.cbCanal.Location = new System.Drawing.Point(128, 4);
            this.cbCanal.Name = "cbCanal";
            this.cbCanal.Size = new System.Drawing.Size(150, 21);
            this.cbCanal.TabIndex = 127;
            this.cbCanal.SelectedIndexChanged += new System.EventHandler(this.cbCanal_SelectedIndexChanged);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(648, 502);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(79, 26);
            this.btnExportar.TabIndex = 126;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // cbPrecioAFacturar
            // 
            this.cbPrecioAFacturar.AutoSize = true;
            this.cbPrecioAFacturar.Location = new System.Drawing.Point(799, 81);
            this.cbPrecioAFacturar.Name = "cbPrecioAFacturar";
            this.cbPrecioAFacturar.Size = new System.Drawing.Size(112, 17);
            this.cbPrecioAFacturar.TabIndex = 125;
            this.cbPrecioAFacturar.Text = "Precios a Facturar";
            this.cbPrecioAFacturar.UseVisualStyleBackColor = true;
            this.cbPrecioAFacturar.CheckedChanged += new System.EventHandler(this.cbPrecioAFacturar_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(832, 502);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 124;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(740, 502);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 123;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(849, 107);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 122;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaIngreso,
            this.Proveedor,
            this.Canal,
            this.Producto,
            this.Lote,
            this.Ingreso,
            this.Stock,
            this.PrecioPromedio,
            this.CantVendida,
            this.PrecioCargado,
            this.PrecioDeseado,
            this.PrecioVenta});
            this.dgvDatos.Location = new System.Drawing.Point(11, 141);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(901, 348);
            this.dgvDatos.TabIndex = 121;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            this.dgvDatos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDatos_EditingControlShowing);
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.DataPropertyName = "FechaIngreso";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "d";
            this.FechaIngreso.DefaultCellStyle = dataGridViewCellStyle10;
            this.FechaIngreso.HeaderText = "Fecha Ingreso";
            this.FechaIngreso.Name = "FechaIngreso";
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "NombreProveedor";
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            // 
            // Canal
            // 
            this.Canal.DataPropertyName = "Canal";
            this.Canal.HeaderText = "Canal";
            this.Canal.Name = "Canal";
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "NombreProducto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "Lote";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lote.DefaultCellStyle = dataGridViewCellStyle11;
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            // 
            // Ingreso
            // 
            this.Ingreso.DataPropertyName = "CantidadIngresada";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Ingreso.DefaultCellStyle = dataGridViewCellStyle12;
            this.Ingreso.HeaderText = "Ingreso";
            this.Ingreso.Name = "Ingreso";
            this.Ingreso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle13;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PrecioPromedio
            // 
            this.PrecioPromedio.DataPropertyName = "PrecioPromedio";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "C2";
            dataGridViewCellStyle14.NullValue = null;
            this.PrecioPromedio.DefaultCellStyle = dataGridViewCellStyle14;
            this.PrecioPromedio.HeaderText = "Precio Promedio";
            this.PrecioPromedio.Name = "PrecioPromedio";
            this.PrecioPromedio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CantVendida
            // 
            this.CantVendida.DataPropertyName = "Ventas";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CantVendida.DefaultCellStyle = dataGridViewCellStyle15;
            this.CantVendida.HeaderText = "Cant. Vendida";
            this.CantVendida.Name = "CantVendida";
            this.CantVendida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PrecioCargado
            // 
            this.PrecioCargado.DataPropertyName = "PrecioCargado";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "C2";
            this.PrecioCargado.DefaultCellStyle = dataGridViewCellStyle16;
            this.PrecioCargado.HeaderText = "Precio de Venta";
            this.PrecioCargado.Name = "PrecioCargado";
            // 
            // PrecioDeseado
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "C2";
            dataGridViewCellStyle17.NullValue = null;
            this.PrecioDeseado.DefaultCellStyle = dataGridViewCellStyle17;
            this.PrecioDeseado.HeaderText = "Precio a Liq.";
            this.PrecioDeseado.Name = "PrecioDeseado";
            // 
            // PrecioVenta
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "C2";
            dataGridViewCellStyle18.NullValue = null;
            this.PrecioVenta.DefaultCellStyle = dataGridViewCellStyle18;
            this.PrecioVenta.HeaderText = "Precio a Cargar";
            this.PrecioVenta.Name = "PrecioVenta";
            // 
            // lblNombreCanal
            // 
            this.lblNombreCanal.AutoSize = true;
            this.lblNombreCanal.Enabled = false;
            this.lblNombreCanal.Location = new System.Drawing.Point(284, 12);
            this.lblNombreCanal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCanal.Name = "lblNombreCanal";
            this.lblNombreCanal.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCanal.TabIndex = 120;
            // 
            // lblCanal
            // 
            this.lblCanal.AutoSize = true;
            this.lblCanal.Location = new System.Drawing.Point(34, 12);
            this.lblCanal.Name = "lblCanal";
            this.lblCanal.Size = new System.Drawing.Size(34, 13);
            this.lblCanal.TabIndex = 119;
            this.lblCanal.Text = "Canal";
            // 
            // txtCodigoCanal
            // 
            this.txtCodigoCanal.Enabled = false;
            this.txtCodigoCanal.Location = new System.Drawing.Point(577, 4);
            this.txtCodigoCanal.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCanal.Name = "txtCodigoCanal";
            this.txtCodigoCanal.ShortcutsEnabled = false;
            this.txtCodigoCanal.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoCanal.TabIndex = 118;
            this.txtCodigoCanal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCanal.Visible = false;
            this.txtCodigoCanal.TextChanged += new System.EventHandler(this.txtCodigoCanal_TextChanged);
            this.txtCodigoCanal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCanal_KeyDown);
            this.txtCodigoCanal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCanal_KeyPress);
            // 
            // cbCanales
            // 
            this.cbCanales.AutoSize = true;
            this.cbCanales.Location = new System.Drawing.Point(350, 6);
            this.cbCanales.Name = "cbCanales";
            this.cbCanales.Size = new System.Drawing.Size(113, 17);
            this.cbCanales.TabIndex = 117;
            this.cbCanales.Text = "Todos los Canales";
            this.cbCanales.UseVisualStyleBackColor = true;
            this.cbCanales.Visible = false;
            this.cbCanales.CheckedChanged += new System.EventHandler(this.cbCanales_CheckedChanged);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Enabled = false;
            this.lblLote.Location = new System.Drawing.Point(153, 95);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(28, 13);
            this.lblLote.TabIndex = 116;
            this.lblLote.Text = "Lote";
            // 
            // txtCodigoLote
            // 
            this.txtCodigoLote.Enabled = false;
            this.txtCodigoLote.Location = new System.Drawing.Point(239, 92);
            this.txtCodigoLote.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoLote.Name = "txtCodigoLote";
            this.txtCodigoLote.ShortcutsEnabled = false;
            this.txtCodigoLote.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoLote.TabIndex = 114;
            this.txtCodigoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoLote.TextChanged += new System.EventHandler(this.txtCodigoLote_TextChanged);
            this.txtCodigoLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoLote_KeyDown);
            this.txtCodigoLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoLote_KeyPress);
            // 
            // lblNombreLote
            // 
            this.lblNombreLote.AutoSize = true;
            this.lblNombreLote.Enabled = false;
            this.lblNombreLote.Location = new System.Drawing.Point(284, 96);
            this.lblNombreLote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreLote.Name = "lblNombreLote";
            this.lblNombreLote.Size = new System.Drawing.Size(0, 13);
            this.lblNombreLote.TabIndex = 115;
            // 
            // cbLotes
            // 
            this.cbLotes.AutoSize = true;
            this.cbLotes.Checked = true;
            this.cbLotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLotes.Location = new System.Drawing.Point(12, 94);
            this.cbLotes.Name = "cbLotes";
            this.cbLotes.Size = new System.Drawing.Size(101, 17);
            this.cbLotes.TabIndex = 113;
            this.cbLotes.Text = "Todos los Lotes";
            this.cbLotes.UseVisualStyleBackColor = true;
            this.cbLotes.CheckedChanged += new System.EventHandler(this.cbLotes_CheckedChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Enabled = false;
            this.lblProducto.Location = new System.Drawing.Point(153, 68);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(71, 13);
            this.lblProducto.TabIndex = 112;
            this.lblProducto.Text = "Producto (F5)";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Location = new System.Drawing.Point(239, 65);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.ShortcutsEnabled = false;
            this.txtCodigoProducto.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProducto.TabIndex = 110;
            this.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProducto.TextChanged += new System.EventHandler(this.txtCodigoProducto_TextChanged);
            this.txtCodigoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProducto_KeyDown);
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Enabled = false;
            this.lblNombreProducto.Location = new System.Drawing.Point(284, 69);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProducto.TabIndex = 111;
            // 
            // cbProductos
            // 
            this.cbProductos.AutoSize = true;
            this.cbProductos.Checked = true;
            this.cbProductos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProductos.Location = new System.Drawing.Point(12, 67);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(123, 17);
            this.cbProductos.TabIndex = 109;
            this.cbProductos.Text = "Todos los Productos";
            this.cbProductos.UseVisualStyleBackColor = true;
            this.cbProductos.CheckedChanged += new System.EventHandler(this.cbProductos_CheckedChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Enabled = false;
            this.lblProveedor.Location = new System.Drawing.Point(153, 41);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(77, 13);
            this.lblProveedor.TabIndex = 104;
            this.lblProveedor.Text = "Proveedor (F6)";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Enabled = false;
            this.txtCodigoProveedor.Location = new System.Drawing.Point(239, 38);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.ShortcutsEnabled = false;
            this.txtCodigoProveedor.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProveedor.TabIndex = 102;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Enabled = false;
            this.lblNombreProveedor.Location = new System.Drawing.Point(284, 42);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 103;
            // 
            // cbProveedores
            // 
            this.cbProveedores.AutoSize = true;
            this.cbProveedores.Checked = true;
            this.cbProveedores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProveedores.Location = new System.Drawing.Point(12, 40);
            this.cbProveedores.Name = "cbProveedores";
            this.cbProveedores.Size = new System.Drawing.Size(135, 17);
            this.cbProveedores.TabIndex = 101;
            this.cbProveedores.Text = "Todos los Proveedores";
            this.cbProveedores.UseVisualStyleBackColor = true;
            this.cbProveedores.CheckedChanged += new System.EventHandler(this.cbProveedores_CheckedChanged);
            // 
            // frmPreciosLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(923, 537);
            this.Controls.Add(this.cbSoloPoductosConSaldoEnSucursales);
            this.Controls.Add(this.cbCanal);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.cbPrecioAFacturar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.lblNombreCanal);
            this.Controls.Add(this.lblCanal);
            this.Controls.Add(this.txtCodigoCanal);
            this.Controls.Add(this.cbCanales);
            this.Controls.Add(this.lblLote);
            this.Controls.Add(this.txtCodigoLote);
            this.Controls.Add(this.lblNombreLote);
            this.Controls.Add(this.cbLotes);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.txtCodigoProducto);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.cbProductos);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.cbProveedores);
            this.Name = "frmPreciosLotes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblNombreCanal;
        private System.Windows.Forms.Label lblCanal;
        public System.Windows.Forms.TextBox txtCodigoCanal;
        private System.Windows.Forms.CheckBox cbCanales;
        private System.Windows.Forms.Label lblLote;
        public System.Windows.Forms.TextBox txtCodigoLote;
        public System.Windows.Forms.Label lblNombreLote;
        private System.Windows.Forms.CheckBox cbLotes;
        private System.Windows.Forms.Label lblProducto;
        public System.Windows.Forms.TextBox txtCodigoProducto;
        public System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.CheckBox cbProductos;
        private System.Windows.Forms.Label lblProveedor;
        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.CheckBox cbProveedores;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.CheckBox cbPrecioAFacturar;
        public System.Windows.Forms.Button btnExportar;
        public System.Windows.Forms.ComboBox cbCanal;
        private System.Windows.Forms.CheckBox cbSoloPoductosConSaldoEnSucursales;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Canal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioPromedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantVendida;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioDeseado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
    }
}
