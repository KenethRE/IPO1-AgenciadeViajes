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
    /// Lógica de interacción para Monitor.xaml
    /// </summary>
    public partial class InfoMonitor : Window
    {
        public InfoMonitor(Dominio.Monitor monitor)
        {
            InitializeComponent();
            txtNomMon.Content = monitor.Nombre;
            lblTelefonoMonitor.Content = monitor.Telefono;
            txtcorreosmonitor.Content = monitor.Correo;
            txtidiomamonitor.Content = monitor.Idioma;
            txtformacionmonitor.Content = monitor.Formacion;
            txtrestriccionesmonitor.Content = monitor.Restricciones;
            var bitmap = new BitmapImage(monitor.Foto);
            img_monitor.Source = bitmap;
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }
    }
}
