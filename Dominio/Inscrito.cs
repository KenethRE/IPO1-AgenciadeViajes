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

        public Inscrito(string nombre, string correo, int telefono, string v3, Uri p, string v4)
        {
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Pago = v3;
            Foto = p;
            Inscripcion = v4;
        }
    }
}

