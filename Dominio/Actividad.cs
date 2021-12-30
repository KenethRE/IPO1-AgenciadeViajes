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
        public Monitor Monitor { set; get; }
        public string Horario { set; get; }
        public bool Niños { set; get; }
        public int MaxCapacidad { set; get; }
        public int MinCapacidad { set; get; }
        public double Precio { set; get; }
        public string Area { set; get; }
        public string Equipamiento { set; get; }
        public bool Estado { set; get; }

        public Actividad(string titulo, string descripcion, Monitor monitor, string horario,bool niños, int maxcapacidad,int mincapacidad, double precio, string area, string equipamiento, bool estado)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            Monitor = monitor;
            Horario = horario;
            Niños = niños;
            MinCapacidad = mincapacidad;
            MaxCapacidad = maxcapacidad;
            Precio = precio;
            Area = area;
            Equipamiento = equipamiento;
            Estado = estado;
        }
    }
}
