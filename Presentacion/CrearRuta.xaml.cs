﻿using System;
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
    /// Lógica de interacción para CrearRuta.xaml
    /// </summary>
    public partial class CrearRuta : Window
    {
        public CrearRuta()
        {
            InitializeComponent();
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void mostrarCoordenadas(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            //lblEstado.Content = "Coordenadas pulsadas: (" + p.X + ", " + p.Y + ")";
            //lblEstado.Foreground = Brushes.Black;
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
    }
}
