namespace Presentacion
{
    partial class frmRetencionesPercepcionesPagos
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProveedorCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroAgente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoRetAsociada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.CodigoCuentaContable,
            this.CodigoPago,
            this.CodigoFactura,
            this.Fecha,
            this.CUIT,
            this.ProveedorCliente,
            this.NroAgente,
            this.NroComprobante,
            this.Importe,
            this.CodigoImpuesto,
            this.CodigoRetAsociada,
            this.CodigoSucursal});
            this.dgvDatos.Location = new System.Drawing.Point(10, 12);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(617, 281);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(549, 340);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 14;
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
            this.shapeContainer1.Size = new System.Drawing.Size(639, 377);
            this.shapeContainer1.TabIndex = 14;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(638, 376);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(479, 312);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 391;
            this.label14.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(524, 310);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 390;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Seleccionado
            // 
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            // 
            // CodigoCuentaContable
            // 
            this.CodigoCuentaContable.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.Visible = false;
            // 
            // CodigoPago
            // 
            this.CodigoPago.HeaderText = "CodigoPago";
            this.CodigoPago.Name = "CodigoPago";
            this.CodigoPago.Visible = false;
            // 
            // CodigoFactura
            // 
            this.CodigoFactura.HeaderText = "CodigoFactura";
            this.CodigoFactura.Name = "CodigoFactura";
            this.CodigoFactura.Visible = false;
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
            // CUIT
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CUIT.DefaultCellStyle = dataGridViewCellStyle2;
            this.CUIT.HeaderText = "CUIT";
            this.CUIT.Name = "CUIT";
            // 
            // ProveedorCliente
            // 
            this.ProveedorCliente.HeaderText = "Proveedor/Cliente";
            this.ProveedorCliente.Name = "ProveedorCliente";
            // 
            // NroAgente
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.NroAgente.DefaultCellStyle = dataGridViewCellStyle3;
            this.NroAgente.HeaderText = "Nro Agente";
            this.NroAgente.Name = "NroAgente";
            // 
            // NroComprobante
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.NroComprobante.DefaultCellStyle = dataGridViewCellStyle4;
            this.NroComprobante.HeaderText = "Nro Comp.";
            this.NroComprobante.Name = "NroComprobante";
            // 
            // Importe
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle5;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // CodigoImpuesto
            // 
            this.CodigoImpuesto.HeaderText = "CodigoImpuesto";
            this.CodigoImpuesto.Name = "CodigoImpuesto";
            this.CodigoImpuesto.Visible = false;
            // 
            // CodigoRetAsociada
            // 
            this.CodigoRetAsociada.HeaderText = "CodigoRetAsociada";
            this.CodigoRetAsociada.Name = "CodigoRetAsociada";
            this.CodigoRetAsociada.Visible = false;
            // 
            // CodigoSucursal
            // 
            this.CodigoSucursal.HeaderText = "CodigoSucursal";
            this.CodigoSucursal.Name = "CodigoSucursal";
            this.CodigoSucursal.Visible = false;
            // 
            // frmRetencionesPercepcionesPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(639, 377);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRetencionesPercepcionesPagos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnConfirmar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProveedorCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroAgente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoRetAsociada;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSucursal;
    }
}
