namespace Presentacion
{
    partial class frmInversionesInformes
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
            this.dgvFC = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFondos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbInversiones = new System.Windows.Forms.ComboBox();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.cbPendientes = new System.Windows.Forms.CheckBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fondo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intereses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFC
            // 
            this.dgvFC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Fecha,
            this.CodigoTipoOperacion,
            this.TipoOperacion,
            this.Fondo,
            this.NroReferencia,
            this.Debe,
            this.Haber,
            this.Saldo,
            this.Intereses,
            this.Eliminar});
            this.dgvFC.Location = new System.Drawing.Point(13, 89);
            this.dgvFC.Name = "dgvFC";
            this.dgvFC.Size = new System.Drawing.Size(937, 344);
            this.dgvFC.TabIndex = 431;
            this.dgvFC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFC_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(511, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 429;
            this.label7.Text = "Fondo:";
            // 
            // cbFondos
            // 
            this.cbFondos.Location = new System.Drawing.Point(557, 48);
            this.cbFondos.Name = "cbFondos";
            this.cbFondos.Size = new System.Drawing.Size(167, 21);
            this.cbFondos.TabIndex = 428;
            this.cbFondos.SelectedIndexChanged += new System.EventHandler(this.cbFondos_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 427;
            this.label6.Text = "Tipo Operación:";
            // 
            // cbTipoOperacion
            // 
            this.cbTipoOperacion.FormattingEnabled = true;
            this.cbTipoOperacion.Location = new System.Drawing.Point(340, 48);
            this.cbTipoOperacion.Name = "cbTipoOperacion";
            this.cbTipoOperacion.Size = new System.Drawing.Size(118, 21);
            this.cbTipoOperacion.TabIndex = 426;
            this.cbTipoOperacion.SelectedIndexChanged += new System.EventHandler(this.cbTipoOperacion_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(875, 43);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 26);
            this.btnBuscar.TabIndex = 425;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 424;
            this.label5.Text = "Inversion:";
            // 
            // cbInversiones
            // 
            this.cbInversiones.FormattingEnabled = true;
            this.cbInversiones.Location = new System.Drawing.Point(66, 48);
            this.cbInversiones.Name = "cbInversiones";
            this.cbInversiones.Size = new System.Drawing.Size(158, 21);
            this.cbInversiones.TabIndex = 423;
            this.cbInversiones.SelectedIndexChanged += new System.EventHandler(this.cbInversiones_SelectedIndexChanged);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(750, 12);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 422;
            this.dtHasta.ValueChanged += new System.EventHandler(this.dtHasta_ValueChanged);
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(557, 12);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 421;
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(705, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 420;
            this.label1.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 419;
            this.label3.Text = "Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 418;
            this.label4.Text = "Nro de Cuenta:";
            // 
            // cbCuentaBancaria
            // 
            this.cbCuentaBancaria.FormattingEnabled = true;
            this.cbCuentaBancaria.Location = new System.Drawing.Point(340, 11);
            this.cbCuentaBancaria.Name = "cbCuentaBancaria";
            this.cbCuentaBancaria.Size = new System.Drawing.Size(118, 21);
            this.cbCuentaBancaria.TabIndex = 416;
            this.cbCuentaBancaria.SelectedIndexChanged += new System.EventHandler(this.cbCuentaBancaria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 417;
            this.label2.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(66, 11);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(158, 21);
            this.cbBancos.TabIndex = 415;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            // 
            // cbPendientes
            // 
            this.cbPendientes.AutoSize = true;
            this.cbPendientes.Location = new System.Drawing.Point(750, 50);
            this.cbPendientes.Name = "cbPendientes";
            this.cbPendientes.Size = new System.Drawing.Size(103, 17);
            this.cbPendientes.TabIndex = 430;
            this.cbPendientes.Text = "Solo Pendientes";
            this.cbPendientes.UseVisualStyleBackColor = true;
            this.cbPendientes.Visible = false;
            this.cbPendientes.CheckedChanged += new System.EventHandler(this.cbPendientes_CheckedChanged);
            // 
            // btnExportar
            // 
            this.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExportar.Location = new System.Drawing.Point(777, 447);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(79, 26);
            this.btnExportar.TabIndex = 433;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(871, 447);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 432;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Codigo.Visible = false;
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
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Fecha.Width = 70;
            // 
            // CodigoTipoOperacion
            // 
            this.CodigoTipoOperacion.DataPropertyName = "CodigoTipoOperacion";
            this.CodigoTipoOperacion.HeaderText = "CodigoTipoOperacion";
            this.CodigoTipoOperacion.Name = "CodigoTipoOperacion";
            this.CodigoTipoOperacion.Visible = false;
            // 
            // TipoOperacion
            // 
            this.TipoOperacion.DataPropertyName = "TipoOperacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TipoOperacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.TipoOperacion.HeaderText = "Tipo Operación";
            this.TipoOperacion.Name = "TipoOperacion";
            this.TipoOperacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TipoOperacion.Width = 90;
            // 
            // Fondo
            // 
            this.Fondo.DataPropertyName = "Fondo";
            this.Fondo.HeaderText = "Fondo";
            this.Fondo.Name = "Fondo";
            this.Fondo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Fondo.Width = 160;
            // 
            // NroReferencia
            // 
            this.NroReferencia.DataPropertyName = "NroReferencia";
            this.NroReferencia.HeaderText = "Nro. referencia";
            this.NroReferencia.Name = "NroReferencia";
            this.NroReferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Debe
            // 
            this.Debe.DataPropertyName = "Debe";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Debe.DefaultCellStyle = dataGridViewCellStyle3;
            this.Debe.HeaderText = "Debe";
            this.Debe.Name = "Debe";
            this.Debe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Debe.Width = 110;
            // 
            // Haber
            // 
            this.Haber.DataPropertyName = "Haber";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Haber.DefaultCellStyle = dataGridViewCellStyle4;
            this.Haber.HeaderText = "Haber";
            this.Haber.Name = "Haber";
            this.Haber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Haber.Width = 110;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle5;
            this.Saldo.HeaderText = "Saldo/Tenencia";
            this.Saldo.Name = "Saldo";
            this.Saldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Saldo.Width = 110;
            // 
            // Intereses
            // 
            this.Intereses.DataPropertyName = "Intereses";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.Intereses.DefaultCellStyle = dataGridViewCellStyle6;
            this.Intereses.HeaderText = "Intereses";
            this.Intereses.Name = "Intereses";
            this.Intereses.Width = 110;
            // 
            // Eliminar
            // 
            this.Eliminar.ActiveLinkColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Eliminar.DefaultCellStyle = dataGridViewCellStyle7;
            this.Eliminar.HeaderText = "";
            this.Eliminar.LinkColor = System.Drawing.Color.Blue;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseColumnTextForLinkValue = true;
            this.Eliminar.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Eliminar.Width = 60;
            // 
            // frmInversionesInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 481);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvFC);
            this.Controls.Add(this.cbPendientes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbFondos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTipoOperacion);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbInversiones);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCuentaBancaria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBancos);
            this.Name = "frmInversionesInformes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbInversiones;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbTipoOperacion;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cbFondos;
        private System.Windows.Forms.DataGridView dgvFC;
        private System.Windows.Forms.CheckBox cbPendientes;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fondo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intereses;
        private System.Windows.Forms.DataGridViewLinkColumn Eliminar;
    }
}
