using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO1_AgenciadeViajes.Dominio
{
    class RutaSenderista
    {
        public string Titulo { set; get; }
        public string Descripcion { set; get; }
        public Uri Mapa { set; get; }
        public string Horario { set; get; }
        public string Monitor { set; get; }
        public string Encuentro { set; get; }
        public string Capacidad { set; get; }
        public string Dificultad { set; get; }
        public Uri URL_IMDB { set; get; }

        public RutaSenderista(string titulo, string descripcion, Uri mapa, string horario, string monitor, string encuentro, string capacidad, string dificultad)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            Mapa = mapa;
            Horario = horario;
            Monitor = monitor;
            Encuentro = encuentro;
            Capacidad = capacidad;
            Dificultad = dificultad;
        }
    }
}
