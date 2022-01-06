using GemBox.Pdf;
using GemBox.Pdf.Content;
using NuGet.Protocol.Plugins;
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
using System.Windows.Xps.Packaging;

namespace IPO1_AgenciadeViajes.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Documentacion.xaml
    /// </summary>
    public partial class Documentacion : Window
    {
        
        XpsDocument xpsDocument;
        public Documentacion()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();
            using (var document = PdfDocument.Load("input.pdf"))
            {
                this.xpsDocument = document.ConvertToXpsDocument(SaveOptions.Xps);
                this.docViewer.Document = this.xpsDocument.GetFixedDocumentSequence();
            }
        }
    }
}
