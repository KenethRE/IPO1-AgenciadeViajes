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
    /// Lógica de interacción para Cabana.xaml
    /// </summary>
    public partial class InfoCabana : Window
    {
        private ConfirmacionCabana ventanaconfirmacioncabana;
        private Dominio.Cabana cabana;
        public InfoCabana(Dominio.Cabana cabana)
        {
            this.cabana = cabana;
            InitializeComponent();
            txtTitulo.Text = cabana.Titulo;
            txtprecio.Text = cabana.Precio.ToString() + " €";
            txtcapacidad.Text = cabana.Capacidad.ToString()+ " personas";
            txtrestriccion.Text = cabana.Restriccion;
            txtequipamiento.Text = cabana.Equipamiento;
            txtdispon.Text = cabana.Estado.ToString();
            var bitmap = new BitmapImage(cabana.Foto);
            img_cabana.Source = bitmap;



        }


        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void btnCancelarCabana_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnReservarCabana_Click(object sender, RoutedEventArgs e)
        {
            if (fechafin.Text == "" || fechainic.Text== "")
            {
                MessageBox.Show("Debe introducir las fechas de reserva");
            }
            else
            {
                ventanaconfirmacioncabana = new ConfirmacionCabana(cabana, fechainic, fechafin);
                ventanaconfirmacioncabana.Show();
            }
        }
    }
}
