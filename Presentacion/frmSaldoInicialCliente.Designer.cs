namespace Presentacion
{
    partial class frmSaldoInicialCliente
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
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbDebito = new System.Windows.Forms.RadioButton();
            this.lblTipoComprobanteCliente = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtCodigoVendedor = new System.Windows.Forms.TextBox();
            this.lblNombreVendedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucNumeroComprobante = new Presentacion.ucNumeroComprobante();
            this.cbNumeroComprobante = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(105, 73);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoCliente.TabIndex = 2;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(142, 77);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Cliente (F2):";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(237, 6);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 0;
            this.dtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFecha_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 396;
            this.label1.Text = "Fecha:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCredito);
            this.groupBox1.Controls.Add(this.rbDebito);
            this.groupBox1.Location = new System.Drawing.Point(46, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 61);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Afectacíon Cuenta Corriente";
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Location = new System.Drawing.Point(153, 28);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(58, 17);
            this.rbCredito.TabIndex = 1;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.UseVisualStyleBackColor = true;
            this.rbCredito.CheckedChanged += new System.EventHandler(this.rbCredito_CheckedChanged);
            this.rbCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rbCredito_KeyPress);
            // 
            // rbDebito
            // 
            this.rbDebito.AutoSize = true;
            this.rbDebito.Checked = true;
            this.rbDebito.Location = new System.Drawing.Point(26, 28);
            this.rbDebito.Name = "rbDebito";
            this.rbDebito.Size = new System.Drawing.Size(56, 17);
            this.rbDebito.TabIndex = 0;
            this.rbDebito.TabStop = true;
            this.rbDebito.Text = "Débito";
            this.rbDebito.UseVisualStyleBackColor = true;
            this.rbDebito.CheckedChanged += new System.EventHandler(this.rbDebito_CheckedChanged);
            this.rbDebito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rbDebito_KeyPress);
            // 
            // lblTipoComprobanteCliente
            // 
            this.lblTipoComprobanteCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTipoComprobanteCliente.ForeColor = System.Drawing.Color.Black;
            this.lblTipoComprobanteCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTipoComprobanteCliente.Location = new System.Drawing.Point(20, 5);
            this.lblTipoComprobanteCliente.Name = "lblTipoComprobanteCliente";
            this.lblTipoComprobanteCliente.Size = new System.Drawing.Size(163, 21);
            this.lblTipoComprobanteCliente.TabIndex = 399;
            this.lblTipoComprobanteCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTipoComprobanteCliente.Visible = false;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(110, 232);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(128, 20);
            this.txtImporte.TabIndex = 6;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 235);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 401;
            this.label2.Text = "Importe:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(249, 283);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(150, 283);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtCodigoVendedor
            // 
            this.txtCodigoVendedor.Location = new System.Drawing.Point(105, 41);
            this.txtCodigoVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoVendedor.Name = "txtCodigoVendedor";
            this.txtCodigoVendedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoVendedor.TabIndex = 1;
            this.txtCodigoVendedor.TextChanged += new System.EventHandler(this.txtCodigoVendedor_TextChanged);
            this.txtCodigoVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoVendedor_KeyDown);
            this.txtCodigoVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoVendedor_KeyPress);
            // 
            // lblNombreVendedor
            // 
            this.lblNombreVendedor.AutoSize = true;
            this.lblNombreVendedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreVendedor.Location = new System.Drawing.Point(142, 46);
            this.lblNombreVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreVendedor.Name = "lblNombreVendedor";
            this.lblNombreVendedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreVendedor.TabIndex = 406;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(16, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 405;
            this.label3.Text = "Vendedor (F1):";
            // 
            // ucNumeroComprobante
            // 
            this.ucNumeroComprobante.Location = new System.Drawing.Point(137, 102);
            this.ucNumeroComprobante.Name = "ucNumeroComprobante";
            this.ucNumeroComprobante.Size = new System.Drawing.Size(118, 25);
            this.ucNumeroComprobante.TabIndex = 4;
            // 
            // cbNumeroComprobante
            // 
            this.cbNumeroComprobante.AutoSize = true;
            this.cbNumeroComprobante.Location = new System.Drawing.Point(19, 108);
            this.cbNumeroComprobante.Name = "cbNumeroComprobante";
            this.cbNumeroComprobante.Size = new System.Drawing.Size(112, 17);
            this.cbNumeroComprobante.TabIndex = 3;
            this.cbNumeroComprobante.Text = "Nro Comprobante:";
            this.cbNumeroComprobante.UseVisualStyleBackColor = true;
            this.cbNumeroComprobante.CheckedChanged += new System.EventHandler(this.cbNumeroComprobante_CheckedChanged);
            // 
            // frmSaldoInicialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(334, 319);
            this.Controls.Add(this.cbNumeroComprobante);
            this.Controls.Add(this.ucNumeroComprobante);
            this.Controls.Add(this.txtCodigoVendedor);
            this.Controls.Add(this.lblNombreVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTipoComprobanteCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label4);
            this.Name = "frmSaldoInicialCliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        public System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.RadioButton rbDebito;
        private System.Windows.Forms.Label lblTipoComprobanteCliente;
        public System.Windows.Forms.TextBox txtImporte;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.TextBox txtCodigoVendedor;
        public System.Windows.Forms.Label lblNombreVendedor;
        public System.Windows.Forms.Label label3;
        private Presentacion.ucNumeroComprobante ucNumeroComprobante;
        private System.Windows.Forms.CheckBox cbNumeroComprobante;
    }
}
