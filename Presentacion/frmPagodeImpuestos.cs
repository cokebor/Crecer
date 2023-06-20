using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPagodeImpuestos : Presentacion.frmColor
    {
        public frmPagodeImpuestos()
        {
            InitializeComponent();
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial() {
            Titulo();
            Formatos();
        }
        void Titulo() {
            this.Text = "PAGO DE IMPUESTOS";
        }
        void Formatos() {
            Utilidades.Formularios.ConfiguracionInicial(this);
            Utilidades.Combo.Formato(cbImpuesto);
            tpConceptos.BackColor = frmColor.Color;
            tpFormasDePago.BackColor = frmColor.Color;
        }
    }
}
