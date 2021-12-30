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
    /// Lógica de interacción para ConfirmacionParcela.xaml
    /// </summary>
    public partial class ConfirmacionParcela : Window
    {
        public ConfirmacionParcela()
        {
            InitializeComponent();

        }

        private void AceptarConfirmacionParcela(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("El usuario: {0}, Ha reservado la parcela {1}{2}", _nombre.Text,
            Environment.NewLine, _comentario.Text));
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

    }

}
