namespace Presentacion
{
    partial class frmLiquidacionDeSueldos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbTipoSalario = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNroCuenta = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFormaDePago = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 542;
            this.label3.Text = "Periodo:";
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Location = new System.Drawing.Point(286, 10);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(116, 21);
            this.cbPeriodo.TabIndex = 541;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(12, 14);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 540;
            this.lblTipo.Text = "Tipo:";
            // 
            // cbTipoSalario
            // 
            this.cbTipoSalario.FormattingEnabled = true;
            this.cbTipoSalario.Location = new System.Drawing.Point(99, 10);
            this.cbTipoSalario.Name = "cbTipoSalario";
            this.cbTipoSalario.Size = new System.Drawing.Size(116, 21);
            this.cbTipoSalario.TabIndex = 539;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(515, 514);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 538;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(468, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 531;
            this.label6.Text = "Fecha :";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(560, 10);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 530;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeight = 40;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoEmpleado,
            this.Legajo,
            this.DNI,
            this.Empleado,
            this.Monto});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvDatos.Location = new System.Drawing.Point(12, 85);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(678, 373);
            this.dgvDatos.TabIndex = 526;
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            this.dgvDatos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDatos_EditingControlShowing);
            // 
            // CodigoEmpleado
            // 
            this.CodigoEmpleado.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.CodigoEmpleado.DefaultCellStyle = dataGridViewCellStyle2;
            this.CodigoEmpleado.HeaderText = "CodigoEmpleado";
            this.CodigoEmpleado.Name = "CodigoEmpleado";
            this.CodigoEmpleado.Visible = false;
            // 
            // Legajo
            // 
            this.Legajo.DataPropertyName = "Legajo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0000";
            this.Legajo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            // 
            // DNI
            // 
            this.DNI.DataPropertyName = "NumeroDocumento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DNI.DefaultCellStyle = dataGridViewCellStyle4;
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            // 
            // Empleado
            // 
            this.Empleado.DataPropertyName = "Nombres";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Empleado.DefaultCellStyle = dataGridViewCellStyle5;
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            this.Empleado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Empleado.Width = 200;
            // 
            // Monto
            // 
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.Monto.DefaultCellStyle = dataGridViewCellStyle6;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.Width = 80;
            // 
            // lblNroCuenta
            // 
            this.lblNroCuenta.AutoSize = true;
            this.lblNroCuenta.Location = new System.Drawing.Point(468, 48);
            this.lblNroCuenta.Name = "lblNroCuenta";
            this.lblNroCuenta.Size = new System.Drawing.Size(79, 13);
            this.lblNroCuenta.TabIndex = 546;
            this.lblNroCuenta.Text = "Nro de Cuenta:";
            // 
            // cbCuentaBancaria
            // 
            this.cbCuentaBancaria.FormattingEnabled = true;
            this.cbCuentaBancaria.Location = new System.Drawing.Point(561, 44);
            this.cbCuentaBancaria.Name = "cbCuentaBancaria";
            this.cbCuentaBancaria.Size = new System.Drawing.Size(129, 21);
            this.cbCuentaBancaria.TabIndex = 544;
            this.cbCuentaBancaria.SelectedIndexChanged += new System.EventHandler(this.cbCuentaBancaria_SelectedIndexChanged);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(235, 48);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(41, 13);
            this.lblBanco.TabIndex = 545;
            this.lblBanco.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(286, 44);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(158, 21);
            this.cbBancos.TabIndex = 543;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 548;
            this.label1.Text = "Forma de Pago:";
            // 
            // cbFormaDePago
            // 
            this.cbFormaDePago.FormattingEnabled = true;
            this.cbFormaDePago.Location = new System.Drawing.Point(99, 44);
            this.cbFormaDePago.Name = "cbFormaDePago";
            this.cbFormaDePago.Size = new System.Drawing.Size(115, 21);
            this.cbFormaDePago.TabIndex = 547;
            this.cbFormaDePago.SelectedIndexChanged += new System.EventHandler(this.cbFormaDePago_SelectedIndexChanged_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(611, 514);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 549;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(499, 480);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 13);
            this.label22.TabIndex = 551;
            this.label22.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotal.Location = new System.Drawing.Point(557, 477);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(133, 18);
            this.lblTotal.TabIndex = 550;
            this.lblTotal.Text = "0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLiquidacionDeSueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(702, 551);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFormaDePago);
            this.Controls.Add(this.lblNroCuenta);
            this.Controls.Add(this.cbCuentaBancaria);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.cbBancos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPeriodo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cbTipoSalario);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmLiquidacionDeSueldos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargaSalarios_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblTipo;
        internal System.Windows.Forms.ComboBox cbTipoSalario;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.Label lblNroCuenta;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        private System.Windows.Forms.Label lblBanco;
        public System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbFormaDePago;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
    }
}
