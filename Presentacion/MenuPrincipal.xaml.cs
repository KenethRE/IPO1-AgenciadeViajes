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
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    
    public partial class MenuPrincipal : Window
    {
        private CrearRuta ventana;
        private Monitor ventanaMonitor;
        private Parcela ventanaParcela;
        private Cabana ventanaCabana;
        private Actividad ventanaActividad;
        private Promocion ventanaPromocion;
        private RutaSenderista ventanaRutaSenderista;

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ventana = new CrearRuta ();
            ventana.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void btnMonitor_Click(object sender, RoutedEventArgs e)
        {
            ventanaMonitor = new Monitor();
            ventanaMonitor.Show();
        }

        private void btnParcela_Click(object sender, RoutedEventArgs e)
        {
            ventanaParcela = new Parcela();
            ventanaParcela.Show();
        }

        private void btnCabana_Click(object sender, RoutedEventArgs e)
        {
            ventanaCabana = new Cabana();
            ventanaCabana.Show();
        }

        private void btnActividad_Click(object sender, RoutedEventArgs e)
        {
            ventanaActividad = new Actividad();
            ventanaActividad.Show();
        }

        private void btnPromocion_Click(object sender, RoutedEventArgs e)
        {
            ventanaPromocion = new Promocion();
            ventanaPromocion.Show();
        }

        private void btnRutaSenderista_Click(object sender, RoutedEventArgs e)
        {
            ventanaRutaSenderista = new RutaSenderista();
            ventanaRutaSenderista.Show();
        }

    }

}
