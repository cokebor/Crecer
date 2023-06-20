namespace Presentacion
{
    partial class frmGastosInforme
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbConceptos = new System.Windows.Forms.ComboBox();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Efectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheques = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tranferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetencionesPercepciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(760, 604);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 417;
            this.label12.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotal.Location = new System.Drawing.Point(807, 604);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(156, 16);
            this.lblTotal.TabIndex = 416;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Fecha,
            this.Descripcion,
            this.Monto,
            this.Efectivo,
            this.Cheques,
            this.Tranferencia,
            this.RetencionesPercepciones,
            this.Total,
            this.Detalle});
            this.dgvDatos.Location = new System.Drawing.Point(31, 88);
            this.dgvDatos.Name = "dgvDatos";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDatos.Size = new System.Drawing.Size(932, 498);
            this.dgvDatos.TabIndex = 415;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(888, 44);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 26);
            this.btnBuscar.TabIndex = 414;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(763, 13);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 410;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(570, 13);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 409;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(718, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 408;
            this.label1.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(526, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 407;
            this.label3.Text = "Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 406;
            this.label4.Text = "Cuenta Contable:";
            // 
            // cbConceptos
            // 
            this.cbConceptos.FormattingEnabled = true;
            this.cbConceptos.Location = new System.Drawing.Point(123, 13);
            this.cbConceptos.Name = "cbConceptos";
            this.cbConceptos.Size = new System.Drawing.Size(276, 21);
            this.cbConceptos.TabIndex = 404;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Comprobante";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 250;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "C2";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle2;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Monto.Width = 150;
            // 
            // Efectivo
            // 
            this.Efectivo.DataPropertyName = "Efectivo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.Efectivo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Efectivo.HeaderText = "Efectivo";
            this.Efectivo.Name = "Efectivo";
            this.Efectivo.Width = 150;
            // 
            // Cheques
            // 
            this.Cheques.DataPropertyName = "Cheques";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Cheques.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cheques.HeaderText = "Cheques";
            this.Cheques.Name = "Cheques";
            this.Cheques.Width = 150;
            // 
            // Tranferencia
            // 
            this.Tranferencia.DataPropertyName = "Tranferencia";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Tranferencia.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tranferencia.HeaderText = "Tranferencia";
            this.Tranferencia.Name = "Tranferencia";
            this.Tranferencia.Width = 150;
            // 
            // RetencionesPercepciones
            // 
            this.RetencionesPercepciones.DataPropertyName = "RetPerc";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.RetencionesPercepciones.DefaultCellStyle = dataGridViewCellStyle6;
            this.RetencionesPercepciones.HeaderText = "Ret./Perc.";
            this.RetencionesPercepciones.Name = "RetencionesPercepciones";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle7;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.Width = 150;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "";
            this.Detalle.Name = "Detalle";
            this.Detalle.Text = "Detalle";
            this.Detalle.UseColumnTextForLinkValue = true;
            // 
            // frmGastosInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(975, 639);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbConceptos);
            this.Name = "frmGastosInforme";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbConceptos;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Efectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheques;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tranferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetencionesPercepciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewLinkColumn Detalle;
    }
}
