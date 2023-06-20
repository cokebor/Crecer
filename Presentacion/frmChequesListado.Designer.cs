namespace Presentacion
{
    partial class frmChequesListado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbIngreso = new System.Windows.Forms.RadioButton();
            this.rbVencimiento = new System.Windows.Forms.RadioButton();
            this.rbEmision = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTiposEstados = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbIngreso);
            this.groupBox1.Controls.Add(this.rbVencimiento);
            this.groupBox1.Controls.Add(this.rbEmision);
            this.groupBox1.Location = new System.Drawing.Point(23, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango por Fechas";
            // 
            // rbIngreso
            // 
            this.rbIngreso.AutoSize = true;
            this.rbIngreso.Location = new System.Drawing.Point(229, 20);
            this.rbIngreso.Name = "rbIngreso";
            this.rbIngreso.Size = new System.Drawing.Size(60, 17);
            this.rbIngreso.TabIndex = 2;
            this.rbIngreso.Text = "Ingreso";
            this.rbIngreso.UseVisualStyleBackColor = true;
            // 
            // rbVencimiento
            // 
            this.rbVencimiento.AutoSize = true;
            this.rbVencimiento.Location = new System.Drawing.Point(117, 20);
            this.rbVencimiento.Name = "rbVencimiento";
            this.rbVencimiento.Size = new System.Drawing.Size(83, 17);
            this.rbVencimiento.TabIndex = 1;
            this.rbVencimiento.Text = "Vencimiento";
            this.rbVencimiento.UseVisualStyleBackColor = true;
            // 
            // rbEmision
            // 
            this.rbEmision.AutoSize = true;
            this.rbEmision.Checked = true;
            this.rbEmision.Location = new System.Drawing.Point(18, 20);
            this.rbEmision.Name = "rbEmision";
            this.rbEmision.Size = new System.Drawing.Size(61, 17);
            this.rbEmision.TabIndex = 0;
            this.rbEmision.TabStop = true;
            this.rbEmision.Text = "Emisión";
            this.rbEmision.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(246, 180);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(147, 180);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(230, 16);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(95, 20);
            this.dtHasta.TabIndex = 13;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(64, 16);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(95, 20);
            this.dtDesde.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(188, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Desde:";
            // 
            // cbTiposEstados
            // 
            this.cbTiposEstados.FormattingEnabled = true;
            this.cbTiposEstados.Location = new System.Drawing.Point(69, 137);
            this.cbTiposEstados.Name = "cbTiposEstados";
            this.cbTiposEstados.Size = new System.Drawing.Size(131, 21);
            this.cbTiposEstados.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Estado:";
            // 
            // frmChequesListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(349, 225);
            this.Controls.Add(this.cbTiposEstados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmChequesListado";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.RadioButton rbIngreso;
        private System.Windows.Forms.RadioButton rbVencimiento;
        private System.Windows.Forms.RadioButton rbEmision;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbTiposEstados;
        private System.Windows.Forms.Label label4;
    }
}
