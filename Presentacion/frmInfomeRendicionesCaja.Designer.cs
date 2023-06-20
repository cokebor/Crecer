namespace Presentacion
{
    partial class frmInfomeRendicionesCaja
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
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSucursalDestino = new System.Windows.Forms.Label();
            this.txtCodigoSucursal = new System.Windows.Forms.TextBox();
            this.lblNombreSucursal = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pesos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheques = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(246, 12);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 11;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(53, 12);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(201, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Desde";
            // 
            // lblSucursalDestino
            // 
            this.lblSucursalDestino.AutoSize = true;
            this.lblSucursalDestino.Location = new System.Drawing.Point(374, 15);
            this.lblSucursalDestino.Name = "lblSucursalDestino";
            this.lblSucursalDestino.Size = new System.Drawing.Size(51, 13);
            this.lblSucursalDestino.TabIndex = 82;
            this.lblSucursalDestino.Text = "Sucursal:";
            // 
            // txtCodigoSucursal
            // 
            this.txtCodigoSucursal.Location = new System.Drawing.Point(429, 12);
            this.txtCodigoSucursal.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoSucursal.Name = "txtCodigoSucursal";
            this.txtCodigoSucursal.ShortcutsEnabled = false;
            this.txtCodigoSucursal.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoSucursal.TabIndex = 80;
            this.txtCodigoSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoSucursal.TextChanged += new System.EventHandler(this.txtCodigoSucursal_TextChanged);
            this.txtCodigoSucursal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoSucursal_KeyPress);
            // 
            // lblNombreSucursal
            // 
            this.lblNombreSucursal.AutoSize = true;
            this.lblNombreSucursal.Enabled = false;
            this.lblNombreSucursal.Location = new System.Drawing.Point(474, 16);
            this.lblNombreSucursal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreSucursal.Name = "lblNombreSucursal";
            this.lblNombreSucursal.Size = new System.Drawing.Size(0, 13);
            this.lblNombreSucursal.TabIndex = 81;
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(649, 6);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 83;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Numero,
            this.Observaciones,
            this.Pesos,
            this.Dolares,
            this.Cheques});
            this.dgvDatos.Location = new System.Drawing.Point(11, 39);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(700, 414);
            this.dgvDatos.TabIndex = 84;
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
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pesos
            // 
            this.Pesos.DataPropertyName = "Pesos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.Pesos.DefaultCellStyle = dataGridViewCellStyle3;
            this.Pesos.HeaderText = "Pesos";
            this.Pesos.Name = "Pesos";
            this.Pesos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Dolares
            // 
            this.Dolares.DataPropertyName = "Dolares";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Dolares.DefaultCellStyle = dataGridViewCellStyle4;
            this.Dolares.HeaderText = "Dolares";
            this.Dolares.Name = "Dolares";
            this.Dolares.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cheques
            // 
            this.Cheques.DataPropertyName = "Cheques";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Cheques.DefaultCellStyle = dataGridViewCellStyle5;
            this.Cheques.HeaderText = "Cheques";
            this.Cheques.Name = "Cheques";
            this.Cheques.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnCerrar
            // 
            this.btnCerrar.CausesValidation = false;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCerrar.Location = new System.Drawing.Point(649, 461);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(62, 26);
            this.btnCerrar.TabIndex = 85;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmInfomeRendicionesCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(722, 498);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblSucursalDestino);
            this.Controls.Add(this.txtCodigoSucursal);
            this.Controls.Add(this.lblNombreSucursal);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmInfomeRendicionesCaja";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSucursalDestino;
        public System.Windows.Forms.TextBox txtCodigoSucursal;
        public System.Windows.Forms.Label lblNombreSucursal;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pesos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheques;
        public System.Windows.Forms.Button btnCerrar;
    }
}
