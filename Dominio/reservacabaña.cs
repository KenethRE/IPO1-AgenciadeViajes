using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace IPO1_AgenciadeViajes.Dominio
{
    internal class reservacabaña {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Cabana Cabana { get; set; }
        public string Solicitud { get; set; }

        public reservacabaña(string nombre, string telefono, string email, Cabana cabana, string solicitud)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Cabana = cabana;
            Solicitud = solicitud;
        }
    }
}
