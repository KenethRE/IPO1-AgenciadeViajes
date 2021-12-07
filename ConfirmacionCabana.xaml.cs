using System;
using System.Collections.Generic;
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
    }
}
