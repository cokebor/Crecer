namespace Presentacion
{
    partial class frmMovimientosDeUnCheque
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
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewLinkColumn();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbChequesDuplicados = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Banco,
            this.Numero,
            this.FechaEmision,
            this.FechaPago,
            this.Importe,
            this.Estado});
            this.dgvDatos.Location = new System.Drawing.Point(19, 65);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(572, 297);
            this.dgvDatos.TabIndex = 420;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "CodigoCheque";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // FechaEmision
            // 
            this.FechaEmision.DataPropertyName = "FechaEmision";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaEmision.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaEmision.HeaderText = "Fecha Emision";
            this.FechaEmision.Name = "FechaEmision";
            // 
            // FechaPago
            // 
            this.FechaPago.DataPropertyName = "FechaPago";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaPago.DefaultCellStyle = dataGridViewCellStyle4;
            this.FechaPago.HeaderText = "Fecha Pago";
            this.FechaPago.Name = "FechaPago";
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle5;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "EstadoValor";
            this.Estado.HeaderText = "EstadoValor";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(328, 14);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(127, 20);
            this.txtNumero.TabIndex = 419;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(516, 11);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 26);
            this.btnBuscar.TabIndex = 418;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 417;
            this.label2.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(63, 14);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(158, 21);
            this.cbBancos.TabIndex = 416;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 415;
            this.label4.Text = "Nro Cheque:";
            // 
            // cbChequesDuplicados
            // 
            this.cbChequesDuplicados.AutoSize = true;
            this.cbChequesDuplicados.Location = new System.Drawing.Point(19, 42);
            this.cbChequesDuplicados.Name = "cbChequesDuplicados";
            this.cbChequesDuplicados.Size = new System.Drawing.Size(124, 17);
            this.cbChequesDuplicados.TabIndex = 421;
            this.cbChequesDuplicados.Text = "Cheques Duplicados";
            this.cbChequesDuplicados.UseVisualStyleBackColor = true;
            this.cbChequesDuplicados.CheckedChanged += new System.EventHandler(this.cbChequesDuplicados_CheckedChanged);
            // 
            // frmMovimientosDeUnCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(602, 366);
            this.Controls.Add(this.cbChequesDuplicados);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBancos);
            this.Controls.Add(this.label4);
            this.Name = "frmMovimientosDeUnCheque";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbBancos;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNumero;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewLinkColumn Estado;
        private System.Windows.Forms.CheckBox cbChequesDuplicados;
    }
}
