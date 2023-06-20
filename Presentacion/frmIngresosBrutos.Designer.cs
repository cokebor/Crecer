namespace Presentacion
{
    partial class frmIngresosBrutos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbPersonalizado = new System.Windows.Forms.RadioButton();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.cbMeses = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacturasA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacturasB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotasDeDebitoA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotasDeDebitoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotasDeCreditoA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotasdeCreditoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtHasta
            // 
            this.dtHasta.Enabled = false;
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(461, 39);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(83, 20);
            this.dtHasta.TabIndex = 529;
            // 
            // dtDesde
            // 
            this.dtDesde.Enabled = false;
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(318, 39);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(87, 20);
            this.dtDesde.TabIndex = 528;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 527;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 526;
            this.label4.Text = "Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbPersonalizado);
            this.groupBox2.Controls.Add(this.rbMensual);
            this.groupBox2.Location = new System.Drawing.Point(11, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(236, 43);
            this.groupBox2.TabIndex = 525;
            this.groupBox2.TabStop = false;
            // 
            // rbPersonalizado
            // 
            this.rbPersonalizado.AutoSize = true;
            this.rbPersonalizado.Location = new System.Drawing.Point(123, 16);
            this.rbPersonalizado.Name = "rbPersonalizado";
            this.rbPersonalizado.Size = new System.Drawing.Size(91, 17);
            this.rbPersonalizado.TabIndex = 7;
            this.rbPersonalizado.Text = "Personalizado";
            this.rbPersonalizado.UseVisualStyleBackColor = true;
            this.rbPersonalizado.CheckedChanged += new System.EventHandler(this.rbPersonalizado_CheckedChanged);
            // 
            // rbMensual
            // 
            this.rbMensual.AutoSize = true;
            this.rbMensual.Checked = true;
            this.rbMensual.Location = new System.Drawing.Point(22, 16);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(65, 17);
            this.rbMensual.TabIndex = 6;
            this.rbMensual.TabStop = true;
            this.rbMensual.Text = "Mensual";
            this.rbMensual.UseVisualStyleBackColor = true;
            this.rbMensual.CheckedChanged += new System.EventHandler(this.rbMensual_CheckedChanged);
            // 
            // cbMeses
            // 
            this.cbMeses.FormattingEnabled = true;
            this.cbMeses.Location = new System.Drawing.Point(318, 12);
            this.cbMeses.Name = "cbMeses";
            this.cbMeses.Size = new System.Drawing.Size(144, 21);
            this.cbMeses.TabIndex = 524;
            this.cbMeses.SelectedIndexChanged += new System.EventHandler(this.cbMeses_SelectedIndexChanged);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(269, 15);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(30, 13);
            this.lblMes.TabIndex = 523;
            this.lblMes.Text = "Mes:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(756, 35);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 530;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.FacturasA,
            this.FacturasB,
            this.NotasDeDebitoA,
            this.NotasDeDebitoB,
            this.NotasDeCreditoA,
            this.NotasdeCreditoB,
            this.Total});
            this.dgvDatos.Location = new System.Drawing.Point(11, 77);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(807, 193);
            this.dgvDatos.TabIndex = 531;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tipo.Width = 130;
            // 
            // FacturasA
            // 
            this.FacturasA.DataPropertyName = "Facturas_A";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.FacturasA.DefaultCellStyle = dataGridViewCellStyle2;
            this.FacturasA.HeaderText = "Facturas A";
            this.FacturasA.Name = "FacturasA";
            this.FacturasA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FacturasB
            // 
            this.FacturasB.DataPropertyName = "Facturas_B";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.FacturasB.DefaultCellStyle = dataGridViewCellStyle3;
            this.FacturasB.HeaderText = "Facturas B";
            this.FacturasB.Name = "FacturasB";
            this.FacturasB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NotasDeDebitoA
            // 
            this.NotasDeDebitoA.DataPropertyName = "ND_A";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.NotasDeDebitoA.DefaultCellStyle = dataGridViewCellStyle4;
            this.NotasDeDebitoA.HeaderText = "Notas de Débito A";
            this.NotasDeDebitoA.Name = "NotasDeDebitoA";
            this.NotasDeDebitoA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NotasDeDebitoB
            // 
            this.NotasDeDebitoB.DataPropertyName = "ND_B";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.NotasDeDebitoB.DefaultCellStyle = dataGridViewCellStyle5;
            this.NotasDeDebitoB.HeaderText = "Notas de Débito B";
            this.NotasDeDebitoB.Name = "NotasDeDebitoB";
            this.NotasDeDebitoB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NotasDeCreditoA
            // 
            this.NotasDeCreditoA.DataPropertyName = "NC_A";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.NotasDeCreditoA.DefaultCellStyle = dataGridViewCellStyle6;
            this.NotasDeCreditoA.HeaderText = "Notas de   Crédito A";
            this.NotasDeCreditoA.Name = "NotasDeCreditoA";
            this.NotasDeCreditoA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NotasdeCreditoB
            // 
            this.NotasdeCreditoB.DataPropertyName = "NC_B";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            this.NotasdeCreditoB.DefaultCellStyle = dataGridViewCellStyle7;
            this.NotasdeCreditoB.HeaderText = "Notas de   Crédito B";
            this.NotasdeCreditoB.Name = "NotasdeCreditoB";
            this.NotasdeCreditoB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle8;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnExportar
            // 
            this.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExportar.Location = new System.Drawing.Point(645, 283);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(79, 26);
            this.btnExportar.TabIndex = 533;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(739, 283);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 532;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmIngresosBrutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(829, 315);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbMeses);
            this.Controls.Add(this.lblMes);
            this.Name = "frmIngresosBrutos";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton rbPersonalizado;
        internal System.Windows.Forms.RadioButton rbMensual;
        internal System.Windows.Forms.ComboBox cbMeses;
        internal System.Windows.Forms.Label lblMes;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacturasA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacturasB;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotasDeDebitoA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotasDeDebitoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotasDeCreditoA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotasdeCreditoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
