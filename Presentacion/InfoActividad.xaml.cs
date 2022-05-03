using IPO1_AgenciadeViajes.Dominio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml;

namespace IPO1_AgenciadeViajes
{
    /// <summary>
    /// Lógica de interacción para InfoActividad.xaml
    /// </summary>
  

    public partial class InfoActividad : Window
    {
        private InfoInscrito ventanaInscrito;
       
        

        public InfoActividad(Dominio.Actividad actividad)
        {
           
            InitializeComponent();
            LblTitulo.Content = actividad.Titulo;
            DescipcionAct.Content = actividad.Descripcion;
            lbnommonitor.Content = actividad.Monitor;
            lblhorario.Content=actividad.Horario;
            lblCupoactividad.Content = "Entre "+actividad.MinCapacidad+ " y " + actividad.MaxCapacidad +" personas";
            lblPrecioActividad.Content = actividad.Precio + " € la hora";
            lblAreaActividad.Content = actividad.Area;
            lblequipactividad1.Content = actividad.Equipamiento;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ventanaInscrito = new InfoInscrito();
            ventanaInscrito.Show();
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }
        private void MiAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            new Presentacion.Acercade().ShowDialog();

        }
        private void MiDocumentacion_Click(object sender, RoutedEventArgs e)
        {
            new Presentacion.Documentacion().Show();

        }

        private void miError_Click(object sender, RoutedEventArgs e)
        {

            new Presentacion.ReportarErrrores().Show();
        }

        private void spanish_Click(object sender, RoutedEventArgs e)
        {
            App.SelectCulture("es-ES");
        }

        private void english_Click(object sender, RoutedEventArgs e)
        {
            App.SelectCulture("en-US");
        }

        private void miSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelarActividad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
