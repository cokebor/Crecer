namespace Presentacion
{
    partial class frmInformes
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
            this.ORIGINAL = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnTriplicado = new System.Windows.Forms.Button();
            this.btnDuplicado = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ORIGINAL
            // 
            this.ORIGINAL.Location = new System.Drawing.Point(3, 0);
            this.ORIGINAL.Name = "ORIGINAL";
            this.ORIGINAL.Size = new System.Drawing.Size(90, 23);
            this.ORIGINAL.TabIndex = 1;
            this.ORIGINAL.Text = "ORIGINAL";
            this.ORIGINAL.UseVisualStyleBackColor = true;
            this.ORIGINAL.Click += new System.EventHandler(this.ORIGINAL_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(457, 466);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.reportViewer1_ReportExport);
            // 
            // btnTriplicado
            // 
            this.btnTriplicado.Location = new System.Drawing.Point(195, 0);
            this.btnTriplicado.Name = "btnTriplicado";
            this.btnTriplicado.Size = new System.Drawing.Size(90, 23);
            this.btnTriplicado.TabIndex = 2;
            this.btnTriplicado.Text = "TRIPLICADO";
            this.btnTriplicado.UseVisualStyleBackColor = true;
            this.btnTriplicado.Click += new System.EventHandler(this.btnTriplicado_Click);
            // 
            // btnDuplicado
            // 
            this.btnDuplicado.Location = new System.Drawing.Point(99, 0);
            this.btnDuplicado.Name = "btnDuplicado";
            this.btnDuplicado.Size = new System.Drawing.Size(90, 23);
            this.btnDuplicado.TabIndex = 3;
            this.btnDuplicado.Text = "DUPLICADO";
            this.btnDuplicado.UseVisualStyleBackColor = true;
            this.btnDuplicado.Click += new System.EventHandler(this.btnDuplicado_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.ORIGINAL);
            this.panel.Controls.Add(this.btnTriplicado);
            this.panel.Controls.Add(this.btnDuplicado);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 443);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(457, 23);
            this.panel.TabIndex = 4;
            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(457, 466);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInformes";
            this.Load += new System.EventHandler(this.frmInformes_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button ORIGINAL;
        private System.Windows.Forms.Button btnTriplicado;
        private System.Windows.Forms.Button btnDuplicado;
        private System.Windows.Forms.Panel panel;
    }
}
