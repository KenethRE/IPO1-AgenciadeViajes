using Microsoft.Win32;
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
    /// Lógica de interacción para Parcela.xaml
    /// </summary>
    /// 
    

    public partial class InfoParcela : Window
    {
        private ConfirmacionParcela ventanaConfirmacionParcela;
        private Dominio.Parcela Parcela;
        public InfoParcela(Dominio.Parcela parcela)
            
        {
            
            this.Parcela = parcela;
            InitializeComponent();
            titparcela.Text = parcela.Titulo;
            txtprecio.Text = parcela.Precio.ToString()+ " €";
            txtUbicParcela.Text = parcela.Ubicacion + "\nTamaño: "+ parcela.Tamano+ "\nTemporada: "+parcela.Temporada;
            txtServicparcela.Text = parcela.Servicios;
            disp_parcela.Text = parcela.Estado.ToString();
            var bitmap = new BitmapImage(parcela.Foto);
            Img_parcela.Source = bitmap;
            fechainic.DisplayDateStart = DateTime.Now;
            fechafin.DisplayDateStart = DateTime.Now;
            Btn_img.Visibility = Visibility.Hidden;
            Guardar.Visibility = Visibility.Hidden;


        }

        private void ReservarParcela_Click(object sender, RoutedEventArgs e)
        {
            if (fechafin.Text == "" || fechainic.Text == "")
            {
                MessageBox.Show("Debe introducir las fechas de reserva");
            }
            else
            {
                DateTime fechafin1 = (DateTime)fechafin.SelectedDate;
                DateTime fechainic2 = (DateTime)fechainic.SelectedDate;
                int result = DateTime.Compare(fechafin1, fechainic2);
                if (result > 0)
                {
                    ventanaConfirmacionParcela = new ConfirmacionParcela(Parcela, fechainic, fechafin);
                    ventanaConfirmacionParcela.Show();
                }
                else
                    MessageBox.Show("la fecha de inicio y final no son correctas");
            }

        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void btnCancelarParcela_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("¿Estás seguro de cerrar la ventana?", "Cerrar Sesión", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            titparcela.IsEnabled = true;
            txtprecio.IsEnabled = true;
            txtUbicParcela.IsEnabled = true;
            txtServicparcela.IsEnabled = true;
            disp_parcela.IsEnabled = true;
            btnModificar.Visibility = Visibility.Hidden;
            btnReservarParcela.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Hidden;
            btnBorrar.Visibility = Visibility.Hidden;
            Btn_img.Visibility = Visibility.Visible;
            Guardar.Visibility = Visibility.Visible;
            fechafin.Visibility = Visibility.Hidden;
            fechainic.Visibility = Visibility.Hidden;
            lblFechaFinParcela.Visibility = Visibility.Hidden;
            lblFechaInicioParcela.Visibility= Visibility.Hidden;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            titparcela.Text = "";
            txtprecio.Text = "";
            txtUbicParcela.Text = "";
            txtServicparcela.Text = "";
            disp_parcela.Text = "";
            titparcela.IsEnabled = true;
            txtprecio.IsEnabled = true;
            txtServicparcela.IsEnabled = true;
            txtUbicParcela.IsEnabled = true;
            disp_parcela.IsEnabled = true;
            Btn_img.Visibility = Visibility.Visible;
            btnNuevo.Visibility = Visibility.Hidden;
            btnBorrar.Visibility = Visibility.Hidden;
            btnModificar.Visibility = Visibility.Hidden;
            lblFechaInicioParcela.Visibility = Visibility.Hidden;
            lblFechaFinParcela.Visibility = Visibility.Hidden;
            fechafin.Visibility = Visibility.Hidden;
            fechainic.Visibility = Visibility.Hidden;
            Guardar.Visibility = Visibility.Visible;
            Img_parcela.Source = new BitmapImage(new Uri(@"/Recursos/Imagenes/icono_imagen.png", UriKind.Relative));
            btnReservarParcela.Visibility = Visibility.Hidden;
            
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            titparcela.IsEnabled = false;
            txtprecio.IsEnabled = false;
            txtUbicParcela.IsEnabled = false;
            txtServicparcela.IsEnabled = false;
            disp_parcela.IsEnabled = false;
            fechafin.Visibility = Visibility.Visible;
            fechafin.Visibility = Visibility.Visible;
            btnReservarParcela.Visibility = Visibility.Visible;
            Btn_img.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Visible;
            btnBorrar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Visible;
            Guardar.Visibility = Visibility.Hidden;
            lblFechaInicioParcela.Visibility = Visibility.Visible;
            lblFechaFinParcela.Visibility = Visibility.Visible;
            fechafin.Visibility = Visibility.Visible;
            fechainic.Visibility = Visibility.Visible;

            MessageBox.Show("Parcela guardada correctamente");
        }

        private void Btn_img_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    Img_parcela.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el fichero de imagen " + ex.Message);
                }

            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("¿Estás seguro de borrar esta promocion?", "Borrar promocion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

                MessageBox.Show("Promocion borrada ");
                this.Close();
            }
        }
    }
}
