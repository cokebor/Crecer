namespace Presentacion
{
    partial class frmRemitoSucursalInformeFiltro
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
            this.cbSucursalesOrigen = new System.Windows.Forms.CheckBox();
            this.txtCodigoSucursalOrigen = new System.Windows.Forms.TextBox();
            this.lblNombreSucursalOrigen = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
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
            this.cbLotes = new System.Windows.Forms.CheckBox();
            this.lblNombreLote = new System.Windows.Forms.Label();
            this.txtCodigoLote = new System.Windows.Forms.TextBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.cbEnviados = new System.Windows.Forms.CheckBox();
            this.cbRecibidos = new System.Windows.Forms.CheckBox();
            this.lblSucursalDestino = new System.Windows.Forms.Label();
            this.txtCodigoSucursalDestino = new System.Windows.Forms.TextBox();
            this.lblNombreSucursalDestino = new System.Windows.Forms.Label();
            this.cbSucursalDestino = new System.Windows.Forms.CheckBox();
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
            // cbSucursalesOrigen
            // 
            this.cbSucursalesOrigen.AutoSize = true;
            this.cbSucursalesOrigen.Checked = true;
            this.cbSucursalesOrigen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSucursalesOrigen.Location = new System.Drawing.Point(32, 51);
            this.cbSucursalesOrigen.Name = "cbSucursalesOrigen";
            this.cbSucursalesOrigen.Size = new System.Drawing.Size(127, 17);
            this.cbSucursalesOrigen.TabIndex = 10;
            this.cbSucursalesOrigen.Text = "Todas las Sucursales";
            this.cbSucursalesOrigen.UseVisualStyleBackColor = true;
            this.cbSucursalesOrigen.Visible = false;
            this.cbSucursalesOrigen.CheckedChanged += new System.EventHandler(this.cbSucursales_CheckedChanged);
            // 
            // txtCodigoSucursalOrigen
            // 
            this.txtCodigoSucursalOrigen.Enabled = false;
            this.txtCodigoSucursalOrigen.Location = new System.Drawing.Point(263, 49);
            this.txtCodigoSucursalOrigen.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoSucursalOrigen.Name = "txtCodigoSucursalOrigen";
            this.txtCodigoSucursalOrigen.ShortcutsEnabled = false;
            this.txtCodigoSucursalOrigen.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoSucursalOrigen.TabIndex = 56;
            this.txtCodigoSucursalOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoSucursalOrigen.Visible = false;
            this.txtCodigoSucursalOrigen.TextChanged += new System.EventHandler(this.txtCodigoSucursal_TextChanged);
            this.txtCodigoSucursalOrigen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoSucursal_KeyDown);
            this.txtCodigoSucursalOrigen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoSucursal_KeyPress);
            // 
            // lblNombreSucursalOrigen
            // 
            this.lblNombreSucursalOrigen.AutoSize = true;
            this.lblNombreSucursalOrigen.Enabled = false;
            this.lblNombreSucursalOrigen.Location = new System.Drawing.Point(308, 53);
            this.lblNombreSucursalOrigen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreSucursalOrigen.Name = "lblNombreSucursalOrigen";
            this.lblNombreSucursalOrigen.Size = new System.Drawing.Size(0, 13);
            this.lblNombreSucursalOrigen.TabIndex = 58;
            this.lblNombreSucursalOrigen.Visible = false;
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Enabled = false;
            this.lblSucursal.Location = new System.Drawing.Point(173, 52);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(85, 13);
            this.lblSucursal.TabIndex = 59;
            this.lblSucursal.Text = "Sucursal Origen:";
            this.lblSucursal.Visible = false;
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Enabled = false;
            this.lblRubro.Location = new System.Drawing.Point(173, 83);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(36, 13);
            this.lblRubro.TabIndex = 63;
            this.lblRubro.Text = "Rubro";
            // 
            // txtCodigoRubro
            // 
            this.txtCodigoRubro.Enabled = false;
            this.txtCodigoRubro.Location = new System.Drawing.Point(263, 80);
            this.txtCodigoRubro.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoRubro.Name = "txtCodigoRubro";
            this.txtCodigoRubro.ShortcutsEnabled = false;
            this.txtCodigoRubro.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoRubro.TabIndex = 61;
            this.txtCodigoRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoRubro.TextChanged += new System.EventHandler(this.txtCodigoRubro_TextChanged);
            this.txtCodigoRubro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoRubro_KeyDown);
            this.txtCodigoRubro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoRubro_KeyPress);
            // 
            // lblNombreRubro
            // 
            this.lblNombreRubro.AutoSize = true;
            this.lblNombreRubro.Enabled = false;
            this.lblNombreRubro.Location = new System.Drawing.Point(308, 84);
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
            this.cbRubros.Location = new System.Drawing.Point(32, 82);
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
            this.lblProducto.Location = new System.Drawing.Point(173, 114);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(71, 13);
            this.lblProducto.TabIndex = 67;
            this.lblProducto.Text = "Producto (F5)";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Location = new System.Drawing.Point(263, 111);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.ShortcutsEnabled = false;
            this.txtCodigoProducto.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoProducto.TabIndex = 65;
            this.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProducto.TextChanged += new System.EventHandler(this.txtCodigoProducto_TextChanged);
            this.txtCodigoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProducto_KeyDown);
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Enabled = false;
            this.lblNombreProducto.Location = new System.Drawing.Point(308, 115);
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
            this.cbProductos.Location = new System.Drawing.Point(32, 113);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(123, 17);
            this.cbProductos.TabIndex = 64;
            this.cbProductos.Text = "Todos los Productos";
            this.cbProductos.UseVisualStyleBackColor = true;
            this.cbProductos.CheckedChanged += new System.EventHandler(this.cbProductos_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(395, 218);
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
            this.btnCancelar.Location = new System.Drawing.Point(506, 218);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 73;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbLotes
            // 
            this.cbLotes.AutoSize = true;
            this.cbLotes.Checked = true;
            this.cbLotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLotes.Location = new System.Drawing.Point(32, 143);
            this.cbLotes.Name = "cbLotes";
            this.cbLotes.Size = new System.Drawing.Size(101, 17);
            this.cbLotes.TabIndex = 68;
            this.cbLotes.Text = "Todos los Lotes";
            this.cbLotes.UseVisualStyleBackColor = true;
            this.cbLotes.CheckedChanged += new System.EventHandler(this.cbLotes_CheckedChanged);
            // 
            // lblNombreLote
            // 
            this.lblNombreLote.AutoSize = true;
            this.lblNombreLote.Enabled = false;
            this.lblNombreLote.Location = new System.Drawing.Point(308, 145);
            this.lblNombreLote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreLote.Name = "lblNombreLote";
            this.lblNombreLote.Size = new System.Drawing.Size(0, 13);
            this.lblNombreLote.TabIndex = 70;
            // 
            // txtCodigoLote
            // 
            this.txtCodigoLote.Enabled = false;
            this.txtCodigoLote.Location = new System.Drawing.Point(263, 141);
            this.txtCodigoLote.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoLote.Name = "txtCodigoLote";
            this.txtCodigoLote.ShortcutsEnabled = false;
            this.txtCodigoLote.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoLote.TabIndex = 69;
            this.txtCodigoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoLote.TextChanged += new System.EventHandler(this.txtCodigoLote_TextChanged);
            this.txtCodigoLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoLote_KeyDown);
            this.txtCodigoLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoLote_KeyPress);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Enabled = false;
            this.lblLote.Location = new System.Drawing.Point(173, 144);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(28, 13);
            this.lblLote.TabIndex = 71;
            this.lblLote.Text = "Lote";
            // 
            // cbEnviados
            // 
            this.cbEnviados.AutoSize = true;
            this.cbEnviados.Checked = true;
            this.cbEnviados.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnviados.Location = new System.Drawing.Point(32, 171);
            this.cbEnviados.Name = "cbEnviados";
            this.cbEnviados.Size = new System.Drawing.Size(70, 17);
            this.cbEnviados.TabIndex = 74;
            this.cbEnviados.Text = "Enviados";
            this.cbEnviados.UseVisualStyleBackColor = true;
            // 
            // cbRecibidos
            // 
            this.cbRecibidos.AutoSize = true;
            this.cbRecibidos.Checked = true;
            this.cbRecibidos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecibidos.Location = new System.Drawing.Point(32, 197);
            this.cbRecibidos.Name = "cbRecibidos";
            this.cbRecibidos.Size = new System.Drawing.Size(73, 17);
            this.cbRecibidos.TabIndex = 75;
            this.cbRecibidos.Text = "Recibidos";
            this.cbRecibidos.UseVisualStyleBackColor = true;
            // 
            // lblSucursalDestino
            // 
            this.lblSucursalDestino.AutoSize = true;
            this.lblSucursalDestino.Enabled = false;
            this.lblSucursalDestino.Location = new System.Drawing.Point(173, 53);
            this.lblSucursalDestino.Name = "lblSucursalDestino";
            this.lblSucursalDestino.Size = new System.Drawing.Size(90, 13);
            this.lblSucursalDestino.TabIndex = 79;
            this.lblSucursalDestino.Text = "Sucursal Destino:";
            // 
            // txtCodigoSucursalDestino
            // 
            this.txtCodigoSucursalDestino.Enabled = false;
            this.txtCodigoSucursalDestino.Location = new System.Drawing.Point(263, 50);
            this.txtCodigoSucursalDestino.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoSucursalDestino.Name = "txtCodigoSucursalDestino";
            this.txtCodigoSucursalDestino.ShortcutsEnabled = false;
            this.txtCodigoSucursalDestino.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoSucursalDestino.TabIndex = 77;
            this.txtCodigoSucursalDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoSucursalDestino.TextChanged += new System.EventHandler(this.txtCodigoSucursalDestino_TextChanged);
            this.txtCodigoSucursalDestino.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoSucursalDestino_KeyDown);
            this.txtCodigoSucursalDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoSucursalDestino_KeyPress);
            // 
            // lblNombreSucursalDestino
            // 
            this.lblNombreSucursalDestino.AutoSize = true;
            this.lblNombreSucursalDestino.Enabled = false;
            this.lblNombreSucursalDestino.Location = new System.Drawing.Point(308, 54);
            this.lblNombreSucursalDestino.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreSucursalDestino.Name = "lblNombreSucursalDestino";
            this.lblNombreSucursalDestino.Size = new System.Drawing.Size(0, 13);
            this.lblNombreSucursalDestino.TabIndex = 78;
            // 
            // cbSucursalDestino
            // 
            this.cbSucursalDestino.AutoSize = true;
            this.cbSucursalDestino.Checked = true;
            this.cbSucursalDestino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSucursalDestino.Location = new System.Drawing.Point(32, 52);
            this.cbSucursalDestino.Name = "cbSucursalDestino";
            this.cbSucursalDestino.Size = new System.Drawing.Size(127, 17);
            this.cbSucursalDestino.TabIndex = 76;
            this.cbSucursalDestino.Text = "Todas las Sucursales";
            this.cbSucursalDestino.UseVisualStyleBackColor = true;
            this.cbSucursalDestino.CheckedChanged += new System.EventHandler(this.cbSucursalDestino_CheckedChanged);
            // 
            // frmRemitoSucursalInformeFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(597, 253);
            this.Controls.Add(this.lblSucursalDestino);
            this.Controls.Add(this.txtCodigoSucursalDestino);
            this.Controls.Add(this.lblNombreSucursalDestino);
            this.Controls.Add(this.cbSucursalDestino);
            this.Controls.Add(this.cbRecibidos);
            this.Controls.Add(this.cbEnviados);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
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
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.txtCodigoSucursalOrigen);
            this.Controls.Add(this.lblNombreSucursalOrigen);
            this.Controls.Add(this.cbSucursalesOrigen);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRemitoSucursalInformeFiltro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSucursalesOrigen;
        public System.Windows.Forms.TextBox txtCodigoSucursalOrigen;
        public System.Windows.Forms.Label lblNombreSucursalOrigen;
        private System.Windows.Forms.Label lblSucursal;
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
        private System.Windows.Forms.CheckBox cbLotes;
        public System.Windows.Forms.Label lblNombreLote;
        public System.Windows.Forms.TextBox txtCodigoLote;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.CheckBox cbEnviados;
        private System.Windows.Forms.CheckBox cbRecibidos;
        private System.Windows.Forms.Label lblSucursalDestino;
        public System.Windows.Forms.TextBox txtCodigoSucursalDestino;
        public System.Windows.Forms.Label lblNombreSucursalDestino;
        private System.Windows.Forms.CheckBox cbSucursalDestino;
    }
}
