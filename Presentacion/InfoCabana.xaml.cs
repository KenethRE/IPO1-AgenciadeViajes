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
        public InfoCabana(Dominio.Cabana cabana)
        {
            InitializeComponent();
            titcabna.Content = cabana.Titulo;
            txtprecio.Content = cabana.Precio;
            txtrestric.Content = cabana.Restriccion;
            txt_equip.Content = cabana.Equipamiento;
            txtdipon.Content = cabana.Estado;
            var bitmap = new BitmapImage(cabana.Foto);
            img_cabana.Source = bitmap;



        }


        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }
    }
}
