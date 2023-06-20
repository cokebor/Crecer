namespace Presentacion
{
    partial class frmIntegracion
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnIntegracionTotal = new System.Windows.Forms.Button();
            this.btnIntegracionParcial = new System.Windows.Forms.Button();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFinal = new System.Windows.Forms.Label();
            this.txtDatos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(35, 170);
            this.progressBar.Maximum = 120;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(481, 23);
            this.progressBar.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(35, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(481, 23);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIntegracionTotal
            // 
            this.btnIntegracionTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIntegracionTotal.Location = new System.Drawing.Point(343, 255);
            this.btnIntegracionTotal.Margin = new System.Windows.Forms.Padding(2);
            this.btnIntegracionTotal.Name = "btnIntegracionTotal";
            this.btnIntegracionTotal.Size = new System.Drawing.Size(79, 26);
            this.btnIntegracionTotal.TabIndex = 393;
            this.btnIntegracionTotal.Text = "TOTAL";
            this.btnIntegracionTotal.UseVisualStyleBackColor = true;
            this.btnIntegracionTotal.Click += new System.EventHandler(this.btnIntegracionTotal_Click);
            // 
            // btnIntegracionParcial
            // 
            this.btnIntegracionParcial.CausesValidation = false;
            this.btnIntegracionParcial.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIntegracionParcial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIntegracionParcial.Location = new System.Drawing.Point(437, 255);
            this.btnIntegracionParcial.Margin = new System.Windows.Forms.Padding(2);
            this.btnIntegracionParcial.Name = "btnIntegracionParcial";
            this.btnIntegracionParcial.Size = new System.Drawing.Size(79, 26);
            this.btnIntegracionParcial.TabIndex = 392;
            this.btnIntegracionParcial.Text = "PARCIAL";
            this.btnIntegracionParcial.UseVisualStyleBackColor = true;
            this.btnIntegracionParcial.Click += new System.EventHandler(this.btnIntegracionParcial_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.Location = new System.Drawing.Point(35, 206);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(0, 15);
            this.lblInicio.TabIndex = 394;
            this.lblInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinal.Location = new System.Drawing.Point(328, 202);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(0, 15);
            this.lblFinal.TabIndex = 395;
            this.lblFinal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDatos
            // 
            this.txtDatos.Location = new System.Drawing.Point(38, 55);
            this.txtDatos.Multiline = true;
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.ReadOnly = true;
            this.txtDatos.Size = new System.Drawing.Size(478, 98);
            this.txtDatos.TabIndex = 396;
            // 
            // frmIntegracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(551, 296);
            this.Controls.Add(this.txtDatos);
            this.Controls.Add(this.lblFinal);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.btnIntegracionTotal);
            this.Controls.Add(this.btnIntegracionParcial);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.progressBar);
            this.Name = "frmIntegracion";
            this.Load += new System.EventHandler(this.frmIntegracion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnIntegracionTotal;
        private System.Windows.Forms.Button btnIntegracionParcial;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.TextBox txtDatos;
    }
}
