using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO1_AgenciadeViajes.Dominio
{
    class Parcela
    {
        public string Titulo { set; get; }
        public string Precio { set; get; }
        public string Temporada { set; get; }
        public string Ubicacion { set; get; }
        public string Tamano { set; get; }
        public string Servicios { set; get; }
        public string Disponibilidad { set; get; }

        public Parcela(string titulo, string precio, string temporada, string ubicacion, string tamano, string servicios, string disponibilidad)
        {
            Titulo = titulo;
            Precio = precio;
            Temporada = temporada;
            Ubicacion = ubicacion;
            Tamano = tamano;
            Servicios = servicios;
            Disponibilidad = disponibilidad;
        }
    }
}
