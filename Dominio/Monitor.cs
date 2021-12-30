using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO1_AgenciadeViajes.Dominio
{
    class Monitor
    {
        public string Nombre { set; get; }
        public int Telefono { set; get; }
        public int Correo { set; get; }
        public string Idioma { set; get; }
        public Uri Foto { set; get; }
        public string Formacion { set; get; }
        public string Restricciones { set; get; }
        public bool Estado { set; get; }
        public Uri URL_IMDB { set; get; }

        public Monitor(string nombre, int telefono, int correo, string idioma, Uri foto, string formacion, string restricciones, bool estado)
        {
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Idioma = idioma;
            Foto = foto;
            Formacion = formacion;
            Restricciones = restricciones;
            Estado = estado;
        }
    }
}
