using System;
namespace IPO1_AgenciadeViajes {
    public class Inscrito
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Pago { get; set; }
        public string Inscripcion { get; set; }

        public Inscrito(string nombre, string correo, string telefono, bool pago, string instripcion)
        {
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Pago = pago;
            Inscripcion = instripcion;
        }
    }
}

