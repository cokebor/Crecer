namespace Presentacion.Controles
{
    partial class ucFondoComunRescate
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
            this.txtCapital = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCodigoInversiones = new System.Windows.Forms.ComboBox();
            this.txtPlazo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVariacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCapital
            // 
            this.txtCapital.Location = new System.Drawing.Point(340, 46);
            this.txtCapital.Name = "txtCapital";
            this.txtCapital.ReadOnly = true;
            this.txtCapital.ShortcutsEnabled = false;
            this.txtCapital.Size = new System.Drawing.Size(118, 20);
            this.txtCapital.TabIndex = 4;
            this.txtCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.txtInteres.TextChanged += new System.EventHandler(this.txtInteres_TextChanged);
            this.txtInteres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteres_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 433;
            this.label1.Text = "Codigo:";
            // 
            // cbCodigoInversiones
            // 
            this.cbCodigoInversiones.FormattingEnabled = true;
            this.cbCodigoInversiones.Location = new System.Drawing.Point(83, 45);
            this.cbCodigoInversiones.Name = "cbCodigoInversiones";
            this.cbCodigoInversiones.Size = new System.Drawing.Size(51, 21);
            this.cbCodigoInversiones.TabIndex = 432;
            this.cbCodigoInversiones.SelectedIndexChanged += new System.EventHandler(this.cbCodigoInversiones_SelectedIndexChanged);
            // 
            // txtPlazo
            // 
            this.txtPlazo.Location = new System.Drawing.Point(205, 45);
            this.txtPlazo.Name = "txtPlazo";
            this.txtPlazo.ReadOnly = true;
            this.txtPlazo.ShortcutsEnabled = false;
            this.txtPlazo.Size = new System.Drawing.Size(44, 20);
            this.txtPlazo.TabIndex = 434;
            this.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(151, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 435;
            this.label6.Text = "Plazo:";
            // 
            // txtVariacion
            // 
            this.txtVariacion.Location = new System.Drawing.Point(205, 78);
            this.txtVariacion.Name = "txtVariacion";
            this.txtVariacion.ReadOnly = true;
            this.txtVariacion.ShortcutsEnabled = false;
            this.txtVariacion.Size = new System.Drawing.Size(44, 20);
            this.txtVariacion.TabIndex = 436;
            this.txtVariacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 437;
            this.label8.Text = "Variación:";
            // 
            // ucFondoComunRescate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtVariacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPlazo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCodigoInversiones);
            this.Controls.Add(this.txtInteres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCapital);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCuentaBancaria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBancos);
            this.Name = "ucFondoComunRescate";
            this.Size = new System.Drawing.Size(469, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtCapital;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtInteres;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbCodigoInversiones;
        public System.Windows.Forms.TextBox txtPlazo;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtVariacion;
        private System.Windows.Forms.Label label8;
    }
}
