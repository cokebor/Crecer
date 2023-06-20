namespace Presentacion
{
    partial class frmSaldoInicialProveedor
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
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbDebito = new System.Windows.Forms.RadioButton();
            this.lblTipoComprobanteProveedor = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(95, 46);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoProveedor.TabIndex = 2;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Location = new System.Drawing.Point(132, 50);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Proveedor (F6):";
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
            this.groupBox1.Location = new System.Drawing.Point(45, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 61);
            this.groupBox1.TabIndex = 3;
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
            // lblTipoComprobanteProveedor
            // 
            this.lblTipoComprobanteProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTipoComprobanteProveedor.ForeColor = System.Drawing.Color.Black;
            this.lblTipoComprobanteProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTipoComprobanteProveedor.Location = new System.Drawing.Point(20, 5);
            this.lblTipoComprobanteProveedor.Name = "lblTipoComprobanteProveedor";
            this.lblTipoComprobanteProveedor.Size = new System.Drawing.Size(163, 21);
            this.lblTipoComprobanteProveedor.TabIndex = 399;
            this.lblTipoComprobanteProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTipoComprobanteProveedor.Visible = false;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(109, 164);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(128, 20);
            this.txtImporte.TabIndex = 4;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 401;
            this.label2.Text = "Importe:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(248, 215);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(149, 215);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmSaldoInicialProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(334, 251);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTipoComprobanteProveedor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.label4);
            this.Name = "frmSaldoInicialProveedor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        public System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.RadioButton rbDebito;
        private System.Windows.Forms.Label lblTipoComprobanteProveedor;
        public System.Windows.Forms.TextBox txtImporte;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
    }
}
