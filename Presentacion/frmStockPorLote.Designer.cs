namespace Presentacion
{
    partial class frmStockPorLote
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
            this.cbStockCero = new System.Windows.Forms.CheckBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStockCero
            // 
            this.cbStockCero.AutoSize = true;
            this.cbStockCero.Checked = true;
            this.cbStockCero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStockCero.Location = new System.Drawing.Point(13, 253);
            this.cbStockCero.Name = "cbStockCero";
            this.cbStockCero.Size = new System.Drawing.Size(169, 17);
            this.cbStockCero.TabIndex = 15;
            this.cbStockCero.Text = "Ocultar Lotes con Stock Cero.";
            this.cbStockCero.UseVisualStyleBackColor = true;
            this.cbStockCero.CheckedChanged += new System.EventHandler(this.cbStockCero_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(235, 262);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 13;
            this.btnConfirmar.Text = "SALIR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lote,
            this.Proveedor,
            this.Stock});
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(325, 238);
            this.dgvDatos.TabIndex = 12;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(325, 299);
            this.shapeContainer1.TabIndex = 14;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(324, 297);
            // 
            // Lote
            // 
            this.Lote.DataPropertyName = "Lote";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Lote.DefaultCellStyle = dataGridViewCellStyle5;
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.Width = 60;
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Proveedor";
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.Width = 200;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle6;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.Width = 60;
            // 
            // frmStockPorLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(325, 299);
            this.Controls.Add(this.cbStockCero);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.shapeContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmStockPorLote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnConfirmar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.CheckBox cbStockCero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
    }
}
