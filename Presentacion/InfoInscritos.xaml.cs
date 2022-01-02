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
                var nuevoInscrito = new Inscrito("", "", 0, false, "");
                nuevoInscrito.Nombre = node.Attributes["Nombre"].Value;
                nuevoInscrito.Correo = node.Attributes["Correo"].Value;
                nuevoInscrito.Telefono = Convert.ToInt32(node.Attributes["Telefono"].Value);
                nuevoInscrito.Pago = Convert.ToBoolean(node.Attributes["Pago"].Value);
                nuevoInscrito.Inscripcion = node.Attributes["Inscripcion"].Value;
                listadoInscritos.Add(nuevoInscrito);
            }
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void miAniadirItemLB_Click(object sender, RoutedEventArgs e)
        {
            var nuevoInscrito = new Inscrito("...", "...", 0, false, "...");
            // Añadimos una nueva película a la lista de películas (listadoPeliculas)
            listadoInscritos.Add(nuevoInscrito);
            //nuevoInscrito.AltaEnVideoteca = DateTime.Today;
            // Actualizaremos tanto el ListBox como el DataGrid para que las dos vistas
            // queden actualizadas
            lstListaInscritos.Items.Refresh();
        }
        private void miEliminarItemLB_Click(object sender, RoutedEventArgs e)
        {
            // CUIDADO CON HACERLO DE ESTA FORMA: 
            // Se da un error porque la fuente de datos está en uso:
            // lstListaPeliculas.Items.RemoveAt(lstListaPeliculas.SelectedIndex);
            listadoInscritos.RemoveAt(lstListaInscritos.SelectedIndex);
            // Actualizaremos tanto el ListBox como el DataGrid para que las dos vistas
            // queden actualizadas
            lstListaInscritos.Items.Refresh();
        }

    }
}