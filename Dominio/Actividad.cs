using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO1_AgenciadeViajes.Dominio
{
    class Actividad
    {
        public string Titulo { set; get; }
        public string Descripcion { set; get; }
        public string Monitor { set; get; }
        public string Horario { set; get; }
        public string Capacidad { set; get; }
        public string Precio { set; get; }
        public string Area { set; get; }
        public string Equipamiento { set; get; }
        public bool Estado { set; get; }

        public Actividad(string titulo, string descripcion, string monitor, string horario, string capacidad, string precio, string area, string equipamiento, bool estado)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            Monitor = monitor;
            Horario = horario;
            Capacidad = capacidad;
            Precio = precio;
            Area = area;
            Equipamiento = equipamiento;
            Estado = estado;
        }
    }
}
