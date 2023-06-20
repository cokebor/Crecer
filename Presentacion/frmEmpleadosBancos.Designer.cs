
namespace Presentacion
{
    partial class frmEmpleadosBancos
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CuentaBancaria = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoEmpleado,
            this.Empleado,
            this.Banco,
            this.CuentaBancaria});
            this.dgvDatos.Location = new System.Drawing.Point(12, 12);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(591, 237);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            // 
            // CodigoEmpleado
            // 
            this.CodigoEmpleado.DataPropertyName = "Codigo";
            this.CodigoEmpleado.HeaderText = "CodigoEmpleado";
            this.CodigoEmpleado.Name = "CodigoEmpleado";
            this.CodigoEmpleado.Visible = false;
            // 
            // Empleado
            // 
            this.Empleado.DataPropertyName = "NombreCompleto";
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            // 
            // Banco
            // 
            this.Banco.DataPropertyName = "CodigoBanco";
            this.Banco.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            this.Banco.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Banco.Width = 120;
            // 
            // CuentaBancaria
            // 
            this.CuentaBancaria.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.CuentaBancaria.HeaderText = "Cta Bancaria";
            this.CuentaBancaria.Name = "CuentaBancaria";
            this.CuentaBancaria.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CuentaBancaria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CuentaBancaria.Width = 120;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(525, 262);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 105;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(426, 262);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 104;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmEmpleadosBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(615, 299);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmEmpleadosBancos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewComboBoxColumn Banco;
        private System.Windows.Forms.DataGridViewComboBoxColumn CuentaBancaria;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
    }
}
