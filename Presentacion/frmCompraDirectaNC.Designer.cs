namespace Presentacion
{
    partial class frmCompraDirectaNC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Renglon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadDevuelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cbComprobantes = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Renglon,
            this.Codigo,
            this.Descripción,
            this.Lote,
            this.Cantidad,
            this.PorcIva,
            this.PrecioUnitario,
            this.Iva,
            this.CantidadDevuelta,
            this.Total});
            this.dgvDatos.Location = new System.Drawing.Point(26, 37);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(564, 247);
            this.dgvDatos.TabIndex = 121;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            this.dgvDatos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDatos_EditingControlShowing);
            // 
            // Renglon
            // 
            this.Renglon.HeaderText = "Renglon";
            this.Renglon.Name = "Renglon";
            this.Renglon.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Descripción
            // 
            this.Descripción.DataPropertyName = "Descripcion";
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.Name = "Descripción";
            // 
            // Lote
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lote.DefaultCellStyle = dataGridViewCellStyle2;
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            // 
            // Cantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // PorcIva
            // 
            this.PorcIva.HeaderText = "PorcIva";
            this.PorcIva.Name = "PorcIva";
            this.PorcIva.ReadOnly = true;
            this.PorcIva.Visible = false;
            // 
            // PrecioUnitario
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.PrecioUnitario.DefaultCellStyle = dataGridViewCellStyle4;
            this.PrecioUnitario.HeaderText = "Prec. U.";
            this.PrecioUnitario.Name = "PrecioUnitario";
            // 
            // Iva
            // 
            this.Iva.HeaderText = "Iva";
            this.Iva.Name = "Iva";
            this.Iva.Visible = false;
            // 
            // CantidadDevuelta
            // 
            this.CantidadDevuelta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CantidadDevuelta.DefaultCellStyle = dataGridViewCellStyle5;
            this.CantidadDevuelta.HeaderText = "Cant. Devuelta";
            this.CantidadDevuelta.Name = "CantidadDevuelta";
            // 
            // Total
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle6;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 120;
            this.label3.Text = "Comprobante:";
            // 
            // cbComprobantes
            // 
            this.cbComprobantes.FormattingEnabled = true;
            this.cbComprobantes.Location = new System.Drawing.Point(141, 9);
            this.cbComprobantes.Margin = new System.Windows.Forms.Padding(2);
            this.cbComprobantes.Name = "cbComprobantes";
            this.cbComprobantes.Size = new System.Drawing.Size(158, 21);
            this.cbComprobantes.TabIndex = 119;
            this.cbComprobantes.SelectedIndexChanged += new System.EventHandler(this.cbComprobantes_SelectedIndexChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(511, 299);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 118;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(612, 336);
            this.shapeContainer1.TabIndex = 122;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(608, 333);
            this.rectangleShape1.Click += new System.EventHandler(this.rectangleShape1_Click);
            // 
            // frmCompraDirectaNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(612, 336);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbComprobantes);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCompraDirectaNC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCompraDirecta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.ComboBox cbComprobantes;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Renglon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadDevuelta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}
