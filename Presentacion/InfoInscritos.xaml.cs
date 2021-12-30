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
using System.Xml;

namespace IPO1_AgenciadeViajes
{
    /// <summary>
    /// Lógica de interacción para InfoInscrito.xaml
    /// </summary>
    public partial class InfoInscrito : Window
    {
        List<Inscrito> listadoInscritos;
        public InfoInscrito()
        {
            InitializeComponent();
            // Crear el listado de películas
            listadoInscritos = new List<Inscrito>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXML();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            lstListaInscritos.ItemsSource = listadoInscritos;

        }


        private void CargarContenidoListaXML()
        {
            // Cargar contenido de prueba

            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/Inscritos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoInscrito = new Inscrito("", "", 0, "", null, "");
                nuevoInscrito.Nombre = node.Attributes["Nombre"].Value;
                nuevoInscrito.Correo = node.Attributes["Correo"].Value;
                nuevoInscrito.Telefono = Convert.ToInt32(node.Attributes["Telefono"].Value);
                nuevoInscrito.Pago = node.Attributes["Pago"].Value;
                nuevoInscrito.Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative);
                nuevoInscrito.Inscripcion = node.Attributes["Inscripcion"].Value;
                listadoInscritos.Add(nuevoInscrito);
            }
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

    }
}