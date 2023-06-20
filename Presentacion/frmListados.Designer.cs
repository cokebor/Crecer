namespace Presentacion
{
    partial class frmListados
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.optPersonalizado = new System.Windows.Forms.RadioButton();
            this.optPeriodo = new System.Windows.Forms.RadioButton();
            this.optMes = new System.Windows.Forms.RadioButton();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbLibroMayor = new System.Windows.Forms.RadioButton();
            this.rbSumasySaldos = new System.Windows.Forms.RadioButton();
            this.rbAsientos = new System.Windows.Forms.RadioButton();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMeses = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cbEjercicio = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbFechaEmision = new System.Windows.Forms.RadioButton();
            this.rbFechaContable = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.optPersonalizado);
            this.panel2.Controls.Add(this.optPeriodo);
            this.panel2.Controls.Add(this.optMes);
            this.panel2.Location = new System.Drawing.Point(28, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 25);
            this.panel2.TabIndex = 521;
            // 
            // optPersonalizado
            // 
            this.optPersonalizado.AutoSize = true;
            this.optPersonalizado.Location = new System.Drawing.Point(247, 3);
            this.optPersonalizado.Name = "optPersonalizado";
            this.optPersonalizado.Size = new System.Drawing.Size(91, 17);
            this.optPersonalizado.TabIndex = 5;
            this.optPersonalizado.Text = "Personalizado";
            this.optPersonalizado.UseVisualStyleBackColor = true;
            this.optPersonalizado.CheckedChanged += new System.EventHandler(this.optPersonalizado_CheckedChanged);
            // 
            // optPeriodo
            // 
            this.optPeriodo.AutoSize = true;
            this.optPeriodo.Checked = true;
            this.optPeriodo.Location = new System.Drawing.Point(28, 3);
            this.optPeriodo.Name = "optPeriodo";
            this.optPeriodo.Size = new System.Drawing.Size(80, 17);
            this.optPeriodo.TabIndex = 3;
            this.optPeriodo.TabStop = true;
            this.optPeriodo.Text = "Por Periodo";
            this.optPeriodo.UseVisualStyleBackColor = true;
            this.optPeriodo.CheckedChanged += new System.EventHandler(this.optPeriodo_CheckedChanged);
            // 
            // optMes
            // 
            this.optMes.AutoSize = true;
            this.optMes.Location = new System.Drawing.Point(145, 3);
            this.optMes.Name = "optMes";
            this.optMes.Size = new System.Drawing.Size(65, 17);
            this.optMes.TabIndex = 4;
            this.optMes.Text = "Mensual";
            this.optMes.UseVisualStyleBackColor = true;
            this.optMes.CheckedChanged += new System.EventHandler(this.optMes_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(322, 228);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 520;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbLibroMayor);
            this.panel1.Controls.Add(this.rbSumasySaldos);
            this.panel1.Controls.Add(this.rbAsientos);
            this.panel1.Location = new System.Drawing.Point(15, 177);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 37);
            this.panel1.TabIndex = 519;
            // 
            // rbLibroMayor
            // 
            this.rbLibroMayor.AutoSize = true;
            this.rbLibroMayor.Location = new System.Drawing.Point(292, 11);
            this.rbLibroMayor.Name = "rbLibroMayor";
            this.rbLibroMayor.Size = new System.Drawing.Size(80, 17);
            this.rbLibroMayor.TabIndex = 6;
            this.rbLibroMayor.Text = "Libro Mayor";
            this.rbLibroMayor.UseVisualStyleBackColor = true;
            this.rbLibroMayor.CheckedChanged += new System.EventHandler(this.rbLibroMayor_CheckedChanged);
            // 
            // rbSumasySaldos
            // 
            this.rbSumasySaldos.AutoSize = true;
            this.rbSumasySaldos.Location = new System.Drawing.Point(137, 11);
            this.rbSumasySaldos.Name = "rbSumasySaldos";
            this.rbSumasySaldos.Size = new System.Drawing.Size(100, 17);
            this.rbSumasySaldos.TabIndex = 5;
            this.rbSumasySaldos.Text = "Sumas y Saldos";
            this.rbSumasySaldos.UseVisualStyleBackColor = true;
            this.rbSumasySaldos.CheckedChanged += new System.EventHandler(this.rbSumasySaldos_CheckedChanged);
            // 
            // rbAsientos
            // 
            this.rbAsientos.AutoSize = true;
            this.rbAsientos.Checked = true;
            this.rbAsientos.Location = new System.Drawing.Point(13, 11);
            this.rbAsientos.Name = "rbAsientos";
            this.rbAsientos.Size = new System.Drawing.Size(65, 17);
            this.rbAsientos.TabIndex = 4;
            this.rbAsientos.TabStop = true;
            this.rbAsientos.Text = "Asientos";
            this.rbAsientos.UseVisualStyleBackColor = true;
            // 
            // dtHasta
            // 
            this.dtHasta.Enabled = false;
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(233, 148);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(83, 20);
            this.dtHasta.TabIndex = 518;
            // 
            // dtDesde
            // 
            this.dtDesde.Enabled = false;
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(73, 148);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(87, 20);
            this.dtDesde.TabIndex = 517;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 516;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 515;
            this.label4.Text = "Desde:";
            // 
            // cbMeses
            // 
            this.cbMeses.Enabled = false;
            this.cbMeses.FormattingEnabled = true;
            this.cbMeses.Location = new System.Drawing.Point(73, 116);
            this.cbMeses.Name = "cbMeses";
            this.cbMeses.Size = new System.Drawing.Size(144, 21);
            this.cbMeses.TabIndex = 514;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(13, 119);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(30, 13);
            this.Label2.TabIndex = 513;
            this.Label2.Text = "Mes:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(341, 82);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(65, 13);
            this.lblHasta.TabIndex = 512;
            this.lblHasta.Text = "00/00/0000";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(310, 82);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(15, 13);
            this.Label6.TabIndex = 511;
            this.Label6.Text = "al";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(241, 82);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(65, 13);
            this.lblDesde.TabIndex = 510;
            this.lblDesde.Text = "00/00/0000";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 13);
            this.Label1.TabIndex = 509;
            this.Label1.Text = "Ejercicio:";
            // 
            // cbEjercicio
            // 
            this.cbEjercicio.FormattingEnabled = true;
            this.cbEjercicio.Location = new System.Drawing.Point(73, 80);
            this.cbEjercicio.Name = "cbEjercicio";
            this.cbEjercicio.Size = new System.Drawing.Size(144, 21);
            this.cbEjercicio.TabIndex = 508;
            this.cbEjercicio.SelectedIndexChanged += new System.EventHandler(this.cbEjercicio_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbFechaEmision);
            this.panel3.Controls.Add(this.rbFechaContable);
            this.panel3.Location = new System.Drawing.Point(90, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(264, 21);
            this.panel3.TabIndex = 522;
            // 
            // rbFechaEmision
            // 
            this.rbFechaEmision.AutoSize = true;
            this.rbFechaEmision.Checked = true;
            this.rbFechaEmision.Location = new System.Drawing.Point(12, 0);
            this.rbFechaEmision.Name = "rbFechaEmision";
            this.rbFechaEmision.Size = new System.Drawing.Size(94, 17);
            this.rbFechaEmision.TabIndex = 5;
            this.rbFechaEmision.TabStop = true;
            this.rbFechaEmision.Text = "Fecha Emisión";
            this.rbFechaEmision.UseVisualStyleBackColor = true;
            this.rbFechaEmision.CheckedChanged += new System.EventHandler(this.rbFechaEmision_CheckedChanged);
            // 
            // rbFechaContable
            // 
            this.rbFechaContable.AutoSize = true;
            this.rbFechaContable.Location = new System.Drawing.Point(153, 0);
            this.rbFechaContable.Name = "rbFechaContable";
            this.rbFechaContable.Size = new System.Drawing.Size(100, 17);
            this.rbFechaContable.TabIndex = 6;
            this.rbFechaContable.Text = "Fecha Contable";
            this.rbFechaContable.UseVisualStyleBackColor = true;
            this.rbFechaContable.CheckedChanged += new System.EventHandler(this.rbFechaContable_CheckedChanged);
            // 
            // frmListados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(417, 266);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbMeses);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cbEjercicio);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmListados";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RadioButton optPersonalizado;
        internal System.Windows.Forms.RadioButton optMes;
        internal System.Windows.Forms.RadioButton optPeriodo;
        internal System.Windows.Forms.Label lblHasta;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblDesde;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cbEjercicio;
        internal System.Windows.Forms.ComboBox cbMeses;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.RadioButton rbAsientos;
        internal System.Windows.Forms.RadioButton rbLibroMayor;
        internal System.Windows.Forms.RadioButton rbSumasySaldos;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.RadioButton rbFechaEmision;
        internal System.Windows.Forms.RadioButton rbFechaContable;
    }
}
