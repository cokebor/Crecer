namespace Presentacion
{
    partial class frmIVA
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
            this.rbVentas = new System.Windows.Forms.RadioButton();
            this.rbCompras = new System.Windows.Forms.RadioButton();
            this.cbMeses = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbPersonalizado = new System.Windows.Forms.RadioButton();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbVentas
            // 
            this.rbVentas.AutoSize = true;
            this.rbVentas.Location = new System.Drawing.Point(138, 18);
            this.rbVentas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbVentas.Name = "rbVentas";
            this.rbVentas.Size = new System.Drawing.Size(58, 17);
            this.rbVentas.TabIndex = 1;
            this.rbVentas.Text = "Ventas";
            this.rbVentas.UseVisualStyleBackColor = true;
            this.rbVentas.CheckedChanged += new System.EventHandler(this.rbVentas_CheckedChanged);
            // 
            // rbCompras
            // 
            this.rbCompras.AutoSize = true;
            this.rbCompras.Checked = true;
            this.rbCompras.Location = new System.Drawing.Point(34, 17);
            this.rbCompras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCompras.Name = "rbCompras";
            this.rbCompras.Size = new System.Drawing.Size(66, 17);
            this.rbCompras.TabIndex = 0;
            this.rbCompras.TabStop = true;
            this.rbCompras.Text = "Compras";
            this.rbCompras.UseVisualStyleBackColor = true;
            this.rbCompras.CheckedChanged += new System.EventHandler(this.rbCompras_CheckedChanged);
            // 
            // cbMeses
            // 
            this.cbMeses.FormattingEnabled = true;
            this.cbMeses.Location = new System.Drawing.Point(95, 106);
            this.cbMeses.Name = "cbMeses";
            this.cbMeses.Size = new System.Drawing.Size(144, 21);
            this.cbMeses.TabIndex = 516;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(46, 109);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(30, 13);
            this.lblMes.TabIndex = 515;
            this.lblMes.Text = "Mes:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCompras);
            this.groupBox1.Controls.Add(this.rbVentas);
            this.groupBox1.Location = new System.Drawing.Point(26, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(236, 43);
            this.groupBox1.TabIndex = 517;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbPersonalizado);
            this.groupBox2.Controls.Add(this.rbMensual);
            this.groupBox2.Location = new System.Drawing.Point(26, 53);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(236, 43);
            this.groupBox2.TabIndex = 518;
            this.groupBox2.TabStop = false;
            // 
            // rbPersonalizado
            // 
            this.rbPersonalizado.AutoSize = true;
            this.rbPersonalizado.Location = new System.Drawing.Point(123, 16);
            this.rbPersonalizado.Name = "rbPersonalizado";
            this.rbPersonalizado.Size = new System.Drawing.Size(91, 17);
            this.rbPersonalizado.TabIndex = 7;
            this.rbPersonalizado.Text = "Personalizado";
            this.rbPersonalizado.UseVisualStyleBackColor = true;
            this.rbPersonalizado.CheckedChanged += new System.EventHandler(this.optPersonalizado_CheckedChanged);
            // 
            // rbMensual
            // 
            this.rbMensual.AutoSize = true;
            this.rbMensual.Checked = true;
            this.rbMensual.Location = new System.Drawing.Point(22, 16);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(65, 17);
            this.rbMensual.TabIndex = 6;
            this.rbMensual.TabStop = true;
            this.rbMensual.Text = "Mensual";
            this.rbMensual.UseVisualStyleBackColor = true;
            this.rbMensual.CheckedChanged += new System.EventHandler(this.optMes_CheckedChanged);
            // 
            // dtHasta
            // 
            this.dtHasta.Enabled = false;
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(193, 137);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(83, 20);
            this.dtHasta.TabIndex = 522;
            // 
            // dtDesde
            // 
            this.dtDesde.Enabled = false;
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(50, 137);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(87, 20);
            this.dtDesde.TabIndex = 521;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 520;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 519;
            this.label4.Text = "Desde:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(160, 176);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 75;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(50, 176);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 74;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmIVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 210);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbMeses);
            this.Controls.Add(this.lblMes);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmIVA";
            this.Load += new System.EventHandler(this.frmIVA_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbCompras;
        private System.Windows.Forms.RadioButton rbVentas;
        internal System.Windows.Forms.ComboBox cbMeses;
        internal System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton rbPersonalizado;
        internal System.Windows.Forms.RadioButton rbMensual;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
    }
}
