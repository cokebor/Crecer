namespace Presentacion
{
    partial class frmPreciosVentaInforme
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsFrutar = new Presentacion.dsFrutar();
            this.SP_PRECIOSVENTA_INFORMEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_PRECIOSVENTA_INFORMETableAdapter = new Presentacion.dsFrutarTableAdapters.SP_PRECIOSVENTA_INFORMETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_PRECIOSVENTA_INFORMEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_PRECIOSVENTA_INFORMEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.repPreciosProductos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(770, 576);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsFrutar
            // 
            this.dsFrutar.DataSetName = "dsFrutar";
            this.dsFrutar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_PRECIOSVENTA_INFORMEBindingSource
            // 
            this.SP_PRECIOSVENTA_INFORMEBindingSource.DataMember = "SP_PRECIOSVENTA_INFORME";
            this.SP_PRECIOSVENTA_INFORMEBindingSource.DataSource = this.dsFrutar;
            // 
            // SP_PRECIOSVENTA_INFORMETableAdapter
            // 
            this.SP_PRECIOSVENTA_INFORMETableAdapter.ClearBeforeFill = true;
            // 
            // frmPreciosVentaInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(770, 576);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmPreciosVentaInforme";
            this.Load += new System.EventHandler(this.frmPreciosVentaInforme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsFrutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_PRECIOSVENTA_INFORMEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_PRECIOSVENTA_INFORMEBindingSource;
        private dsFrutar dsFrutar;
        private dsFrutarTableAdapters.SP_PRECIOSVENTA_INFORMETableAdapter SP_PRECIOSVENTA_INFORMETableAdapter;
    }
}
