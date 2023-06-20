namespace Presentacion
{
    partial class ucContado
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCotizacion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbMoneda
            // 
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(108, 9);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(158, 21);
            this.cbMoneda.TabIndex = 3;
            this.cbMoneda.SelectedIndexChanged += new System.EventHandler(this.cbMoneda_SelectedIndexChanged);
            this.cbMoneda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbMoneda_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "Moneda:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Cotización:";
            // 
            // lblCotizacion
            // 
            this.lblCotizacion.AutoSize = true;
            this.lblCotizacion.Location = new System.Drawing.Point(111, 47);
            this.lblCotizacion.Name = "lblCotizacion";
            this.lblCotizacion.Size = new System.Drawing.Size(0, 13);
            this.lblCotizacion.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Importe:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(370, 44);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ShortcutsEnabled = false;
            this.txtImporte.Size = new System.Drawing.Size(100, 20);
            this.txtImporte.TabIndex = 1;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(481, 41);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // ucContado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCotizacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMoneda);
            this.Name = "ucContado";
            this.Size = new System.Drawing.Size(509, 79);
            this.Load += new System.EventHandler(this.ucContado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblCotizacion;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.TextBox txtImporte;
    }
}
