using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IPO1_AgenciadeViajes.Dominio
{
    class Cabana : ValidationRule
    {
        public string Titulo { set; get; }
        public double Precio { set; get; }
        public int Capacidad { set; get; }
        public string Descripcion { set; get; }
        public Uri Imagen { set; get; }
        public string Restriccion { set; get; }
        public string Equipamiento { set; get; }
        public bool Disponibilidad { set; get; }
        public int MinimoCaracteres { set; get; }
        public int MaximoCaracteres { set; get; }

        public Cabana(string titulo, double precio, int capacidad, string descripcion, Uri imagen, string restriccion, string equipamiento, bool disponibilidad)
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
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int longitud = ((string)value).Length;
            if ((longitud < MinimoCaracteres) || (longitud > MaximoCaracteres))
                return new ValidationResult(false, "Loongitud entre " +
                MinimoCaracteres.ToString() + " y " + MaximoCaracteres.ToString() +
                " caracteres");
            return new ValidationResult(true, null);
        }

    }
}
