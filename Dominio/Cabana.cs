using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO1_AgenciadeViajes.Dominio
{
    class Cabana
    {
        public string Titulo { set; get; }
        public double Precio { set; get; }
        public int Capacidad { set; get; }
        public string Descripcion { set; get; }
        public Uri Imagen { set; get; }
        public string Restriccion { set; get; }
        public string Equipamiento { set; get; }
        public string Disponibilidad { set; get; }
        public Uri URL_IMDB { set; get; }

        public Cabana(string titulo, double precio, int capacidad, string descripcion, Uri imagen, string restriccion, string equipamiento, string disponibilidad)
        {
            Titulo = titulo;
            Precio = precio;
            Capacidad = capacidad;
            Descripcion = descripcion;
            Imagen = imagen;
            Restriccion = restriccion;
            Equipamiento = equipamiento;
            Disponibilidad = disponibilidad;
        }

    }
}
