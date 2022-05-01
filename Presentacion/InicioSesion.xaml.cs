using IPO1_AgenciadeViajes.Presentacion;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;

namespace IPO1_AgenciadeViajes
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class InicioSesion : Window

    {
        public ObservableCollection<Dominio.Usuario> ListadoUsuarios { get; set; }
        public InicioSesion()
        {
            InitializeComponent();
            ListadoUsuarios = new ObservableCollection<Dominio.Usuario>();
            CargarContenidoUsuarios();
            App.SelectCulture("es-ES");
        }


        private void comprobarInformacion()
        {
            string usuarioacomprobar = tbxEmail.Text;
            var nuevousuarioactual = new Dominio.Usuario("", "", "", null);


            for (int i = 0; i < ListadoUsuarios.Count; i++)
            {
                if (usuarioacomprobar == ListadoUsuarios[i].Nombre)
                {
                    nuevousuarioactual = ListadoUsuarios[i];
                }
                else
                {
                    // comprobación errónea
                    tbxEmail.BorderBrush = Brushes.Red;
                    tbxEmail.BorderThickness = new Thickness(2);
                    lblEstado.Content = "Usuario no existe!";
                    lblEstado.Foreground = Brushes.Red;
                }

            }
            if (!String.IsNullOrEmpty(tbxEmail.Text) && tbxEmail.Text.Equals(nuevousuarioactual.Nombre, StringComparison.InvariantCultureIgnoreCase))
            {
                // comprobación correcta
                tbxEmail.BorderBrush = Brushes.Transparent;

                if (pbxContraseña.IsEnabled && !String.IsNullOrEmpty(pbxContraseña.Password))
                {
                    if (!pbxContraseña.Password.Equals(nuevousuarioactual.Pass))
                    {
                        // marcamos borde en rojo
                        pbxContraseña.BorderBrush = Brushes.Red;
                        pbxContraseña.BorderThickness = new Thickness(2);
                        // mostramos estado incorrecto
                        lblEstado.Content = "¡Contraseña incorrecta!";
                        lblEstado.Foreground = Brushes.Red;
                    }
                    else
                    {
                        // restauramos estado normal del borde
                        pbxContraseña.BorderBrush = Brushes.Transparent;
                        // mostramos estado correcto
                        lblEstado.Content = "¡Bienvenido! Iniciando Sesion...";
                        lblEstado.Foreground = Brushes.Green;

                        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
                        timer.Start();
                        timer.Tick += (sender, args) =>
                        {
                            //new MenuPrincipal().Show();
                            new MenuPrincipal(nuevousuarioactual).Show();
                            timer.Stop();
                            this.Close();
                        };
                    }
                }

            }
            else
            {
                // comprobación errónea
                tbxEmail.BorderBrush = Brushes.Red;
                tbxEmail.BorderThickness = new Thickness(2);
                lblEstado.Content = "Usuario Incorrecto!";
                lblEstado.Foreground = Brushes.Red;
            }

        }


        private void cambiarBandera(string idioma)
        {
            imgIdioma.Source = idioma.Equals("en-US")
            ? new BitmapImage(new Uri("/Recursos/Imagenes/united-states.png",
            UriKind.Relative))
            : new BitmapImage(new Uri("/Recursos/Imagenes/spain.png",
            UriKind.Relative));
        }

        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbIdiomas.SelectedItem;
            string selectedText = cbi.Content.ToString();
            if ((selectedText.Equals("ES") || selectedText.Equals("SP"))
            && !CultureInfo.CurrentCulture.Name.Equals("es-ES"))
            {
                App.SelectCulture("es-ES");
                cambiarBandera("es-ES");
            }
            else if (selectedText.Equals("EN")
            && !CultureInfo.CurrentCulture.Name.Equals("en-US"))
            {
                App.SelectCulture("en-US");
                cambiarBandera("en-US");
            }
        }

        private void Enter_Presionado(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) comprobarInformacion();
        }

        private void ComprobarInformacion(object sender, RoutedEventArgs e) {

            comprobarInformacion();
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void miAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            new Acercade().ShowDialog();

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
        private void CargarContenidoUsuarios()
        {
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Persistencia/usuarios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevousuario = new Dominio.Usuario("","","",null)
                {
                    Nombre = node.Attributes["Nombre"].Value,
                    UltimoInicio = node.Attributes["ultinic"].Value,
                    Pass = node.Attributes["pass"].Value,
                    ImgUsuario = new Uri(node.Attributes["Foto"].Value, UriKind.Relative)
                   
                };
                ListadoUsuarios.Add(nuevousuario);
            }

        }

    }
}
