using IPO1_AgenciadeViajes.Presentacion;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace IPO1_AgenciadeViajes
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class InicioSesion : Window

    {
        public InicioSesion()
        {
            InitializeComponent();
            App.SelectCulture("es-ES");
        }


        private void comprobarInformacion()
        {
            string usuario = "usuario1";
            if (!String.IsNullOrEmpty(tbxEmail.Text) && tbxEmail.Text.Equals(usuario, StringComparison.InvariantCultureIgnoreCase))
            {
                // comprobación correcta
                tbxEmail.BorderBrush = Brushes.Transparent;

                string pass_usuario = "1234";
                if (pbxContraseña.IsEnabled && !String.IsNullOrEmpty(pbxContraseña.Password))
                {
                    if (!pbxContraseña.Password.Equals(pass_usuario))
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
                            Uri uri = new Uri("/Recursos/Imagenes/Persona.png", UriKind.RelativeOrAbsolute);
                            new MenuPrincipal(uri).Show();
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
    }
}
