using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace IPO1_AgenciadeViajes.Dominio
{
    public class Usuario
    {
        public string Nombre { set; get; }
        public string UltimoInicio { set; get; }
        public Uri ImgUsuario { set; get; }
        public string Pass { set; get; }
        public Usuario(string nombre, string ultimoInicio,string pass, Uri imgUsuario)
        {
            Nombre = nombre;
            UltimoInicio = ultimoInicio;
            ImgUsuario = imgUsuario;
            Pass = pass;
        }

       

    }
}
