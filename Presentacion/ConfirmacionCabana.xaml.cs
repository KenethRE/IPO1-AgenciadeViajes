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
        private Dominio.Cabana cabana;
        public ConfirmacionCabana(Dominio.Cabana cabana,DatePicker fechainicio, DatePicker fechafin)
        {
            this.cabana = cabana;   
            InitializeComponent();
            Lblconfirmacion.Text= "Para reservar la cabaña "+ cabana.Titulo + " \n para las fechas "+ fechainicio.ToString() + " a " + fechafin.ToString()+ " \n debe rellenar estos datos";
        }

    

        private void AceptarConfirmacionCabana_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se Ha reservado " + cabana.Titulo);
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void btnCancelarReservarCabana_Click(object sender, RoutedEventArgs e)
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
