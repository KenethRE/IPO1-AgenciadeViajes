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
        public InfoParcela(Dominio.Parcela parcela)
        {
            InitializeComponent();
            titparcela.Text = parcela.Titulo;
            txtprecpac.Content = parcela.Precio;
            txtUbicParcela.Content = parcela.Ubicacion + "\nTamaño: "+ parcela.Tamano+ "\nTemporada: "+parcela.Temporada;
            txtServicparcela.Content = parcela.Servicios;
            disp_parcela.Content = parcela.Estado;
            var bitmap = new BitmapImage(parcela.Foto);
            Img_parcela.Source = bitmap;

        }

        private void ReservarParcela_Click(object sender, RoutedEventArgs e)
        {
            ventanaConfirmacionParcela = new ConfirmacionParcela();
            ventanaConfirmacionParcela.Show();

        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }
    }
}
