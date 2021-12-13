using System;
namespace IPO1_AgenciadeViajes {
    public class Inscrito
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Pago { get; set; }
        public Uri Foto { get; set; }
        public string Inscripcion { get; set; }

        public Inscrito(string v, string v1, int v2, string v3, Uri p, string v4)
        {
            this.Nombre = v;
            this.Correo = v1;
            this.Telefono = v2;
            this.Pago = v3;
            this.Foto = p;
            this.Inscripcion = v4;
        }
    }
}

