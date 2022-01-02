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
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    
    public partial class MenuPrincipal : Window
    {
        private CrearRuta ventana;
        private InfoMonitor ventanaMonitor;
        private InfoParcela ventanaParcela;
        private InfoCabana ventanaCabana;
        private InfoActividad ventanaActividad;
        private InfoPromocion ventanaPromocion;
        private InfoRutaSenderista ventanaRutaSenderista;

        List<Monitor>listadoMonitores;
        List<Parcela> listadoParcelas;
        List<Cabana> listadoCabanas;
        List<Actividad> listadoActividades;
        List<Promociones> listadoPromociones;

        public MenuPrincipal()
        {
            InitializeComponent();
            // Crear el listado de monitores
            listadoMonitores = new List<Monitor>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLMonitores();
            // Indicar que el origen de datos del ListBox es listadoMonitores
            dgMonitores.ItemsSource = listadoMonitores;

            // Crear el listado de parcelas
            listadoParcelas = new List<Parcela>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLParcelas();
            // Indicar que el origen de datos del ListBox es listadoParcelas
            dgParcelas.ItemsSource = listadoParcelas;

            // Crear el listado de cabañas
            listadoCabanas = new List<Cabana>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLCabanas();
            // Indicar que el origen de datos del ListBox es listadoParcelas
            dgCabanas.ItemsSource = listadoCabanas;

            // Crear el listado de actividades
            listadoActividades = new List<Actividad>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLActividades();
            // Indicar que el origen de datos del ListBox es listadoParcelas
            dgActividades.ItemsSource = listadoActividades;

            // Crear el listado de actividades
            listadoPromociones = new List<Promocion>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLPromociones();
            // Indicar que el origen de datos del ListBox es listadoParcelas
            dgPromociones.ItemsSource = listadoPromociones;
        }
        private void CargarContenidoListaXMLMonitores()
        {
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/Monitores.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoMonitor = new Monitor("", 0, "", "", null, "", "", false);
                nuevoMonitor.Nombre = node.Attributes["Nombre"].Value;
                nuevoMonitor.Telefono = Convert.ToInt32(node.Attributes["Telefono"].Value);
                nuevoMonitor.Correo = node.Attributes["Correo"].Value;
                nuevoMonitor.Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative);
                nuevoMonitor.Formacion = node.Attributes["Formacion"].Value;
                nuevoMonitor.Restricciones = node.Attributes["Restricciones"].Value;
                nuevoMonitor.Estado = Convert.ToBoolean(node.Attributes["Estado"].Value);
                listadoMonitores.Add(nuevoMonitor);
            }

        }

        private void CargarContenidoListaXMLParcelas()
        {
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/Parcelas.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaParcela = new Parcela("", 0, "", "", 0, "", false);
                nuevaParcela.Titulo = node.Attributes["Titulo"].Value;
                nuevaParcela.Precio = Convert.ToInt32(node.Attributes["Precio"].Value);
                nuevaParcela.Temporada = node.Attributes["Temporada"].Value;
                nuevaParcela.Ubicacion = node.Attributes["Ubicacion"].Value;
                nuevaParcela.Servicios = node.Attributes["Servicios"].Value;
                nuevaParcela.Disponibilidad = Convert.ToBoolean(node.Attributes["Disponibilidad"].Value);
                listadoParcelas.Add(nuevaParcela);
            }

        }


        private void CargarContenidoListaXMLCabanas()
        {
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/Cabanas.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaCabana = new Cabana("", 0, 0, "", null, "", "", false);
                nuevaCabana.Titulo = node.Attributes["Titulo"].Value;
                nuevaCabana.Precio = Convert.ToInt32(node.Attributes["Precio"].Value);
                nuevaCabana.Capacidad = Convert.ToInt32(node.Attributes["Capacidad"].Value);
                nuevaCabana.Descripcion = node.Attributes["Descripcion"].Value;
                nuevaCabana.Imagen = new Uri(node.Attributes["Imagen"].Value, UriKind.Relative);
                nuevaCabana.Restriccion = node.Attributes["Restriccion"].Value;
                nuevaCabana.Equipamiento = node.Attributes["Equipamiento"].Value;
                nuevaCabana.Disponibilidad = Convert.ToBoolean(node.Attributes["Disponibilidad"].Value);
                listadoCabanas.Add(nuevaCabana);
            }

        }

        private void CargarContenidoListaXMLActividades()
        {
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/Actividades.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaActividad = new Actividad("", "", "", false, 0, 0, 0, "", "", false);
                nuevaActividad.Titulo = node.Attributes["Titulo"].Value;
                nuevaActividad.Descipcion = node.Attributes["Descripcion"].Value;
                nuevaActividad.Monitor = node.Attributes["Monitor"].Value;
                nuevaActividad.Niños = Convert.ToBoolean(node.Attributes["Niños"].Value);
                nuevaActividad.MaxCapacidad = Convert.ToInt32(node.Attributes["MaxCapacidad"].Value);
                nuevaActividad.MinCapacidad = Convert.ToInt32(node.Attributes["MinCapacidad"].Value);
                nuevaActividad.Precio = Convert.ToInt32(node.Attributes["Precio"].Value);
                nuevaActividad.Area = node.Attributes["Area"].Value;
                nuevaActividad.Equipamiento = node.Attributes["Equipamiento"].Value;
                nuevaActividad.Estado = Convert.ToBoolean(node.Attributes["Estado"].Value);
                listadoActividades.Add(nuevaActividad);
            }

        }

        private void CargarContenidoListaXMLPromociones()
        {
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/Promociones.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaPromocion = new Promocion("", "", null, false);
                nuevaPromocion.Titulo = node.Attributes["Titulo"].Value;
                nuevaPromocion.Descipcion = node.Attributes["Descripcion"].Value;
                nuevaPromocion.Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative);
                nuevaPromocion.Estado = Convert.ToBoolean(node.Attributes["Estado"].Value);
                listadoPromociones.Add(nuevaPromocion);
            }

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
            ventanaMonitor = new InfoMonitor();
            ventanaMonitor.Show();
        }

        private void btnParcela_Click(object sender, RoutedEventArgs e)
        {
            ventanaParcela = new InfoParcela();
            ventanaParcela.Show();
        }

        private void btnCabana_Click(object sender, RoutedEventArgs e)
        {
            ventanaCabana = new InfoCabana();
            ventanaCabana.Show();
        }

        private void btnActividad_Click(object sender, RoutedEventArgs e)
        {
            ventanaActividad = new InfoActividad();
            ventanaActividad.Show();
        }

        private void btnPromocion_Click(object sender, RoutedEventArgs e)
        {
            ventanaPromocion = new InfoPromocion();
            ventanaPromocion.Show();
        }

        private void btnRutaSenderista_Click(object sender, RoutedEventArgs e)
        {
            ventanaRutaSenderista = new InfoRutaSenderista();
            ventanaRutaSenderista.Show();
        }

    }

}
