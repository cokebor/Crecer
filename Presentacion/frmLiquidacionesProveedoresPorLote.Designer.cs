namespace Presentacion
{
    partial class frmLiquidacionesProveedoresPorLote  
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBuscar = new System.Windows.Forms.Button();
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(779, 12);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 64;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Enabled = false;
            this.lblLote.Location = new System.Drawing.Point(160, 106);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(28, 13);
            this.lblLote.TabIndex = 466;
            this.lblLote.Text = "Lote";
            // 
            // txtCodigoLote
            // 
            this.txtCodigoLote.Enabled = false;
            this.txtCodigoLote.Location = new System.Drawing.Point(246, 103);
            this.txtCodigoLote.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoLote.Name = "txtCodigoLote";
            this.txtCodigoLote.ShortcutsEnabled = false;
            this.txtCodigoLote.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoLote.TabIndex = 464;
            this.txtCodigoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoLote.TextChanged += new System.EventHandler(this.txtCodigoLote_TextChanged);
            this.txtCodigoLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoLote_KeyDown);
            this.txtCodigoLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoLote_KeyPress);
            // 
            // lblNombreLote
            // 
            this.lblNombreLote.AutoSize = true;
            this.lblNombreLote.Enabled = false;
            this.lblNombreLote.Location = new System.Drawing.Point(291, 107);
            this.lblNombreLote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreLote.Name = "lblNombreLote";
            this.lblNombreLote.Size = new System.Drawing.Size(0, 13);
            this.lblNombreLote.TabIndex = 465;
            // 
            // cbLotes
            // 
            this.cbLotes.AutoSize = true;
            this.cbLotes.Checked = true;
            this.cbLotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLotes.Location = new System.Drawing.Point(19, 105);
            this.cbLotes.Name = "cbLotes";
            this.cbLotes.Size = new System.Drawing.Size(101, 17);
            this.cbLotes.TabIndex = 463;
            this.cbLotes.Text = "Todos los Lotes";
            this.cbLotes.UseVisualStyleBackColor = true;
            this.cbLotes.CheckedChanged += new System.EventHandler(this.cbLotes_CheckedChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Enabled = false;
            this.lblProducto.Location = new System.Drawing.Point(160, 79);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(71, 13);
            this.lblProducto.TabIndex = 462;
            this.lblProducto.Text = "Producto (F5)";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Location = new System.Drawing.Point(246, 76);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.ShortcutsEnabled = false;
            this.txtCodigoProducto.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProducto.TabIndex = 460;
            this.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProducto.TextChanged += new System.EventHandler(this.txtCodigoProducto_TextChanged);
            this.txtCodigoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProducto_KeyDown);
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Enabled = false;
            this.lblNombreProducto.Location = new System.Drawing.Point(291, 80);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProducto.TabIndex = 461;
            // 
            // cbProductos
            // 
            this.cbProductos.AutoSize = true;
            this.cbProductos.Checked = true;
            this.cbProductos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProductos.Location = new System.Drawing.Point(19, 78);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(123, 17);
            this.cbProductos.TabIndex = 459;
            this.cbProductos.Text = "Todos los Productos";
            this.cbProductos.UseVisualStyleBackColor = true;
            this.cbProductos.CheckedChanged += new System.EventHandler(this.cbProductos_CheckedChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Enabled = false;
            this.lblProveedor.Location = new System.Drawing.Point(160, 53);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(77, 13);
            this.lblProveedor.TabIndex = 458;
            this.lblProveedor.Text = "Proveedor (F6)";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Enabled = false;
            this.txtCodigoProveedor.Location = new System.Drawing.Point(246, 50);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.ShortcutsEnabled = false;
            this.txtCodigoProveedor.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProveedor.TabIndex = 456;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown_1);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Enabled = false;
            this.lblNombreProveedor.Location = new System.Drawing.Point(291, 54);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 457;
            // 
            // cbProveedores
            // 
            this.cbProveedores.AutoSize = true;
            this.cbProveedores.Checked = true;
            this.cbProveedores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProveedores.Location = new System.Drawing.Point(19, 52);
            this.cbProveedores.Name = "cbProveedores";
            this.cbProveedores.Size = new System.Drawing.Size(135, 17);
            this.cbProveedores.TabIndex = 455;
            this.cbProveedores.Text = "Todos los Proveedores";
            this.cbProveedores.UseVisualStyleBackColor = true;
            this.cbProveedores.CheckedChanged += new System.EventHandler(this.cbProveedores_CheckedChanged);
            // 
            // btnExportar
            // 
            this.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExportar.Location = new System.Drawing.Point(669, 580);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(79, 26);
            this.btnExportar.TabIndex = 448;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(763, 580);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 447;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(253, 12);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 444;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(60, 12);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 443;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 442;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 441;
            this.label1.Text = "Desde";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Proveedor,
            this.Liquidacion,
            this.Producto,
            this.Lote,
            this.Cantidad,
            this.Precio,
            this.Total});
            this.dgvDatos.Location = new System.Drawing.Point(11, 145);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(831, 420);
            this.dgvDatos.TabIndex = 65;
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Proveedor";
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Liquidacion
            // 
            this.Liquidacion.DataPropertyName = "Liquidacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Liquidacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Liquidacion.HeaderText = "Liquidacion";
            this.Liquidacion.Name = "Liquidacion";
            this.Liquidacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "IdLote";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Lote.DefaultCellStyle = dataGridViewCellStyle3;
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "CantidadLiquidada";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Precio.DefaultCellStyle = dataGridViewCellStyle5;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle6;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmLiquidacionesProveedoresPorLote
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(853, 617);
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
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnBuscar);
            this.Name = "frmLiquidacionesProveedoresPorLote";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblProveedor;
        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.CheckBox cbProveedores;
        private System.Windows.Forms.Label lblProducto;
        public System.Windows.Forms.TextBox txtCodigoProducto;
        public System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.CheckBox cbProductos;
        private System.Windows.Forms.Label lblLote;
        public System.Windows.Forms.TextBox txtCodigoLote;
        public System.Windows.Forms.Label lblNombreLote;
        private System.Windows.Forms.CheckBox cbLotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Liquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}
