namespace Presentacion
{
    partial class frmStockPorSucursal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbStockCero = new System.Windows.Forms.CheckBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Rubro,
            this.Producto,
            this.Stock,
            this.Estado});
            this.dgvDatos.Location = new System.Drawing.Point(5, 48);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(397, 426);
            this.dgvDatos.TabIndex = 8;
            this.dgvDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle6;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 5;
            // 
            // Rubro
            // 
            this.Rubro.DataPropertyName = "RubroProducto";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Rubro.DefaultCellStyle = dataGridViewCellStyle7;
            this.Rubro.HeaderText = "Rubro";
            this.Rubro.Name = "Rubro";
            this.Rubro.Visible = false;
            this.Rubro.Width = 5;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Descripcion";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.Width = 5;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle8;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cbStockCero
            // 
            this.cbStockCero.AutoSize = true;
            this.cbStockCero.Checked = true;
            this.cbStockCero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStockCero.Location = new System.Drawing.Point(13, 486);
            this.cbStockCero.Name = "cbStockCero";
            this.cbStockCero.Size = new System.Drawing.Size(191, 17);
            this.cbStockCero.TabIndex = 9;
            this.cbStockCero.Text = "Ocultar Productos con Stock Cero.";
            this.cbStockCero.UseVisualStyleBackColor = true;
            this.cbStockCero.CheckedChanged += new System.EventHandler(this.cbStockCero_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(323, 513);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 14;
            this.btnConfirmar.Text = "SALIR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(229, 513);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(79, 26);
            this.btnImprimir.TabIndex = 15;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblSucursales
            // 
            this.lblSucursales.AutoSize = true;
            this.lblSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSucursales.Location = new System.Drawing.Point(10, 14);
            this.lblSucursales.Name = "lblSucursales";
            this.lblSucursales.Size = new System.Drawing.Size(51, 13);
            this.lblSucursales.TabIndex = 395;
            this.lblSucursales.Text = "Sucursal:";
            this.lblSucursales.Visible = false;
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(78, 11);
            this.cbSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(94, 21);
            this.cbSucursales.TabIndex = 394;
            this.cbSucursales.Visible = false;
            this.cbSucursales.SelectedIndexChanged += new System.EventHandler(this.cbSucursales_SelectedIndexChanged);
            // 
            // frmStockPorSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(407, 547);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cbStockCero);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmStockPorSucursal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.CheckBox cbStockCero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.ComboBox cbSucursales;
    }
}
