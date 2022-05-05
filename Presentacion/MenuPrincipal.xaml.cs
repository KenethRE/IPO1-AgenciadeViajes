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
using System.IO;
using Path = System.IO.Path;

namespace IPO1_AgenciadeViajes.Presentacion
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        private CrearRuta ventana;
        private InfoParcela ventanaParcela;
        private InfoCabana ventanaCabana;
        private InfoActividad ventanaActividad;
        private InfoPromocion ventanaPromocion;
        private InfoRutaSenderista ventanaRutaSenderista;
        private NuevoUsuario2 ventananuevousuario;
        private Monitores ventanaMonitores;
        

        public Usuario usuarioActual { get; set; }

        public ObservableCollection<Dominio.Monitor> listadoMonitores { get; set;}
        public ObservableCollection<Parcela> listadoParcelas { get; set; }
        public ObservableCollection<Cabana> listadoCabanas { get; set; }
        public ObservableCollection<Dominio.Actividad> listadoActividades { get; set; }
        public ObservableCollection<Promocion> listadoPromociones { get; set; }

        public MenuPrincipal(Usuario usuarioactual)
        {
            this.usuarioActual = usuarioactual;
             listadoMonitores = new ObservableCollection<Dominio.Monitor>();
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
            // Indicar que el origen de datos del ListBox es listadoCabanas
            //dgCabanas.ItemsSource = listadoCabanas;

            // Crear el listado de actividades
            listadoActividades = new ObservableCollection<Dominio.Actividad>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLActividades();
            // Indicar que el origen de datos del ListBox es listadoActividades
            //dgActividades.ItemsSource = listadoActividades;

            // Crear el listado de actividades
            listadoPromociones = new ObservableCollection<Promocion>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXMLPromociones();
            // Indicar que el origen de datos del ListBox es listadoPromociones
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
                var nuevoMonitor = new Dominio.Monitor("", 0, "", "", null, "", "", false)
                {
                    Nombre = node.Attributes["Nombre"].Value,
                    Telefono = Convert.ToInt32(node.Attributes["Telefono"].Value),
                    Correo = node.Attributes["Correo"].Value,
                    Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative),
                    Formacion = node.Attributes["Formacion"].Value,
                    Restricciones = node.Attributes["Restricciones"].Value,
                    Estado = Convert.ToBoolean(node.Attributes["Estado"].Value)
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
                var nuevaParcela = new Dominio.Parcela("", 0, "", "", 0, "", false,null)
                {
                    Titulo = node.Attributes["Titulo"].Value,
                    Precio = Convert.ToInt32(node.Attributes["Precio"].Value),
                    Temporada = node.Attributes["Temporada"].Value,
                    Ubicacion = node.Attributes["Ubicacion"].Value,
                    Servicios = node.Attributes["Servicios"].Value,
                    Estado = Convert.ToBoolean(node.Attributes["Disponibilidad"].Value),
                    Tamano = Convert.ToInt32(node.Attributes["Tamano"].Value),
                    Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative)
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
                var nuevaActividad = new Dominio.Actividad("", "", "", "", false, 0, 0, 0, "", "", false,null)
                {
                    Titulo = node.Attributes["Titulo"].Value,
                    Descripcion = node.Attributes["Descripcion"].Value,
                    Monitor = node.Attributes["Monitor"].Value,
                    Horario = node.Attributes["Horario"].Value,
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

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("¿Estás seguro de cerrar la sesión?", "Cerrar Sesión", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                string UltimoInicio = DateTime.Now.ToString("d");
                XmlDocument doc = new XmlDocument();
                String outputpaht = Environment.CurrentDirectory;
                String outputpath2 = outputpaht.Replace("\\bin\\Debug", "");
                var xmpath = Path.Combine(outputpath2, "Persistencia/usuarios.xml");
                string xmpath2 = new Uri(xmpath).LocalPath;
                //var fichero = Application.GetResourceStream(new Uri("Persistencia/usuarios.xml", UriKind.Relative));
                doc.Load(xmpath2);
                XmlElement usuariomodificado = doc.DocumentElement;
                var listanodos = usuariomodificado.SelectNodes("/Usuarios/Usuario");
                foreach (XmlNode node in listanodos) {
                    var nombre = node.SelectSingleNode("@Nombre").InnerText;
                    if (nombre == usuarioActual.Nombre)
                    {
                        node.SelectSingleNode("@ultinic").InnerText = UltimoInicio;
                        //String outputpaht = Environment.CurrentDirectory;
                        //String outputpath2=outputpaht.Replace("\\bin\\Debug", "");
                        //var xmpath = Path.Combine(outputpath2, "Persistencia/usuarios.xml");
                        //string xmpath2 = new Uri(xmpath).LocalPath;
                        doc.Save(xmpath2);
                    }

                }
               
                Visibility = Visibility.Hidden;
                new InicioSesion().Show();
                this.Close();
                //var fichero2 = Application.GetResourceStream(new Uri("Persistencia/usuarios.xml", UriKind.Relative));
                //doc.Save(fichero2.Stream);
            }

        }


        private void BtnParcela_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnCabana_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnActividad_Click(object sender, RoutedEventArgs e)
        {
            Actividad actividad = sender as Actividad;
            ventanaActividad = new InfoActividad(actividad)
            {
                Owner = this
            };
            ventanaActividad.Show();
        }
        private void BtnPromocion_Click(object sender, RoutedEventArgs e)
        {
            //ventanaPromocion = new InfoPromocion();

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

        private void crearRuta_Click(object sender, RoutedEventArgs e)
        {
            new CrearRuta().ShowDialog();
        }

        private void mngMonit_Click(object sender, RoutedEventArgs e)
        {
            ventanaMonitores = new Monitores(listadoMonitores);
            ventanaMonitores.Show();
        }

        private void histActividades_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            ventananuevousuario = new NuevoUsuario2();
            ventananuevousuario.Show();
        }


        private void ContentControl_PreviewMouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            var promocion = ((FrameworkElement)sender).DataContext as Promocion;
            if (promocion.Estado == true)
            {
                ventanaPromocion = new InfoPromocion(promocion);
                ventanaPromocion.Show();
            }
            else
                MessageBox.Show("promocion no disponible");
            
            
                      

        }
        private void ContentControl_PreviewMouseLeftButtonDown2(object sender, MouseButtonEventArgs e)
        {
            var cabana = ((FrameworkElement)sender).DataContext as Cabana;

            if (cabana.Estado == true)
            {
                ventanaCabana = new InfoCabana(cabana);
                ventanaCabana.Show();
            }
            else
                MessageBox.Show("Cabaña no disponible");

            

        }
        private void ContentControl_PreviewMouseLeftButtonDown3(object sender, MouseButtonEventArgs e)
        {
            var parcela = ((FrameworkElement)sender).DataContext as Parcela;

            if (parcela.Estado == true)
            {
                ventanaParcela = new InfoParcela(parcela);
                ventanaParcela.Show();
            }
            else
                MessageBox.Show("Parcela no disponible");



        }
        private void ContentControl_PreviewMouseLeftButtonDown4(object sender, MouseButtonEventArgs e)
        {
            var actividad = ((FrameworkElement)sender).DataContext as Actividad;

            if (actividad.Estado == true)
            {
                ventanaActividad = new InfoActividad(actividad);
                ventanaActividad.Show();
            }
            else
                MessageBox.Show("Actividad no disponible");



        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BorrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/usuarios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            XmlElement usuariomodificado = doc.DocumentElement;
            var listanodos = usuariomodificado.SelectNodes("/Usuarios/Usuario");
            if (listanodos.Count <= 1)
            {
                MessageBox.Show("No se puede borrar el usuario al ser el unico existente");
            }
            else
            {
                foreach (XmlNode node in listanodos)
                {
                    var nombre = node.SelectSingleNode("@Nombre").InnerText;
                    if (nombre == usuarioActual.Nombre)
                    {
                        XmlElement el = (XmlElement)node;
                        try
                        {
                           el.ParentNode.RemoveChild(el);
                           doc.Save("C:/Users/plati/source/repos/KenethRE/IPO1-AgenciadeViajes/Persistencia/usuarios.xml");
                           MessageBox.Show("usuario "+usuarioActual.Nombre + "  borrado correctamente" );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al borrar el usuario " + ex.Message);
                            
                        }

                        
                    }

                }
            }

        }
    }
}
