namespace Presentacion
{
    partial class frmChequesCartera
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Librador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(258, 314);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 13;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.Codigo,
            this.CodigoBanco,
            this.Banco,
            this.Numero,
            this.FechaEmision,
            this.FechaPago,
            this.Librador,
            this.CUIT,
            this.CodigoMoneda,
            this.Moneda,
            this.Cotizacion,
            this.Importe2,
            this.Importe,
            this.CodigoCuentaContable});
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(345, 308);
            this.dgvDatos.TabIndex = 12;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // Seleccionado
            // 
            this.Seleccionado.DataPropertyName = "Seleccionado";
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // CodigoBanco
            // 
            this.CodigoBanco.DataPropertyName = "CodigoBanco";
            this.CodigoBanco.HeaderText = "CodigoBanco";
            this.CodigoBanco.Name = "CodigoBanco";
            this.CodigoBanco.Visible = false;
            // 
            // Banco
            // 
            this.Banco.DataPropertyName = "Banco";
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "NroCheque";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // FechaEmision
            // 
            this.FechaEmision.HeaderText = "FechaEmision";
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.Visible = false;
            // 
            // FechaPago
            // 
            this.FechaPago.HeaderText = "FechaPago";
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.Visible = false;
            // 
            // Librador
            // 
            this.Librador.HeaderText = "Librador";
            this.Librador.Name = "Librador";
            this.Librador.Visible = false;
            // 
            // CUIT
            // 
            this.CUIT.HeaderText = "CUIT";
            this.CUIT.Name = "CUIT";
            this.CUIT.Visible = false;
            // 
            // CodigoMoneda
            // 
            this.CodigoMoneda.HeaderText = "CodigoMoneda";
            this.CodigoMoneda.Name = "CodigoMoneda";
            this.CodigoMoneda.Visible = false;
            // 
            // Moneda
            // 
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.Visible = false;
            // 
            // Cotizacion
            // 
            this.Cotizacion.HeaderText = "Cotizacion";
            this.Cotizacion.Name = "Cotizacion";
            this.Cotizacion.Visible = false;
            // 
            // Importe2
            // 
            this.Importe2.DataPropertyName = "Importe";
            this.Importe2.HeaderText = "Importe2";
            this.Importe2.Name = "Importe2";
            this.Importe2.Visible = false;
            // 
            // Importe
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // CodigoCuentaContable
            // 
            this.CodigoCuentaContable.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.Visible = false;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(345, 346);
            this.shapeContainer1.TabIndex = 14;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(344, 345);
            // 
            // frmChequesCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(345, 346);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmChequesCartera";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnConfirmar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Librador;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
    }
}
