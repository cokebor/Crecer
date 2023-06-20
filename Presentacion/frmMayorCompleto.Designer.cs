namespace Presentacion
{
    partial class frmMayorCompleto
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
            this.SP_MAYORCOMPLETO_SELECTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsFrutar = new Presentacion.dsFrutar();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_MAYORCOMPLETO_SELECTTableAdapter = new Presentacion.dsFrutarTableAdapters.SP_MAYORCOMPLETO_SELECTTableAdapter();
            this.sP_MAYORCOMPLETO_SELECTSUCURSALESTableAdapter = new Presentacion.dsFrutarTableAdapters.SP_MAYORCOMPLETO_SELECTSUCURSALESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_MAYORCOMPLETO_SELECTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_MAYORCOMPLETO_SELECTBindingSource
            // 
            this.SP_MAYORCOMPLETO_SELECTBindingSource.DataMember = "SP_MAYORCOMPLETO_SELECT";
            this.SP_MAYORCOMPLETO_SELECTBindingSource.DataSource = this.dsFrutar;
            // 
            // dsFrutar
            // 
            this.dsFrutar.DataSetName = "dsFrutar";
            this.dsFrutar.EnforceConstraints = false;
            this.dsFrutar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_MAYORCOMPLETO_SELECTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.repMayorDetallado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(784, 514);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_MAYORCOMPLETO_SELECTTableAdapter
            // 
            this.SP_MAYORCOMPLETO_SELECTTableAdapter.ClearBeforeFill = true;
            // 
            // sP_MAYORCOMPLETO_SELECTSUCURSALESTableAdapter
            // 
            this.sP_MAYORCOMPLETO_SELECTSUCURSALESTableAdapter.ClearBeforeFill = true;
            // 
            // frmMayorCompleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 514);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmMayorCompleto";
            this.Load += new System.EventHandler(this.frmMayorCompleto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_MAYORCOMPLETO_SELECTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_MAYORCOMPLETO_SELECTBindingSource;
        private dsFrutar dsFrutar;
        private dsFrutarTableAdapters.SP_MAYORCOMPLETO_SELECTTableAdapter SP_MAYORCOMPLETO_SELECTTableAdapter;
        private dsFrutarTableAdapters.SP_MAYORCOMPLETO_SELECTSUCURSALESTableAdapter sP_MAYORCOMPLETO_SELECTSUCURSALESTableAdapter;
    }
}
