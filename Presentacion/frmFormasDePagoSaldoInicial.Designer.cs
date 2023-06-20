namespace Presentacion
{
    partial class frmFormasDePagoSaldoInicial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.FormaDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Librador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFormasDePago = new System.Windows.Forms.ComboBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.ucCheque = new Presentacion.ucCheque();
            this.ucContado = new Presentacion.ucContado();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 397);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "Total:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(19, 392);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 118;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(398, 395);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 115;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = global::Presentacion.Properties.Resources.pencil;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(482, 204);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(25, 25);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = global::Presentacion.Properties.Resources.remove;
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(482, 164);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 4;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FormaDePago,
            this.Tipo,
            this.CodigoMoneda,
            this.Descripcion,
            this.Cotizacion,
            this.Importe2,
            this.Importe,
            this.CuentaContable,
            this.CodigoBanco,
            this.FechaEmision,
            this.FechaPago,
            this.Librador,
            this.NumeroCheque,
            this.CUIT,
            this.CodigoCuentaBancaria,
            this.CodigoCheque});
            this.dgvDatos.Location = new System.Drawing.Point(19, 164);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(446, 179);
            this.dgvDatos.TabIndex = 3;
            // 
            // FormaDePago
            // 
            this.FormaDePago.HeaderText = "FormaDePago";
            this.FormaDePago.Name = "FormaDePago";
            this.FormaDePago.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // CodigoMoneda
            // 
            this.CodigoMoneda.HeaderText = "CodigoMoneda";
            this.CodigoMoneda.Name = "CodigoMoneda";
            this.CodigoMoneda.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // Cotizacion
            // 
            this.Cotizacion.HeaderText = "Cotizacion";
            this.Cotizacion.Name = "Cotizacion";
            this.Cotizacion.Visible = false;
            // 
            // Importe2
            // 
            this.Importe2.HeaderText = "Importe2";
            this.Importe2.Name = "Importe2";
            this.Importe2.Visible = false;
            // 
            // Importe
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle1;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // CuentaContable
            // 
            this.CuentaContable.DataPropertyName = "CuentaContable";
            this.CuentaContable.HeaderText = "CuentaContable";
            this.CuentaContable.Name = "CuentaContable";
            this.CuentaContable.Visible = false;
            // 
            // CodigoBanco
            // 
            this.CodigoBanco.HeaderText = "CodigoBanco";
            this.CodigoBanco.Name = "CodigoBanco";
            this.CodigoBanco.Visible = false;
            // 
            // FechaEmision
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FechaEmision.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaEmision.HeaderText = "FechaEmision";
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.Visible = false;
            // 
            // FechaPago
            // 
            dataGridViewCellStyle3.Format = "d";
            this.FechaPago.DefaultCellStyle = dataGridViewCellStyle3;
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
            // NumeroCheque
            // 
            this.NumeroCheque.HeaderText = "NumeroCheque";
            this.NumeroCheque.Name = "NumeroCheque";
            this.NumeroCheque.Visible = false;
            // 
            // CUIT
            // 
            this.CUIT.HeaderText = "CUIT";
            this.CUIT.Name = "CUIT";
            this.CUIT.Visible = false;
            // 
            // CodigoCuentaBancaria
            // 
            this.CodigoCuentaBancaria.DataPropertyName = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.HeaderText = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.Name = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.Visible = false;
            // 
            // CodigoCheque
            // 
            this.CodigoCheque.HeaderText = "CodigoCheque";
            this.CodigoCheque.Name = "CodigoCheque";
            this.CodigoCheque.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Forma de Pago:";
            // 
            // cbFormasDePago
            // 
            this.cbFormasDePago.FormattingEnabled = true;
            this.cbFormasDePago.Location = new System.Drawing.Point(110, 9);
            this.cbFormasDePago.Margin = new System.Windows.Forms.Padding(2);
            this.cbFormasDePago.Name = "cbFormasDePago";
            this.cbFormasDePago.Size = new System.Drawing.Size(158, 21);
            this.cbFormasDePago.TabIndex = 0;
            this.cbFormasDePago.SelectedIndexChanged += new System.EventHandler(this.cbFormasDePago_SelectedIndexChanged);
            this.cbFormasDePago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFormasDePago_KeyPress);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(521, 429);
            this.shapeContainer1.TabIndex = 125;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(520, 428);
            // 
            // ucCheque
            // 
            this.ucCheque.Location = new System.Drawing.Point(1, 30);
            this.ucCheque.Margin = new System.Windows.Forms.Padding(4);
            this.ucCheque.Name = "ucCheque";
            this.ucCheque.Size = new System.Drawing.Size(516, 125);
            this.ucCheque.TabIndex = 2;
            // 
            // ucContado
            // 
            this.ucContado.Location = new System.Drawing.Point(1, 55);
            this.ucContado.Margin = new System.Windows.Forms.Padding(4);
            this.ucContado.Name = "ucContado";
            this.ucContado.Size = new System.Drawing.Size(516, 64);
            this.ucContado.TabIndex = 1;
            // 
            // frmFormasDePagoSaldoInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(521, 429);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.ucCheque);
            this.Controls.Add(this.ucContado);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFormasDePago);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmFormasDePagoSaldoInicial";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frmFormasDePago_Activated);
            this.Load += new System.EventHandler(this.frmFormasDePago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFormasDePago;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgvDatos;
        private Presentacion.ucContado ucContado;
        private Presentacion.ucCheque ucCheque;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminarProducto;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Librador;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCheque;
    }
}
