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
        private ObservableCollection<Dominio.Actividad> listadoActividades;
        private Actividad actividad;

        public InfoActividad(Dominio.Actividad actividad)
        {
            listadoActividades = new ObservableCollection<Dominio.Actividad>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLActividades();
            //DescipcionAct.Content = actividad.Descripcion;
            InitializeComponent();
        }

        private void CargarContenidoListaXMLActividades()
        {
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/Actividades.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaActividad = new Dominio.Actividad("", "", "", "", false, 0, 0, 0, "", "", false)
                {
                    Titulo = node.Attributes["Titulo"].Value,
                    Descripcion = node.Attributes["Descripcion"].Value,
                    Monitor = node.Attributes["Monitor"].Value,
                    Niños = Convert.ToBoolean(node.Attributes["Niños"].Value),
                    MaxCapacidad = Convert.ToInt32(node.Attributes["MaxCapacidad"].Value),
                    MinCapacidad = Convert.ToInt32(node.Attributes["MinCapacidad"].Value),
                    Precio = Convert.ToInt32(node.Attributes["Precio"].Value),
                    Area = node.Attributes["Area"].Value,
                    Equipamiento = node.Attributes["Equipamiento"].Value,
                    Estado = Convert.ToBoolean(node.Attributes["Estado"].Value),
                    Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative)
                };
                listadoActividades.Add(nuevaActividad);
            }

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
    }
}
