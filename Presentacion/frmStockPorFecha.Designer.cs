namespace Presentacion
{
    partial class frmStockPorFecha
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
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbCanal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(119, 48);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(83, 20);
            this.dtFecha.TabIndex = 522;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 520;
            this.label3.Text = "Fecha:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(161, 123);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 75;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(51, 123);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 74;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblSucursales
            // 
            this.lblSucursales.AutoSize = true;
            this.lblSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSucursales.Location = new System.Drawing.Point(63, 14);
            this.lblSucursales.Name = "lblSucursales";
            this.lblSucursales.Size = new System.Drawing.Size(51, 13);
            this.lblSucursales.TabIndex = 524;
            this.lblSucursales.Text = "Sucursal:";
            this.lblSucursales.Visible = false;
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(119, 11);
            this.cbSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(110, 21);
            this.cbSucursales.TabIndex = 523;
            this.cbSucursales.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(63, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 526;
            this.label17.Text = "Canal:";
            // 
            // cbCanal
            // 
            this.cbCanal.FormattingEnabled = true;
            this.cbCanal.Location = new System.Drawing.Point(119, 83);
            this.cbCanal.Name = "cbCanal";
            this.cbCanal.Size = new System.Drawing.Size(111, 21);
            this.cbCanal.TabIndex = 525;
            // 
            // frmStockPorFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbCanal);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmStockPorFecha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cbCanal;
    }
}
