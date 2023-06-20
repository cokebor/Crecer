namespace Presentacion
{
    partial class frmAsociacionConceptosCuentasContables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsociacionConceptosCuentasContables));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label17 = new System.Windows.Forms.Label();
            this.cbConcepto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCuentaContable = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbDebe = new System.Windows.Forms.RadioButton();
            this.rbHaber = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAgregarGasto = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebeOHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebeOHaber2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "Concepto:";
            // 
            // cbConcepto
            // 
            this.cbConcepto.Enabled = false;
            this.cbConcepto.FormattingEnabled = true;
            this.cbConcepto.Location = new System.Drawing.Point(79, 11);
            this.cbConcepto.Name = "cbConcepto";
            this.cbConcepto.Size = new System.Drawing.Size(162, 21);
            this.cbConcepto.TabIndex = 0;
            this.cbConcepto.SelectedIndexChanged += new System.EventHandler(this.cbConcepto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Cuenta:";
            // 
            // cbCuentaContable
            // 
            this.cbCuentaContable.FormattingEnabled = true;
            this.cbCuentaContable.Location = new System.Drawing.Point(79, 42);
            this.cbCuentaContable.Name = "cbCuentaContable";
            this.cbCuentaContable.Size = new System.Drawing.Size(293, 21);
            this.cbCuentaContable.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(79, 74);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(162, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Descripción:";
            // 
            // rbDebe
            // 
            this.rbDebe.AutoSize = true;
            this.rbDebe.Checked = true;
            this.rbDebe.Location = new System.Drawing.Point(257, 74);
            this.rbDebe.Margin = new System.Windows.Forms.Padding(2);
            this.rbDebe.Name = "rbDebe";
            this.rbDebe.Size = new System.Drawing.Size(51, 17);
            this.rbDebe.TabIndex = 3;
            this.rbDebe.TabStop = true;
            this.rbDebe.Text = "Debe";
            this.rbDebe.UseVisualStyleBackColor = true;
            // 
            // rbHaber
            // 
            this.rbHaber.AutoSize = true;
            this.rbHaber.Location = new System.Drawing.Point(309, 74);
            this.rbHaber.Margin = new System.Windows.Forms.Padding(2);
            this.rbHaber.Name = "rbHaber";
            this.rbHaber.Size = new System.Drawing.Size(54, 17);
            this.rbHaber.TabIndex = 4;
            this.rbHaber.Text = "Haber";
            this.rbHaber.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(376, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAgregarGasto
            // 
            this.btnAgregarGasto.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregarGasto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarGasto.Location = new System.Drawing.Point(376, 115);
            this.btnAgregarGasto.Name = "btnAgregarGasto";
            this.btnAgregarGasto.Size = new System.Drawing.Size(25, 25);
            this.btnAgregarGasto.TabIndex = 5;
            this.btnAgregarGasto.UseVisualStyleBackColor = true;
            this.btnAgregarGasto.Click += new System.EventHandler(this.btnAgregarGasto_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.CuentaContable,
            this.DebeOHaber,
            this.DebeOHaber2});
            this.dgvDatos.Location = new System.Drawing.Point(14, 115);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(356, 110);
            this.dgvDatos.TabIndex = 403;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Descripcion.Width = 180;
            // 
            // CuentaContable
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CuentaContable.DefaultCellStyle = dataGridViewCellStyle1;
            this.CuentaContable.HeaderText = "Cuenta Contable";
            this.CuentaContable.Name = "CuentaContable";
            this.CuentaContable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DebeOHaber
            // 
            this.DebeOHaber.HeaderText = "";
            this.DebeOHaber.Name = "DebeOHaber";
            this.DebeOHaber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DebeOHaber2
            // 
            this.DebeOHaber2.HeaderText = "";
            this.DebeOHaber2.Name = "DebeOHaber2";
            this.DebeOHaber2.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(321, 243);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(104, 243);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(14, 243);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmAsociacionConceptosCuentasContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(406, 283);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAgregarGasto);
            this.Controls.Add(this.rbHaber);
            this.Controls.Add(this.rbDebe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCuentaContable);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbConcepto);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAsociacionConceptosCuentasContables";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cbConcepto;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbCuentaContable;
        public System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbDebe;
        private System.Windows.Forms.RadioButton rbHaber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAgregarGasto;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebeOHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebeOHaber2;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnConfirmar;
    }
}
