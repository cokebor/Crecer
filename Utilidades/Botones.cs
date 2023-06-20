using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{
    public static class Botones
    {
        public static void Inicial(Button btnNuevo, Button btnConfirmar, Button btnEliminar,Button btnCancelar=null){
            if (btnNuevo != null)
                btnNuevo.Enabled = true;
            btnConfirmar.Enabled = false;
            if (btnEliminar != null)
                btnEliminar.Enabled = false;
            if( btnCancelar !=null)
                btnCancelar.Enabled = false;
        }

        public static void Nuevo(Button btnNuevo, Button btnConfirmar, Button btnEliminar, Button btnCancelar=null)
        {
            if (btnNuevo != null)
                btnNuevo.Enabled = false;
            btnConfirmar.Enabled = true;
            if (btnEliminar != null)
                btnEliminar.Enabled = false;
            if(btnCancelar!=null)
                btnCancelar.Enabled = true;
        }
        public static void Modificar(Button btnNuevo, Button btnConfirmar, Button btnEliminar, Button btnCancelar=null)
        {
            if (btnNuevo != null)
                btnNuevo.Enabled = false;
            btnConfirmar.Enabled = true;
            btnEliminar.Enabled = true;
            if (btnCancelar != null)
                btnCancelar.Enabled = true;
        }
    }
}
