namespace Presentacion
{
    partial class frmAsientosAperturaCierre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsientosAperturaCierre));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaApertura = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEjercicio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCuentaContable = new System.Windows.Forms.ComboBox();
            this.pDebeOhaber = new System.Windows.Forms.Panel();
            this.rbHaber = new System.Windows.Forms.RadioButton();
            this.rbDebe = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminarProducto2 = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDebe = new System.Windows.Forms.Label();
            this.lblHaber = new System.Windows.Forms.Label();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.lblDifTitulo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pDebeOhaber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(48, 10);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(134, 21);
            this.cbTipo.TabIndex = 54;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Tipo:";
            // 
            // dtpFechaApertura
            // 
            this.dtpFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaApertura.Location = new System.Drawing.Point(667, 10);
            this.dtpFechaApertura.Name = "dtpFechaApertura";
            this.dtpFechaApertura.Size = new System.Drawing.Size(103, 20);
            this.dtpFechaApertura.TabIndex = 56;
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCierre.Location = new System.Drawing.Point(468, 10);
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(103, 20);
            this.dtpFechaCierre.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Fecha Apertura:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Fecha Cierre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 511;
            this.label3.Text = "Ejercicio:";
            // 
            // cbEjercicio
            // 
            this.cbEjercicio.FormattingEnabled = true;
            this.cbEjercicio.Location = new System.Drawing.Point(244, 10);
            this.cbEjercicio.Name = "cbEjercicio";
            this.cbEjercicio.Size = new System.Drawing.Size(144, 21);
            this.cbEjercicio.TabIndex = 510;
            this.cbEjercicio.SelectedIndexChanged += new System.EventHandler(this.cbEjercicio_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 513;
            this.label5.Text = "Cuenta Contable:";
            // 
            // cbCuentaContable
            // 
            this.cbCuentaContable.FormattingEnabled = true;
            this.cbCuentaContable.Location = new System.Drawing.Point(110, 47);
            this.cbCuentaContable.Name = "cbCuentaContable";
            this.cbCuentaContable.Size = new System.Drawing.Size(303, 21);
            this.cbCuentaContable.TabIndex = 512;
            this.cbCuentaContable.SelectedIndexChanged += new System.EventHandler(this.cbCuentaContable_SelectedIndexChanged);
            // 
            // pDebeOhaber
            // 
            this.pDebeOhaber.Controls.Add(this.rbHaber);
            this.pDebeOhaber.Controls.Add(this.rbDebe);
            this.pDebeOhaber.Location = new System.Drawing.Point(428, 44);
            this.pDebeOhaber.Name = "pDebeOhaber";
            this.pDebeOhaber.Size = new System.Drawing.Size(128, 26);
            this.pDebeOhaber.TabIndex = 514;
            // 
            // rbHaber
            // 
            this.rbHaber.AutoSize = true;
            this.rbHaber.Location = new System.Drawing.Point(63, 5);
            this.rbHaber.Margin = new System.Windows.Forms.Padding(2);
            this.rbHaber.Name = "rbHaber";
            this.rbHaber.Size = new System.Drawing.Size(54, 17);
            this.rbHaber.TabIndex = 124;
            this.rbHaber.Text = "Haber";
            this.rbHaber.UseVisualStyleBackColor = true;
            // 
            // rbDebe
            // 
            this.rbDebe.AutoSize = true;
            this.rbDebe.Checked = true;
            this.rbDebe.Location = new System.Drawing.Point(11, 5);
            this.rbDebe.Margin = new System.Windows.Forms.Padding(2);
            this.rbDebe.Name = "rbDebe";
            this.rbDebe.Size = new System.Drawing.Size(51, 17);
            this.rbDebe.TabIndex = 123;
            this.rbDebe.TabStop = true;
            this.rbDebe.Text = "Debe";
            this.rbDebe.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(580, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 516;
            this.label12.Text = "Importe:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(627, 47);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(95, 20);
            this.txtImporte.TabIndex = 515;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(745, 107);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(25, 25);
            this.btnEditar.TabIndex = 519;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminarProducto2
            // 
            this.btnEliminarProducto2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarProducto2.BackgroundImage")));
            this.btnEliminarProducto2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto2.Location = new System.Drawing.Point(745, 76);
            this.btnEliminarProducto2.Name = "btnEliminarProducto2";
            this.btnEliminarProducto2.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto2.TabIndex = 518;
            this.btnEliminarProducto2.UseVisualStyleBackColor = true;
            this.btnEliminarProducto2.Click += new System.EventHandler(this.btnEliminarProducto2_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(745, 45);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 517;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeight = 25;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoCuentaContable,
            this.CuentaContable,
            this.Debe,
            this.Haber});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvDatos.Location = new System.Drawing.Point(18, 76);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(704, 271);
            this.dgvDatos.TabIndex = 527;
            // 
            // CodigoCuentaContable
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.CodigoCuentaContable.DefaultCellStyle = dataGridViewCellStyle2;
            this.CodigoCuentaContable.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.ReadOnly = true;
            this.CodigoCuentaContable.Visible = false;
            // 
            // CuentaContable
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CuentaContable.DefaultCellStyle = dataGridViewCellStyle3;
            this.CuentaContable.HeaderText = "Cuenta Contable";
            this.CuentaContable.Name = "CuentaContable";
            this.CuentaContable.ReadOnly = true;
            this.CuentaContable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Debe
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "c2";
            this.Debe.DefaultCellStyle = dataGridViewCellStyle4;
            this.Debe.HeaderText = "Debe";
            this.Debe.Name = "Debe";
            this.Debe.ReadOnly = true;
            this.Debe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Haber
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.Haber.DefaultCellStyle = dataGridViewCellStyle5;
            this.Haber.HeaderText = "Haber";
            this.Haber.Name = "Haber";
            this.Haber.ReadOnly = true;
            this.Haber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblDebe
            // 
            this.lblDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebe.Location = new System.Drawing.Point(390, 357);
            this.lblDebe.Name = "lblDebe";
            this.lblDebe.Size = new System.Drawing.Size(100, 23);
            this.lblDebe.TabIndex = 528;
            this.lblDebe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHaber
            // 
            this.lblHaber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaber.Location = new System.Drawing.Point(211, 357);
            this.lblHaber.Name = "lblHaber";
            this.lblHaber.Size = new System.Drawing.Size(100, 23);
            this.lblHaber.TabIndex = 529;
            this.lblHaber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.Location = new System.Drawing.Point(622, 392);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(100, 23);
            this.lblDiferencia.TabIndex = 530;
            this.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDifTitulo
            // 
            this.lblDifTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifTitulo.Location = new System.Drawing.Point(467, 392);
            this.lblDifTitulo.Name = "lblDifTitulo";
            this.lblDifTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblDifTitulo.TabIndex = 531;
            this.lblDifTitulo.Text = "Diferencia:";
            this.lblDifTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(688, 430);
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
            this.btnConfirmar.Location = new System.Drawing.Point(595, 430);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 532;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmAsientosAperturaCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(778, 466);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblDifTitulo);
            this.Controls.Add(this.lblDiferencia);
            this.Controls.Add(this.lblHaber);
            this.Controls.Add(this.lblDebe);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminarProducto2);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.pDebeOhaber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbCuentaContable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEjercicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaCierre);
            this.Controls.Add(this.dtpFechaApertura);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label4);
            this.Name = "frmAsientosAperturaCierre";
            this.pDebeOhaber.ResumeLayout(false);
            this.pDebeOhaber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaApertura;
        private System.Windows.Forms.DateTimePicker dtpFechaCierre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cbEjercicio;
        internal System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbCuentaContable;
        private System.Windows.Forms.Panel pDebeOhaber;
        private System.Windows.Forms.RadioButton rbHaber;
        private System.Windows.Forms.RadioButton rbDebe;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtImporte;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnEliminarProducto2;
        public System.Windows.Forms.Button btnAgregar;
        internal System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber;
        private System.Windows.Forms.Label lblDebe;
        private System.Windows.Forms.Label lblHaber;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Label lblDifTitulo;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
    }
}
