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
            fechainic.DisplayDateStart = DateTime.Now;
            fechafin.DisplayDateStart= DateTime.Now;
            Btn_img.Visibility = Visibility.Hidden;
            Guardar.Visibility = Visibility.Hidden;


        }


        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void btnCancelarCabana_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("¿Estás seguro de cerrar la ventana?", "Cerrar Sesión", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnReservarCabana_Click(object sender, RoutedEventArgs e)
        {
            if (fechafin.Text == "" || fechainic.Text== "")
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
                    ventanaconfirmacioncabana = new ConfirmacionCabana(cabana, fechainic, fechafin);
                    ventanaconfirmacioncabana.Show();
                }
                else
                    MessageBox.Show("la fecha de inicio y final no son correctas");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            txtTitulo.IsEnabled = true;
            txtprecio.IsEnabled = true;
            txtequipamiento.IsEnabled = true;
            txtrestriccion.IsEnabled = true;
            txtcapacidad.IsEnabled = true;
            txtdispon.IsEnabled = true;
            btnModificar.Visibility = Visibility.Hidden;
            btnReservarCabana.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Hidden;
            btnBorrar.Visibility = Visibility.Hidden;
            Btn_img.Visibility = Visibility.Visible;
            Guardar.Visibility = Visibility.Visible;
            lblFechaFinCabana.Visibility = Visibility.Hidden;
            lblFechaInicioCabana.Visibility = Visibility.Hidden;
            fechainic.Visibility = Visibility.Hidden; 
            fechafin.Visibility = Visibility.Hidden; 

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtTitulo.Text = "";
            txtprecio.Text = "";
            txtrestriccion.Text = "";
            txtequipamiento.Text = "";
            txtcapacidad.Text = "";
            txtdispon.Text = "";
            txtTitulo.IsEnabled = true;
            txtprecio.IsEnabled = true;
            txtequipamiento.IsEnabled = true;
            txtrestriccion.IsEnabled = true;
            txtcapacidad.IsEnabled = true;
            txtdispon.IsEnabled = true;
            Btn_img.Visibility = Visibility.Visible;
            btnNuevo.Visibility = Visibility.Hidden;
            btnBorrar.Visibility= Visibility.Hidden;
            btnModificar.Visibility = Visibility.Hidden;
            lblFechaInicioCabana.Visibility = Visibility.Hidden;
            lblFechaFinCabana.Visibility = Visibility.Hidden;
            fechafin.Visibility = Visibility.Hidden;
            fechainic.Visibility = Visibility.Hidden;
            Guardar.Visibility = Visibility.Visible;
            img_cabana.Source = new BitmapImage(new Uri(@"/Recursos/Imagenes/icono_imagen.png", UriKind.Relative));
            btnReservarCabana.Visibility = Visibility.Hidden;
            fechafin.Visibility = Visibility.Hidden;
            fechafin.Visibility = Visibility.Hidden;


        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            txtTitulo.IsEnabled = false;
            txtprecio.IsEnabled = false;
            txtequipamiento.IsEnabled = false;
            txtrestriccion.IsEnabled = false;
            txtcapacidad.IsEnabled = false;
            txtdispon.IsEnabled = false;
            fechafin.Visibility = Visibility.Visible;
            fechafin.Visibility = Visibility.Visible;
            btnReservarCabana.Visibility = Visibility.Visible;
            Btn_img.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Visible;
            btnBorrar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Visible;
            Guardar.Visibility = Visibility.Hidden;
            lblFechaInicioCabana.Visibility = Visibility.Visible;
            lblFechaFinCabana.Visibility = Visibility.Visible;
            fechafin.Visibility = Visibility.Visible;
            fechainic.Visibility = Visibility.Visible;

            MessageBox.Show("Cabaña guardada correctamente");
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
                    img_cabana.Source = bitmap;
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
