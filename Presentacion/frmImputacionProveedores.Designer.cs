namespace Presentacion
{
    partial class frmImputacionProveedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imputado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbSaldo = new System.Windows.Forms.CheckBox();
            this.dgvDatos2 = new System.Windows.Forms.DataGridView();
            this.cbComprobantes = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.lblAplicado = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Codigo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoDocumentoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imputado2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AAplicar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoImputacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(102, 11);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoProveedor.TabIndex = 0;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Location = new System.Drawing.Point(139, 16);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Proveedor (F6):";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Fecha,
            this.Numero,
            this.Importe,
            this.Imputado,
            this.Total});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDatos.Location = new System.Drawing.Point(25, 73);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(465, 435);
            this.dgvDatos.TabIndex = 51;
            this.dgvDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellDoubleClick);
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
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle3;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle4;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // Imputado
            // 
            this.Imputado.DataPropertyName = "Imputado";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Imputado.DefaultCellStyle = dataGridViewCellStyle5;
            this.Imputado.HeaderText = "Imputado";
            this.Imputado.Name = "Imputado";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle6;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Pagos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(428, 8);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbSaldo
            // 
            this.cbSaldo.AutoSize = true;
            this.cbSaldo.Checked = true;
            this.cbSaldo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaldo.Location = new System.Drawing.Point(25, 513);
            this.cbSaldo.Name = "cbSaldo";
            this.cbSaldo.Size = new System.Drawing.Size(190, 17);
            this.cbSaldo.TabIndex = 63;
            this.cbSaldo.Text = "Ocultar Pagos sin saldo disponible.";
            this.cbSaldo.UseVisualStyleBackColor = true;
            this.cbSaldo.CheckedChanged += new System.EventHandler(this.cbSaldo_CheckedChanged);
            // 
            // dgvDatos2
            // 
            this.dgvDatos2.CausesValidation = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDatos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.Codigo2,
            this.Fecha2,
            this.Tipo,
            this.CodigoTipoDocumentoProveedor,
            this.Numero2,
            this.Total2,
            this.Imputado2,
            this.Pendiente,
            this.AAplicar,
            this.CodigoImputacion});
            this.dgvDatos2.Location = new System.Drawing.Point(513, 73);
            this.dgvDatos2.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos2.Name = "dgvDatos2";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos2.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvDatos2.RowTemplate.Height = 24;
            this.dgvDatos2.Size = new System.Drawing.Size(638, 435);
            this.dgvDatos2.TabIndex = 64;
            this.dgvDatos2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos2_CellClick);
            // 
            // cbComprobantes
            // 
            this.cbComprobantes.AutoSize = true;
            this.cbComprobantes.Checked = true;
            this.cbComprobantes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbComprobantes.Location = new System.Drawing.Point(513, 513);
            this.cbComprobantes.Name = "cbComprobantes";
            this.cbComprobantes.Size = new System.Drawing.Size(228, 17);
            this.cbComprobantes.TabIndex = 65;
            this.cbComprobantes.Text = "Ocultar Comprobantes sin saldo pendiente.";
            this.cbComprobantes.UseVisualStyleBackColor = true;
            this.cbComprobantes.CheckedChanged += new System.EventHandler(this.cbComprobantes_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(513, 547);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 66;
            this.label2.Text = "Disponible:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(754, 547);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 67;
            this.label4.Text = "Aplicado:";
            // 
            // lblDisponible
            // 
            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.Location = new System.Drawing.Point(599, 547);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(0, 15);
            this.lblDisponible.TabIndex = 68;
            // 
            // lblAplicado
            // 
            this.lblAplicado.AutoSize = true;
            this.lblAplicado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplicado.Location = new System.Drawing.Point(826, 547);
            this.lblAplicado.Name = "lblAplicado";
            this.lblAplicado.Size = new System.Drawing.Size(0, 15);
            this.lblAplicado.TabIndex = 69;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1064, 576);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(965, 576);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 70;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(513, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "Comprobantes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(654, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Imputar primero las Notas de Crédito";
            // 
            // btnDetalle
            // 
            this.btnDetalle.Enabled = false;
            this.btnDetalle.Location = new System.Drawing.Point(389, 524);
            this.btnDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(101, 26);
            this.btnDetalle.TabIndex = 74;
            this.btnDetalle.Text = "VER DETALLE";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // Seleccionado
            // 
            this.Seleccionado.DataPropertyName = "Seleccionado";
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            // 
            // Codigo2
            // 
            this.Codigo2.DataPropertyName = "Codigo";
            this.Codigo2.HeaderText = "Codigo";
            this.Codigo2.Name = "Codigo2";
            this.Codigo2.Visible = false;
            // 
            // Fecha2
            // 
            this.Fecha2.DataPropertyName = "FechaEmision";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "d";
            this.Fecha2.DefaultCellStyle = dataGridViewCellStyle9;
            this.Fecha2.HeaderText = "Fecha";
            this.Fecha2.Name = "Fecha2";
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tipo.DefaultCellStyle = dataGridViewCellStyle10;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // CodigoTipoDocumentoProveedor
            // 
            this.CodigoTipoDocumentoProveedor.DataPropertyName = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.HeaderText = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.Name = "CodigoTipoDocumentoProveedor";
            this.CodigoTipoDocumentoProveedor.Visible = false;
            // 
            // Numero2
            // 
            this.Numero2.DataPropertyName = "Numero";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero2.DefaultCellStyle = dataGridViewCellStyle11;
            this.Numero2.HeaderText = "Numero";
            this.Numero2.Name = "Numero2";
            // 
            // Total2
            // 
            this.Total2.DataPropertyName = "Total";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "C2";
            this.Total2.DefaultCellStyle = dataGridViewCellStyle12;
            this.Total2.HeaderText = "Total";
            this.Total2.Name = "Total2";
            // 
            // Imputado2
            // 
            this.Imputado2.DataPropertyName = "Imputado";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "C2";
            this.Imputado2.DefaultCellStyle = dataGridViewCellStyle13;
            this.Imputado2.HeaderText = "Imputado";
            this.Imputado2.Name = "Imputado2";
            // 
            // Pendiente
            // 
            this.Pendiente.DataPropertyName = "Saldo";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "C2";
            this.Pendiente.DefaultCellStyle = dataGridViewCellStyle14;
            this.Pendiente.HeaderText = "Pendiente";
            this.Pendiente.Name = "Pendiente";
            // 
            // AAplicar
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "C2";
            this.AAplicar.DefaultCellStyle = dataGridViewCellStyle15;
            this.AAplicar.HeaderText = "A Aplicar";
            this.AAplicar.Name = "AAplicar";
            // 
            // CodigoImputacion
            // 
            this.CodigoImputacion.HeaderText = "CodigoImputacion";
            this.CodigoImputacion.Name = "CodigoImputacion";
            this.CodigoImputacion.Visible = false;
            // 
            // frmImputacionProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1157, 615);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblAplicado);
            this.Controls.Add(this.lblDisponible);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbComprobantes);
            this.Controls.Add(this.dgvDatos2);
            this.Controls.Add(this.cbSaldo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.label3);
            this.Name = "frmImputacionProveedores";
            this.Activated += new System.EventHandler(this.frmImputacionClientes_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImputacionClientes_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Imputado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.CheckBox cbSaldo;
        public System.Windows.Forms.DataGridView dgvDatos2;
        private System.Windows.Forms.CheckBox cbComprobantes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Label lblAplicado;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoDocumentoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Imputado2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn AAplicar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoImputacion;
    }
}
