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

namespace IPO1_AgenciadeViajes
{
    /// <summary>
    /// Lógica de interacción para ConfirmacionCabana.xaml
    /// </summary>
    public partial class ConfirmacionCabana : Window
    {
        public ConfirmacionCabana()
        {
            InitializeComponent();
        }

    

        private void AceptarConfirmacionCabana_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("El usuario: {0}, Ha reservado la cabaña {1}{2}", _nombre.Text,
            Environment.NewLine, _comentario.Text));
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }
    }
    public class ReglaRangoLongitudCaracteres : ValidationRule
    {
        public int MinimoCaracteres { set; get; }
        public int MaximoCaracteres { set; get; }
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
    class Customer
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Nombre es obligatorio.");
                }
            }
        }
    }
}
