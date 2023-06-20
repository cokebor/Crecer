namespace Presentacion
{
    partial class frmCuentasContablesInforme
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
            this.V_CUENTASCONTABLESINFORMEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsFrutar = new Presentacion.dsFrutar();
            this.V_CUENTASCONTABLESINFORMETableAdapter = new Presentacion.dsFrutarTableAdapters.V_CUENTASCONTABLESINFORMETableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.V_CUENTASCONTABLESINFORMEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).BeginInit();
            this.SuspendLayout();
            // 
            // V_CUENTASCONTABLESINFORMEBindingSource
            // 
            this.V_CUENTASCONTABLESINFORMEBindingSource.DataMember = "V_CUENTASCONTABLESINFORME";
            this.V_CUENTASCONTABLESINFORMEBindingSource.DataSource = this.dsFrutar;
            // 
            // dsFrutar
            // 
            this.dsFrutar.DataSetName = "dsFrutar";
            this.dsFrutar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // V_CUENTASCONTABLESINFORMETableAdapter
            // 
            this.V_CUENTASCONTABLESINFORMETableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.V_CUENTASCONTABLESINFORMEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.repCuentasContables.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(539, 483);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmCuentasContablesInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(539, 483);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmCuentasContablesInforme";
            this.Text = "Cuentas Contables";
            this.Load += new System.EventHandler(this.frmCuentasContablesInforme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.V_CUENTASCONTABLESINFORMEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource V_CUENTASCONTABLESINFORMEBindingSource;
        private dsFrutar dsFrutar;
        private dsFrutarTableAdapters.V_CUENTASCONTABLESINFORMETableAdapter V_CUENTASCONTABLESINFORMETableAdapter;
    }
}
