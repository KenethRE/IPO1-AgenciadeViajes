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
        public string ultimoInicio { set; get; }
        public BitmapImage ImgUsuario { set; get; }

        public Usuario()
        { 
        }
    }
}
