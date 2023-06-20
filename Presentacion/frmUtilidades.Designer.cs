
namespace Presentacion
{
    partial class frmUtilidades
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
            this.lblSucursales = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRubro = new System.Windows.Forms.RadioButton();
            this.rbProducto = new System.Windows.Forms.RadioButton();
            this.rbProveedor = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.cbClientes = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSucursales
            // 
            this.lblSucursales.AutoSize = true;
            this.lblSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSucursales.Location = new System.Drawing.Point(410, 17);
            this.lblSucursales.Name = "lblSucursales";
            this.lblSucursales.Size = new System.Drawing.Size(51, 13);
            this.lblSucursales.TabIndex = 395;
            this.lblSucursales.Text = "Sucursal:";
            this.lblSucursales.Visible = false;
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(478, 14);
            this.cbSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(94, 21);
            this.cbSucursales.TabIndex = 394;
            this.cbSucursales.Visible = false;
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(255, 14);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 399;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(62, 14);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 398;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(210, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 397;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 396;
            this.label1.Text = "Desde";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Enabled = false;
            this.lblProducto.Location = new System.Drawing.Point(154, 119);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(71, 13);
            this.lblProducto.TabIndex = 411;
            this.lblProducto.Text = "Producto (F5)";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Location = new System.Drawing.Point(240, 116);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.ShortcutsEnabled = false;
            this.txtCodigoProducto.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProducto.TabIndex = 409;
            this.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProducto.TextChanged += new System.EventHandler(this.txtCodigoProducto_TextChanged);
            this.txtCodigoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProducto_KeyDown);
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Enabled = false;
            this.lblNombreProducto.Location = new System.Drawing.Point(285, 120);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProducto.TabIndex = 410;
            // 
            // cbProductos
            // 
            this.cbProductos.AutoSize = true;
            this.cbProductos.Checked = true;
            this.cbProductos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProductos.Location = new System.Drawing.Point(13, 118);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(123, 17);
            this.cbProductos.TabIndex = 408;
            this.cbProductos.Text = "Todos los Productos";
            this.cbProductos.UseVisualStyleBackColor = true;
            this.cbProductos.CheckedChanged += new System.EventHandler(this.cbProductos_CheckedChanged);
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Enabled = false;
            this.lblRubro.Location = new System.Drawing.Point(154, 88);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(36, 13);
            this.lblRubro.TabIndex = 407;
            this.lblRubro.Text = "Rubro";
            // 
            // txtCodigoRubro
            // 
            this.txtCodigoRubro.Enabled = false;
            this.txtCodigoRubro.Location = new System.Drawing.Point(240, 85);
            this.txtCodigoRubro.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoRubro.Name = "txtCodigoRubro";
            this.txtCodigoRubro.ShortcutsEnabled = false;
            this.txtCodigoRubro.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoRubro.TabIndex = 405;
            this.txtCodigoRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoRubro.TextChanged += new System.EventHandler(this.txtCodigoRubro_TextChanged);
            this.txtCodigoRubro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoRubro_KeyDown);
            this.txtCodigoRubro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoRubro_KeyPress);
            // 
            // lblNombreRubro
            // 
            this.lblNombreRubro.AutoSize = true;
            this.lblNombreRubro.Enabled = false;
            this.lblNombreRubro.Location = new System.Drawing.Point(285, 89);
            this.lblNombreRubro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreRubro.Name = "lblNombreRubro";
            this.lblNombreRubro.Size = new System.Drawing.Size(0, 13);
            this.lblNombreRubro.TabIndex = 406;
            // 
            // cbRubros
            // 
            this.cbRubros.AutoSize = true;
            this.cbRubros.Checked = true;
            this.cbRubros.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRubros.Location = new System.Drawing.Point(13, 87);
            this.cbRubros.Name = "cbRubros";
            this.cbRubros.Size = new System.Drawing.Size(109, 17);
            this.cbRubros.TabIndex = 404;
            this.cbRubros.Text = "Todos los Rubros";
            this.cbRubros.UseVisualStyleBackColor = true;
            this.cbRubros.CheckedChanged += new System.EventHandler(this.cbRubros_CheckedChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Enabled = false;
            this.lblProveedor.Location = new System.Drawing.Point(154, 58);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(77, 13);
            this.lblProveedor.TabIndex = 403;
            this.lblProveedor.Text = "Proveedor (F6)";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Enabled = false;
            this.txtCodigoProveedor.Location = new System.Drawing.Point(240, 55);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.ShortcutsEnabled = false;
            this.txtCodigoProveedor.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProveedor.TabIndex = 401;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Enabled = false;
            this.lblNombreProveedor.Location = new System.Drawing.Point(285, 59);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 402;
            // 
            // cbProveedores
            // 
            this.cbProveedores.AutoSize = true;
            this.cbProveedores.Checked = true;
            this.cbProveedores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProveedores.Location = new System.Drawing.Point(13, 57);
            this.cbProveedores.Name = "cbProveedores";
            this.cbProveedores.Size = new System.Drawing.Size(135, 17);
            this.cbProveedores.TabIndex = 400;
            this.cbProveedores.Text = "Todos los Proveedores";
            this.cbProveedores.UseVisualStyleBackColor = true;
            this.cbProveedores.CheckedChanged += new System.EventHandler(this.cbProveedores_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRubro);
            this.groupBox1.Controls.Add(this.rbProducto);
            this.groupBox1.Controls.Add(this.rbProveedor);
            this.groupBox1.Location = new System.Drawing.Point(21, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 42);
            this.groupBox1.TabIndex = 412;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar por";
            // 
            // rbRubro
            // 
            this.rbRubro.AutoSize = true;
            this.rbRubro.Location = new System.Drawing.Point(114, 19);
            this.rbRubro.Name = "rbRubro";
            this.rbRubro.Size = new System.Drawing.Size(54, 17);
            this.rbRubro.TabIndex = 3;
            this.rbRubro.Text = "Rubro";
            this.rbRubro.UseVisualStyleBackColor = true;
            // 
            // rbProducto
            // 
            this.rbProducto.AutoSize = true;
            this.rbProducto.Location = new System.Drawing.Point(190, 19);
            this.rbProducto.Name = "rbProducto";
            this.rbProducto.Size = new System.Drawing.Size(68, 17);
            this.rbProducto.TabIndex = 2;
            this.rbProducto.Text = "Producto";
            this.rbProducto.UseVisualStyleBackColor = true;
            // 
            // rbProveedor
            // 
            this.rbProveedor.AutoSize = true;
            this.rbProveedor.Checked = true;
            this.rbProveedor.Location = new System.Drawing.Point(24, 19);
            this.rbProveedor.Name = "rbProveedor";
            this.rbProveedor.Size = new System.Drawing.Size(74, 17);
            this.rbProveedor.TabIndex = 1;
            this.rbProveedor.TabStop = true;
            this.rbProveedor.Text = "Proveedor";
            this.rbProveedor.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(493, 217);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 414;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(382, 217);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 413;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Enabled = false;
            this.lblCliente.Location = new System.Drawing.Point(154, 150);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(60, 13);
            this.lblCliente.TabIndex = 418;
            this.lblCliente.Text = "Cliente (F2)";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Location = new System.Drawing.Point(240, 147);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.ShortcutsEnabled = false;
            this.txtCodigoCliente.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoCliente.TabIndex = 416;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Enabled = false;
            this.lblNombreCliente.Location = new System.Drawing.Point(285, 151);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 417;
            // 
            // cbClientes
            // 
            this.cbClientes.AutoSize = true;
            this.cbClientes.Checked = true;
            this.cbClientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClientes.Location = new System.Drawing.Point(13, 149);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(112, 17);
            this.cbClientes.TabIndex = 415;
            this.cbClientes.Text = "Todos los Clientes";
            this.cbClientes.UseVisualStyleBackColor = true;
            this.cbClientes.CheckedChanged += new System.EventHandler(this.cbClientes_CheckedChanged);
            // 
            // frmUtilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(592, 250);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox1);
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
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Name = "frmUtilidades";
            this.Load += new System.EventHandler(this.frmUtilidades_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRubro;
        private System.Windows.Forms.RadioButton rbProducto;
        private System.Windows.Forms.RadioButton rbProveedor;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.CheckBox cbClientes;
    }
}
