using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO1_AgenciadeViajes.Dominio
{
    class Promocion
    {
        public string Titulo { set; get; }
        public string Descripcion { set; get; }
        public Uri Foto { set; get; }
        public bool Estado { set; get; }

        public Promocion(string titulo, string descripcion, Uri foto, bool estado)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            Foto = foto;
            Estado = estado;
        }
    }
}
