namespace Presentacion
{
    partial class frmRetencionesPercepciones
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbPersonalizado = new System.Windows.Forms.RadioButton();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.cbMeses = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(171, 138);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 524;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dtHasta
            // 
            this.dtHasta.Enabled = false;
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(204, 95);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(83, 20);
            this.dtHasta.TabIndex = 531;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(61, 138);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 523;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dtDesde
            // 
            this.dtDesde.Enabled = false;
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(61, 95);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(87, 20);
            this.dtDesde.TabIndex = 530;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 529;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 528;
            this.label4.Text = "Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbPersonalizado);
            this.groupBox2.Controls.Add(this.rbMensual);
            this.groupBox2.Location = new System.Drawing.Point(37, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(236, 43);
            this.groupBox2.TabIndex = 527;
            this.groupBox2.TabStop = false;
            // 
            // rbPersonalizado
            // 
            this.rbPersonalizado.Location = new System.Drawing.Point(127, 14);
            this.rbPersonalizado.Name = "rbPersonalizado";
            this.rbPersonalizado.Size = new System.Drawing.Size(104, 24);
            this.rbPersonalizado.TabIndex = 0;
            this.rbPersonalizado.Text = "Personalizado";
            this.rbPersonalizado.CheckedChanged += new System.EventHandler(this.rbPersonalizado_CheckedChanged);
            // 
            // rbMensual
            // 
            this.rbMensual.Checked = true;
            this.rbMensual.Location = new System.Drawing.Point(24, 14);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(104, 24);
            this.rbMensual.TabIndex = 1;
            this.rbMensual.TabStop = true;
            this.rbMensual.Text = "Mensual";
            this.rbMensual.CheckedChanged += new System.EventHandler(this.rbMensual_CheckedChanged);
            // 
            // cbMeses
            // 
            this.cbMeses.Location = new System.Drawing.Point(97, 59);
            this.cbMeses.Name = "cbMeses";
            this.cbMeses.Size = new System.Drawing.Size(121, 21);
            this.cbMeses.TabIndex = 532;
            // 
            // lblMes
            // 
            this.lblMes.Location = new System.Drawing.Point(0, 0);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(100, 23);
            this.lblMes.TabIndex = 533;
            // 
            // frmRetencionesPercepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(303, 178);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbMeses);
            this.Controls.Add(this.lblMes);
            this.Name = "frmRetencionesPercepciones";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dtHasta;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton rbPersonalizado;
        internal System.Windows.Forms.RadioButton rbMensual;
        internal System.Windows.Forms.ComboBox cbMeses;
        internal System.Windows.Forms.Label lblMes;
    }
}
