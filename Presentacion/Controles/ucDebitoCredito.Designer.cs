namespace Presentacion
{
    partial class ucDebitoCredito
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCotizacion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNroCupon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblCuotas = new System.Windows.Forms.Label();
            this.cbCuotas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(108, 9);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(158, 21);
            this.cbBancos.TabIndex = 0;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            this.cbBancos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbBancos_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "Banco:";
            // 
            // lblCotizacion
            // 
            this.lblCotizacion.AutoSize = true;
            this.lblCotizacion.Location = new System.Drawing.Point(478, 13);
            this.lblCotizacion.Name = "lblCotizacion";
            this.lblCotizacion.Size = new System.Drawing.Size(0, 13);
            this.lblCotizacion.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Nro de Cuenta:";
            // 
            // cbCuentaBancaria
            // 
            this.cbCuentaBancaria.FormattingEnabled = true;
            this.cbCuentaBancaria.Location = new System.Drawing.Point(364, 9);
            this.cbCuentaBancaria.Name = "cbCuentaBancaria";
            this.cbCuentaBancaria.Size = new System.Drawing.Size(110, 21);
            this.cbCuentaBancaria.TabIndex = 1;
            this.cbCuentaBancaria.SelectedIndexChanged += new System.EventHandler(this.cbCuentaBancaria_SelectedIndexChanged);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(364, 65);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ShortcutsEnabled = false;
            this.txtImporte.Size = new System.Drawing.Size(95, 20);
            this.txtImporte.TabIndex = 3;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 408;
            this.label5.Text = "Importe:";
            // 
            // txtNroCupon
            // 
            this.txtNroCupon.Location = new System.Drawing.Point(108, 65);
            this.txtNroCupon.Name = "txtNroCupon";
            this.txtNroCupon.ShortcutsEnabled = false;
            this.txtNroCupon.Size = new System.Drawing.Size(158, 20);
            this.txtNroCupon.TabIndex = 2;
            this.txtNroCupon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroCupon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroCupon_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 411;
            this.label2.Text = "Nro Cupon:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(480, 62);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 409;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 413;
            this.label3.Text = "Tipo:";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(108, 37);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(158, 21);
            this.cbTipo.TabIndex = 414;
            // 
            // lblCuotas
            // 
            this.lblCuotas.AutoSize = true;
            this.lblCuotas.Location = new System.Drawing.Point(277, 39);
            this.lblCuotas.Name = "lblCuotas";
            this.lblCuotas.Size = new System.Drawing.Size(43, 13);
            this.lblCuotas.TabIndex = 416;
            this.lblCuotas.Text = "Cuotas:";
            // 
            // cbCuotas
            // 
            this.cbCuotas.FormattingEnabled = true;
            this.cbCuotas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cbCuotas.Location = new System.Drawing.Point(364, 37);
            this.cbCuotas.Name = "cbCuotas";
            this.cbCuotas.Size = new System.Drawing.Size(95, 21);
            this.cbCuotas.TabIndex = 415;
            // 
            // ucDebitoCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCuotas);
            this.Controls.Add(this.cbCuotas);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNroCupon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCuentaBancaria);
            this.Controls.Add(this.lblCotizacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBancos);
            this.Name = "ucDebitoCredito";
            this.Size = new System.Drawing.Size(513, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbBancos;
        public System.Windows.Forms.Label lblCotizacion;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        public System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.TextBox txtNroCupon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbTipo;
        public System.Windows.Forms.ComboBox cbCuotas;
        public System.Windows.Forms.Label lblCuotas;
    }
}
