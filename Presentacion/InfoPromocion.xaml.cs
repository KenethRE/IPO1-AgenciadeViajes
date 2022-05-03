using IPO1_AgenciadeViajes.Dominio;
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
            txtgitulo.Text = promocion.Titulo;
            var bitmap = new BitmapImage(promocion.Foto);
            ImPromo.Source = bitmap;
            TxtDescripcion.Text= promocion.Descripcion;
            
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

      
    }
}
