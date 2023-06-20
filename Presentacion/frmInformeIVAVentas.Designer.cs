namespace Presentacion
{
    partial class frmInformeIVAVentas
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvInforme = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbPersonalizado = new System.Windows.Forms.RadioButton();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.cbMeses = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.dsFrutar = new Presentacion.dsFrutar();
            this.SP_IVASUCURSALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_IVASUCURSALESTableAdapter = new Presentacion.dsFrutarTableAdapters.SP_IVASUCURSALESTableAdapter();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_IVASUCURSALESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvInforme
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_IVASUCURSALESBindingSource;
            this.rvInforme.LocalReport.DataSources.Add(reportDataSource1);
            this.rvInforme.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.repIVAVentasSucursales.rdlc";
            this.rvInforme.Location = new System.Drawing.Point(12, 64);
            this.rvInforme.Name = "rvInforme";
            this.rvInforme.Size = new System.Drawing.Size(732, 429);
            this.rvInforme.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(682, 30);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 538;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtHasta
            // 
            this.dtHasta.Enabled = false;
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(463, 33);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(83, 20);
            this.dtHasta.TabIndex = 537;
            this.dtHasta.ValueChanged += new System.EventHandler(this.dtHasta_ValueChanged);
            // 
            // dtDesde
            // 
            this.dtDesde.Enabled = false;
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(320, 33);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(87, 20);
            this.dtDesde.TabIndex = 536;
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 535;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 534;
            this.label4.Text = "Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbPersonalizado);
            this.groupBox2.Controls.Add(this.rbMensual);
            this.groupBox2.Location = new System.Drawing.Point(13, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(236, 43);
            this.groupBox2.TabIndex = 533;
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
            this.rbPersonalizado.CheckedChanged += new System.EventHandler(this.rbPersonalizado_CheckedChanged);
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
            this.rbMensual.CheckedChanged += new System.EventHandler(this.rbMensual_CheckedChanged);
            // 
            // cbMeses
            // 
            this.cbMeses.FormattingEnabled = true;
            this.cbMeses.Location = new System.Drawing.Point(320, 6);
            this.cbMeses.Name = "cbMeses";
            this.cbMeses.Size = new System.Drawing.Size(138, 21);
            this.cbMeses.TabIndex = 532;
            this.cbMeses.SelectedIndexChanged += new System.EventHandler(this.cbMeses_SelectedIndexChanged);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(271, 9);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(30, 13);
            this.lblMes.TabIndex = 531;
            this.lblMes.Text = "Mes:";
            // 
            // dsFrutar
            // 
            this.dsFrutar.DataSetName = "dsFrutar";
            this.dsFrutar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_IVASUCURSALESBindingSource
            // 
            this.SP_IVASUCURSALESBindingSource.DataMember = "SP_IVASUCURSALES";
            this.SP_IVASUCURSALESBindingSource.DataSource = this.dsFrutar;
            // 
            // SP_IVASUCURSALESTableAdapter
            // 
            this.SP_IVASUCURSALESTableAdapter.ClearBeforeFill = true;
            // 
            // frmInformeIVAVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(750, 505);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbMeses);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.rvInforme);
            this.Name = "frmInformeIVAVentas";
            this.Load += new System.EventHandler(this.frmInformeIVAVentas_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_IVASUCURSALESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvInforme;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton rbPersonalizado;
        internal System.Windows.Forms.RadioButton rbMensual;
        internal System.Windows.Forms.ComboBox cbMeses;
        internal System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.BindingSource SP_IVASUCURSALESBindingSource;
        private dsFrutar dsFrutar;
        private dsFrutarTableAdapters.SP_IVASUCURSALESTableAdapter SP_IVASUCURSALESTableAdapter;
    }
}
