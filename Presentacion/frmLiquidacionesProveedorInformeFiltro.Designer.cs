namespace Presentacion
{
    partial class frmLiquidacionesProveedorInformeFiltro
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
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProveedores = new System.Windows.Forms.CheckBox();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.cbProductos = new System.Windows.Forms.CheckBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVendidasTotalmente = new System.Windows.Forms.CheckBox();
            this.cbVendidasParcialmente = new System.Windows.Forms.CheckBox();
            this.cbGuiasVendidos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(245, 12);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasta";
            // 
            // cbProveedores
            // 
            this.cbProveedores.AutoSize = true;
            this.cbProveedores.Checked = true;
            this.cbProveedores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProveedores.Location = new System.Drawing.Point(32, 51);
            this.cbProveedores.Name = "cbProveedores";
            this.cbProveedores.Size = new System.Drawing.Size(135, 17);
            this.cbProveedores.TabIndex = 10;
            this.cbProveedores.Text = "Todos los Proveedores";
            this.cbProveedores.UseVisualStyleBackColor = true;
            this.cbProveedores.CheckedChanged += new System.EventHandler(this.cbProveedores_CheckedChanged);
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Enabled = false;
            this.txtCodigoProveedor.Location = new System.Drawing.Point(259, 49);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.ShortcutsEnabled = false;
            this.txtCodigoProveedor.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProveedor.TabIndex = 56;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Enabled = false;
            this.lblNombreProveedor.Location = new System.Drawing.Point(304, 53);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 58;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Enabled = false;
            this.lblProveedor.Location = new System.Drawing.Point(173, 52);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(77, 13);
            this.lblProveedor.TabIndex = 59;
            this.lblProveedor.Text = "Proveedor (F6)";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Enabled = false;
            this.lblProducto.Location = new System.Drawing.Point(173, 83);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(71, 13);
            this.lblProducto.TabIndex = 67;
            this.lblProducto.Text = "Producto (F5)";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Location = new System.Drawing.Point(259, 80);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.ShortcutsEnabled = false;
            this.txtCodigoProducto.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProducto.TabIndex = 65;
            this.txtCodigoProducto.TextChanged += new System.EventHandler(this.txtCodigoProducto_TextChanged);
            this.txtCodigoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProducto_KeyDown);
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Enabled = false;
            this.lblNombreProducto.Location = new System.Drawing.Point(304, 84);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProducto.TabIndex = 66;
            // 
            // cbProductos
            // 
            this.cbProductos.AutoSize = true;
            this.cbProductos.Checked = true;
            this.cbProductos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProductos.Location = new System.Drawing.Point(32, 82);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(123, 17);
            this.cbProductos.TabIndex = 64;
            this.cbProductos.Text = "Todos los Productos";
            this.cbProductos.UseVisualStyleBackColor = true;
            this.cbProductos.CheckedChanged += new System.EventHandler(this.cbProductos_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(395, 138);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 72;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(506, 138);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 73;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(73, 12);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(106, 20);
            this.dtDesde.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Desde";
            // 
            // cbVendidasTotalmente
            // 
            this.cbVendidasTotalmente.AutoSize = true;
            this.cbVendidasTotalmente.Location = new System.Drawing.Point(32, 113);
            this.cbVendidasTotalmente.Name = "cbVendidasTotalmente";
            this.cbVendidasTotalmente.Size = new System.Drawing.Size(155, 17);
            this.cbVendidasTotalmente.TabIndex = 76;
            this.cbVendidasTotalmente.Text = "Lotes Vendidos Totalmente";
            this.cbVendidasTotalmente.UseVisualStyleBackColor = true;
            this.cbVendidasTotalmente.Click += new System.EventHandler(this.cbVendidasTotalmente_Click);
            // 
            // cbVendidasParcialmente
            // 
            this.cbVendidasParcialmente.AutoSize = true;
            this.cbVendidasParcialmente.Location = new System.Drawing.Point(201, 113);
            this.cbVendidasParcialmente.Name = "cbVendidasParcialmente";
            this.cbVendidasParcialmente.Size = new System.Drawing.Size(163, 17);
            this.cbVendidasParcialmente.TabIndex = 77;
            this.cbVendidasParcialmente.Text = "Lotes Vendidos Parcialmente";
            this.cbVendidasParcialmente.UseVisualStyleBackColor = true;
            this.cbVendidasParcialmente.Click += new System.EventHandler(this.cbVendidasParcialmente_Click);
            // 
            // cbGuiasVendidos
            // 
            this.cbGuiasVendidos.AutoSize = true;
            this.cbGuiasVendidos.Location = new System.Drawing.Point(370, 113);
            this.cbGuiasVendidos.Name = "cbGuiasVendidos";
            this.cbGuiasVendidos.Size = new System.Drawing.Size(156, 17);
            this.cbGuiasVendidos.TabIndex = 78;
            this.cbGuiasVendidos.Text = "Guias Vendidas Totalmente";
            this.cbGuiasVendidos.UseVisualStyleBackColor = true;
            this.cbGuiasVendidos.Click += new System.EventHandler(this.cbGuiasVendidos_Click);
            // 
            // frmLiquidacionesProveedorInformeFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(597, 172);
            this.Controls.Add(this.cbGuiasVendidos);
            this.Controls.Add(this.cbVendidasParcialmente);
            this.Controls.Add(this.cbVendidasTotalmente);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.txtCodigoProducto);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.cbProductos);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.cbProveedores);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.label2);
            this.Name = "frmLiquidacionesProveedorInformeFiltro";
            this.Text = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbProveedores;
        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblProducto;
        public System.Windows.Forms.TextBox txtCodigoProducto;
        public System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.CheckBox cbProductos;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbVendidasTotalmente;
        private System.Windows.Forms.CheckBox cbVendidasParcialmente;
        private System.Windows.Forms.CheckBox cbGuiasVendidos;
    }
}
