namespace Presentacion
{
    partial class ucCheque
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
            this.components = new System.ComponentModel.Container();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.cmsBanco = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCotizacion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEmision = new System.Windows.Forms.DateTimePicker();
            this.dtpPago = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLibrador = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.ucCUIT = new Presentacion.ucCUIT();
            this.cmsBanco.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbBancos
            // 
            this.cbBancos.ContextMenuStrip = this.cmsBanco;
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(108, 9);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(158, 21);
            this.cbBancos.TabIndex = 0;
            this.cbBancos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbBancos_KeyPress);
            // 
            // cmsBanco
            // 
            this.cmsBanco.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBanco.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.cmsBanco.Name = "cmsBanco";
            this.cmsBanco.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Fecha Emision:";
            // 
            // lblCotizacion
            // 
            this.lblCotizacion.AutoSize = true;
            this.lblCotizacion.Location = new System.Drawing.Point(467, 13);
            this.lblCotizacion.Name = "lblCotizacion";
            this.lblCotizacion.Size = new System.Drawing.Size(0, 13);
            this.lblCotizacion.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Importe:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(364, 68);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ShortcutsEnabled = false;
            this.txtImporte.Size = new System.Drawing.Size(100, 20);
            this.txtImporte.TabIndex = 5;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(481, 95);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = true;

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Moneda:";
            // 
            // cbMoneda
            // 
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(364, 9);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(95, 21);
            this.cbMoneda.TabIndex = 1;
            this.cbMoneda.SelectedIndexChanged += new System.EventHandler(this.cbMoneda_SelectedIndexChanged);
            this.cbMoneda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbMoneda_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 114;
            this.label5.Text = "Fecha Pago:";
            // 
            // dtpEmision
            // 
            this.dtpEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmision.Location = new System.Drawing.Point(108, 39);
            this.dtpEmision.Name = "dtpEmision";
            this.dtpEmision.Size = new System.Drawing.Size(95, 20);
            this.dtpEmision.TabIndex = 2;
            this.dtpEmision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpEmision_KeyPress);
            // 
            // dtpPago
            // 
            this.dtpPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPago.Location = new System.Drawing.Point(364, 39);
            this.dtpPago.Name = "dtpPago";
            this.dtpPago.Size = new System.Drawing.Size(95, 20);
            this.dtpPago.TabIndex = 3;
            this.dtpPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpPago_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 118;
            this.label6.Text = "Librador:";
            // 
            // txtLibrador
            // 
            this.txtLibrador.Location = new System.Drawing.Point(108, 98);
            this.txtLibrador.Margin = new System.Windows.Forms.Padding(2);
            this.txtLibrador.Name = "txtLibrador";
            this.txtLibrador.Size = new System.Drawing.Size(158, 20);
            this.txtLibrador.TabIndex = 6;
            this.txtLibrador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLibrador_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 120;
            this.label7.Text = "C.U.I.T.:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 122;
            this.label8.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(108, 68);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(158, 20);
            this.txtNumero.TabIndex = 4;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // ucCUIT
            // 
            this.ucCUIT.AutoSize = true;
            this.ucCUIT.Location = new System.Drawing.Point(364, 98);
            this.ucCUIT.Name = "ucCUIT";
            this.ucCUIT.Size = new System.Drawing.Size(102, 23);
            this.ucCUIT.TabIndex = 7;
            this.ucCUIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ucCUIT_KeyPress);
            // 
            // ucCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ucCUIT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLibrador);
            this.Controls.Add(this.dtpPago);
            this.Controls.Add(this.dtpEmision);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbMoneda);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCotizacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBancos);
            this.Name = "ucCheque";
            this.Size = new System.Drawing.Size(509, 127);
            this.Load += new System.EventHandler(this.ucCheque_Load);
            this.cmsBanco.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblCotizacion;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip cmsBanco;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtLibrador;
        public System.Windows.Forms.DateTimePicker dtpEmision;
        public System.Windows.Forms.DateTimePicker dtpPago;
        private System.Windows.Forms.Label label7;
        public ucCUIT ucCUIT;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtNumero;
    }
}
