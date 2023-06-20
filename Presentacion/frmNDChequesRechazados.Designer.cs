namespace Presentacion
{
    partial class frmNDChequesRechazados
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
            this.txtCodigoVendedor = new System.Windows.Forms.TextBox();
            this.lblNombreVendedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTipoComprobanteCliente = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGastos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigoVendedor
            // 
            this.txtCodigoVendedor.Location = new System.Drawing.Point(87, 8);
            this.txtCodigoVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoVendedor.Name = "txtCodigoVendedor";
            this.txtCodigoVendedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoVendedor.TabIndex = 0;
            this.txtCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoVendedor.TextChanged += new System.EventHandler(this.txtCodigoVendedor_TextChanged);
            this.txtCodigoVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoVendedor_KeyDown);
            this.txtCodigoVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoVendedor_KeyPress);
            // 
            // lblNombreVendedor
            // 
            this.lblNombreVendedor.Location = new System.Drawing.Point(124, 13);
            this.lblNombreVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreVendedor.Name = "lblNombreVendedor";
            this.lblNombreVendedor.Size = new System.Drawing.Size(175, 15);
            this.lblNombreVendedor.TabIndex = 408;
            this.lblNombreVendedor.Click += new System.EventHandler(this.lblNombreVendedor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 407;
            this.label3.Text = "Vendedor (F1):";
            // 
            // lblTipoComprobanteCliente
            // 
            this.lblTipoComprobanteCliente.AutoSize = true;
            this.lblTipoComprobanteCliente.Location = new System.Drawing.Point(313, 15);
            this.lblTipoComprobanteCliente.Name = "lblTipoComprobanteCliente";
            this.lblTipoComprobanteCliente.Size = new System.Drawing.Size(0, 13);
            this.lblTipoComprobanteCliente.TabIndex = 406;
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(87, 43);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoCliente.TabIndex = 1;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.Location = new System.Drawing.Point(124, 48);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(175, 15);
            this.lblNombreCliente.TabIndex = 403;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 402;
            this.label4.Text = "Cliente (F2):";
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
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.Codigo,
            this.CodigoBanco,
            this.Banco,
            this.Numero,
            this.Importe});
            this.dgvDatos.Location = new System.Drawing.Point(10, 79);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(437, 256);
            this.dgvDatos.TabIndex = 3;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            // 
            // Seleccionado
            // 
            this.Seleccionado.DataPropertyName = "Seleccionado";
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // CodigoBanco
            // 
            this.CodigoBanco.DataPropertyName = "CodigoBanco";
            this.CodigoBanco.HeaderText = "CodigoBanco";
            this.CodigoBanco.Name = "CodigoBanco";
            this.CodigoBanco.Visible = false;
            // 
            // Banco
            // 
            this.Banco.DataPropertyName = "Banco";
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "NroCheque";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(385, 40);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 346);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 413;
            this.label2.Text = "Gastos:";
            // 
            // txtGastos
            // 
            this.txtGastos.Location = new System.Drawing.Point(52, 343);
            this.txtGastos.Margin = new System.Windows.Forms.Padding(2);
            this.txtGastos.Name = "txtGastos";
            this.txtGastos.Size = new System.Drawing.Size(92, 20);
            this.txtGastos.TabIndex = 414;
            this.txtGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastos.TextChanged += new System.EventHandler(this.txtGastos_TextChanged);
            this.txtGastos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGastos_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Location = new System.Drawing.Point(13, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 63);
            this.groupBox1.TabIndex = 415;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motivo de Rechazo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(5, 18);
            this.txtMotivo.Margin = new System.Windows.Forms.Padding(2);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(421, 39);
            this.txtMotivo.TabIndex = 415;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(368, 468);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 417;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(269, 468);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 416;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer1";
            this.shapeContainer2.Size = new System.Drawing.Size(747, 542);
            this.shapeContainer2.TabIndex = 61;
            this.shapeContainer2.TabStop = false;
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(219, 343);
            this.txtIVA.Margin = new System.Windows.Forms.Padding(2);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(63, 20);
            this.txtIVA.TabIndex = 424;
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 346);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 423;
            this.label5.Text = "IVA 21%.:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(289, 445);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 426;
            this.label14.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(344, 443);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 425;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmNDChequesRechazados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(456, 498);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGastos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtCodigoVendedor);
            this.Controls.Add(this.lblNombreVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTipoComprobanteCliente);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label4);
            this.Name = "frmNDChequesRechazados";
            this.Load += new System.EventHandler(this.frmNDChequesRechazados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoVendedor;
        public System.Windows.Forms.Label lblNombreVendedor;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTipoComprobanteCliente;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        public System.Windows.Forms.Label label4;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtGastos;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtMotivo;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        public System.Windows.Forms.TextBox txtIVA;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
    }
}
