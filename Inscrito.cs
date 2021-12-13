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
            Nombre = v;
            Correo = v1;
            Telefono = v2;
            Pago = v3;
            Foto = p;
            Inscripcion = v4;
        }
    }
}

