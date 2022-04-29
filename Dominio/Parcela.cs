using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO1_AgenciadeViajes.Dominio
{
    public class Parcela
    {
        public string Titulo { set; get; }
        public double Precio { set; get; }
        public string Temporada { set; get; }
        public string Ubicacion { set; get; }
        public int Tamano { set; get; }
        public string Servicios { set; get; }
        public Uri Foto { set; get; }
        public bool Estado { set; get; }

        public Parcela(string titulo, double precio, string temporada, string ubicacion, int tamano, string servicios, bool disponibilidad, Uri foto)
        {
            Titulo = titulo;
            Precio = precio;
            Temporada = temporada;
            Ubicacion = ubicacion;
            Tamano = tamano;
            Servicios = servicios;
            Estado = disponibilidad;
            Foto = foto;
        }
    }
}
