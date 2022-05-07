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
        private Dominio.Parcela Parcela;
        public ConfirmacionParcela(Dominio.Parcela parcela, DatePicker fechainicio, DatePicker fechafin)
            
        {
            this.Parcela = parcela;
            InitializeComponent();
            lblconfirmacion.Text = "Para reservar la parcel  " + Parcela.Titulo + " \n para las fechas " + fechainicio.ToString() + " a " + fechafin.ToString() + " \n debe rellenar estos datos";


        }

        private void AceptarConfirmacionParcela(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se Ha reservado " + Parcela.Titulo);
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }
        private void btnCancelarReservarParcela_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("¿Estás seguro de cancelar la reserva?", "Cancelar reserva", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

    }

}
