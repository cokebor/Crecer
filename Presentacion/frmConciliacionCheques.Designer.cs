namespace Presentacion
{
    partial class frmConciliacionCheques
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
            this.label4 = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CodigoCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMovimientoBancario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Nro de Cuenta:";
            // 
            // cbCuentaBancaria
            // 
            this.cbCuentaBancaria.FormattingEnabled = true;
            this.cbCuentaBancaria.Location = new System.Drawing.Point(326, 12);
            this.cbCuentaBancaria.Name = "cbCuentaBancaria";
            this.cbCuentaBancaria.Size = new System.Drawing.Size(113, 21);
            this.cbCuentaBancaria.TabIndex = 115;
            this.cbCuentaBancaria.SelectedIndexChanged += new System.EventHandler(this.cbCuentaBancaria_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(53, 12);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(158, 21);
            this.cbBancos.TabIndex = 114;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(481, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 427;
            this.label6.Text = "Fecha :";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(529, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 426;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.CodigoCheque,
            this.Banco,
            this.CodigoMovimientoBancario,
            this.NroCheque,
            this.FechaEmision,
            this.FechaPago,
            this.Importe});
            this.dgvDatos.Location = new System.Drawing.Point(9, 58);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(621, 354);
            this.dgvDatos.TabIndex = 428;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CodigoCheque
            // 
            this.CodigoCheque.DataPropertyName = "CodigoCheque";
            this.CodigoCheque.HeaderText = "CodigoCheque";
            this.CodigoCheque.Name = "CodigoCheque";
            this.CodigoCheque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CodigoCheque.Visible = false;
            // 
            // Banco
            // 
            this.Banco.DataPropertyName = "Banco";
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            this.Banco.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CodigoMovimientoBancario
            // 
            this.CodigoMovimientoBancario.DataPropertyName = "CodigoMovimientoBancario";
            this.CodigoMovimientoBancario.HeaderText = "CodigoMovimientoBancario";
            this.CodigoMovimientoBancario.Name = "CodigoMovimientoBancario";
            this.CodigoMovimientoBancario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CodigoMovimientoBancario.Visible = false;
            // 
            // NroCheque
            // 
            this.NroCheque.DataPropertyName = "NroCheque";
            this.NroCheque.HeaderText = "Nro Cheque";
            this.NroCheque.Name = "NroCheque";
            this.NroCheque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FechaEmision
            // 
            this.FechaEmision.DataPropertyName = "FechaEmision";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.FechaEmision.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaEmision.HeaderText = "Fecha Emision";
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FechaPago
            // 
            this.FechaPago.DataPropertyName = "FechaPago";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FechaPago.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaPago.HeaderText = "Fecha Pago";
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle3;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(436, 440);
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
            this.lblTotal.Location = new System.Drawing.Point(499, 438);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(127, 15);
            this.lblTotal.TabIndex = 429;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(551, 465);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 432;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(452, 465);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 431;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmConciliacionCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(637, 502);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCuentaBancaria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBancos);
            this.Name = "frmConciliacionCheques";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMovimientoBancario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
    }
}
