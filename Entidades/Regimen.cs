namespace Entidades
{
    public class Regimen :DatosGenerales
    {
        public Regimen() {
            impuesto = new ImpuestoRetencion();
        }
        private ImpuestoRetencion impuesto;

        public ImpuestoRetencion Impuesto
        {
            get
            {
                return impuesto;
            }

            set
            {
                impuesto = value;
            }
        }
    }
}