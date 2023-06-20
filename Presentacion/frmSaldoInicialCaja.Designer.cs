using Controles2;


namespace Presentacion
{
    partial class frmSaldoInicialCaja
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFormaDePago = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.Label15 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(348, 183);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(107, 43);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(321, 20);
            this.txtObservaciones.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 389;
            this.label1.Text = "Observaciones:";
            // 
            // btnFormaDePago
            // 
            this.btnFormaDePago.Location = new System.Drawing.Point(310, 86);
            this.btnFormaDePago.Margin = new System.Windows.Forms.Padding(2);
            this.btnFormaDePago.Name = "btnFormaDePago";
            this.btnFormaDePago.Size = new System.Drawing.Size(118, 26);
            this.btnFormaDePago.TabIndex = 5;
            this.btnFormaDePago.Text = "FORMAS DE PAGO";
            this.btnFormaDePago.UseVisualStyleBackColor = true;
            this.btnFormaDePago.Click += new System.EventHandler(this.btnFormaDePago_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(262, 150);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 387;
            this.label14.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(327, 148);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 386;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(249, 183);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(344, 11);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 2;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(302, 15);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(40, 13);
            this.Label15.TabIndex = 54;
            this.Label15.Text = "Fecha:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(440, 219);
            this.shapeContainer1.TabIndex = 108;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 439;
            this.lineShape1.Y1 = 76;
            this.lineShape1.Y2 = 76;
            // 
            // frmSaldoInicialCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(440, 219);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFormaDePago);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.shapeContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSaldoInicialCaja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.DateTimePicker dtFecha;
        internal System.Windows.Forms.Label Label15;
        public System.Windows.Forms.Button btnConfirmar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnFormaDePago;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtObservaciones;
        public System.Windows.Forms.Button btnCancelar;
    }
}
