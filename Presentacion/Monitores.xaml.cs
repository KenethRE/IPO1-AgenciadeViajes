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

namespace IPO1_AgenciadeViajes.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Monitores.xaml
    /// </summary>
    public partial class Monitores : Window
       
    {
        private InfoMonitor ventanaMonitor;
        public ObservableCollection<Dominio.Monitor> listadoMonitores { get; set; }
        public Monitores(ObservableCollection<Dominio.Monitor> listadoMonitores)
        {
            this.listadoMonitores = listadoMonitores;
            InitializeComponent();
        }

        private void MiAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            new Acercade().ShowDialog();

        }
        private void MiDocumentacion_Click(object sender, RoutedEventArgs e)
        {
            new Documentacion().Show();

        }

        private void miError_Click(object sender, RoutedEventArgs e)
        {

            new ReportarErrrores().Show();
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

        private void Masinfo_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void ContentControl_PreviewMouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            var monitor = ((FrameworkElement)sender).DataContext as Dominio.Monitor;
            if (monitor.Estado == true)
            {
                ventanaMonitor = new InfoMonitor(monitor);
                ventanaMonitor.Show();
            }
            else
                MessageBox.Show("Monitor no disponible");




        }

    }
   
}
