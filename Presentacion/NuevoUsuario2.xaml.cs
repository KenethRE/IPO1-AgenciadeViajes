﻿using Microsoft.Win32;
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
                string ultinic = DateTime.Now.ToString();
                string Foto = Imgtxt.Text;
                string pass = PassTxt.Text;

                XmlElement NuevoUsuario = doc.CreateElement("Usuario");
                NuevoUsuario.SetAttribute("Nombre", Nombre);
                NuevoUsuario.SetAttribute("ultinic", ultinic);
                NuevoUsuario.SetAttribute("Foto", Foto);
                NuevoUsuario.SetAttribute("pass",pass);
                /*XmlAttribute Nombreatrib = doc.CreateAttribute("Nombre");
                Nombreatrib.Value = Nombre;
                NuevoUsuario.Attributes.Append(Nombreatrib);
                XmlAttribute ultinicatrib = doc.CreateAttribute("ultinic");
                ultinicatrib.Value = ultinic;
                NuevoUsuario.Attributes.Append(ultinicatrib);
                XmlAttribute fotoatrib = doc.CreateAttribute("Foto");
                ultinicatrib.Value = Foto;
                NuevoUsuario.Attributes.Append(fotoatrib);
                XmlAttribute passatrib = doc.CreateAttribute("Pass");
                passatrib.Value = pass;
                NuevoUsuario.Attributes.Append(passatrib);*/
                //XmlNode refElem = doc.DocumentElement.LastChild;
                //doc.InsertAfter(NuevoUsuario, refElem);
                doc.DocumentElement.AppendChild(NuevoUsuario);
                doc.Save("C:/Users/plati/Source/Repos/KenethRE/IPO1-AgenciadeViajes/Persistencia/usuarios.xml");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el usuario " + ex.Message);
            }

        }
    }
}
