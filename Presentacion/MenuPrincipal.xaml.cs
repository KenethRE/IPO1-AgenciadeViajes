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

namespace IPO1_AgenciadeViajes.Presentacion
{
    /// <summary>
    /// Interaction logic for Window1.xaml
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
        
        public Usuario usuarioActual { get; set; }

        public ObservableCollection<Dominio.Monitor> listadoMonitores { get; set;}
        public ObservableCollection<Parcela> listadoParcelas { get; set; }
        public ObservableCollection<Cabana> listadoCabanas { get; set; }
        public ObservableCollection<Dominio.Actividad> listadoActividades { get; set; }
        public ObservableCollection<Promocion> listadoPromociones { get; set; }

        public MenuPrincipal(Uri uriUsuario)
        {
            this.usuarioActual = new Usuario();
            if (uriUsuario == null) usuarioActual.ImgUsuario = new BitmapImage(new Uri("/Recursos/Imagenes/user.png", UriKind.RelativeOrAbsolute));
            else usuarioActual.ImgUsuario = new BitmapImage(uriUsuario);

            usuarioActual.Nombre = "José";
            usuarioActual.ultimoInicio = DateTime.Now.ToString();
            // Crear el listado de monitores
            listadoMonitores = new ObservableCollection<Dominio.Monitor>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLMonitores();
            // Indicar que el origen de datos del ListBox es listadoMonitores
            //dgMonitores.ItemsSource = listadoMonitores;

            // Crear el listado de parcelas
            listadoParcelas = new ObservableCollection<Dominio.Parcela>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLParcelas();
            // Indicar que el origen de datos del ListBox es listadoParcelas
            //dgParcelas.ItemsSource = listadoParcelas;

            // Crear el listado de cabañas
            listadoCabanas = new ObservableCollection<Dominio.Cabana>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLCabanas();
            // Indicar que el origen de datos del ListBox es listadoParcelas
            //dgCabanas.ItemsSource = listadoCabanas;

            // Crear el listado de actividades
            listadoActividades = new ObservableCollection<Dominio.Actividad>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLActividades();
            // Indicar que el origen de datos del ListBox es listadoParcelas
            //dgActividades.ItemsSource = listadoActividades;

            // Crear el listado de actividades
            listadoPromociones = new ObservableCollection<Promocion>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLPromociones();
            // Indicar que el origen de datos del ListBox es listadoParcelas
            //dgPromociones.ItemsSource = listadoPromociones;

            InitializeComponent();
        }
        private void CargarContenidoListaXMLMonitores()
        {
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/Monitores.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoMonitor = new Dominio.Monitor("", 0, "", "", null, "", "", "")
                {
                    Nombre = node.Attributes["Nombre"].Value,
                    Telefono = Convert.ToInt32(node.Attributes["Telefono"].Value),
                    Correo = node.Attributes["Correo"].Value,
                    Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative),
                    Formacion = node.Attributes["Formacion"].Value,
                    Restricciones = node.Attributes["Restricciones"].Value,
                    Estado = node.Attributes["Estado"].Value
                };
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
                var nuevaParcela = new Dominio.Parcela("", 0, "", "", 0, "", false)
                {
                    Titulo = node.Attributes["Titulo"].Value,
                    Precio = Convert.ToInt32(node.Attributes["Precio"].Value),
                    Temporada = node.Attributes["Temporada"].Value,
                    Ubicacion = node.Attributes["Ubicacion"].Value,
                    Servicios = node.Attributes["Servicios"].Value,
                    Disponibilidad = Convert.ToBoolean(node.Attributes["Disponibilidad"].Value)
                };
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
                var nuevaCabana = new Dominio.Cabana("", 0, 0, "", null, "", "", false)
                {
                    Titulo = node.Attributes["Titulo"].Value,
                    Precio = Convert.ToInt32(node.Attributes["Precio"].Value),
                    Capacidad = Convert.ToInt32(node.Attributes["Capacidad"].Value),
                    Descripcion = node.Attributes["Descripcion"].Value,
                    Foto = new Uri(node.Attributes["Imagen"].Value, UriKind.Relative),
                    Restriccion = node.Attributes["Restriccion"].Value,
                    Equipamiento = node.Attributes["Equipamiento"].Value,
                    Estado = Convert.ToBoolean(node.Attributes["Disponibilidad"].Value)
                };
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
                    Estado = Convert.ToBoolean(node.Attributes["Estado"].Value)
                };
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
                var nuevaPromocion = new Dominio.Promocion("", "", null, false)
                {
                    Titulo = node.Attributes["Titulo"].Value,
                    Descripcion = node.Attributes["Descripcion"].Value,
                    Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative),
                    Estado = Convert.ToBoolean(node.Attributes["Estado"].Value)
                };
                listadoPromociones.Add(nuevaPromocion);
            }

        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ventana = new CrearRuta();
            ventana.Show();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void btnMonitor_Click(object sender, RoutedEventArgs e)
        {
            ventanaMonitor = new InfoMonitor();
            ventanaMonitor.Show();
        }

        private void BtnParcela_Click(object sender, RoutedEventArgs e)
        {
            ventanaParcela = new InfoParcela();
            ventanaParcela.Show();
        }

        private void BtnCabana_Click(object sender, RoutedEventArgs e)
        {
            ventanaCabana = new InfoCabana();
            ventanaCabana.Show();
        }

        private void BtnActividad_Click(object sender, RoutedEventArgs e)
        {
            ventanaActividad = new InfoActividad();
            ventanaActividad.Show();
        }

        private void BtnPromocion_Click(object sender, RoutedEventArgs e)
        {
            ventanaPromocion = new InfoPromocion();
            ventanaPromocion.Show();
        }

        private void BtnRutaSenderista_Click(object sender, RoutedEventArgs e)
        {
            ventanaRutaSenderista = new InfoRutaSenderista();
            ventanaRutaSenderista.Show();
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
    }
}
