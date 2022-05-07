using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO1_AgenciadeViajes.Dominio
{
    public class HistorialActividades
    {
        public string Titulo { set; get; }
        public string Hora { set; get; }
        public string Niños { set; get; }

        public HistorialActividades(string titulo,string hora, string niños)
        {
            Titulo = titulo;
            Hora = hora;
            Niños = niños;

        }

        
    }
}
