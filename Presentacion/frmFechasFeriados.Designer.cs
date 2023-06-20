
namespace Presentacion
{
    partial class frmFechasFeriados
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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.Label15 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cbPago = new System.Windows.Forms.CheckBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cancelar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(747, 542);
            this.shapeContainer1.TabIndex = 61;
            this.shapeContainer1.TabStop = false;
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(58, 12);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 0;
            this.dtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFecha_KeyPress);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(9, 16);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(40, 13);
            this.Label15.TabIndex = 404;
            this.Label15.Text = "Fecha:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(309, 260);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 409;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(214, 260);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(206, 12);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(94, 21);
            this.cbSucursales.TabIndex = 410;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(152, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 13);
            this.label26.TabIndex = 411;
            this.label26.Text = "Sucursal:";
            // 
            // cbPago
            // 
            this.cbPago.AutoSize = true;
            this.cbPago.Location = new System.Drawing.Point(312, 14);
            this.cbPago.Name = "cbPago";
            this.cbPago.Size = new System.Drawing.Size(51, 17);
            this.cbPago.TabIndex = 412;
            this.cbPago.Text = "Pago";
            this.cbPago.UseVisualStyleBackColor = true;
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.CodigoSucursal,
            this.Sucursal,
            this.Pago,
            this.Cancelar});
            this.dgvDatos.Location = new System.Drawing.Point(12, 40);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(378, 197);
            this.dgvDatos.TabIndex = 414;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // Fecha
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // CodigoSucursal
            // 
            this.CodigoSucursal.HeaderText = "CodigoSucursal";
            this.CodigoSucursal.Name = "CodigoSucursal";
            this.CodigoSucursal.Visible = false;
            // 
            // Sucursal
            // 
            this.Sucursal.HeaderText = "Sucursal";
            this.Sucursal.Name = "Sucursal";
            // 
            // Pago
            // 
            this.Pago.HeaderText = "Pago";
            this.Pago.Name = "Pago";
            this.Pago.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Cancelar
            // 
            this.Cancelar.HeaderText = "";
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cancelar.Text = "Eliminar";
            this.Cancelar.UseColumnTextForLinkValue = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.CausesValidation = false;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(365, 9);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 26);
            this.btnAgregar.TabIndex = 415;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmFechasFeriados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(399, 297);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.cbPago);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.Label15);
            this.Name = "frmFechasFeriados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        internal System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox cbPago;
        private System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pago;
        private System.Windows.Forms.DataGridViewLinkColumn Cancelar;
    }
}
