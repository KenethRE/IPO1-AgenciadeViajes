using IPO1_AgenciadeViajes.Dominio;
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
    /// Lógica de interacción para Promocion.xaml
    /// </summary>
    public partial class InfoPromocion : Window
    {
        public Promocion promocion;
        public InfoPromocion(Dominio.Promocion promocion)
        {
            this.promocion = promocion;
            InitializeComponent();
            txttitulo.Text = promocion.Titulo;
            txttitulo.IsEnabled = false;
            var bitmap = new BitmapImage(promocion.Foto);
            ImPromo.Source = bitmap;
            txtdescrip2.Text = promocion.Descripcion;
            txtdescrip2.IsEnabled = false;
            cargar_foto.Visibility = Visibility.Hidden;

        }
        private void btnCancelarPromocion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("¿Estás seguro de cerrar la ventana?", "Cerrar Sesión", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnModificarPromocion_Click(object sender, RoutedEventArgs e)
        {
            btnborrar.Visibility = Visibility.Hidden;
            btnDarPromocion.Visibility = Visibility.Hidden;
            cargar_foto.Visibility = Visibility.Visible;
            txttitulo.IsEnabled = true;
            cargar_foto.IsEnabled = true;
            txtdescrip2.IsEnabled = true;
        }

        private void btnGuardarPromocion_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Promocion  Guardada");
            btnborrar.Visibility = Visibility.Visible;
            btnDarPromocion.Visibility = Visibility.Visible;
            btnCancelarPromocion.Visibility = Visibility.Visible;
            btnDarPromocion.Visibility = Visibility.Visible;
            btnModificarPromocion.Visibility=Visibility.Visible;
            txtdescrip2.IsEnabled = false;
            txttitulo.IsEnabled = false;
        }

        private void btnDarPromocion_Click(object sender, RoutedEventArgs e)
        {
            txttitulo.IsEnabled = true;
            txtdescrip2.IsEnabled = true;
            txttitulo.Text = "";
            txtdescrip2.Text = "";
            ImPromo.Source = new BitmapImage(new Uri(@"/Recursos/Imagenes/icono_imagen.png", UriKind.Relative));
            cargar_foto.Visibility = Visibility.Visible;
            btnDarPromocion.Visibility = Visibility.Hidden;
            btnModificarPromocion.Visibility = Visibility.Hidden;
            btnborrar.Visibility = Visibility.Hidden;
            cargar_foto.IsEnabled = true;


        }

        private void cargar_foto_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    ImPromo.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el fichero de imagen " + ex.Message);
                }
            }
        }

        private void btnborrar_Click(object sender, RoutedEventArgs e)
        {
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
}
