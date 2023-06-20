namespace Presentacion
{
    partial class frmMovimientosBancariosInforme
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
            this.SP_MOVIMIENTOSBANCARIOS_SELECTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsFrutar = new Presentacion.dsFrutar();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMovimientos = new System.Windows.Forms.ComboBox();
            this.rvInforme = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SP_MOVIMIENTOSBANCARIOS_SELECTTableAdapter = new Presentacion.dsFrutarTableAdapters.SP_MOVIMIENTOSBANCARIOS_SELECTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_MOVIMIENTOSBANCARIOS_SELECTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_MOVIMIENTOSBANCARIOS_SELECTBindingSource
            // 
            this.SP_MOVIMIENTOSBANCARIOS_SELECTBindingSource.DataMember = "SP_MOVIMIENTOSBANCARIOS_SELECT";
            this.SP_MOVIMIENTOSBANCARIOS_SELECTBindingSource.DataSource = this.dsFrutar;
            // 
            // dsFrutar
            // 
            this.dsFrutar.DataSetName = "dsFrutar";
            this.dsFrutar.EnforceConstraints = false;
            this.dsFrutar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 406;
            this.label4.Text = "Nro de Cuenta:";
            // 
            // cbCuentaBancaria
            // 
            this.cbCuentaBancaria.FormattingEnabled = true;
            this.cbCuentaBancaria.Location = new System.Drawing.Point(353, 12);
            this.cbCuentaBancaria.Name = "cbCuentaBancaria";
            this.cbCuentaBancaria.Size = new System.Drawing.Size(118, 21);
            this.cbCuentaBancaria.TabIndex = 404;
            this.cbCuentaBancaria.SelectedIndexChanged += new System.EventHandler(this.cbCuentaBancaria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 405;
            this.label2.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(68, 12);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(158, 21);
            this.cbBancos.TabIndex = 403;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(763, 13);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 410;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(570, 13);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 409;
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(718, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 408;
            this.label1.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(526, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 407;
            this.label3.Text = "Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 412;
            this.label5.Text = "Tipo:";
            // 
            // cbMovimientos
            // 
            this.cbMovimientos.FormattingEnabled = true;
            this.cbMovimientos.Location = new System.Drawing.Point(68, 49);
            this.cbMovimientos.Name = "cbMovimientos";
            this.cbMovimientos.Size = new System.Drawing.Size(158, 21);
            this.cbMovimientos.TabIndex = 411;
            this.cbMovimientos.SelectedIndexChanged += new System.EventHandler(this.cbMovimientos_SelectedIndexChanged);
            // 
            // rvInforme
            // 
            this.rvInforme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_MOVIMIENTOSBANCARIOS_SELECTBindingSource;
            this.rvInforme.LocalReport.DataSources.Add(reportDataSource1);
            this.rvInforme.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.repMovimientosBancarios.rdlc";
            this.rvInforme.Location = new System.Drawing.Point(24, 86);
            this.rvInforme.Name = "rvInforme";
            this.rvInforme.Size = new System.Drawing.Size(939, 434);
            this.rvInforme.TabIndex = 413;
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(888, 44);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 26);
            this.btnBuscar.TabIndex = 414;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // SP_MOVIMIENTOSBANCARIOS_SELECTTableAdapter
            // 
            this.SP_MOVIMIENTOSBANCARIOS_SELECTTableAdapter.ClearBeforeFill = true;
            // 
            // frmMovimientosBancariosInforme
            // 
            this.ClientSize = new System.Drawing.Size(975, 532);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.rvInforme);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbMovimientos);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCuentaBancaria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBancos);
            this.Name = "frmMovimientosBancariosInforme";
            ((System.ComponentModel.ISupportInitialize)(this.SP_MOVIMIENTOSBANCARIOS_SELECTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbMovimientos;
        private Microsoft.Reporting.WinForms.ReportViewer rvInforme;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.BindingSource SP_MOVIMIENTOSBANCARIOS_SELECTBindingSource;
        private dsFrutar dsFrutar;
        private dsFrutarTableAdapters.SP_MOVIMIENTOSBANCARIOS_SELECTTableAdapter SP_MOVIMIENTOSBANCARIOS_SELECTTableAdapter;
    }
}
