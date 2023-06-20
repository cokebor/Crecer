namespace Presentacion
{
    partial class frmGastosDetalle
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFormassDePago = new System.Windows.Forms.DataGridView();
            this.NombreFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormassDePago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Formas de Pago";
            // 
            // dgvFormassDePago
            // 
            this.dgvFormassDePago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormassDePago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreFormaPago,
            this.MontoFormaPago,
            this.Ver});
            this.dgvFormassDePago.Location = new System.Drawing.Point(13, 195);
            this.dgvFormassDePago.Name = "dgvFormassDePago";
            this.dgvFormassDePago.Size = new System.Drawing.Size(374, 113);
            this.dgvFormassDePago.TabIndex = 2;
            this.dgvFormassDePago.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormassDePago_CellContentClick);
            // 
            // NombreFormaPago
            // 
            this.NombreFormaPago.DataPropertyName = "Descripcion";
            this.NombreFormaPago.HeaderText = "Descripcion";
            this.NombreFormaPago.Name = "NombreFormaPago";
            this.NombreFormaPago.Width = 250;
            // 
            // MontoFormaPago
            // 
            this.MontoFormaPago.DataPropertyName = "Monto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            this.MontoFormaPago.DefaultCellStyle = dataGridViewCellStyle1;
            this.MontoFormaPago.HeaderText = "Monto";
            this.MontoFormaPago.Name = "MontoFormaPago";
            // 
            // Ver
            // 
            this.Ver.HeaderText = "";
            this.Ver.Name = "Ver";
            this.Ver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ver.Text = "Ver";
            this.Ver.UseColumnTextForLinkValue = true;
            this.Ver.Width = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detalle";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Monto});
            this.dgvDetalle.Location = new System.Drawing.Point(13, 32);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(374, 126);
            this.dgvDetalle.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Descripcion";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 250;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle2;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            // 
            // frmGastosDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(399, 320);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvFormassDePago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetalle);
            this.Name = "frmGastosDetalle";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormassDePago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFormassDePago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreFormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoFormaPago;
        private System.Windows.Forms.DataGridViewLinkColumn Ver;
    }
}
