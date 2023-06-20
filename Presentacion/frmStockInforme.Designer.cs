namespace Presentacion
{
    partial class frmStockInforme
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCanalDetallado = new System.Windows.Forms.RadioButton();
            this.rbCanal = new System.Windows.Forms.RadioButton();
            this.rbDetalle = new System.Windows.Forms.RadioButton();
            this.rbResumen = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtCodigoLote = new System.Windows.Forms.TextBox();
            this.lblNombreLote = new System.Windows.Forms.Label();
            this.cbLotes = new System.Windows.Forms.CheckBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.cbProductos = new System.Windows.Forms.CheckBox();
            this.lblRubro = new System.Windows.Forms.Label();
            this.txtCodigoRubro = new System.Windows.Forms.TextBox();
            this.lblNombreRubro = new System.Windows.Forms.Label();
            this.cbRubros = new System.Windows.Forms.CheckBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.cbProveedores = new System.Windows.Forms.CheckBox();
            this.lblCanal = new System.Windows.Forms.Label();
            this.txtCodigoCanal = new System.Windows.Forms.TextBox();
            this.cbCanales = new System.Windows.Forms.CheckBox();
            this.lblNombreCanal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCanalDetallado);
            this.groupBox1.Controls.Add(this.rbCanal);
            this.groupBox1.Controls.Add(this.rbDetalle);
            this.groupBox1.Controls.Add(this.rbResumen);
            this.groupBox1.Location = new System.Drawing.Point(79, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbCanalDetallado
            // 
            this.rbCanalDetallado.AutoSize = true;
            this.rbCanalDetallado.Location = new System.Drawing.Point(321, 23);
            this.rbCanalDetallado.Name = "rbCanalDetallado";
            this.rbCanalDetallado.Size = new System.Drawing.Size(119, 17);
            this.rbCanalDetallado.TabIndex = 3;
            this.rbCanalDetallado.Text = "Por Canal Detallado";
            this.rbCanalDetallado.UseVisualStyleBackColor = true;
            this.rbCanalDetallado.CheckedChanged += new System.EventHandler(this.rbCanalDetallado_CheckedChanged);
            // 
            // rbCanal
            // 
            this.rbCanal.AutoSize = true;
            this.rbCanal.Location = new System.Drawing.Point(219, 23);
            this.rbCanal.Name = "rbCanal";
            this.rbCanal.Size = new System.Drawing.Size(71, 17);
            this.rbCanal.TabIndex = 2;
            this.rbCanal.Text = "Por Canal";
            this.rbCanal.UseVisualStyleBackColor = true;
            // 
            // rbDetalle
            // 
            this.rbDetalle.AutoSize = true;
            this.rbDetalle.Location = new System.Drawing.Point(129, 23);
            this.rbDetalle.Name = "rbDetalle";
            this.rbDetalle.Size = new System.Drawing.Size(70, 17);
            this.rbDetalle.TabIndex = 1;
            this.rbDetalle.Text = "Detallado";
            this.rbDetalle.UseVisualStyleBackColor = true;
            // 
            // rbResumen
            // 
            this.rbResumen.AutoSize = true;
            this.rbResumen.Checked = true;
            this.rbResumen.Location = new System.Drawing.Point(31, 23);
            this.rbResumen.Name = "rbResumen";
            this.rbResumen.Size = new System.Drawing.Size(72, 17);
            this.rbResumen.TabIndex = 0;
            this.rbResumen.TabStop = true;
            this.rbResumen.Text = "Resumido";
            this.rbResumen.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(517, 239);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 75;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(406, 239);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 74;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Enabled = false;
            this.lblLote.Location = new System.Drawing.Point(166, 113);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(28, 13);
            this.lblLote.TabIndex = 91;
            this.lblLote.Text = "Lote";
            this.lblLote.Click += new System.EventHandler(this.lblLote_Click);
            // 
            // txtCodigoLote
            // 
            this.txtCodigoLote.Enabled = false;
            this.txtCodigoLote.Location = new System.Drawing.Point(252, 110);
            this.txtCodigoLote.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoLote.Name = "txtCodigoLote";
            this.txtCodigoLote.ShortcutsEnabled = false;
            this.txtCodigoLote.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoLote.TabIndex = 89;
            this.txtCodigoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoLote.TextChanged += new System.EventHandler(this.txtCodigoLote_TextChanged);
            this.txtCodigoLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoLote_KeyDown);
            this.txtCodigoLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoLote_KeyPress);
            // 
            // lblNombreLote
            // 
            this.lblNombreLote.AutoSize = true;
            this.lblNombreLote.Enabled = false;
            this.lblNombreLote.Location = new System.Drawing.Point(297, 114);
            this.lblNombreLote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreLote.Name = "lblNombreLote";
            this.lblNombreLote.Size = new System.Drawing.Size(0, 13);
            this.lblNombreLote.TabIndex = 90;
            this.lblNombreLote.Click += new System.EventHandler(this.lblNombreLote_Click);
            // 
            // cbLotes
            // 
            this.cbLotes.AutoSize = true;
            this.cbLotes.Checked = true;
            this.cbLotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLotes.Location = new System.Drawing.Point(25, 112);
            this.cbLotes.Name = "cbLotes";
            this.cbLotes.Size = new System.Drawing.Size(101, 17);
            this.cbLotes.TabIndex = 88;
            this.cbLotes.Text = "Todos los Lotes";
            this.cbLotes.UseVisualStyleBackColor = true;
            this.cbLotes.CheckedChanged += new System.EventHandler(this.cbLotes_CheckedChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Enabled = false;
            this.lblProducto.Location = new System.Drawing.Point(166, 83);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(71, 13);
            this.lblProducto.TabIndex = 87;
            this.lblProducto.Text = "Producto (F5)";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Location = new System.Drawing.Point(252, 80);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.ShortcutsEnabled = false;
            this.txtCodigoProducto.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProducto.TabIndex = 85;
            this.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProducto.TextChanged += new System.EventHandler(this.txtCodigoProducto_TextChanged);
            this.txtCodigoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProducto_KeyDown);
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Enabled = false;
            this.lblNombreProducto.Location = new System.Drawing.Point(297, 84);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProducto.TabIndex = 86;
            // 
            // cbProductos
            // 
            this.cbProductos.AutoSize = true;
            this.cbProductos.Checked = true;
            this.cbProductos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProductos.Location = new System.Drawing.Point(25, 82);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(123, 17);
            this.cbProductos.TabIndex = 84;
            this.cbProductos.Text = "Todos los Productos";
            this.cbProductos.UseVisualStyleBackColor = true;
            this.cbProductos.CheckedChanged += new System.EventHandler(this.cbProductos_CheckedChanged);
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Enabled = false;
            this.lblRubro.Location = new System.Drawing.Point(166, 52);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(36, 13);
            this.lblRubro.TabIndex = 83;
            this.lblRubro.Text = "Rubro";
            // 
            // txtCodigoRubro
            // 
            this.txtCodigoRubro.Enabled = false;
            this.txtCodigoRubro.Location = new System.Drawing.Point(252, 49);
            this.txtCodigoRubro.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoRubro.Name = "txtCodigoRubro";
            this.txtCodigoRubro.ShortcutsEnabled = false;
            this.txtCodigoRubro.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoRubro.TabIndex = 81;
            this.txtCodigoRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoRubro.TextChanged += new System.EventHandler(this.txtCodigoRubro_TextChanged);
            this.txtCodigoRubro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoRubro_KeyDown);
            this.txtCodigoRubro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoRubro_KeyPress);
            // 
            // lblNombreRubro
            // 
            this.lblNombreRubro.AutoSize = true;
            this.lblNombreRubro.Enabled = false;
            this.lblNombreRubro.Location = new System.Drawing.Point(297, 53);
            this.lblNombreRubro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreRubro.Name = "lblNombreRubro";
            this.lblNombreRubro.Size = new System.Drawing.Size(0, 13);
            this.lblNombreRubro.TabIndex = 82;
            // 
            // cbRubros
            // 
            this.cbRubros.AutoSize = true;
            this.cbRubros.Checked = true;
            this.cbRubros.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRubros.Location = new System.Drawing.Point(25, 51);
            this.cbRubros.Name = "cbRubros";
            this.cbRubros.Size = new System.Drawing.Size(109, 17);
            this.cbRubros.TabIndex = 80;
            this.cbRubros.Text = "Todos los Rubros";
            this.cbRubros.UseVisualStyleBackColor = true;
            this.cbRubros.CheckedChanged += new System.EventHandler(this.cbRubros_CheckedChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Enabled = false;
            this.lblProveedor.Location = new System.Drawing.Point(166, 22);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(77, 13);
            this.lblProveedor.TabIndex = 79;
            this.lblProveedor.Text = "Proveedor (F6)";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Enabled = false;
            this.txtCodigoProveedor.Location = new System.Drawing.Point(252, 19);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.ShortcutsEnabled = false;
            this.txtCodigoProveedor.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProveedor.TabIndex = 77;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Enabled = false;
            this.lblNombreProveedor.Location = new System.Drawing.Point(297, 23);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 78;
            // 
            // cbProveedores
            // 
            this.cbProveedores.AutoSize = true;
            this.cbProveedores.Checked = true;
            this.cbProveedores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProveedores.Location = new System.Drawing.Point(25, 21);
            this.cbProveedores.Name = "cbProveedores";
            this.cbProveedores.Size = new System.Drawing.Size(135, 17);
            this.cbProveedores.TabIndex = 76;
            this.cbProveedores.Text = "Todos los Proveedores";
            this.cbProveedores.UseVisualStyleBackColor = true;
            this.cbProveedores.CheckedChanged += new System.EventHandler(this.cbProveedores_CheckedChanged);
            // 
            // lblCanal
            // 
            this.lblCanal.AutoSize = true;
            this.lblCanal.Enabled = false;
            this.lblCanal.Location = new System.Drawing.Point(166, 143);
            this.lblCanal.Name = "lblCanal";
            this.lblCanal.Size = new System.Drawing.Size(34, 13);
            this.lblCanal.TabIndex = 95;
            this.lblCanal.Text = "Canal";
            // 
            // txtCodigoCanal
            // 
            this.txtCodigoCanal.Enabled = false;
            this.txtCodigoCanal.Location = new System.Drawing.Point(252, 140);
            this.txtCodigoCanal.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCanal.Name = "txtCodigoCanal";
            this.txtCodigoCanal.ShortcutsEnabled = false;
            this.txtCodigoCanal.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoCanal.TabIndex = 93;
            this.txtCodigoCanal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCanal.TextChanged += new System.EventHandler(this.txtCodigoCanal_TextChanged);
            this.txtCodigoCanal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCanal_KeyDown);
            this.txtCodigoCanal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCanal_KeyPress);
            // 
            // cbCanales
            // 
            this.cbCanales.AutoSize = true;
            this.cbCanales.Checked = true;
            this.cbCanales.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCanales.Location = new System.Drawing.Point(25, 142);
            this.cbCanales.Name = "cbCanales";
            this.cbCanales.Size = new System.Drawing.Size(113, 17);
            this.cbCanales.TabIndex = 92;
            this.cbCanales.Text = "Todos los Canales";
            this.cbCanales.UseVisualStyleBackColor = true;
            this.cbCanales.CheckedChanged += new System.EventHandler(this.cbCanales_CheckedChanged);
            // 
            // lblNombreCanal
            // 
            this.lblNombreCanal.AutoSize = true;
            this.lblNombreCanal.Enabled = false;
            this.lblNombreCanal.Location = new System.Drawing.Point(297, 144);
            this.lblNombreCanal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCanal.Name = "lblNombreCanal";
            this.lblNombreCanal.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCanal.TabIndex = 96;
            // 
            // frmStockInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(607, 274);
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
            this.Controls.Add(this.lblRubro);
            this.Controls.Add(this.txtCodigoRubro);
            this.Controls.Add(this.lblNombreRubro);
            this.Controls.Add(this.cbRubros);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.cbProveedores);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmStockInforme";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCanal;
        private System.Windows.Forms.RadioButton rbDetalle;
        private System.Windows.Forms.RadioButton rbResumen;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.RadioButton rbCanalDetallado;
        private System.Windows.Forms.Label lblLote;
        public System.Windows.Forms.TextBox txtCodigoLote;
        public System.Windows.Forms.Label lblNombreLote;
        private System.Windows.Forms.CheckBox cbLotes;
        private System.Windows.Forms.Label lblProducto;
        public System.Windows.Forms.TextBox txtCodigoProducto;
        public System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.CheckBox cbProductos;
        private System.Windows.Forms.Label lblRubro;
        public System.Windows.Forms.TextBox txtCodigoRubro;
        public System.Windows.Forms.Label lblNombreRubro;
        private System.Windows.Forms.CheckBox cbRubros;
        private System.Windows.Forms.Label lblProveedor;
        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.CheckBox cbProveedores;
        private System.Windows.Forms.Label lblCanal;
        public System.Windows.Forms.TextBox txtCodigoCanal;
        private System.Windows.Forms.CheckBox cbCanales;
        public System.Windows.Forms.Label lblNombreCanal;
    }
}
