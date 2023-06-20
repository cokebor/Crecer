using Controles2;

namespace Presentacion
{
    partial class frmSaldoInicialVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaldoInicialVentas));
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panelPorUnidad = new System.Windows.Forms.Panel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ivas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLote = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoVendedor = new System.Windows.Forms.TextBox();
            this.lblNombreVendedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblCtaCte = new System.Windows.Forms.Label();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lblStock = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panelPorUnidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(473, 11);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 395;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(419, 412);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 388;
            this.label12.Text = "Total:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(484, 439);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 103;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(385, 439);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // panelPorUnidad
            // 
            this.panelPorUnidad.Controls.Add(this.dgvDatos);
            this.panelPorUnidad.Controls.Add(this.btnEditar);
            this.panelPorUnidad.Controls.Add(this.btnEliminarProducto);
            this.panelPorUnidad.Controls.Add(this.btnAgregar);
            this.panelPorUnidad.Controls.Add(this.label5);
            this.panelPorUnidad.Controls.Add(this.txtPrecio);
            this.panelPorUnidad.Controls.Add(this.label6);
            this.panelPorUnidad.Controls.Add(this.cbLote);
            this.panelPorUnidad.Controls.Add(this.label7);
            this.panelPorUnidad.Controls.Add(this.txtCantidad);
            this.panelPorUnidad.Controls.Add(this.lblProducto);
            this.panelPorUnidad.Controls.Add(this.label8);
            this.panelPorUnidad.Controls.Add(this.txtProducto);
            this.panelPorUnidad.Location = new System.Drawing.Point(9, 76);
            this.panelPorUnidad.Name = "panelPorUnidad";
            this.panelPorUnidad.Size = new System.Drawing.Size(556, 314);
            this.panelPorUnidad.TabIndex = 2;
            this.panelPorUnidad.Visible = false;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripción,
            this.Lote,
            this.Cantidad,
            this.PUnitario,
            this.Total,
            this.Ivas,
            this.PorcIVA});
            this.dgvDatos.Location = new System.Drawing.Point(0, 37);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(522, 274);
            this.dgvDatos.TabIndex = 89;
            // 
            // Codigo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Descripción
            // 
            this.Descripción.DataPropertyName = "Descripcion";
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.Name = "Descripción";
            // 
            // Lote
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lote.DefaultCellStyle = dataGridViewCellStyle2;
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            // 
            // Cantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // PUnitario
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C4";
            dataGridViewCellStyle4.NullValue = null;
            this.PUnitario.DefaultCellStyle = dataGridViewCellStyle4;
            this.PUnitario.HeaderText = "P. Unitario";
            this.PUnitario.Name = "PUnitario";
            // 
            // Total
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C4";
            dataGridViewCellStyle5.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // Ivas
            // 
            this.Ivas.HeaderText = "Iva";
            this.Ivas.Name = "Ivas";
            this.Ivas.Visible = false;
            // 
            // PorcIVA
            // 
            this.PorcIVA.HeaderText = "PorcIVA";
            this.PorcIVA.Name = "PorcIVA";
            this.PorcIVA.Visible = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(529, 117);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(25, 25);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarProducto.BackgroundImage")));
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(529, 77);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 5;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(529, 37);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "P. Unit.:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(503, 1);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(51, 20);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecio_KeyDown);
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Lote:";
            // 
            // cbLote
            // 
            this.cbLote.FormattingEnabled = true;
            this.cbLote.Location = new System.Drawing.Point(384, 0);
            this.cbLote.Name = "cbLote";
            this.cbLote.Size = new System.Drawing.Size(65, 21);
            this.cbLote.TabIndex = 2;
            this.cbLote.SelectedIndexChanged += new System.EventHandler(this.cbLote_SelectedIndexChanged);
            this.cbLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLote_KeyDown);
            this.cbLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLote_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(307, 1);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(39, 20);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(119, 4);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(0, 13);
            this.lblProducto.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Producto (F5):";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(82, 1);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(32, 20);
            this.txtProducto.TabIndex = 0;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            this.txtProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProducto_KeyDown);
            this.txtProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducto_KeyPress);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(463, 409);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 65;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Fecha:";
            // 
            // txtCodigoVendedor
            // 
            this.txtCodigoVendedor.Location = new System.Drawing.Point(91, 12);
            this.txtCodigoVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoVendedor.Name = "txtCodigoVendedor";
            this.txtCodigoVendedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoVendedor.TabIndex = 0;
            this.txtCodigoVendedor.TextChanged += new System.EventHandler(this.txtCodigoVendedor_TextChanged);
            this.txtCodigoVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoVendedor_KeyDown);
            this.txtCodigoVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoVendedor_KeyPress);
            // 
            // lblNombreVendedor
            // 
            this.lblNombreVendedor.AutoSize = true;
            this.lblNombreVendedor.Location = new System.Drawing.Point(128, 17);
            this.lblNombreVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreVendedor.Name = "lblNombreVendedor";
            this.lblNombreVendedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreVendedor.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Vendedor (F1):";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 55);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 396;
            this.label19.Text = "Stock (F4)";
            // 
            // lblCtaCte
            // 
            this.lblCtaCte.AutoSize = true;
            this.lblCtaCte.Location = new System.Drawing.Point(235, 55);
            this.lblCtaCte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCtaCte.Name = "lblCtaCte";
            this.lblCtaCte.Size = new System.Drawing.Size(0, 13);
            this.lblCtaCte.TabIndex = 398;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.UseWaitCursor = true;
            this.lineShape3.X1 = 1;
            this.lineShape3.X2 = 568;
            this.lineShape3.Y1 = 42;
            this.lineShape3.Y2 = 42;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3});
            this.shapeContainer1.Size = new System.Drawing.Size(569, 477);
            this.shapeContainer1.TabIndex = 399;
            this.shapeContainer1.TabStop = false;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(433, 56);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(0, 13);
            this.lblStock.TabIndex = 401;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(396, 57);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 400;
            this.label20.Text = "Stock:";
            // 
            // frmSaldoInicialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(569, 477);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblCtaCte);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panelPorUnidad);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoVendedor);
            this.Controls.Add(this.lblNombreVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shapeContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSaldoInicialVentas";
            this.panelPorUnidad.ResumeLayout(false);
            this.panelPorUnidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoVendedor;
        public System.Windows.Forms.Label lblNombreVendedor;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnEliminarProducto;
        public System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbLote;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtCantidad;
        public System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtProducto;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ivas;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcIVA;
        public System.Windows.Forms.Panel panelPorUnidad;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Label label12;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label lblCtaCte;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label20;
    }
}
