namespace Presentacion
{
    partial class frmProducto
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
            this.components = new System.ComponentModel.Container();
            this.cmsRubro = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.nupPeso = new System.Windows.Forms.NumericUpDown();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cbIVA = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.cbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigoDeBarra = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nupStockMinimo = new System.Windows.Forms.NumericUpDown();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRubroProducto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbFacturacionPorCubeta = new System.Windows.Forms.CheckBox();
            this.cbVacio = new System.Windows.Forms.CheckBox();
            this.cmsRubro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockMinimo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsRubro
            // 
            this.cmsRubro.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRubro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.cmsRubro.Name = "cmsRubro";
            this.cmsRubro.Size = new System.Drawing.Size(117, 26);
            this.cmsRubro.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRubro_Opening);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(259, 11);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 42;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // nupPeso
            // 
            this.nupPeso.Enabled = false;
            this.nupPeso.Location = new System.Drawing.Point(239, 130);
            this.nupPeso.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupPeso.Name = "nupPeso";
            this.nupPeso.Size = new System.Drawing.Size(48, 20);
            this.nupPeso.TabIndex = 3;
            this.nupPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupPeso_KeyPress);
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(186, 311);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(96, 311);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(9, 311);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cbIVA
            // 
            this.cbIVA.Enabled = false;
            this.cbIVA.FormattingEnabled = true;
            this.cbIVA.Items.AddRange(new object[] {
            " 0,00",
            "10,50",
            "21,00"});
            this.cbIVA.Location = new System.Drawing.Point(134, 246);
            this.cbIVA.Name = "cbIVA";
            this.cbIVA.Size = new System.Drawing.Size(63, 21);
            this.cbIVA.TabIndex = 7;
            this.cbIVA.SelectedIndexChanged += new System.EventHandler(this.cbIVA_SelectedIndexChanged);
            this.cbIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbIVA_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Porc. IVA:";
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(239, 168);
            this.txtStock.Margin = new System.Windows.Forms.Padding(2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(48, 20);
            this.txtStock.TabIndex = 5;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // cbUnidadMedida
            // 
            this.cbUnidadMedida.Enabled = false;
            this.cbUnidadMedida.FormattingEnabled = true;
            this.cbUnidadMedida.Items.AddRange(new object[] {
            "Unidad",
            "Kg.",
            "Cubetas"});
            this.cbUnidadMedida.Location = new System.Drawing.Point(134, 130);
            this.cbUnidadMedida.Name = "cbUnidadMedida";
            this.cbUnidadMedida.Size = new System.Drawing.Size(63, 21);
            this.cbUnidadMedida.TabIndex = 2;
            this.cbUnidadMedida.SelectedIndexChanged += new System.EventHandler(this.cbUnidadMedida_SelectedIndexChanged);
            this.cbUnidadMedida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbUnidadMedida_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Codigo de Barra :";
            // 
            // txtCodigoDeBarra
            // 
            this.txtCodigoDeBarra.Enabled = false;
            this.txtCodigoDeBarra.Location = new System.Drawing.Point(134, 207);
            this.txtCodigoDeBarra.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoDeBarra.Name = "txtCodigoDeBarra";
            this.txtCodigoDeBarra.Size = new System.Drawing.Size(153, 20);
            this.txtCodigoDeBarra.TabIndex = 6;
            this.txtCodigoDeBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoDeBarra_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Stock:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Stock Minimo:";
            // 
            // nupStockMinimo
            // 
            this.nupStockMinimo.Enabled = false;
            this.nupStockMinimo.Location = new System.Drawing.Point(134, 169);
            this.nupStockMinimo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupStockMinimo.Name = "nupStockMinimo";
            this.nupStockMinimo.Size = new System.Drawing.Size(63, 20);
            this.nupStockMinimo.TabIndex = 4;
            this.nupStockMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupStockMinimo_KeyPress);
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(203, 134);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(34, 13);
            this.lblUnidad.TabIndex = 31;
            this.lblUnidad.Text = "Peso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Unid. de Medida :";
            // 
            // cbRubroProducto
            // 
            this.cbRubroProducto.ContextMenuStrip = this.cmsRubro;
            this.cbRubroProducto.Enabled = false;
            this.cbRubroProducto.FormattingEnabled = true;
            this.cbRubroProducto.Location = new System.Drawing.Point(134, 93);
            this.cbRubroProducto.Name = "cbRubroProducto";
            this.cbRubroProducto.Size = new System.Drawing.Size(153, 21);
            this.cbRubroProducto.TabIndex = 1;
            this.cbRubroProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbRubroProducto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Rubro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(134, 55);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(153, 20);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Codigo:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(131, 17);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 23;
            this.lblCodigo.Text = "(Codigo)";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(277, 311);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbFacturacionPorCubeta
            // 
            this.cbFacturacionPorCubeta.AutoSize = true;
            this.cbFacturacionPorCubeta.Enabled = false;
            this.cbFacturacionPorCubeta.Location = new System.Drawing.Point(43, 286);
            this.cbFacturacionPorCubeta.Name = "cbFacturacionPorCubeta";
            this.cbFacturacionPorCubeta.Size = new System.Drawing.Size(137, 17);
            this.cbFacturacionPorCubeta.TabIndex = 59;
            this.cbFacturacionPorCubeta.Text = "Facturación por Cubeta";
            this.cbFacturacionPorCubeta.UseVisualStyleBackColor = true;
            // 
            // cbVacio
            // 
            this.cbVacio.AutoSize = true;
            this.cbVacio.Enabled = false;
            this.cbVacio.Location = new System.Drawing.Point(186, 286);
            this.cbVacio.Name = "cbVacio";
            this.cbVacio.Size = new System.Drawing.Size(53, 17);
            this.cbVacio.TabIndex = 60;
            this.cbVacio.Text = "Vacio";
            this.cbVacio.UseVisualStyleBackColor = true;
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(358, 344);
            this.Controls.Add(this.cbVacio);
            this.Controls.Add(this.cbFacturacionPorCubeta);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.nupPeso);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cbIVA);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.cbUnidadMedida);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCodigoDeBarra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nupStockMinimo);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbRubroProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCodigo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProducto";
            this.Activated += new System.EventHandler(this.frmProducto_Activated);
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.cmsRubro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStockMinimo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblCodigo;
        public System.Windows.Forms.ComboBox cbRubroProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.NumericUpDown nupStockMinimo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtCodigoDeBarra;
        public System.Windows.Forms.ComboBox cbUnidadMedida;
        public System.Windows.Forms.TextBox txtStock;
        public System.Windows.Forms.ComboBox cbIVA;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.NumericUpDown nupPeso;
        private System.Windows.Forms.ContextMenuStrip cmsRubro;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox cbFacturacionPorCubeta;
        private System.Windows.Forms.CheckBox cbVacio;
    }
}
