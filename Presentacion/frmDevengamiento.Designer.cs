namespace Presentacion
{
    partial class frmDevengamiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevengamiento));
            this.label17 = new System.Windows.Forms.Label();
            this.cbConcepto = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbTipoSalario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCuentaContable = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblHasta = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbFecha = new System.Windows.Forms.CheckBox();
            this.cbPagos = new System.Windows.Forms.ComboBox();
            this.lblDebe = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.cbPago = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "Concepto:";
            // 
            // cbConcepto
            // 
            this.cbConcepto.FormattingEnabled = true;
            this.cbConcepto.Location = new System.Drawing.Point(86, 12);
            this.cbConcepto.Name = "cbConcepto";
            this.cbConcepto.Size = new System.Drawing.Size(162, 21);
            this.cbConcepto.TabIndex = 43;
            this.cbConcepto.SelectedIndexChanged += new System.EventHandler(this.cbConcepto_SelectedIndexChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(19, 53);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 520;
            this.lblTipo.Text = "Tipo:";
            // 
            // cbTipoSalario
            // 
            this.cbTipoSalario.FormattingEnabled = true;
            this.cbTipoSalario.Location = new System.Drawing.Point(86, 49);
            this.cbTipoSalario.Name = "cbTipoSalario";
            this.cbTipoSalario.Size = new System.Drawing.Size(116, 21);
            this.cbTipoSalario.TabIndex = 519;
            this.cbTipoSalario.SelectedIndexChanged += new System.EventHandler(this.cbTipoSalario_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 522;
            this.label3.Text = "Periodo:";
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Location = new System.Drawing.Point(392, 49);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(116, 21);
            this.cbPeriodo.TabIndex = 521;
            this.cbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cbPeriodo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 524;
            this.label1.Text = "Descripción:";
            // 
            // cbCuentaContable
            // 
            this.cbCuentaContable.FormattingEnabled = true;
            this.cbCuentaContable.Location = new System.Drawing.Point(86, 86);
            this.cbCuentaContable.Name = "cbCuentaContable";
            this.cbCuentaContable.Size = new System.Drawing.Size(206, 21);
            this.cbCuentaContable.TabIndex = 523;
            this.cbCuentaContable.SelectedIndexChanged += new System.EventHandler(this.cbCuentaContable_SelectedIndexChanged);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(392, 86);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(2);
            this.txtMonto.MaxLength = 15;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(116, 20);
            this.txtMonto.TabIndex = 525;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 526;
            this.label2.Text = "Monto:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoCuentaContable,
            this.CodigoConcepto,
            this.Descripcion,
            this.Debe2,
            this.Haber2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvDatos.Location = new System.Drawing.Point(22, 131);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(480, 140);
            this.dgvDatos.TabIndex = 529;
            // 
            // CodigoCuentaContable
            // 
            this.CodigoCuentaContable.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.ReadOnly = true;
            this.CodigoCuentaContable.Visible = false;
            // 
            // CodigoConcepto
            // 
            this.CodigoConcepto.HeaderText = "CodigoConcepto";
            this.CodigoConcepto.Name = "CodigoConcepto";
            this.CodigoConcepto.ReadOnly = true;
            this.CodigoConcepto.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 215;
            // 
            // Debe2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.Debe2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Debe2.HeaderText = "Debe";
            this.Debe2.Name = "Debe2";
            this.Debe2.ReadOnly = true;
            this.Debe2.Width = 124;
            // 
            // Haber2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.Haber2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Haber2.HeaderText = "Haber";
            this.Haber2.Name = "Haber2";
            this.Haber2.ReadOnly = true;
            this.Haber2.Width = 124;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(529, 135);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 25);
            this.btnEliminar.TabIndex = 528;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(529, 84);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 527;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(370, 286);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(110, 23);
            this.lblHasta.TabIndex = 531;
            this.lblHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(475, 358);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 533;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(382, 358);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 532;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Enabled = false;
            this.lblFecha.Location = new System.Drawing.Point(405, 16);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(43, 13);
            this.lblFecha.TabIndex = 535;
            this.lblFecha.Text = "Fecha :";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(453, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 534;
            // 
            // cbFecha
            // 
            this.cbFecha.AutoSize = true;
            this.cbFecha.Location = new System.Drawing.Point(382, 15);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(15, 14);
            this.cbFecha.TabIndex = 536;
            this.cbFecha.UseVisualStyleBackColor = true;
            this.cbFecha.CheckedChanged += new System.EventHandler(this.cbFecha_CheckedChanged);
            // 
            // cbPagos
            // 
            this.cbPagos.FormattingEnabled = true;
            this.cbPagos.Location = new System.Drawing.Point(86, 322);
            this.cbPagos.Name = "cbPagos";
            this.cbPagos.Size = new System.Drawing.Size(162, 21);
            this.cbPagos.TabIndex = 537;
            this.cbPagos.Visible = false;
            this.cbPagos.SelectedIndexChanged += new System.EventHandler(this.cbPagos_SelectedIndexChanged);
            // 
            // lblDebe
            // 
            this.lblDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebe.Location = new System.Drawing.Point(252, 286);
            this.lblDebe.Name = "lblDebe";
            this.lblDebe.Size = new System.Drawing.Size(110, 23);
            this.lblDebe.TabIndex = 530;
            this.lblDebe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPago
            // 
            this.lblPago.Location = new System.Drawing.Point(256, 326);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(298, 17);
            this.lblPago.TabIndex = 539;
            this.lblPago.Visible = false;
            // 
            // cbPago
            // 
            this.cbPago.AutoSize = true;
            this.cbPago.Location = new System.Drawing.Point(22, 326);
            this.cbPago.Name = "cbPago";
            this.cbPago.Size = new System.Drawing.Size(56, 17);
            this.cbPago.TabIndex = 540;
            this.cbPago.Text = "Pagos";
            this.cbPago.UseVisualStyleBackColor = true;
            this.cbPago.Visible = false;
            this.cbPago.CheckedChanged += new System.EventHandler(this.cbPago_CheckedChanged);
            // 
            // frmDevengamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(566, 393);
            this.Controls.Add(this.cbPago);
            this.Controls.Add(this.lblPago);
            this.Controls.Add(this.cbPagos);
            this.Controls.Add(this.cbFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDebe);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCuentaContable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPeriodo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cbTipoSalario);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbConcepto);
            this.Name = "frmDevengamiento";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cbConcepto;
        private System.Windows.Forms.Label lblTipo;
        internal System.Windows.Forms.ComboBox cbTipoSalario;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbCuentaContable;
        public System.Windows.Forms.TextBox txtMonto;
        public System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblHasta;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblFecha;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.CheckBox cbFecha;
        public System.Windows.Forms.ComboBox cbPagos;
        private System.Windows.Forms.Label lblDebe;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.CheckBox cbPago;
    }
}
