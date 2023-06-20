namespace Presentacion
{
    partial class frmConceptosAsociacion
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
            this.pDebeOhaber = new System.Windows.Forms.Panel();
            this.rbHaber = new System.Windows.Forms.RadioButton();
            this.rbDebe = new System.Windows.Forms.RadioButton();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebeOHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebeOHaber2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MostrarEnPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cbCuentaContable = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.cbMostrarEnPago = new System.Windows.Forms.CheckBox();
            this.pDebeOhaber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // pDebeOhaber
            // 
            this.pDebeOhaber.Controls.Add(this.rbHaber);
            this.pDebeOhaber.Controls.Add(this.rbDebe);
            this.pDebeOhaber.Enabled = false;
            this.pDebeOhaber.Location = new System.Drawing.Point(372, 118);
            this.pDebeOhaber.Name = "pDebeOhaber";
            this.pDebeOhaber.Size = new System.Drawing.Size(128, 26);
            this.pDebeOhaber.TabIndex = 130;
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
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion,
            this.CodigoCuentaContable,
            this.DebeOHaber,
            this.DebeOHaber2,
            this.Estado,
            this.MostrarEnPago});
            this.dgvDatos.Location = new System.Drawing.Point(11, 11);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(338, 197);
            this.dgvDatos.TabIndex = 129;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            // 
            // CodigoCuentaContable
            // 
            this.CodigoCuentaContable.DataPropertyName = "CodigoCuentaContable";
            this.CodigoCuentaContable.HeaderText = "Cuenta Contable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.Visible = false;
            // 
            // DebeOHaber
            // 
            this.DebeOHaber.DataPropertyName = "DebeOHaber";
            this.DebeOHaber.HeaderText = "";
            this.DebeOHaber.Name = "DebeOHaber";
            // 
            // DebeOHaber2
            // 
            this.DebeOHaber2.HeaderText = "";
            this.DebeOHaber2.Name = "DebeOHaber2";
            this.DebeOHaber2.Visible = false;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // MostrarEnPago
            // 
            this.MostrarEnPago.HeaderText = "MostrarEnPago";
            this.MostrarEnPago.Name = "MostrarEnPago";
            this.MostrarEnPago.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(575, 223);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 128;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(199, 223);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 127;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(109, 223);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 126;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(18, 223);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 125;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cbCuentaContable
            // 
            this.cbCuentaContable.Enabled = false;
            this.cbCuentaContable.FormattingEnabled = true;
            this.cbCuentaContable.Location = new System.Drawing.Point(440, 82);
            this.cbCuentaContable.Name = "cbCuentaContable";
            this.cbCuentaContable.Size = new System.Drawing.Size(214, 21);
            this.cbCuentaContable.TabIndex = 121;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 117;
            this.label5.Text = "Cuenta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Descripción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "Codigo:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(440, 49);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(214, 20);
            this.txtDescripcion.TabIndex = 110;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(435, 16);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 111;
            this.lblCodigo.Text = "(Codigo)";
            // 
            // cbMostrarEnPago
            // 
            this.cbMostrarEnPago.AutoSize = true;
            this.cbMostrarEnPago.Checked = true;
            this.cbMostrarEnPago.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMostrarEnPago.Enabled = false;
            this.cbMostrarEnPago.Location = new System.Drawing.Point(372, 162);
            this.cbMostrarEnPago.Name = "cbMostrarEnPago";
            this.cbMostrarEnPago.Size = new System.Drawing.Size(104, 17);
            this.cbMostrarEnPago.TabIndex = 131;
            this.cbMostrarEnPago.Text = "Mostrar en Pago";
            this.cbMostrarEnPago.UseVisualStyleBackColor = true;
            // 
            // frmConceptosAsociacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(666, 269);
            this.Controls.Add(this.cbMostrarEnPago);
            this.Controls.Add(this.pDebeOhaber);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cbCuentaContable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmConceptosAsociacion";
            this.pDebeOhaber.ResumeLayout(false);
            this.pDebeOhaber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbCuentaContable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.RadioButton rbHaber;
        private System.Windows.Forms.RadioButton rbDebe;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel pDebeOhaber;
        private System.Windows.Forms.CheckBox cbMostrarEnPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebeOHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebeOHaber2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn MostrarEnPago;
    }
}
