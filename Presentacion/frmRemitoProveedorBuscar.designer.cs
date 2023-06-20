namespace Presentacion
{
    partial class frmRemitoProveedorBuscar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDato = new System.Windows.Forms.TextBox();
            this.cbTiempo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Proveedor / Remito:";
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
            this.Fecha,
            this.Nombre,
            this.Remito});
            this.dgvDatos.Location = new System.Drawing.Point(13, 52);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(340, 395);
            this.dgvDatos.TabIndex = 2;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Codigo.HeaderText = "Cod. Remito";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Proveedor";
            this.Nombre.Name = "Nombre";
            // 
            // Remito
            // 
            this.Remito.DataPropertyName = "NumRemito2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Remito.DefaultCellStyle = dataGridViewCellStyle3;
            this.Remito.HeaderText = "Remito";
            this.Remito.Name = "Remito";
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(121, 18);
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(232, 20);
            this.txtDato.TabIndex = 1;
            this.txtDato.TextChanged += new System.EventHandler(this.txtDato_TextChanged);
            // 
            // cbTiempo
            // 
            this.cbTiempo.AutoSize = true;
            this.cbTiempo.Checked = true;
            this.cbTiempo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTiempo.Location = new System.Drawing.Point(15, 453);
            this.cbTiempo.Margin = new System.Windows.Forms.Padding(2);
            this.cbTiempo.Name = "cbTiempo";
            this.cbTiempo.Size = new System.Drawing.Size(113, 17);
            this.cbTiempo.TabIndex = 5;
            this.cbTiempo.Text = "Ultimos tres meses";
            this.cbTiempo.UseVisualStyleBackColor = true;
            this.cbTiempo.CheckedChanged += new System.EventHandler(this.cbTiempo_CheckedChanged);
            // 
            // frmRemitoProveedorBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 478);
            this.Controls.Add(this.cbTiempo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtDato);
            this.Name = "frmRemitoProveedorBuscar";
            this.Text = "frmBuscar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRemitoProveedorBuscar_FormClosing);
            this.Load += new System.EventHandler(this.frmRemitoProveedorBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtDato;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remito;
        private System.Windows.Forms.CheckBox cbTiempo;
    }
}