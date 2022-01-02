﻿using System;
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

namespace IPO1_AgenciadeViajes.Presentacion
{
    /// <summary>
    /// Lógica de interacción para ReportarErrrores.xaml
    /// </summary>
    public partial class ReportarErrrores : Window
    {
        public ReportarErrrores()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (EMail.Text == "" || Comentario.Text == "")
            {
                MessageBox.Show("Campos requeridos"); 
            }
            else {
                MessageBox.Show("Mensaje enviado, Gracias");
                EMail.Text = "";
                Comentario.Text = "";
            }
        }
    }
}