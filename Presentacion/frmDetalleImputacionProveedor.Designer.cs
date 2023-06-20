namespace Presentacion
{
    partial class frmDetalleImputacionProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleImputacionProveedor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnEliminarProducto2 = new System.Windows.Forms.Button();
            this.lblRecibo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoDocumentoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumentoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imputado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(460, 537);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 71;
            this.btnConfirmar.Text = "CERRAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnEliminarProducto2
            // 
            this.btnEliminarProducto2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarProducto2.BackgroundImage")));
            this.btnEliminarProducto2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto2.Location = new System.Drawing.Point(524, 111);
            this.btnEliminarProducto2.Name = "btnEliminarProducto2";
            this.btnEliminarProducto2.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto2.TabIndex = 59;
            this.btnEliminarProducto2.UseVisualStyleBackColor = true;
            this.btnEliminarProducto2.Click += new System.EventHandler(this.btnEliminarProducto2_Click);
            // 
            // lblRecibo
            // 
            this.lblRecibo.AutoSize = true;
            this.lblRecibo.Location = new System.Drawing.Point(93, 66);
            this.lblRecibo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecibo.Name = "lblRecibo";
            this.lblRecibo.Size = new System.Drawing.Size(0, 13);
            this.lblRecibo.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Recibo:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(93, 42);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Fecha:";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(93, 18);
            this.lblProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblProveedor.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Proveedor:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.CodigoTipoDocumentoProveedor,
            this.Fecha,
            this.TipoDocumentoProveedor,
            this.Numero,
            this.Importe,
            this.Imputado});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDatos.Location = new System.Drawing.Point(11, 91);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(508, 435);
            this.dgvDatos.TabIndex = 52;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "CodigoFacturaCompra";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // CodigoTipoDocumentoProveedor
            // 
            this.CodigoTipoDocumentoProveedor.DataPropertyName = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.HeaderText = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.Name = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // TipoDocumentoProveedor
            // 
            this.TipoDocumentoProveedor.DataPropertyName = "TipoDocumentoProveedor";
            this.TipoDocumentoProveedor.HeaderText = "Descripción";
            this.TipoDocumentoProveedor.Name = "TipoDocumentoProveedor";
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle3;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Total";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle4;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // Imputado
            // 
            this.Imputado.DataPropertyName = "Imputado";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Imputado.DefaultCellStyle = dataGridViewCellStyle5;
            this.Imputado.HeaderText = "Imputado";
            this.Imputado.Name = "Imputado";
            // 
            // frmDetalleImputacionProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(559, 574);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnEliminarProducto2);
            this.Controls.Add(this.lblRecibo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmDetalleImputacionProveedor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblProveedor;
        public System.Windows.Forms.Label lblFecha;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblRecibo;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnEliminarProducto2;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoDocumentoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumentoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Imputado;
    }
}
