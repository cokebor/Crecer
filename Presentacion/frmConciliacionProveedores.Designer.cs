namespace Presentacion
{
    partial class frmConciliacionProveedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CodigoPagoSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoDocumentoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Efectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheques = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCierreCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.CodigoPagoSucursal,
            this.Fecha,
            this.CodigoTipoDocumentoProveedor,
            this.Documento,
            this.CodigoProveedor,
            this.Proveedor,
            this.Numero,
            this.Efectivo,
            this.Cheques,
            this.TotalPago,
            this.CodigoCuentaContable,
            this.CodigoCierreCaja});
            this.dgvDatos.Location = new System.Drawing.Point(9, 46);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(743, 354);
            this.dgvDatos.TabIndex = 428;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(557, 420);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 430;
            this.label14.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(620, 418);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(127, 15);
            this.lblTotal.TabIndex = 429;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(672, 445);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 432;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(573, 445);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 431;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblSucursales
            // 
            this.lblSucursales.AutoSize = true;
            this.lblSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSucursales.Location = new System.Drawing.Point(586, 14);
            this.lblSucursales.Name = "lblSucursales";
            this.lblSucursales.Size = new System.Drawing.Size(51, 13);
            this.lblSucursales.TabIndex = 440;
            this.lblSucursales.Text = "Sucursal:";
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(642, 11);
            this.cbSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(110, 21);
            this.cbSucursales.TabIndex = 439;
            this.cbSucursales.SelectedIndexChanged += new System.EventHandler(this.cbSucursales_SelectedIndexChanged);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CodigoPagoSucursal
            // 
            this.CodigoPagoSucursal.DataPropertyName = "CodigoPago";
            this.CodigoPagoSucursal.HeaderText = "CodigoPagoSucursal";
            this.CodigoPagoSucursal.Name = "CodigoPagoSucursal";
            this.CodigoPagoSucursal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CodigoPagoSucursal.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // CodigoTipoDocumentoProveedor
            // 
            this.CodigoTipoDocumentoProveedor.DataPropertyName = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.HeaderText = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.Name = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.Visible = false;
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "Documento";
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            // 
            // CodigoProveedor
            // 
            this.CodigoProveedor.DataPropertyName = "CodigoProveedor";
            this.CodigoProveedor.HeaderText = "CodigoProveedor";
            this.CodigoProveedor.Name = "CodigoProveedor";
            this.CodigoProveedor.Visible = false;
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Proveedor";
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.Numero.HeaderText = "Nro Recibo";
            this.Numero.Name = "Numero";
            this.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Efectivo
            // 
            this.Efectivo.DataPropertyName = "Efectivo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Efectivo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Efectivo.HeaderText = "Efectivo";
            this.Efectivo.Name = "Efectivo";
            this.Efectivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cheques
            // 
            this.Cheques.DataPropertyName = "Cheques";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Cheques.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cheques.HeaderText = "Cheques";
            this.Cheques.Name = "Cheques";
            this.Cheques.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalPago
            // 
            this.TotalPago.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.TotalPago.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalPago.HeaderText = "Total";
            this.TotalPago.Name = "TotalPago";
            this.TotalPago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CodigoCuentaContable
            // 
            this.CodigoCuentaContable.DataPropertyName = "CodigoCuentaContable";
            this.CodigoCuentaContable.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.Visible = false;
            // 
            // CodigoCierreCaja
            // 
            this.CodigoCierreCaja.DataPropertyName = "CodigoCierreCaja";
            this.CodigoCierreCaja.HeaderText = "CodigoCierreCaja";
            this.CodigoCierreCaja.Name = "CodigoCierreCaja";
            this.CodigoCierreCaja.Visible = false;
            // 
            // frmConciliacionProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(764, 484);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmConciliacionProveedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPagoSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoDocumentoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Efectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheques;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCierreCaja;
    }
}
