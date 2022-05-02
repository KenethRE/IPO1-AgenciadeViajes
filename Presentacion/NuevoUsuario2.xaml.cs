using Microsoft.Win32;
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
using System.Xml.Linq;
using MessageBox = System.Windows.MessageBox;
using Path = System.IO.Path;
namespace IPO1_AgenciadeViajes.Presentacion
{
    /// <summary>
    /// Lógica de interacción para NuevoUsuario2.xaml
    /// </summary>
    public partial class NuevoUsuario2 : Window
    {
        public NuevoUsuario2()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    Imagen.Source = bitmap;
                    Imgtxt.Text = Path.GetFileName(abrirDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el fichero de imagen " + ex.Message);
                }
            }

        }

        private void Button_ClickGuardar(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                var fichero = Application.GetResourceStream(new Uri("Persistencia/usuarios.xml", UriKind.Relative));
                doc.Load(fichero.Stream);
                string Nombre = NombreTxt.Text;
                string ultinic = DateTime.Now.ToString("d");
                string Foto = Imgtxt.Text;
                string pass = PassTxt.Text;
                XmlElement NuevoUsuario = doc.CreateElement("Usuario");
                NuevoUsuario.SetAttribute("Nombre", Nombre);
                NuevoUsuario.SetAttribute("ultinic", ultinic);
                NuevoUsuario.SetAttribute("Foto", Foto);
                NuevoUsuario.SetAttribute("pass",pass);
                
                doc.DocumentElement.AppendChild(NuevoUsuario);
                doc.Save(fichero.Stream);
                MessageBox.Show("Usuario Guardado");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el usuario " + ex.Message);
            }

        }
    }
}
