namespace Presentacion.Controles
{
    partial class ucPlazoFijo
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
            this.txtPlazo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCapital = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.txtTNA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.dtFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPlazo
            // 
            this.txtPlazo.Location = new System.Drawing.Point(83, 46);
            this.txtPlazo.Name = "txtPlazo";
            this.txtPlazo.ShortcutsEnabled = false;
            this.txtPlazo.Size = new System.Drawing.Size(44, 20);
            this.txtPlazo.TabIndex = 2;
            this.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPlazo.TextChanged += new System.EventHandler(this.txtPlazo_TextChanged);
            this.txtPlazo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlazo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 426;
            this.label6.Text = "Plazo en dias:";
            // 
            // txtCapital
            // 
            this.txtCapital.Location = new System.Drawing.Point(340, 46);
            this.txtCapital.Name = "txtCapital";
            this.txtCapital.ShortcutsEnabled = false;
            this.txtCapital.Size = new System.Drawing.Size(118, 20);
            this.txtCapital.TabIndex = 4;
            this.txtCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCapital.TextChanged += new System.EventHandler(this.txtCapital_TextChanged);
            this.txtCapital.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCapital_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 424;
            this.label5.Text = "Capital:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 422;
            this.label4.Text = "Nro de Cuenta:";
            // 
            // cbCuentaBancaria
            // 
            this.cbCuentaBancaria.FormattingEnabled = true;
            this.cbCuentaBancaria.Location = new System.Drawing.Point(340, 13);
            this.cbCuentaBancaria.Name = "cbCuentaBancaria";
            this.cbCuentaBancaria.Size = new System.Drawing.Size(118, 21);
            this.cbCuentaBancaria.TabIndex = 1;
            this.cbCuentaBancaria.SelectedIndexChanged += new System.EventHandler(this.cbCuentaBancaria_SelectedIndexChanged);
            this.cbCuentaBancaria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCuentaBancaria_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 421;
            this.label2.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(83, 13);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(140, 21);
            this.cbBancos.TabIndex = 0;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            this.cbBancos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbBancos_KeyPress);
            // 
            // txtTNA
            // 
            this.txtTNA.Location = new System.Drawing.Point(179, 46);
            this.txtTNA.Name = "txtTNA";
            this.txtTNA.ShortcutsEnabled = false;
            this.txtTNA.Size = new System.Drawing.Size(44, 20);
            this.txtTNA.TabIndex = 3;
            this.txtTNA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTNA.TextChanged += new System.EventHandler(this.txtTNA_TextChanged);
            this.txtTNA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTNA_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 428;
            this.label1.Text = "TNA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 429;
            this.label3.Text = "Interes:";
            // 
            // txtInteres
            // 
            this.txtInteres.Location = new System.Drawing.Point(340, 78);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.ShortcutsEnabled = false;
            this.txtInteres.Size = new System.Drawing.Size(118, 20);
            this.txtInteres.TabIndex = 6;
            this.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInteres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteres_KeyPress);
            // 
            // dtFechaVencimiento
            // 
            this.dtFechaVencimiento.Enabled = false;
            this.dtFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaVencimiento.Location = new System.Drawing.Point(83, 78);
            this.dtFechaVencimiento.Name = "dtFechaVencimiento";
            this.dtFechaVencimiento.Size = new System.Drawing.Size(86, 20);
            this.dtFechaVencimiento.TabIndex = 5;
            this.dtFechaVencimiento.ValueChanged += new System.EventHandler(this.dtFechaVencimiento_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 81);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 431;
            this.label7.Text = "Fecha Ven.:";
            // 
            // ucPlazoFijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtFechaVencimiento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInteres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTNA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlazo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCapital);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCuentaBancaria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBancos);
            this.Name = "ucPlazoFijo";
            this.Size = new System.Drawing.Size(469, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtPlazo;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtCapital;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbBancos;
        public System.Windows.Forms.TextBox txtTNA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtInteres;
        internal System.Windows.Forms.DateTimePicker dtFechaVencimiento;
        public System.Windows.Forms.Label label7;
    }
}
