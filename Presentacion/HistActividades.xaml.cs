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
using System.Xml;
using Path = System.IO.Path;

namespace IPO1_AgenciadeViajes.Presentacion
{
    /// <summary>
    /// Lógica de interacción para HistActividades.xaml
    /// </summary>
    public partial class HistActividades : Window
    {
        List<HistorialActividades> listadoActividades;
        public HistActividades()
        {
            listadoActividades = new List<HistorialActividades>();
            InitializeComponent();
            CargarContenidoListaXML();
            DatagridActividades.ItemsSource = listadoActividades;

        }
        private void CargarContenidoListaXML()
        {
            // Cargar contenido de prueba
            
            XmlDocument doc = new XmlDocument();
            String outputpath = Environment.CurrentDirectory;
            String outputpath2 = outputpath.Replace("\\bin\\Debug", "");
            var xmpath = Path.Combine(outputpath2, "Persistencia/HistActividades.xml");
            string xmpath2 = new Uri(xmpath).LocalPath;
            doc.Load(xmpath2);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoActividad = new Dominio.HistorialActividades("","","");
                nuevoActividad.Titulo = node.Attributes["Titulo"].Value;
                nuevoActividad.Hora = node.Attributes["Hora"].Value;
                nuevoActividad.Niños = node.Attributes["Niños"].Value;
                listadoActividades.Add(nuevoActividad);
            }
        }
    }
}
