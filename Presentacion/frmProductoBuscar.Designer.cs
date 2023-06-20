namespace Presentacion
{
    partial class frmProductoBuscar
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtDato = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Producto:";
            // 
            // dgvDatos
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Rubro,
            this.Producto,
            this.Estado});
            this.dgvDatos.Location = new System.Drawing.Point(13, 52);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(295, 395);
            this.dgvDatos.TabIndex = 6;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            this.dgvDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDatos_KeyDown);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 5;
            // 
            // Rubro
            // 
            this.Rubro.DataPropertyName = "RubroProducto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Rubro.DefaultCellStyle = dataGridViewCellStyle3;
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
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(72, 18);
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(235, 20);
            this.txtDato.TabIndex = 5;
            this.txtDato.TextChanged += new System.EventHandler(this.txtDato_TextChanged);
            this.txtDato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDato_KeyDown);
            // 
            // frmProductoBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(320, 459);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtDato);
            this.Name = "frmProductoBuscar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.TextBox txtDato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
    }
}
