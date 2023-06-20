namespace Presentacion
{
    partial class frmVentaPorProductoInformeFiltro
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
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClientes = new System.Windows.Forms.CheckBox();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblRubro = new System.Windows.Forms.Label();
            this.txtCodigoRubro = new System.Windows.Forms.TextBox();
            this.lblNombreRubro = new System.Windows.Forms.Label();
            this.cbRubros = new System.Windows.Forms.CheckBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.cbProductos = new System.Windows.Forms.CheckBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.cbAgrupadoPorRubro = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(266, 12);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 7;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(73, 12);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desde";
            // 
            // cbClientes
            // 
            this.cbClientes.AutoSize = true;
            this.cbClientes.Checked = true;
            this.cbClientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClientes.Location = new System.Drawing.Point(32, 51);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(112, 17);
            this.cbClientes.TabIndex = 10;
            this.cbClientes.Text = "Todos los Clientes";
            this.cbClientes.UseVisualStyleBackColor = true;
            this.cbClientes.CheckedChanged += new System.EventHandler(this.cbClientes_CheckedChanged);
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Location = new System.Drawing.Point(259, 49);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.ShortcutsEnabled = false;
            this.txtCodigoCliente.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoCliente.TabIndex = 56;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Enabled = false;
            this.lblNombreCliente.Location = new System.Drawing.Point(304, 53);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 58;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Enabled = false;
            this.lblCliente.Location = new System.Drawing.Point(173, 52);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(60, 13);
            this.lblCliente.TabIndex = 59;
            this.lblCliente.Text = "Cliente (F2)";
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Enabled = false;
            this.lblRubro.Location = new System.Drawing.Point(173, 82);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(36, 13);
            this.lblRubro.TabIndex = 63;
            this.lblRubro.Text = "Rubro";
            // 
            // txtCodigoRubro
            // 
            this.txtCodigoRubro.Enabled = false;
            this.txtCodigoRubro.Location = new System.Drawing.Point(259, 79);
            this.txtCodigoRubro.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoRubro.Name = "txtCodigoRubro";
            this.txtCodigoRubro.ShortcutsEnabled = false;
            this.txtCodigoRubro.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoRubro.TabIndex = 61;
            this.txtCodigoRubro.TextChanged += new System.EventHandler(this.txtCodigoRubro_TextChanged);
            this.txtCodigoRubro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoRubro_KeyDown);
            this.txtCodigoRubro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoRubro_KeyPress);
            // 
            // lblNombreRubro
            // 
            this.lblNombreRubro.AutoSize = true;
            this.lblNombreRubro.Enabled = false;
            this.lblNombreRubro.Location = new System.Drawing.Point(304, 83);
            this.lblNombreRubro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreRubro.Name = "lblNombreRubro";
            this.lblNombreRubro.Size = new System.Drawing.Size(0, 13);
            this.lblNombreRubro.TabIndex = 62;
            // 
            // cbRubros
            // 
            this.cbRubros.AutoSize = true;
            this.cbRubros.Checked = true;
            this.cbRubros.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRubros.Location = new System.Drawing.Point(32, 81);
            this.cbRubros.Name = "cbRubros";
            this.cbRubros.Size = new System.Drawing.Size(109, 17);
            this.cbRubros.TabIndex = 60;
            this.cbRubros.Text = "Todos los Rubros";
            this.cbRubros.UseVisualStyleBackColor = true;
            this.cbRubros.CheckedChanged += new System.EventHandler(this.cbRubros_CheckedChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Enabled = false;
            this.lblProducto.Location = new System.Drawing.Point(173, 113);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(71, 13);
            this.lblProducto.TabIndex = 67;
            this.lblProducto.Text = "Producto (F5)";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Location = new System.Drawing.Point(259, 110);
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
            this.lblNombreProducto.Location = new System.Drawing.Point(304, 114);
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
            this.cbProductos.Location = new System.Drawing.Point(32, 112);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(123, 17);
            this.cbProductos.TabIndex = 64;
            this.cbProductos.Text = "Todos los Productos";
            this.cbProductos.UseVisualStyleBackColor = true;
            this.cbProductos.CheckedChanged += new System.EventHandler(this.cbProductos_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(408, 156);
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
            this.btnCancelar.Location = new System.Drawing.Point(507, 156);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 73;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblSucursales
            // 
            this.lblSucursales.AutoSize = true;
            this.lblSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSucursales.Location = new System.Drawing.Point(420, 15);
            this.lblSucursales.Name = "lblSucursales";
            this.lblSucursales.Size = new System.Drawing.Size(51, 13);
            this.lblSucursales.TabIndex = 395;
            this.lblSucursales.Text = "Sucursal:";
            this.lblSucursales.Visible = false;
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(492, 11);
            this.cbSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(94, 21);
            this.cbSucursales.TabIndex = 394;
            this.cbSucursales.Visible = false;
            // 
            // cbAgrupadoPorRubro
            // 
            this.cbAgrupadoPorRubro.AutoSize = true;
            this.cbAgrupadoPorRubro.Location = new System.Drawing.Point(32, 145);
            this.cbAgrupadoPorRubro.Name = "cbAgrupadoPorRubro";
            this.cbAgrupadoPorRubro.Size = new System.Drawing.Size(127, 17);
            this.cbAgrupadoPorRubro.TabIndex = 396;
            this.cbAgrupadoPorRubro.Text = "Agrupado por Rubros";
            this.cbAgrupadoPorRubro.UseVisualStyleBackColor = true;
            this.cbAgrupadoPorRubro.Visible = false;
            // 
            // frmVentaPorProductoInformeFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(597, 195);
            this.Controls.Add(this.cbAgrupadoPorRubro);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.txtCodigoProducto);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.cbProductos);
            this.Controls.Add(this.lblRubro);
            this.Controls.Add(this.txtCodigoRubro);
            this.Controls.Add(this.lblNombreRubro);
            this.Controls.Add(this.cbRubros);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmVentaPorProductoInformeFiltro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbClientes;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblRubro;
        public System.Windows.Forms.TextBox txtCodigoRubro;
        public System.Windows.Forms.Label lblNombreRubro;
        private System.Windows.Forms.CheckBox cbRubros;
        private System.Windows.Forms.Label lblProducto;
        public System.Windows.Forms.TextBox txtCodigoProducto;
        public System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.CheckBox cbProductos;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.CheckBox cbAgrupadoPorRubro;
    }
}
