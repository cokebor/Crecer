
namespace Presentacion
{
    partial class frmAdelantos
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
            this.txtCodigoEmpleado = new System.Windows.Forms.TextBox();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigoEmpleado
            // 
            this.txtCodigoEmpleado.Location = new System.Drawing.Point(96, 44);
            this.txtCodigoEmpleado.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoEmpleado.Name = "txtCodigoEmpleado";
            this.txtCodigoEmpleado.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoEmpleado.TabIndex = 1;
            this.txtCodigoEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoEmpleado.TextChanged += new System.EventHandler(this.txtCodigoEmpleado_TextChanged);
            this.txtCodigoEmpleado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoEmpleado_KeyDown);
            this.txtCodigoEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoEmpleado_KeyPress);
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.AutoSize = true;
            this.lblNombreEmpleado.Location = new System.Drawing.Point(133, 49);
            this.lblNombreEmpleado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(0, 13);
            this.lblNombreEmpleado.TabIndex = 402;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 401;
            this.label3.Text = "Empleado (F1):";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(747, 542);
            this.shapeContainer1.TabIndex = 61;
            this.shapeContainer1.TabStop = false;
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(392, 12);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 0;
            this.dtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFecha_KeyPress);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(343, 16);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(40, 13);
            this.Label15.TabIndex = 404;
            this.Label15.Text = "Fecha:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(392, 44);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(86, 20);
            this.txtImporte.TabIndex = 2;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtImporte_KeyDown);
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 406;
            this.label1.Text = "Importe:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Location = new System.Drawing.Point(19, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 104);
            this.groupBox1.TabIndex = 407;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(7, 20);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(446, 74);
            this.txtObservaciones.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(399, 190);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 409;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(304, 190);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmAdelantos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(492, 222);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.txtCodigoEmpleado);
            this.Controls.Add(this.lblNombreEmpleado);
            this.Controls.Add(this.label3);
            this.Name = "frmAdelantos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoEmpleado;
        public System.Windows.Forms.Label lblNombreEmpleado;
        public System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        internal System.Windows.Forms.Label Label15;
        public System.Windows.Forms.TextBox txtImporte;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
    }
}
