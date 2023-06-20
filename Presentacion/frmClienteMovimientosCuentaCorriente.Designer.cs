namespace Presentacion
{
    partial class frmClienteMovimientosCuentaCorriente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cbSaldo = new System.Windows.Forms.CheckBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.CodigoSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExportar.Location = new System.Drawing.Point(515, 511);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(79, 26);
            this.btnExportar.TabIndex = 394;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(609, 511);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 393;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(488, 483);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 392;
            this.label12.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotal.Location = new System.Drawing.Point(533, 480);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(157, 16);
            this.lblTotal.TabIndex = 391;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSaldo
            // 
            this.cbSaldo.AutoSize = true;
            this.cbSaldo.Location = new System.Drawing.Point(12, 21);
            this.cbSaldo.Name = "cbSaldo";
            this.cbSaldo.Size = new System.Drawing.Size(169, 17);
            this.cbSaldo.TabIndex = 82;
            this.cbSaldo.Text = "Solo Comprobantes con Saldo";
            this.cbSaldo.UseVisualStyleBackColor = true;
            this.cbSaldo.CheckedChanged += new System.EventHandler(this.cbSaldo_CheckedChanged);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Enabled = false;
            this.lblNombreCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreCliente.Location = new System.Drawing.Point(32, 20);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 80;
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(632, 13);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 79;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoSucursal,
            this.Codigo,
            this.Tipo,
            this.Fecha,
            this.TipoDocumento,
            this.Numero,
            this.Debito,
            this.Credito,
            this.Suma});
            this.dgvDatos.Location = new System.Drawing.Point(11, 54);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(681, 407);
            this.dgvDatos.TabIndex = 78;
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(507, 16);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 77;
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(463, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Desde";
            // 
            // CodigoSucursal
            // 
            this.CodigoSucursal.DataPropertyName = "CodigoSucursal";
            this.CodigoSucursal.HeaderText = "CodigoSucursal";
            this.CodigoSucursal.Name = "CodigoSucursal";
            this.CodigoSucursal.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Codigo.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tipo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tipo.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.DataPropertyName = "TipoDocumento";
            this.TipoDocumento.HeaderText = "Comprobante";
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle4;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Debito
            // 
            this.Debito.DataPropertyName = "Debito";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Debito.DefaultCellStyle = dataGridViewCellStyle5;
            this.Debito.HeaderText = "Débito";
            this.Debito.Name = "Debito";
            this.Debito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Credito
            // 
            this.Credito.DataPropertyName = "Credito";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.Credito.DefaultCellStyle = dataGridViewCellStyle6;
            this.Credito.HeaderText = "Crédito";
            this.Credito.Name = "Credito";
            this.Credito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Suma
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            this.Suma.DefaultCellStyle = dataGridViewCellStyle7;
            this.Suma.HeaderText = "Suma";
            this.Suma.Name = "Suma";
            this.Suma.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmClienteMovimientosCuentaCorriente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(700, 546);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.cbSaldo);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Name = "frmClienteMovimientosCuentaCorriente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.CheckBox cbSaldo;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suma;
    }
}
