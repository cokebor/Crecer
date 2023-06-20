namespace Presentacion
{
    partial class frmDevolucionMercaderia
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
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLote = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMovStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(101, 11);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoProveedor.TabIndex = 0;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Location = new System.Drawing.Point(138, 15);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Proveedor (F6):";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.Location = new System.Drawing.Point(138, 40);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(200, 18);
            this.lblNombreProducto.TabIndex = 60;
            this.lblNombreProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Producto (F5):";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Location = new System.Drawing.Point(101, 39);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoProducto.TabIndex = 1;
            this.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProducto.TextChanged += new System.EventHandler(this.txtCodigoProducto_TextChanged);
            this.txtCodigoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProducto_KeyDown);
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(599, 43);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(0, 13);
            this.lblStock.TabIndex = 401;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(562, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 400;
            this.label6.Text = "Stock:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 399;
            this.label4.Text = "Lote:";
            // 
            // cbLote
            // 
            this.cbLote.FormattingEnabled = true;
            this.cbLote.Location = new System.Drawing.Point(486, 39);
            this.cbLote.Name = "cbLote";
            this.cbLote.Size = new System.Drawing.Size(63, 21);
            this.cbLote.TabIndex = 3;
            this.cbLote.SelectedIndexChanged += new System.EventHandler(this.cbLote_SelectedIndexChanged);
            this.cbLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLote_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 403;
            this.label2.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(400, 39);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(39, 20);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoProveedor,
            this.Proveedor,
            this.CodigoProducto,
            this.Producto,
            this.Lote,
            this.Cantidad,
            this.CodigoMovStock});
            this.dgvDatos.Location = new System.Drawing.Point(24, 83);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(570, 247);
            this.dgvDatos.TabIndex = 404;
            // 
            // CodigoProveedor
            // 
            this.CodigoProveedor.HeaderText = "CodigoProveedor";
            this.CodigoProveedor.Name = "CodigoProveedor";
            this.CodigoProveedor.Visible = false;
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            // 
            // CodigoProducto
            // 
            this.CodigoProducto.HeaderText = "CodigoProducto";
            this.CodigoProducto.Name = "CodigoProducto";
            this.CodigoProducto.Visible = false;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // Lote
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Lote.DefaultCellStyle = dataGridViewCellStyle1;
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            // 
            // Cantidad
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // CodigoMovStock
            // 
            this.CodigoMovStock.HeaderText = "CodigoMovStock";
            this.CodigoMovStock.Name = "CodigoMovStock";
            this.CodigoMovStock.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(603, 83);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = global::Presentacion.Properties.Resources.remove;
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(603, 123);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 5;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(547, 351);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 406;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(452, 351);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 405;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmDevolucionMercaderia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(637, 388);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbLote);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigoProducto);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.label3);
            this.Name = "frmDevolucionMercaderia";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbLote;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCantidad;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMovStock;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
    }
}
